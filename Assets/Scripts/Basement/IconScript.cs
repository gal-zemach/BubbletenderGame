using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    // These are the direction icons
    public Sprite upIcon;
    public Sprite leftIcon;
    public Sprite downIcon;
    public Sprite rightIcon;

    // This is the Prefab to display the sprites
    public GameObject iconPrefab;

    // Variables
    public float spacing = 2.0f;
    public float scaleFactor = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateIcons(List<string> sequence)
    {
        // Calculate horizontal spacing
        float totalWidth = (sequence.Count - 1) * spacing;

        // Calculate starting position
        Vector3 startPosition = new Vector3(-totalWidth / 2,0,0);

        // Iterate through the sequence
        for (int i = 0; i < sequence.Count; i++)
        {
            // Determine which sprite to instantiate based on the direction
            Sprite spriteToInstantiate = null;

            switch (sequence[i].ToUpper())
            {
                case "W":
                    spriteToInstantiate = upIcon;
                    break;
                case "A":
                    spriteToInstantiate = leftIcon;
                    break;
                case "S":
                    spriteToInstantiate = downIcon;
                    break;
                case "D":
                    spriteToInstantiate = rightIcon;
                    break;
            }

            // Instantiate the sprite at the correct position
            Vector3 position = startPosition + new Vector3(i * spacing, 0, 0);
            GameObject spriteObject = Instantiate(iconPrefab, position, Quaternion.identity);

            // Assign the correct sprite to the instantiated object
            spriteObject.GetComponent<SpriteRenderer>().sprite = spriteToInstantiate;

            // Scale the sprite object
            spriteObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);   
        }
    }
}

