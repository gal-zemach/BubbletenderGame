using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    // These are the direction icons
    public Sprite arrow;
    // public Sprite letterW;
    // public Sprite letterA;
    // public Sprite letterS;
    // public Sprite letterD;

    // This is the Prefab to display the sprites
    public GameObject iconPrefab;

    // Keep list of spawned Icons
    public List<GameObject> spawnedIcons = new List<GameObject>();

    // Variables
    private float spacing = 2.0f;
    private float scaleFactor = 1.2f;
    public float yOffset = 2.0f;
    private float rotationAngle = 0f;

    public void CreateIcons(List<string> sequence)
    {
        // Destroy existing sprites
        DestroyExistingSprites();

        // Calculate horizontal spacing
        float totalWidth = (sequence.Count - 1) * spacing;

        // Calculate starting position
        Vector3 startPosition = new Vector3(-totalWidth / 2, transform.position.y + yOffset, transform.position.z);

        // Iterate through the sequence
        for (int i = 0; i < sequence.Count; i++)
        {
            // Determine which sprite to instantiate based on the direction
            Sprite spriteToInstantiate = arrow;
            string direction = sequence[i].ToUpper();

            switch (direction)
            {
                case "U": // Up Arrow
                    rotationAngle = -90f;
                    break;
                case "L": // Left Arrow
                    rotationAngle = 0f;
                    break;
                case "Q": // Down Arrow
                    rotationAngle = 90f;
                    break;
                case "R": // Right Arrow
                    rotationAngle = 180f;
                    break;
                // case "W":
                //     spriteToInstantiate = letterW;
                //     break;
                // case "A":
                //     spriteToInstantiate = letterA;
                //     break;
                // case "S":
                //     spriteToInstantiate = letterS;
                //     break;
                // case "D":
                //     spriteToInstantiate = letterD;
                    // break;
            }

            // Instantiate the sprite at the correct position
            Vector3 position = startPosition + new Vector3(i * spacing, 0, 0);
            GameObject spriteObject = Instantiate(iconPrefab, position, Quaternion.identity, transform);

            // Assign the correct sprite to the instantiated object
            spriteObject.GetComponent<SpriteRenderer>().sprite = spriteToInstantiate;

            // Scale the sprite object
            spriteObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

            // Rotate the sprite object (based on direction)
            spriteObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            // // Optionally, set a unique identifier on each sprite for easy identification
            spawnedIcons.Add(spriteObject);
        }
    }

    public void DestroyExistingSprites()
    {
        foreach (GameObject sprite in spawnedIcons)
        {
            if (sprite != null)
            {
                Destroy(sprite); // Destroy the sprite object
            }
        }
        spawnedIcons.Clear(); // Clear the list after destruction
    }
}