using Verse;

namespace DecorativeTreeByCattleya;

public class ThingComp_DecorativeTrees : ThingComp
{
    public CompProperties_DecorativeTrees Props => (CompProperties_DecorativeTrees)props;

    public string HarvestGraphicPath => Props.harvestGraphicPath;
}