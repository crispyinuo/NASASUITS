using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoSamplingUIManager : MonoBehaviour
{
    public UrsaUIManager ursaUIManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExecuteTask(string functionName, string displayString)
    {
        switch (functionName)
        {
            case "on_geosampling_start":
                on_geosampling_start();
                break;
            case "on_geosampling_menu_check_current_rock":
                on_geosampling_menu_check_current_rock(displayString);
                break;
            default:
                Debug.Log("Function name does not match any defined method");
                break;
        }
    }

    public void on_geosampling_start()
    {
        ursaUIManager.setOutputText("Say Ursa check current rock after scanning each rock");
    }

    public void on_geosampling_menu_check_current_rock(string display_string)
    {
        // In TSS, pull the scanned rock’s information 
        // Find the rock that matches the scanned rock’s name and id
        // Match the value of each composition, determine whether the rock’s value is normal or not
        ursaUIManager.setOutputText(display_string);
        Debug.Log("geosampling.");
    }
}
