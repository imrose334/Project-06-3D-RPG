using UnityEngine;

// Drop-in Rigidbody jump for the Player prefab.
// Attach to the Player prefab (the same prefab MazeGenerator instantiates).
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerJumpSimple : MonoBehaviour
{
    public float jumpForce = 7f;
    public float extraGravity = 2f;

    Rigidbody rb;
    bool isGrounded = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // cancel Y velocity then impulse up
            Vector3 v = rb.velocity;
            v.y = 0f;
            rb.velocity = v;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Stronger gravity for snappier falling
        rb.AddForce(Physics.gravity * extraGravity, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision other)
    {
        // treat any collision from below/up as grounded; you can refine by checking normal
        // simple and robust for maze floors
        if (other.contacts.Length > 0)
        {
            // optional: ensure contact normal is mostly up
            if (Vector3.Dot(other.contacts[0].normal, Vector3.up) > 0.5f)
                isGrounded = true;
        }
        else
        {
            isGrounded = true;
        }
    }
}
