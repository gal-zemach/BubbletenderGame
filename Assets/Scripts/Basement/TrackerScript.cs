using UnityEngine;
using UnityEngine.UI;

public class TrackerScript : MonoBehaviour
{
    public Transform counterContainer;
    public Sprite[] numberSprites; 
    public Sprite slashSprite;
    private float spriteScaleFactor = 0.007f;
    private float horizontalSpacing = 0.2f;

    // Function to update the counter with the correct sprites
    public void UpdateCounter(int firstNum, int secondNum)
    {
        // Clear any existing child images (to reset the display)
        foreach (Transform child in counterContainer)
        {
            Destroy(child.gameObject);
        }
        
        float currentXPosition = 0f;

        CreateSprite(firstNum, ref currentXPosition);
        CreateSlash(ref currentXPosition);
        CreateSprite(secondNum, ref currentXPosition);
    }

    void CreateSprite(int num, ref float currentXPosition)
    {

        GameObject spriteObj = new GameObject("Sprite", typeof(Image));
        spriteObj.transform.SetParent(counterContainer, false); // Add as a child to the counter container

        Image image = spriteObj.GetComponent<Image>();

        // Assign the sprite to the image
        image.sprite = numberSprites[num];

        // Scale the image using RectTransform
        RectTransform rectTransform = spriteObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(image.sprite.rect.width * spriteScaleFactor, image.sprite.rect.height * spriteScaleFactor);

        rectTransform.anchoredPosition = new Vector2(currentXPosition, 0f);
        currentXPosition += rectTransform.rect.width + horizontalSpacing;
    }

    void CreateSlash(ref float currentXPosition)
    {
        GameObject spriteObj = new GameObject("Slash", typeof(Image));
        spriteObj.transform.SetParent(counterContainer, false); // Add as a child to the counter container

        Image image = spriteObj.GetComponent<Image>();
        image.sprite = slashSprite;

        // Scale the image using RectTransform
        RectTransform rectTransform = spriteObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(image.sprite.rect.width * spriteScaleFactor, image.sprite.rect.height * spriteScaleFactor);
        
        rectTransform.anchoredPosition = new Vector2(currentXPosition, 0f);
        currentXPosition += rectTransform.rect.width + horizontalSpacing;
    }

    public void DestroyTracker()
    {
        foreach (Transform child in counterContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
