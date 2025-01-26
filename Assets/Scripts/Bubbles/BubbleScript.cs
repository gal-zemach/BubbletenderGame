using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rigidbody2D;
    public CircleCollider2D bubbleCollider;

    [Header("Bubble Movement")]
    // public float floatSpeed = 0.01f;
    // public float horizontalAmp = 0.01f;
    // public float horizontalSpeed = 1f;

    // [Space]
    public float bubbleInitialForce = 0.05f;

    [Header("Bubble Collision")]
    public float overlapThresholdToCollect = 0.65f;

    [Header("Bubble State")]
    public bool IsAttachingToBubble = false;

    public bool IsCompleted = false;

    void Start()
    {
        rigidbody2D.AddForce(Vector2.up * bubbleInitialForce);
    }

    // void FixedUpdate()
    // {
    //     FloatUpward();
    // }

    // private void FloatUpward()
    // {
    //     var pos = transform.position;
    //     pos += Vector3.up * floatSpeed;
    //     pos += Vector3.right * horizontalAmp * Mathf.Cos(Time.fixedTime * horizontalSpeed * Mathf.PI);

    //     transform.position = pos;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsCompleted || other.CompareTag("Border"))
        {
            Object.Destroy(this.gameObject);
            return;
        }
        
        CheckOverlap(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsCompleted || other.CompareTag("Border"))
        {
            return;
        }

        CheckOverlap(other);
    }

    private void CheckOverlap(Collider2D other)
    {
        // Only check for colliders with the "Clue" tag
        if (!other.CompareTag("Clue"))
        {
            return;
        }

        IsCompleted = true;
        Object.Destroy(this.gameObject);
    }
}
