using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO; // Include for file operations
using UnityEditor;
[CustomEditor(typeof(DisplayMapImage))]
public class DisplayMapImageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default inspector

        DisplayMapImage script = (DisplayMapImage)target;

        if (GUILayout.Button("Display Map"))
        {
            script.on_navigation_open_map_HMD();
        }
        if (GUILayout.Button("Close Map"))
        {
            script.CloseMap();
        }
    }
}
public class DisplayMapImage : MonoBehaviour
{
    public Image uiImage; // Assign this in the Inspector
    public string jsonFilePath; // Path to the JSON file, set this in the Inspector
    public Sprite defaultMapBackground;//when close the map, set it to default background

    public void on_navigation_open_map_HMD()
    {
        Debug.Log("Update Map Image to HMD UI");
        if (string.IsNullOrEmpty(jsonFilePath) || !File.Exists(jsonFilePath))
        {
            Debug.LogError("JSON file path is not set or file does not exist.");
            return;
        }

        // try
        // {
        //     string jsonData = File.ReadAllText(jsonFilePath);
        //     var jsonObject = JsonUtility.FromJson<JsonData>(jsonData);
        //     DisplayBase64Image(jsonObject.image);
        // }

        try
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            var jsonObject = JsonUtility.FromJson<JsonData>(jsonData);
            string base64Data = jsonObject.image.Replace("data:image/png;base64,", ""); // Ensure no prefix
            Debug.Log("Base64 string starts with: " + base64Data.Substring(0, 50)); // Check initial characters
            DisplayBase64Image(base64Data);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to read or parse JSON file: " + e.Message);
        }
    }
    public void CloseMap(){
        uiImage.sprite = defaultMapBackground;

    }

    public void DisplayBase64Image(string base64)
    {
        byte[] imageData = Convert.FromBase64String(base64);
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(imageData))
        {
            uiImage.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        else
        {
            Debug.LogError("Could not load image data");
        }
    }

    // Helper class to match the JSON structure
    [Serializable]
    private class JsonData
    {
        public string image;
    }
}
