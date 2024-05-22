using UnityEngine;

public class WolfChase : MonoBehaviour
{
    public float speed = 5f; // Speed of the wolf
    public float detectionRange = 10f; // Range within which the wolf can detect prey
    public int damagePerSecond = 10; // Damage dealt per second by the wolf

    private GameObject target = null; // Current target
    private float damageTimer = 0f; // Timer to track damage intervals

    void Update()
    {
        FindTarget();

        if (target != null)
        {
            ChaseTarget();
        }
    }

    void FindTarget()
    {
        GameObject[] roosters = GameObject.FindGameObjectsWithTag("Rooster");
        GameObject[] hens = GameObject.FindGameObjectsWithTag("Hen");
        GameObject[] chicks = GameObject.FindGameObjectsWithTag("Chick");

        GameObject closestPrey = null;
        float closestDistance = detectionRange;

        // Find the closest prey within the detection range
        closestPrey = FindClosestPrey(roosters, closestPrey, ref closestDistance);
        closestPrey = FindClosestPrey(hens, closestPrey, ref closestDistance);
        closestPrey = FindClosestPrey(chicks, closestPrey, ref closestDistance);

        target = closestPrey;
    }

    GameObject FindClosestPrey(GameObject[] preyArray, GameObject closestPrey, ref float closestDistance)
    {
        foreach (GameObject prey in preyArray)
        {
            float distance = Vector3.Distance(transform.position, prey.transform.position);
            if (distance < closestDistance)
            {
                closestPrey = prey;
                closestDistance = distance;
            }
        }
        return closestPrey;
    }

    void ChaseTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target.transform); // Rotate to face the target
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the wolf collides with the target
        if (other.gameObject == target)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= 1f)
            {
                Health targetHealth = target.GetComponent<Health>();
                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(damagePerSecond);
                }
                damageTimer = 0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Reset the timer when the wolf stops colliding with the target
        if (other.gameObject == target)
        {
            damageTimer = 0f;
        }
    }
}
