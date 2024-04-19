using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public List<Vector3> vertices = new List<Vector3>();
    public Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

    public void AddVertex(Vector3 vertex)
    {
        vertices.Add(vertex);
        int newVertexIndex = vertices.Count - 1;
        edges[newVertexIndex] = new List<int>(); // Initialize empty edge list for new vertex
    }

    public void AddEdge(int from, int to)
    {
        if (edges.ContainsKey(from) && from != to)
        {
            edges[from].Add(to);
        }
    }
}
