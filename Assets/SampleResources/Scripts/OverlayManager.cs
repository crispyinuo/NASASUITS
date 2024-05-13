using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;

public class OverlayManager : MonoBehaviour
{
    Transform targetTransform;

    GameObject target;

    Vector3 targetPosition;

    Quaternion targetRotation;

    public GameObject overlay;
    
    public Transform overlayTransform;

    Vector2 size;

    Dictionary<string, Vector2> overlayDict = new Dictionary<string, Vector2>()
    {
        // to the left and to the bottom 
        {"Oxygen-EMU1", new Vector2((float)0.63, (float)0.18)}, 


    };

    // Start is called before the first frame update

    void Start()
    {
        
    }
   
    public void UpdateTarget(string tagName)
    {

        Debug.Log("Update Target");
        this.target = gameObject;
        targetTransform = target.transform;
        targetPosition = targetTransform.position;
        targetRotation = targetTransform.rotation;
        size = target.GetComponent<ImageTargetBehaviour>().GetSize();


        // width = target.GetComponent<Renderer>().bounds.size.x;
        // height = target.GetComponent<Renderer>().bounds.size.y;

        // generateOverlay();
    }

    void generateOverlay()
    {
       
        overlay.SetActive(true);
        Vector3 offset = new Vector3(0, 0, -0.5f);
        overlay.transform.position = overlayTransform.position;
        overlay.transform.rotation = overlayTransform.rotation;
    }
}
