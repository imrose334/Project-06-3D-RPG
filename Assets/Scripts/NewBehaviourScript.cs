using UnityEngine;

public class SimpleWanderAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float turnSpeed = 3f;
    public float wanderRadius = 10f;

    private Vector3 targetPos;

    void Start()
    {
        PickNewDestination();
    }

    void Update()
    {
        Vector3 dir = targetPos - transform.position;
        dir.y = 0;

        // Reached target? Pick a new one
        if (dir.magnitude < 0.5f)
        {
            PickNewDestination();
            return;
        }

        // Rotate smoothly toward the target
        if (dir != Vector3.zero)
        {
            Quaternion look = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                look,
                turnSpeed * Time.deltaTime
            );
        }

        // Move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void PickNewDestination()
    {
        Vector2 circle = Random.insideUnitCircle * wanderRadius;

        targetPos = new Vector3(
            transform.position.x + circle.x,
            transform.position.y,
            transform.position.z + circle.y
        );
    }
}
