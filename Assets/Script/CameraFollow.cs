using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ball ka transform yaha drag karna hoga
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Camera ka position difference
    public float smoothSpeed = 0.125f; // Smooth follow speed

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position (ball + offset)
        Vector3 desiredPosition = target.position + offset;

        // Smooth movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Always look at the ball
        transform.LookAt(target);
    }
}
