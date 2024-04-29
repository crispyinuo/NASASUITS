using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script will be responsible for tracking the player's position at regular intervals.
public class GetUserPosition : MonoBehaviour
{
    public Transform player; // player object
    public float interval = 1.0f; // Interval to record position

    public UserPositionData userPositionData; // Reference to ScriptableObject

    private float timer = 0f;
    private Vector3 lastRecordedPosition;
    public List<Vector3> recordedPositions;
          

    private void Start()
    {

        // Initialize the ScriptableObject list
        // userPositionData = ScriptableObject.CreateInstance<UserPositionData>();
        // userPositionData.positions = new System.Collections.Generic.List<Vector3>();
        // Check if userPositionData is set
        if (userPositionData == null)
        {
            Debug.LogError("UserPositionData is not set. Cannot store data.");
        }
        else
        {
            // Start recording user position
            InvokeRepeating("RecordUserPosition", 0f, interval);
        }

    }

    private void RecordUserPosition()
    {
        // Get the current position of the player
        Vector3 currentPosition = player.position;

        // Check if the current position is different from the last recorded position
        if (currentPosition != lastRecordedPosition)
        {
            recordedPositions.Add(currentPosition);
            // Store the current position
            userPositionData.positions.Add(currentPosition);
            //Debug.Log("add new data...");

            // Update the last recorded position
            lastRecordedPosition = currentPosition;
        }
    }

    private void OnDisable()
    {
        // Save the ScriptableObject asset when the object is disabled
        SaveAsset();
    }

    private void SaveAsset()
    {
        // Create or overwrite the asset file with the recorded positions
        // UnityEditor.AssetDatabase.CreateAsset(userPositionData, "Assets/Data/UserPositionData.asset");
        // UnityEditor.AssetDatabase.SaveAssets();
        // UnityEditor.AssetDatabase.Refresh();
    }
}
