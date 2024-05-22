using UnityEngine;

public class SpawnClick: MonoBehaviour
{
    public GameObject prefabToSpawn; // Reference to the prefab to spawn

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Spawn the prefab at the hit point
                Instantiate(prefabToSpawn, hit.point, Quaternion.identity);
            }
        }
    }
}
