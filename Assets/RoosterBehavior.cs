using UnityEngine;
using System.Collections;

public class RoosterBehavior : MonoBehaviour
{
    public float speed = 5f; // Speed of the rooster
    public float detectionRange = 10f; // Range within which the rooster can detect wolves
    public int damagePerSecond = 10; // Damage dealt per second by the rooster
    public float disappearDelay = 40f; // Delay before the rooster disappears

    private GameObject target = null; // Current target
    private float damageTimer = 0f; // Timer to track damage intervals

    void Start()
    {
        StartCoroutine(DisappearAfterDelay());
    }

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
        GameObject[] wolves = GameObject.FindGameObjectsWithTag("Wolf");

        GameObject closestWolf = null;
        float closestDistance = detectionRange;

        // Find the closest wolf within the detection range
        closestWolf = FindClosestWolf(wolves, closestWolf, ref closestDistance);

        target = closestWolf;
    }

    GameObject FindClosestWolf(GameObject[] wolfArray, GameObject closestWolf, ref float closestDistance)
    {
        foreach (GameObject wolf in wolfArray)
        {
            float distance = Vector3.Distance(transform.position, wolf.transform.position);
            if (distance < closestDistance)
            {
                closestWolf = wolf;
                closestDistance = distance;
            }
        }
        return closestWolf;
    }

    void ChaseTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target.transform); // Rotate to face the target
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the rooster collides with the target
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
        // Reset the timer when the rooster stops colliding with the target
        if (other.gameObject == target)
        {
            damageTimer = 0f;
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);

        Destroy(gameObject);
    }
}
