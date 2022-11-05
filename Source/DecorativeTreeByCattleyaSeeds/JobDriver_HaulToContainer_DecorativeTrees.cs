using System.Collections.Generic;
using RimWorld;
using SeedsPlease;
using Verse;
using Verse.AI;

namespace DecorativeTreeByCattleya;

internal class JobDriver_HaulToContainer_DecorativeTrees : JobDriver_HaulToContainer
{
    private Thing _seed;

    private new int Duration => Container is not Building ? 0 : Container.def.building.haulToContainerDuration;

    protected override IEnumerable<Toil> MakeNewToils()
    {
        this.FailOnDestroyedOrNull(TargetIndex.A);
        this.FailOnDestroyedNullOrForbidden(TargetIndex.B);
        this.FailOn(() => TransporterUtility.WasLoadingCanceled(Container));
        this.FailOn(delegate
        {
            var thingOwner = Container.TryGetInnerInteractableThingOwner();
            if (thingOwner != null && !thingOwner.CanAcceptAnyOf(ThingToCarry))
            {
                return true;
            }

            return Container is IHaulDestination haulDestination && !haulDestination.Accepts(ThingToCarry);
        });
        var getToHaulTarget = Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch)
            .FailOnSomeonePhysicallyInteracting(TargetIndex.A);
        yield return getToHaulTarget;
        var toil = new Toil
        {
            initAction = delegate
            {
                _seed = null;
                if (TargetThingA is not Building_PlantGrower grower)
                {
                    return;
                }

                foreach (var item in grower.PlantsOnMe)
                {
                    if (item is not Plant_DecorativeTree)
                    {
                        continue;
                    }

                    var blueprintDef = item.def.blueprintDef;
                    var def = (SeedDef)(blueprintDef is SeedDef ? blueprintDef : null);
                    _seed = ThingMaker.MakeThing(def);
                    _seed.stackCount = 1;
                }
            }
        };
        yield return toil;
        yield return Toils_Construct.UninstallIfMinifiable(TargetIndex.A)
            .FailOnSomeonePhysicallyInteracting(TargetIndex.A);
        var toil2 = new Toil
        {
            initAction = delegate { _ = _seed; }
        };
        yield return toil2;
        yield return Toils_Haul.StartCarryThing(TargetIndex.A, false, true);
        yield return Toils_Haul.JumpIfAlsoCollectingNextTargetInQueue(getToHaulTarget, TargetIndex.A);
        var carryToContainer = Toils_Haul.CarryHauledThingToContainer();
        yield return carryToContainer;
        yield return Toils_Goto.MoveOffTargetBlueprint(TargetIndex.B);
        var toil3 = Toils_General.Wait(Duration, TargetIndex.B);
        toil3.WithProgressBarToilDelay(TargetIndex.B);
        yield return toil3;
        yield return Toils_Construct.MakeSolidThingFromBlueprintIfNecessary(TargetIndex.B, TargetIndex.C);
        yield return Toils_Haul.DepositHauledThingInContainer(TargetIndex.B, TargetIndex.C);
        yield return Toils_Haul.JumpToCarryToNextContainerIfPossible(carryToContainer, TargetIndex.C);
    }
}