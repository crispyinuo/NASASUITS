using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> pathPoints = new List<Vector3>();
    private Graph graph = new Graph();
    private int startPositionIndex = 0; // Starting position in the graph

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GeneratePseudoPositions();
        DrawPath();
        StartCoroutine(SimulatePathfinding());
        
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

        // Populate the graph with vertices and edges
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
}
