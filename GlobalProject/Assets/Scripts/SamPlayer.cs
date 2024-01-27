using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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


    List<string> actionsList = new List<string>();

    public void InteractObject(InputAction.CallbackContext context)
    {
        //dispara un rayo al centro de la camara
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));


        if (Physics.Raycast(ray, out hit, maxDistanceItObject))
        {
            currentItObject = hit.collider.GetComponent<InteractiveObject>();

            //accion del interactuable
            //currentItObject.Action();

            //añadir accion a la lista(cooldown si hace falta)

            actionsList.Add("interactuas con " + currentItObject.getName());

        }
        else
        {
            currentItObject = null;
        }

        //print(currentItObject); 


    }

    public void Zoom(InputAction.CallbackContext context)
    {
        //dispara un rayo al centro de la camara
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit, maxDistanceVisualObject))
        {
            currentVisualObject = hit.collider.GetComponent<VisualObject>();
        }
        else
        {
            currentVisualObject = null;
        }

        //print(currentVisualObject);

        actionsList.Add("mira a " + currentVisualObject.getName());

    }



    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * maxDistanceItObject, Color.yellow);
        //Debug.Log(actionsList[actionsList.Count-1]);
    }
}

