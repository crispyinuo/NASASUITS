using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public GetShortestWayBack shortestWayBackCalculator;
    public GameObject spherePrefab; // Prefab of the sphere to spawn
    
    public Color emissionColor = Color.green; 
    public float maxDistance = 50.0f; 
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
     for (int i = 0; i < shortestWayBackCalculator.shortestPath.Count; i++)
        {
            SpawnSphereAtPosition(shortestWayBackCalculator.shortestPath[i], i);
        }
    }

     private void SpawnSphereAtPosition(Vector3 position, int index)
    {
        if (spherePrefab == null)
        {
            Debug.LogError("Sphere prefab is not assigned in PathRenderer.");
            return;
        }

        GameObject sphereInstance = Instantiate(spherePrefab, position, Quaternion.identity, transform);
        sphereInstance.name = "PathSphere" + index;
        SetupSphereMaterial(sphereInstance, index);
    }

    private void SetupSphereMaterial(GameObject sphere, int index)
    {
        Material newMaterial = new Material(sphere.GetComponent<Renderer>().material);
        sphere.GetComponent<Renderer>().material = newMaterial;

        // Map index to intensity from -10 to 10
        float mappedIntensity = MapIndexToIntensity(index, shortestWayBackCalculator.shortestPath.Count);

        // Calculate final emission intensity (from 0.0 to 1.0) based on mapped intensity
        float intensity = Mathf.InverseLerp(-10, 10, mappedIntensity);
        Color finalColor = emissionColor * intensity;
        newMaterial.SetColor("_EmissionColor", finalColor);
        DynamicGI.SetEmissive(sphere.GetComponent<Renderer>(), finalColor);
    }

    private float MapIndexToIntensity(int index, int totalCount)
    {
        // Linear mapping of index to intensity range -10 to 10
        return Mathf.Lerp(-10, 10, (float)index / (totalCount - 1));
    }
}
