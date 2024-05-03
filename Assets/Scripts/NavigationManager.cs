using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


[CustomEditor(typeof(NavigationManager))]
public class NavigationManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        NavigationManager navigationManager = (NavigationManager)target; // Get the reference to the PathDrawer

        if (GUILayout.Button("Start Record User Position"))
        {
            navigationManager.StartRecordUserPosition();
        }

        if (GUILayout.Button("ShowWayBack"))
        {
            navigationManager.ShowWayBack();
        }
        if (GUILayout.Button("Clear User Position"))
        {
            navigationManager.ClearUserPositionData();
        }
    }
}


public class NavigationManager : MonoBehaviour
{
    public GetUserPosition userPositionRecorder;

    public UserPositionData userPositionData;
    // Reference to the shortest way back calculator
    public GetShortestWayBack shortestWayBackCalculator;
    // Reference to the path renderer
    public PathRenderer pathRenderer;
    public Vector3 nextPosition;
    //user position will be recorded the whole time but when the user reset or went back home it should clear all the stored data 
    public void StartRecordUserPosition()
    {
        // // Ensure the userPositionRecorder reference is set
        // if (userPositionRecorder == null)
        // {
        //     Debug.LogError("UserPositionRecorder reference is not set in NavigationManager.");
        //     return;
        // }

        // // Start recording user positions
        // userPositionRecorder.enabled = true;
    }


    public void ClearUserPositionData()
    {
        if (userPositionData != null && userPositionData.positions.Count!= 0 )
        {
            userPositionData.positions.Clear();
        }
    }
    public void StopRecordUserPosition()
    {
        // Stop recording user positions
        userPositionRecorder.enabled = false;
    }

    public void ShowWayBack()
    {
       
          if (pathRenderer != null && shortestWayBackCalculator != null)
        {
            // Get the current position of the user
            Vector3 currentPosition = userPositionData.positions.Last();
            // Calculate the shortest path back to the starting point
            shortestWayBackCalculator.GetShortestPath(currentPosition);

            // Render the path back to the starting point
            pathRenderer.RenderPath();
           //Debug.Log("Show way back clicked. Current position: " + nextPosition);
        }

     
        // }
    }
}
