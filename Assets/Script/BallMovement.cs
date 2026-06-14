using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Transform cam;  // Main Camera reference

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform; // Main camera
    }

    void FixedUpdate()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // W A S D input
        if (Input.GetKey(KeyCode.W))
            moveZ = 1f;
        if (Input.GetKey(KeyCode.S))
            moveZ = -1f;
        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        // Direction relative to camera
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        // Ignore vertical tilt (taake sirf horizontal move ho)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * moveZ + right * moveX).normalized;

        rb.AddForce(move * moveSpeed, ForceMode.Force);
    }
}
