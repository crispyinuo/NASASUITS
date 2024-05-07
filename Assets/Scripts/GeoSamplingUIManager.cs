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
    public void on_geosampling_start()
    {
        ursaUIManager.setOutputText("Say Ursa check current rock after scanning each rock");
    }

    public void on_geosampling_check_current_rock()
    {
        // In TSS, pull the scanned rock’s information 
        // Find the rock that matches the scanned rock’s name and id
        // Match the value of each composition, determine whether the rock’s value is normal or not

    }
}
