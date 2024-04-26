using System;
using Verse;

namespace DecorativeTreeByCattleya;

public class CompProperties_DecorativeTrees : CompProperties
{
    public readonly string harvestGraphicPath = "";

    public CompProperties_DecorativeTrees()
    {
        compClass = typeof(ThingComp_DecorativeTrees);
    }

    public CompProperties_DecorativeTrees(Type compClass)
        : base(compClass)
    {
        this.compClass = compClass;
    }
}