using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public GetShortestWayBack shortestWayBackCalculator;
    public GameObject spherePrefab; // Prefab of the sphere to spawn

    public void RenderPath()
    {
        // Check if shortestWayBackCalculator is set and the shortest path has points
        if (shortestWayBackCalculator == null || shortestWayBackCalculator.shortestPath.Count == 0)
        {
            Debug.LogError("ShortestWayBackCalculator reference is not set or shortest path is empty in PathRenderer.");
            return;
        }

        // Clear previous spheres if any (Optional: Depends on use case)
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Go over the list of shortestWayBackCalculator.shortestPath and spawn spheres at each position
        foreach (Vector3 position in shortestWayBackCalculator.shortestPath)
        {
            SpawnSphereAtPosition(position);
        }
    }

    private void SpawnSphereAtPosition(Vector3 position)
    {
        if (spherePrefab == null)
        {
            Debug.LogError("Sphere prefab is not assigned in PathRenderer.");
            return;
        }
        GameObject sphereInstance = Instantiate(spherePrefab, position, Quaternion.identity, transform);
        sphereInstance.name = "PathSphere";
    }
}
