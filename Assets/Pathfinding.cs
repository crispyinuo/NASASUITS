using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public static List<int> BFS(Graph graph, int start, int goal)
    {
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        var path = new Dictionary<int, int>();
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == goal)
                break;
            foreach (var neighbor in graph.edges[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    path[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }
        return ReconstructPath(path, start, goal);
    }

    private static List<int> ReconstructPath(Dictionary<int, int> path, int start, int goal)
    {
        var result = new List<int>();
        int current = goal;
        while (current != start)
        {
            result.Add(current);
            current = path[current];
        }
        result.Add(start);
        result.Reverse();
        return result;
    }
}
