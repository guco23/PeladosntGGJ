using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamPlayer : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    Ray ray;
    RaycastHit hit;

    [SerializeField]
    private float maxDistance;

    private void DetectObject()
    {
        //dispara un rayo al centro de la camara
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));


        if (Physics.Raycast(ray, out hit,maxDistance))
            print("I'm looking at " + hit.transform.name);
        else
            print("I'm looking at nothing!");
        //print(hit); 

    }


    void Start()
    {
        //cam = Camera.main;
    }

    private void Update()
    {
    }

    private void LateUpdate()
    {
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.yellow);
        DetectObject();
    }


}

