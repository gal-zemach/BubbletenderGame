using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    
    public Transform SpawningAreaTopRight;
    public Transform SpawningAreaBottomLeft;

    [Header("Events")]
    public GameEvent bubbleSpawned;

    // [Header("For Debugging")]
    // public Camera mainCamera; // used to spawn the bubble at the mouse position
    
    // private Vector3 INVALID_MOUSE_POSITION = Vector3.positiveInfinity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            SpawnBubble();
        }
    }

    public void SpawnBubble()
    {
        var pos = GetRandomSpawnPosition();
        pos.z = transform.position.z;
        SpawnBubble(pos);
    }

    private void SpawnBubble(Vector3 worldPosition)
    {
        GameObject newBubble = Instantiate(bubblePrefab, worldPosition, Quaternion.identity, this.transform);
        bubbleSpawned.Raise();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return GetRandomPositionInRectangle(SpawningAreaTopRight, SpawningAreaBottomLeft);
    }

    public static Vector3 GetRandomPositionInRectangle(Transform topRight, Transform bottomLeft)
    {
        // Get the bounds of the rectangle
        float minX = bottomLeft.position.x;
        float maxX = topRight.position.x;
        float minY = bottomLeft.position.y;
        float maxY = topRight.position.y;

        // Generate random X and Y within the bounds
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Return the random position
        return new Vector3(randomX, randomY, 0f); 
    }

    // private Vector3 GetMousePosition()
    // {
    //     if (mainCamera == null)
    //     {
    //         Debug.LogError("Main Camera is not assigned in the Inspector.");
    //         return INVALID_MOUSE_POSITION;
    //     }

    //     // Get the mouse position in screen space
    //     Vector3 mouseScreenPosition = Input.mousePosition;

    //     // Convert screen space to world space
    //     return mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));
    // }
}
