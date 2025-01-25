using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CluesScriptableObject", menuName = "Scriptable Objects/CluesScriptableObject")]
public class CluesScriptableObjectScript : ScriptableObject
{
    [Serializable]
    public class SpriteMapping<T>
    {
        public T type;
        public Sprite sprite;
    }

    [Header("Glass Type Sprites")]
    public List<SpriteMapping<CluesEnums.GlassType>> glassTypeSprites;

    [Header("Drink Type Sprites")]
    public List<SpriteMapping<CluesEnums.DrinkType>> drinkTypeSprites;

    [Header("Garnish Sprites")]
    public List<SpriteMapping<CluesEnums.GarnishType>> garnishSprites;

    public Sprite GetSprite(CluesEnums.GlassType glassType)
    {
        return glassTypeSprites.Find(mapping => mapping.type == glassType)?.sprite;
    }

    public Sprite GetSprite(CluesEnums.DrinkType drinkType)
    {
        return drinkTypeSprites.Find(mapping => mapping.type == drinkType)?.sprite;
    }

    public Sprite GetSprite(CluesEnums.GarnishType garnish)
    {
        return garnishSprites.Find(mapping => mapping.type == garnish)?.sprite;
    }
}
