using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.RegularExpressions;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(PinUserLocation))]
public class PinUserLocationEditor : Editor
{
    int pinNumber = 0; // Variable to store the user's input for pin number
    string testMessageBackend = ""; //test the backend message 
    bool useCustomPinNumber = false; // Checkbox to decide if a custom pin number should be used

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        PinUserLocation script = (PinUserLocation)target;

        // Checkbox to enable or disable the use of a custom pin number
        useCustomPinNumber = EditorGUILayout.Toggle("Use Custom Pin Number", useCustomPinNumber);

        // Conditionally display the pin number input field based on the checkbox
        if (useCustomPinNumber)
        {
            pinNumber = EditorGUILayout.IntField("Pin Number", pinNumber);
        }

        // Button to pin location
        if (GUILayout.Button("Pin My Location"))
        {
            if (useCustomPinNumber)
            {
                script.PinMyLocation(pinNumber); // Use the custom pin number
            }
            else
            {
                script.PinMyLocation(); // Use the automatic pin number
            }
        }

        // Input field and button for removing a pin
        pinNumber = EditorGUILayout.IntField("Remove Pin Number", pinNumber);
        if (GUILayout.Button("Remove Pin"))
        {
            script.on_navigation_remove_pin(pinNumber); // Remove the pin with the specified number
        }
        testMessageBackend = EditorGUILayout.TextField("Type in the backend Message", testMessageBackend);

        if (GUILayout.Button("test backend message remove_pin"))
        {
            script.on_navigation_remove_pin_HMD(testMessageBackend); 
        }
        if (GUILayout.Button("on_navigation_pin_my_location_HMD"))
        {
            script.on_navigation_pin_my_location_HMD(testMessageBackend); 
        }
    }
}
#endif
public class PinUserLocation : MonoBehaviour
{
    public GameObject user;
    public UrsaUIManager ursaUIManager;

    // Dictionary to store pin number and location
    private Dictionary<int, Vector3> userPinnedLocations = new Dictionary<int, Vector3>();
    private int nextPinNumber = 0;  // To keep track of the next pin number to assign

    void Start()
    {
        //clear data at start 
        userPinnedLocations.Clear();
    }

    // Method to pin the current location of the user
    public void PinMyLocation()
{
    // Get the current position of the user GameObject
    Vector3 currentUserPosition = user.transform.position;

    // Add the location to the dictionary with the next available pin number
    userPinnedLocations.Add(nextPinNumber, currentUserPosition);
    Debug.Log("Location pinned at: " + currentUserPosition + " with pin number: " + nextPinNumber);

    // Increment the pin number for the next use
    nextPinNumber++;
    ursaUIManager.SetMessageToPinMyLocation();
}
public void on_navigation_pin_my_location_HMD(string displayString){
    // Regular expression to find the pin number in the display string
    string pattern = @"Pin (\d+)";
    Match match = Regex.Match(displayString, pattern);

    if (match.Success)
    {
        // Extract the pin number from the match
        int pinNum = int.Parse(match.Groups[1].Value);

        // Call the on_navigation_remove_pin function with the extracted pin number
        PinMyLocation(pinNum);
    }
    else
    {
        Debug.Log("Pin number not found in the display string.");
    }
}
public void PinMyLocation(int pinNumber)
{
    // Get the current position of the user GameObject
    Vector3 currentUserPosition = user.transform.position;

    // Check if the specified pin number already exists
    if (userPinnedLocations.ContainsKey(pinNumber))
    {
        // Option 1: Overwrite the existing pin
        userPinnedLocations[pinNumber] = currentUserPosition;
        Debug.Log("Updated location of pin " + pinNumber + " to: " + currentUserPosition);

        // Option 2: Error message and return without adding (uncomment to use)
        // Debug.Log("Pin number " + pinNumber + " already exists. No action taken.");
        // return;
        ursaUIManager.SetMessageToPinMyLocation();
    }
    else
    {
        // Add the location with the user-specified pin number
        userPinnedLocations.Add(pinNumber, currentUserPosition);
        Debug.Log("Location pinned at: " + currentUserPosition + " with pin number: " + pinNumber);

        // Update nextPinNumber if necessary to avoid future conflicts
        nextPinNumber = Mathf.Max(nextPinNumber, pinNumber + 1);
    }
}

public void on_navigation_remove_pin_HMD(string displayString)
{
    // Regular expression to find the pin number in the display string
    string pattern = @"Pin (\d+)";
    Match match = Regex.Match(displayString, pattern);

    if (match.Success)
    {
        // Extract the pin number from the match
        int pinNum = int.Parse(match.Groups[1].Value);

        // Call the on_navigation_remove_pin function with the extracted pin number
        on_navigation_remove_pin(pinNum);
    }
    else
    {
        Debug.Log("Pin number not found in the display string.");
    }
}
    public void on_navigation_remove_pin(int pinNum)
    {
        // Check if the pin number exists before trying to remove it
        if (userPinnedLocations.ContainsKey(pinNum))
        {
            userPinnedLocations.Remove(pinNum);
            ursaUIManager.SetMessageToRemoveMyLocation();
            Debug.Log("Removed pin number: " + pinNum);
        }
        else
        {
            Debug.Log("Pin number " + pinNum + " does not exist.");
        }
    }
}