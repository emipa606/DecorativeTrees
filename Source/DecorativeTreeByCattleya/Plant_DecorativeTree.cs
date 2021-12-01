using RimWorld;
using Verse;

namespace DecorativeTreeByCattleya;

public class Plant_DecorativeTree : Plant
{
    public virtual bool ShowHarvestButton { get; } = true;


    public override Graphic Graphic
    {
        get
        {
            if (!(growthInt > 0.8f) || this is Plant_PartyTree)
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
}