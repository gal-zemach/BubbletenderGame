using UnityEngine;

public class RightHandScript : MonoBehaviour
{
    private float rotationSpeed = 8f;   // Rotation speed (degrees per second)
    private float maxRotationAngle = 5f; // Maximum rotation angle (degrees)

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position from which the sprite will move
        initialPosition = transform.position;
    }

    void Update()
    {
        // Apply rotation: Use Mathf.Sin to smoothly oscillate the rotation angle
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
