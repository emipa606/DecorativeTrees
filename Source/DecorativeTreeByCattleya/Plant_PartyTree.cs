using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace DecorativeTreeByCattleya;

public class Plant_PartyTree : Plant_DecorativeTree
{
    private const int PARTY_MAX_TIME = 20;

    public bool IsDecoratedNow;

    private int partyCounter = 20;

    public override bool ShowHarvestButton => false;

    public override Graphic Graphic
    {
        get
        {
            if (!IsDecoratedNow)
            {
                return base.Graphic;
            }

            var harvestGraphicPath = GetComp<ThingComp_DecorativeTrees>().HarvestGraphicPath;
            if (harvestGraphicPath == null)
            {
                return base.Graphic;
            }

            return GraphicDatabase.Get(def.graphicData.graphicClass, harvestGraphicPath, def.graphic.Shader,
                def.graphicData.drawSize, def.graphicData.color, def.graphicData.colorTwo);
        }
    }

    private bool IsCanBeParty()
    {
        return partyCounter >= 20;
    }

    public void PartyStartedNow()
    {
        partyCounter = 0;
        IsDecoratedNow = true;
    }

    private FloatMenuOption GetOption(Pawn selPawn)
    {
        if (!IsCanBeParty())
        {
            return new FloatMenuOption("Plant_PartyTree_PartyWasResently".Translate(), null)
            {
                Disabled = true
            };
        }

        if (growthInt > 0.7f)
        {
            return new FloatMenuOption("Plant_PartyTree_throw_party".Translate(), null)
            {
                action = delegate
                {
                    if (JobDefs_PartyTree.GoToThrowParty == null)
                    {
                        return;
                    }

                    var job = new Job(JobDefs_PartyTree.GoToThrowParty, this)
                    {
                        playerForced = true
                    };
                    selPawn.jobs.TryTakeOrderedJob(job, JobTag.Misc);
                }
            };
        }

        return new FloatMenuOption("Plant_PartyTree_needGrow".Translate(), null)
        {
            Disabled = true
        };
    }

    public override void TickLong()
    {
        base.TickLong();
        if (IsCanBeParty())
        {
            return;
        }

        partyCounter++;
        if (!IsCanBeParty())
        {
            return;
        }

        IsDecoratedNow = false;
        Map.mapDrawer.MapMeshDirty(Position, MapMeshFlagDefOf.Things);
    }

    public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
    {
        yield return GetOption(selPawn);
    }
}