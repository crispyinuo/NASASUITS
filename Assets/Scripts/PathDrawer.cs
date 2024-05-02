using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
[CustomEditor(typeof(PathDrawer))]
public class PathDrawerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        PathDrawer pathDrawer = (PathDrawer)target; // Get the reference to the PathDrawer

        if (GUILayout.Button("Clear"))
        {
            pathDrawer.ClearWaypointsData();
            EditorUtility.SetDirty(pathDrawer); // Mark the object as "dirty" so the scene needs saving and undo works
        }

        if (GUILayout.Button("Generate Way Back"))
        {
            pathDrawer.SetupPath();
            EditorUtility.SetDirty(pathDrawer);
        }
    }
}
*/

public class PathDrawer : MonoBehaviour
{
    public Transform userTransform; // Assign the user's Transform component in the Inspector
    private LineRenderer lineRenderer;
    private List<Vector3> pathPoints = new List<Vector3>();
    private Graph graph = new Graph();
    private int startPositionIndex = 0; // Starting position in the graph
    private float recordInterval = 1.0f; // Time in seconds between recordings

     void Start()
    {
        SetupPath();
    }

    public void SetupPath()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GeneratePseudoPositions(); // For testing without device
        DrawPath();
        StartCoroutine(SimulatePathfinding());

        // Uncomment the next line when testing on HoloLens or when real-time tracking is needed
        // StartCoroutine(RecordUserPosition());
    }
    private void GenerateRandomPositions()
    {
        float maxX = 10.0f; // Maximum x-coordinate
        float maxY = 5.0f;  // Maximum y-coordinate
        float maxZ = 0.0f;  // Maximum z-coordinate (set to 0 for 2D-like movement)

        // Clear any existing points
        pathPoints.Clear();

        // Add the starting point at the origin or another fixed point
        pathPoints.Add(new Vector3(0, 0, 0));

        // Generate random points
        for (int i = 1; i < 20; i++)
        {
            float x = Random.Range(-maxX, maxX);
            float y = Random.Range(-maxY, maxY);
            float z = Random.Range(-maxZ, maxZ); // For 2D paths, keep z constant

            // Add the new random point
            pathPoints.Add(new Vector3(x, y, z));
        }

        // Optionally, connect the last point back to the start to complete a loop
        pathPoints.Add(pathPoints[0]);
    }

    private void GeneratePseudoPositions()
    {
        // Generate pseudo positions
        pathPoints.Add(new Vector3(0, 0, 0));   // Start at origin
        pathPoints.Add(new Vector3(1, 0, 0));   // Move right
        pathPoints.Add(new Vector3(1, 1, 0));   // Move up
        pathPoints.Add(new Vector3(0, 1, 0));   // Move left
        pathPoints.Add(new Vector3(0, 2, 0));   // Move up
        pathPoints.Add(new Vector3(1, 2, 0));   // Move right
        pathPoints.Add(new Vector3(2, 2, 0));   // Move right
        pathPoints.Add(new Vector3(2, 1, 0));   // Move down
        pathPoints.Add(new Vector3(2, 0, 0));   // Move down
        pathPoints.Add(new Vector3(3, 0, 0));   // Move right
        pathPoints.Add(new Vector3(3, 1, 0));   // Move up
        pathPoints.Add(new Vector3(4, 1, 0));   // Move right
        pathPoints.Add(new Vector3(5, 1, 0));   // Move right further
        pathPoints.Add(new Vector3(5, 0, 0));   // Move down
        pathPoints.Add(new Vector3(4, 0, 0));   // Move left
        pathPoints.Add(new Vector3(4, -1, 0));  // Move down
        pathPoints.Add(new Vector3(3, -1, 0));  // Move left
        pathPoints.Add(new Vector3(3, -2, 0));  // Move down to final position

        //GenerateRandomPositions(); // Call the function to generate random points

        // Populate the graph with vertices and edges
        graph = new Graph(); // Re-initialize the graph to clear old data
        for (int i = 0; i < pathPoints.Count; i++)
        {
            graph.AddVertex(pathPoints[i]);
            if (i > 0)
            {
                graph.AddEdge(i - 1, i);
                graph.AddEdge(i, i - 1); // Making bidirectional for easy return
            }
        }
    }

    private void DrawPath()
    {
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.positionCount = pathPoints.Count;
        lineRenderer.SetPositions(pathPoints.ToArray());
    }
    private IEnumerator RecordUserPosition()
    {
        while (true)
        {
            if (Camera.main != null) // Check if the main camera is available
            {
                pathPoints.Add(Camera.main.transform.position); // Record current camera position
                UpdatePathVisual(); // Update the visual representation each time a new point is added
            }
            yield return new WaitForSeconds(recordInterval); // Wait for the specified interval
        }
    }

    private void UpdatePathVisual()
    {
        lineRenderer.positionCount = pathPoints.Count;
        lineRenderer.SetPositions(pathPoints.ToArray());
    }

    private IEnumerator SimulatePathfinding()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds before simulating pathfinding

        //Set final position index is the last point in pathPoints
        int finalPositionIndex = pathPoints.Count - 1;

        // Find path back to the start using BFS
        List<int> pathBack = Pathfinding.BFS(graph, finalPositionIndex, startPositionIndex);

        // Draw the path back in a different color
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;

        Vector3[] pathBackPoints = new Vector3[pathBack.Count];
        for (int i = 0; i < pathBack.Count; i++)
        {
            pathBackPoints[i] = graph.vertices[pathBack[i]];
        }

        lineRenderer.positionCount = pathBackPoints.Length;
        lineRenderer.SetPositions(pathBackPoints);

    }

    public void ClearWaypointsData()
    {
        pathPoints.Clear();
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
        graph = new Graph(); 
    }
}
