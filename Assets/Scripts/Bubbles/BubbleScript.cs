using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    [Header("Bubble Movement")]
    public float floatSpeed = 5f;

    [Header("Bubble Collision")]
    public float overlapThresholdToCollect = 0.65f;

    void Update()
    {
        // FloatUpward();
    }

    private void FloatUpward()
    {
        var pos = transform.position;
        pos += Vector3.up * floatSpeed;
        
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckOverlap(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckOverlap(other);
    }

    private void CheckOverlap(Collider2D other)
    {
        // Only check for colliders with the "Clue" tag
        if (!other.CompareTag("Clue"))
            return;

        CircleCollider2D bubbleCollider = GetComponent<CircleCollider2D>();
        if (bubbleCollider == null)
        {
            Debug.LogError("Bubble does not have a CircleCollider2D component!");
            return;
        }

        // Calculate bounds intersection
        Bounds bubbleBounds = bubbleCollider.bounds;
        Bounds clueBounds = other.bounds;

        if (bubbleBounds.Intersects(clueBounds))
        {
            Bounds intersection = GetIntersectionBounds(bubbleBounds, clueBounds);

            // Calculate overlap area proportion
            float bubbleArea = bubbleBounds.size.x * bubbleBounds.size.y;
            float overlapArea = intersection.size.x * intersection.size.y;

            float overlapProportion = overlapArea / bubbleArea;

            // Check if it satisfies the overlap threshold
            if (overlapProportion >= overlapThresholdToCollect)
            {
                Debug.Log($"Overlap with {other.name} meets the threshold: {overlapProportion * 100:F2}%");
                // todo: Collect clue
            }
        }
    }

    private Bounds GetIntersectionBounds(Bounds a, Bounds b)
    {
        Vector3 min = Vector3.Max(a.min, b.min);
        Vector3 max = Vector3.Min(a.max, b.max);

        if (min.x > max.x || min.y > max.y)
        {
            // No intersection
            return new Bounds();
        }

        return new Bounds((min + max) / 2, max - min);
    }
}
