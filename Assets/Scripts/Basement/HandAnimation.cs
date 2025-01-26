using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    private float moveSpeed = 1f;        // Speed of movement
    private float moveDistance = 0f;     // Distance to move back and forth
    private bool moveHorizontally = true; // Move horizontally (X) or vertically (Y)
    private float rotationSpeed = 10f;   // Rotation speed (degrees per second)
    private float maxRotationAngle = 5f; // Maximum rotation angle (degrees)

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position from which the sprite will move
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move horizontally (X axis)
        if (moveHorizontally)
        {
            float movement = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
            transform.position = initialPosition + new Vector3(movement, 0, 0);
        }
        // Move vertically (Y axis)
        else
        {
            float movement = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
            transform.position = initialPosition + new Vector3(0, movement, 0);
        }

        // Apply rotation: Use Mathf.Sin to smoothly oscillate the rotation angle
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
