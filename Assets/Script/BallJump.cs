using UnityEngine;

public class BallJump : MonoBehaviour
{
    public float jumpForce = 7f;   // Jump ki power
    public LayerMask groundLayer;  // Ground layer select karna hoga
    public Transform groundCheck;  // Empty object ball ke neeche lagana hoga
    public float groundDistance = 0.4f; // Distance ground check ke liye

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // Jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
