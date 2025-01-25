using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarClientScript : MonoBehaviour
{
    public BarOrder order;
    public SpriteRenderer spriteRenderer;

    public List<Sprite> characterSprites;

    public void Init()
    {
        order = new BarOrder(generateRandom: true);
        SetClientSprite();
        
        Show();
    }

    public bool ServeOrder(BarOrder servedOrder)
    {
        return order.IsFulfilled(servedOrder);
    }

    public void Show()
    {
        spriteRenderer.enabled = true;
    }

    public void Hide()
    {
        spriteRenderer.enabled = false;
        // Destroy(this.gameObject);
    }

    private void SetClientSprite()
    {
        int randomIndex = Random.Range(0, characterSprites.Count);
        spriteRenderer.sprite = characterSprites[randomIndex];
    }
}
