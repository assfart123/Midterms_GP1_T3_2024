using UnityEngine;
using System.Collections;

public class ChickBehavior : MonoBehaviour
{
    public GameObject henPrefab;
    public GameObject roosterPrefab;
    public float transformationTime = 10f; // Time in seconds for transformation

    void Start()
    {
        StartCoroutine(DecideChickenTypeAfterDelay(transformationTime));
    }

    IEnumerator DecideChickenTypeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        DecideChickenType();
    }

    void DecideChickenType()
    {
        // Check if there's only one chick in the scene
        if (CountChicks() == 1)
        {
            TransformToHen();
        }
        else
        {
            // Randomly decide whether the chick becomes a hen or a rooster (50/50 chance)
            if (Random.value < 0.5f)
            {
                TransformToHen();
            }
            else
            {
                TransformToRooster();
            }
        }
    }

    void TransformToHen()
    {
        Instantiate(henPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void TransformToRooster()
    {
        Instantiate(roosterPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    int CountChicks()
    {
        // Count the number of chicks in the scene
        GameObject[] chickens = GameObject.FindGameObjectsWithTag("Chick");
        return chickens.Length;
    }
}