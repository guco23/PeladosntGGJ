using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamPlayer : MonoBehaviour
{
    Camera cam;

    Ray ray;
    RaycastHit hit;

    InteractiveObject currentItObject = null;
    VisualObject currentVisualObject = null;



    [SerializeField]
    private float maxDistanceItObject;
    [SerializeField]
    private float maxDistanceVisualObject;

    private void DetectObject()
    {
        //dispara un rayo al centro de la camara
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));


        if (Physics.Raycast(ray, out hit, maxDistanceItObject)){
            currentItObject = hit.collider.GetComponent<InteractiveObject>();
        }
        else{
            currentItObject = null;
        }



        if (Physics.Raycast(ray, out hit, maxDistanceVisualObject)){
            currentVisualObject = hit.collider.GetComponent<VisualObject>();
        }
        else{
            currentVisualObject = null;
        }


    }


    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * maxDistanceItObject, Color.yellow);
        DetectObject();
    }

    private void LateUpdate()
    { }

    


}

