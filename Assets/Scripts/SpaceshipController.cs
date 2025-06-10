using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float acceleration = 10f;
    public float deceleration = 5f;
    public float maxSpeed = 20f;
    public float turnSpeed = 10f;
    public float jumpForce = 8f;

    private Rigidbody rb;
    private bool isGrounded = false;
    private bool canDoubleJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveForwardBackward();
        MoveLeftRight();
        HandleJump();
    }

    void MoveForwardBackward()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (Input.GetKey(KeyCode.W))
        {
            if (flatVelocity.magnitude < maxSpeed)
                rb.AddForce(Vector3.forward * acceleration, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (flatVelocity.magnitude > 0.1f)
                rb.AddForce(-Vector3.forward * deceleration, ForceMode.Acceleration);
        }
    }

    void MoveLeftRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * turnSpeed, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * turnSpeed, ForceMode.Acceleration);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canDoubleJump = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
