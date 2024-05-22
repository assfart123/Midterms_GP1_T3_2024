using UnityEngine;
using System.Collections;

public class HenBehavior : MonoBehaviour
{
    public GameObject eggPrefab; // Reference to the egg prefab
    public int minEggsToLay = 3; // Minimum number of eggs to lay
    public int maxEggsToLay = 5; // Maximum number of eggs to lay
    public float layEggInterval = 1f; // Time interval between each egg laid
    public float layEggDelay = 30f; // Delay before the hen starts laying eggs
    public float disappearDelay = 40f; // Delay before the hen disappears
    public float eggSpawnHeight = 1f; // Height above the hen to spawn the eggs

    private bool layingEggs = false;

    void Start()
    {
        StartCoroutine(LayEggs());
        StartCoroutine(DisappearAfterDelay());
    }

    IEnumerator LayEggs()
    {
        yield return new WaitForSeconds(layEggDelay);

        layingEggs = true;

        int eggsToLay = Random.Range(minEggsToLay, maxEggsToLay + 1);

        for (int i = 0; i < eggsToLay; i++)
        {
            LayEgg();
            yield return new WaitForSeconds(layEggInterval);
        }

        layingEggs = false;
    }

    void LayEgg()
    {
        Vector3 spawnPosition = transform.position + Vector3.up * eggSpawnHeight;
        Instantiate(eggPrefab, spawnPosition, Quaternion.identity);
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);

        Destroy(gameObject);
    }
}
