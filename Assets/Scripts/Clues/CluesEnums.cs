using System;

public static class CluesEnums
{
    public enum GlassType
    {
        None,
        High,
        Low,
        Martini
    }

    public enum DrinkType
    {
        None,
        Whiskey,
        Vodka,
        Champagne
    }

    public enum GarnishType
    {
        None,
        Lime,
        OrangePeel,
        Cherry
    }

    public static T GetRandomEnum<T>()
    {
        Array types = Enum.GetValues(typeof(T));
        return (T)types.GetValue(UnityEngine.Random.Range(0, types.Length));
    }
}
