using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace DecorativeTreeByCattleya;

public class JobDriver_GoToThrowParty : JobDriver
{
    public override bool TryMakePreToilReservations(bool errorOnFailed)
    {
        return pawn.Reserve(TargetA, job);
    }

    protected override IEnumerable<Toil> MakeNewToils()
    {
        yield return Toils_Goto.Goto(TargetIndex.A, PathEndMode.ClosestTouch)
            .FailOnDespawnedNullOrForbidden(TargetIndex.A);
        yield return Toils_General.Wait(10000).WithProgressBarToilDelay(TargetIndex.A)
            .FailOnDespawnedNullOrForbidden(TargetIndex.A);
        var toil = new Toil
        {
            initAction = delegate
            {
                if (TargetA.Thing is Plant_PartyTree tree)
                {
                    tree.PartyStartedNow();
                    Map.mapDrawer.MapMeshDirty(tree.Position, MapMeshFlag.Things);
                }

                pawn.Map.lordsStarter.TryStartGathering(GatheringDefOf.Party);
            }
        };
        yield return toil;
    }
}