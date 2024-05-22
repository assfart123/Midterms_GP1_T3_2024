using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab; // Reference to the egg prefab to be spawned

    void Start()
    {
        Invoke("SpawnEgg", 2f); // Invoke SpawnEgg after 2 seconds
    }

    void SpawnEgg()
    {
        // Instantiate the egg prefab at the spawner's position and rotation
        Instantiate(eggPrefab, transform.position, Quaternion.identity);
    }
}

