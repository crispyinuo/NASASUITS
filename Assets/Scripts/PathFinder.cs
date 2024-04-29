using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinder : MonoBehaviour
{
    private List<Vector3> positions;
    private List<Vector3> shortestPath;

    private void Start()
    {
        positions = GenerateMockupPositionData();
        shortestPath = GetShortestWayBack(positions);
    }

    List<Vector3> GenerateMockupPositionData()
    {
        List<Vector3> positions = new List<Vector3>();
        positions.Add(new Vector3(10, 0, 10)); // Start position
        for (int i = 1; i < 99; i++)
        {
            positions.Add(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
        }
        positions.Add(new Vector3(-10, 0, -10)); // End position
        return positions;
    }

    List<Vector3> GetShortestWayBack(List<Vector3> positions)
    {
        Vector3 start = positions[0];
        Vector3 end = positions[positions.Count - 1];

        var openSet = new List<(Vector3 node, float priority)>();
        var cameFrom = new Dictionary<Vector3, Vector3>();

        Dictionary<Vector3, float> gScore = new Dictionary<Vector3, float>();
        Dictionary<Vector3, float> fScore = new Dictionary<Vector3, float>();

        foreach (var position in positions)
        {
            gScore[position] = float.MaxValue;
            fScore[position] = float.MaxValue;
        }

        gScore[start] = 0;
        fScore[start] = Vector3.Distance(start, end);
        openSet.Add((start, fScore[start]));

        while (openSet.Count > 0)
        {
            openSet = openSet.OrderBy(x => x.priority).ToList();
            var current = openSet[0].node;
            openSet.RemoveAt(0);

            if (current.Equals(end))
                return ReconstructPath(cameFrom, current);

            foreach (var neighbor in GetNeighbors(current, positions))
            {
                float tentative_gScore = gScore[current] + Vector3.Distance(current, neighbor);
                if (tentative_gScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentative_gScore;
                    fScore[neighbor] = gScore[neighbor] + Vector3.Distance(neighbor, end);
                    if (!openSet.Any(p => p.node == neighbor))
                        openSet.Add((neighbor, fScore[neighbor]));
                }
            }
        }

        return new List<Vector3>(); // Return an empty path if no path is found
    }

    List<Vector3> ReconstructPath(Dictionary<Vector3, Vector3> cameFrom, Vector3 current)
    {
        List<Vector3> totalPath = new List<Vector3> { current };
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            totalPath.Add(current);
        }
        totalPath.Reverse();
        return totalPath;
    }

    IEnumerable<Vector3> GetNeighbors(Vector3 current, List<Vector3> positions)
    {
        foreach (var pos in positions)
        {
            if (!pos.Equals(current))
                yield return pos;
        }
    }


    void OnDrawGizmos()
    {
        if (positions == null)
            return;

        // Draw all positions in black
        Gizmos.color = Color.black;
        foreach (Vector3 pos in positions)
        {
            Gizmos.DrawSphere(pos, 0.2f);
        }

        // Draw start and end points in red
        if (positions.Count > 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(positions[0], 0.15f); // Start
            Gizmos.DrawSphere(positions[positions.Count - 1], 0.15f); // End
        }

        // Draw shortest path in green
        if (shortestPath != null)
        {
            Gizmos.color = Color.green;
            foreach (Vector3 pos in shortestPath)
            {
                Gizmos.DrawSphere(pos, 0.1f);
            }
        }
    }
}
