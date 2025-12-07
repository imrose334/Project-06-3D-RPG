using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingBob : MonoBehaviour
{
    [Header("Floating Settings")]
    public float hoverHeight = 1.5f;      // Average height above starting point
    public float bobAmplitude = 0.25f;    // How tall the bobbing wave is
    public float bobFrequency = 1.5f;     // How fast the bobbing is

    [Header("Rotation Settings")]
    public Vector3 rotationSpeed = new Vector3(0f, 45f, 0f); // Degrees per second

    private Rigidbody rb;
    private float startY;
    private float timeOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX |
                         RigidbodyConstraints.FreezePositionZ; 
        // Keeps the cube from drifting away from floating spot

        startY = transform.position.y;
        timeOffset = Random.value * 10f; // prevents multiple objects from syncing perfectly
    }

    void FixedUpdate()
    {
        float t = Time.time + timeOffset;

        // ---- Bobbing movement ----
        float height = startY + hoverHeight + Mathf.Sin(t * bobFrequency) * bobAmplitude;

        Vector3 targetPos = new Vector3(transform.position.x, height, transform.position.z);
        rb.MovePosition(Vector3.Lerp(transform.position, targetPos, 0.1f));

        // ---- Rotation ----
        Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
