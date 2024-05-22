using UnityEngine;
using System.Collections;

public class EggBehavior : MonoBehaviour
{
    public GameObject chickPrefab; // Reference to the chick prefab to switch to

    void Start()
    {
        StartCoroutine(SwitchToChickAfterDelay(10f)); // Start the countdown to switch to a chick after 10 seconds
    }

    IEnumerator SwitchToChickAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Instantiate the chick prefab at the same position and rotation as the egg
        GameObject chickInstance = Instantiate(chickPrefab, transform.position, transform.rotation);

        // Destroy the egg
        Destroy(gameObject);
    }
}
