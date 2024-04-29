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
        shortestPath = new List<Vector3>(userPositionData.positions); // Copy all positions

        shortestPath.Reverse(); 
        shortestPath.Add(currentPosition);

    }

        
}