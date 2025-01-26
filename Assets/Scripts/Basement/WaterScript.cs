using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private float rotationSpeed = 10f;   // Rotation speed (degrees per second)
    private float maxRotationAngle = 5f; // Maximum rotation angle (degrees)

    private void Update()
    {
        // Calculate the rotation angle based on time and speed
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;

        // Apply the rotation around the center of the sprite (default pivot)
        RotateAroundCenter(rotationAngle);
    }

    void RotateAroundCenter(float angle)
    {
        // Apply rotation around the center of the sprite (default pivot in Unity)
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
