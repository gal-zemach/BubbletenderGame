using System;
using static CluesEnums;

[Serializable]
public class BarOrder
{
    public const int numberOfClues = 3;
    
    public GlassType GlassType = GlassType.None;
    public DrinkType DrinkType = DrinkType.None;
    public GarnishType GarnishType = GarnishType.None;

    public BarOrder(bool generateRandom=false)
    {
        if (generateRandom)
        {
            GlassType = GetRandomEnum<GlassType>();
            DrinkType = GetRandomEnum<DrinkType>();
            GarnishType = GetRandomEnum<GarnishType>();
        }
    }

    public BarOrder(GlassType glass, DrinkType drink, GarnishType garnish)
    {
        GlassType = glass;
        DrinkType = drink;
        GarnishType = garnish;
    }

    public bool IsFulfilled(BarOrder other)
    {
        return other.GlassType == GlassType && 
                other.DrinkType == DrinkType && 
                other.GarnishType == GarnishType;
    }
}
