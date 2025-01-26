using UnityEngine;

public class WindBlower : MonoBehaviour
{
    public float windForce = 10f; // Maximum wind force
    public Vector2 windDirection = Vector2.right; // Direction of the wind
    public KeyCode blowKey = KeyCode.Space; // Key to trigger the wind
    public float windAngle = 45f; // Half of the cone's angle (e.g., 45 degrees for a 90-degree cone)
    public float windRadius = 10f; // Maximum distance of the wind effect
    public float angleChangeSpeed = 90f; // Speed at which the wind direction changes (degrees per second)

    private bool ShouldBlowWind = false;

    void Update()
    {
        // Control the wind direction angle using left and right arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ChangeWindDirection(-angleChangeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeWindDirection(angleChangeSpeed * Time.deltaTime);
        }

        // Detect wind activation
        if (!ShouldBlowWind && Input.GetKey(blowKey))
        {
            ShouldBlowWind = true;
        }
    }

    void FixedUpdate()
    {
        if (ShouldBlowWind)
        {
            BlowWind();
            ShouldBlowWind = false;
        }
    }

    private void ChangeWindDirection(float angleDelta)
    {
        // Rotate the wind direction by the given angleDelta
        float currentAngle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;
        currentAngle += angleDelta;
        windDirection = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad)).normalized;
    }

    private void BlowWind()
    {
        // Normalize the wind direction
        Vector2 normalizedWindDirection = windDirection.normalized;

        // Find all colliders within the wind radius
        Collider2D[] bubbles = Physics2D.OverlapCircleAll(transform.position, windRadius);

        foreach (Collider2D bubble in bubbles)
        {
            // Check if the object is tagged as "Bubble"
            if (bubble.CompareTag("Bubble"))
            {
                // Check if the parent exists and has a Rigidbody2D
                Transform parentTransform = bubble.transform.parent;
                if (parentTransform == null)
                {
                    Debug.LogWarning($"Collider {bubble.name} has no parent, skipping...");
                    continue;
                }

                Rigidbody2D rb = parentTransform.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Calculate direction to the bubble
                    Vector2 toBubble = (Vector2)(bubble.transform.position - transform.position);
                    float distance = toBubble.magnitude;

                    // Check if the bubble is within the cone angle
                    float angleToBubble = Vector2.Angle(normalizedWindDirection, toBubble.normalized);
                    if (angleToBubble <= windAngle)
                    {
                        // Calculate force falloff based on distance
                        float forceMultiplier = Mathf.Clamp01(1f - (distance / windRadius));

                        // Apply the wind force
                        Vector2 force = normalizedWindDirection * windForce * forceMultiplier;
                        rb.AddForce(force, ForceMode2D.Force);

                        // Debug.Log($"Applied wind force to {bubble.name}: {force}");
                    }
                }
                else
                {
                    Debug.LogWarning($"Parent of {bubble.name} does not have a Rigidbody2D!");
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the cone in the Scene view
        Gizmos.color = Color.cyan;
        Vector3 forward = windDirection.normalized;
        Vector3 leftBoundary = Quaternion.Euler(0, 0, windAngle) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -windAngle) * forward;

        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(leftBoundary * windRadius));
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(rightBoundary * windRadius));
        Gizmos.DrawWireSphere(transform.position, windRadius);
    }
}
