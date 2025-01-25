using UnityEngine;
using static CluesEnums;

public class ClueScript : MonoBehaviour
{
    public GameObject spritesParent;

    public SpriteRenderer clueSprite;
    
    public CluesScriptableObjectScript cluesSo;

    public enum ClueType
    {
        Glass, Drink, Garnish
    }

    void Start()
    {
        Hide();
    }

    public void Set(BarOrder order, ClueType clueType)
    {
        switch (clueType)
        {
            case ClueType.Glass:
                foreach (var item in cluesSo.glassTypeSprites)
                {
                    if (item.type == order.GlassType)
                    {
                        clueSprite.sprite = item.sprite;
                        Show();
                    }
                }
                break;

            case ClueType.Drink:
                foreach (var item in cluesSo.drinkTypeSprites)
                {
                    if (item.type == order.DrinkType)
                    {
                        clueSprite.sprite = item.sprite;
                        Show();
                    }
                }
                break;

            case ClueType.Garnish:
                foreach (var item in cluesSo.garnishSprites)
                {
                    if (item.type == order.GarnishType)
                    {
                        clueSprite.sprite = item.sprite;
                        Show();
                    }
                }
                break;
        }
    }

    public void Clear()
    {
        Hide();
        clueSprite.sprite = null;
    }
    
    public void Show()
    {
        spritesParent.SetActive(true);
    }

    public void Hide()
    {
        spritesParent.SetActive(false);
    }
}
