using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Movement speed of the AI
    public float rotationSpeed = 100.0f; // Rotation speed of the AI
    public float wanderRadius = 10.0f; // Radius within which the AI can wander
    public float minWanderTime = 1.0f; // Minimum time to wander in one direction
    public float maxWanderTime = 3.0f; // Maximum time to wander in one direction

    private Vector3 targetPosition; // The position the AI is moving towards
    private float wanderTime; // The time to wander in one direction

    void Start()
    {
        // Set initial target position and wander time
        SetNewTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        MoveTowardsTarget();

        // Decrease wander time
        wanderTime -= Time.deltaTime;

        // If wander time is up, set a new target position
        if (wanderTime <= 0)
        {
            SetNewTargetPosition();
        }
    }

    void MoveTowardsTarget()
    {
        // Calculate the direction to the target position
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0; // Keep direction horizontal to prevent tilting

        // Move the AI towards the target position
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate the AI to face the target position
        if (direction != Vector3.zero) // Ensure there is a direction to look towards
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void SetNewTargetPosition()
    {
        // Set a new random target position within the wander radius
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        randomDirection.y = transform.position.y; // Keep the AI on the same Y plane

        targetPosition = randomDirection;

        // Set a new random wander time
        wanderTime = Random.Range(minWanderTime, maxWanderTime);
    }
}
