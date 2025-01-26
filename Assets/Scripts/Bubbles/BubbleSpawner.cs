using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    
    [Header("Events")]
    public GameEvent bubbleSpawned;

    [Header("For Debugging")]
    public Camera mainCamera; // used to spawn the bubble at the mouse position
    
    private Vector3 INVALID_MOUSE_POSITION = Vector3.positiveInfinity;

    public void SpawnBubble()
    {
        var mousePos = GetMousePosition();
        if (mousePos != INVALID_MOUSE_POSITION)
        {
            SpawnBubble(mousePos);
        }
    }

    private void SpawnBubble(Vector3 worldPosition)
    {
        GameObject newBubble = Instantiate(bubblePrefab, worldPosition, Quaternion.identity, this.transform);
        bubbleSpawned.Raise();
    }

    private Vector3 GetMousePosition()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera is not assigned in the Inspector.");
            return INVALID_MOUSE_POSITION;
        }

        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert screen space to world space
        return mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));
    }
}
