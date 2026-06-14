using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Ball ka Transform drag karo
    public float distance = 10f; // Ball se distance
    public float height = 5f;    // Ball ke upar height
    public float rotationSpeed = 100f; // Numpad rotation speed

    private float currentAngle = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        // Numpad inputs (4 = left, 6 = right)
        if (Input.GetKey(KeyCode.Keypad4))
        {
            currentAngle -= rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            currentAngle += rotationSpeed * Time.deltaTime;
        }

        // Calculate rotation around the ball
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        // Set position and look at ball
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
