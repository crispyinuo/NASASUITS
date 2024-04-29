using UnityEngine;
using System.Collections.Generic;

public class GetShortestWayBack : MonoBehaviour
{
    public UserPositionData userPositionData;
    public List<Vector3> shortestPath;

    public void GetShortestPath(Vector3 currentPosition)
    {
        // Check if userPositionData is set
        if (userPositionData == null || userPositionData.positions.Count == 0)
        {
            Debug.LogError("UserPositionData is not set or no data collected.");
            return;
        }

        // Initialize the path with the current position
        shortestPath = new List<Vector3> { currentPosition };

        Vector3 startPoint = userPositionData.positions[0];
        Vector3 currentPoint = currentPosition;

        // Continue finding points until reaching the start
        while (currentPoint != startPoint)
        {
            Vector3 nextPoint = FindNextPoint(currentPoint, startPoint);
            if (nextPoint == currentPoint) // No valid next point found, stop the loop
                break;
            
            shortestPath.Add(nextPoint);
            currentPoint = nextPoint;
        }

        shortestPath.Add(startPoint); // Ensure the start point is added to the path
    }

    private Vector3 FindNextPoint(Vector3 currentPoint, Vector3 targetPoint)
    {
        Vector3 bestPoint = currentPoint;
        float bestDistance = float.MaxValue;

        foreach (Vector3 point in userPositionData.positions)
        {
            if (point == currentPoint)
                continue;

            float distanceToCurrent = Vector2.Distance(new Vector2(point.x, point.z), new Vector2(currentPoint.x, currentPoint.z));
            float distanceToTarget = Vector3.Distance(point, targetPoint);

            // Check if the point is closer to the target and within a step distance on the xz plane
            if (distanceToCurrent < 0.5f && distanceToTarget < Vector3.Distance(currentPoint, targetPoint))
            {
                if (distanceToTarget < bestDistance)
                {
                    bestDistance = distanceToTarget;
                    bestPoint = point;
                }
            }
        }

        return bestPoint;
    }
}