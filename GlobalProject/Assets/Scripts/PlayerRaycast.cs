using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRaycast : MonoBehaviour
{
    PlayerManager playerManager;

    //camara
    Camera cam;

    //variables para lanzar rayos
    Ray ray;
    RaycastHit hit;

    //objetos actuales(interactivo y visual)
    InteractiveObject currentItObject = null;
    VisualObject currentVisualObject = null;

    //distancias de cada rayo, serializadas
    [SerializeField]
    private float maxDistanceItObject;
    [SerializeField]
    private float maxDistanceVisualObject;


    //funcion que se llama al pulsar la tecla de interaccion
    public void InteractObject()
    {
        //dispara un rayo al centro de la camara
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));


        //si el rayo ha colisonado 
        if (Physics.Raycast(ray, out hit, maxDistanceItObject))
        {
            currentItObject = hit.collider.GetComponent<InteractiveObject>();

            //si hemos dado a un objeto interactuable
            if (currentItObject != null)
            {
                //accion del interactuable
                currentItObject.Action();

                //añadir accion a la lista(cooldown si hace falta)
                playerManager.AddAction("interactuas con " + currentItObject.getName());
            }

        }
        else
        {//sino ha chocado con nada el rayo

            currentItObject = null;
        }

        //print(currentItObject); 


    }

    //funcion que se llama al pulsar la tecla de zoom
    public void Zoom()
    {
        //dispara un rayo al centro de la camara
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        //si el rayo ha chocado con algo
        if (Physics.Raycast(ray, out hit, maxDistanceVisualObject))
        {
            currentVisualObject = hit.collider.GetComponent<VisualObject>();

            //si hemos dado a un objeto visual
            if (currentVisualObject != null)
            {
                //añadir a la lista de acciones
                playerManager.AddAction("mira a " + currentVisualObject.getName());
                //hacer el zoom de la camara
                CameraZoom();
            }
        }
        else
        {
            currentVisualObject = null;
        }

        //print(currentVisualObject);


    }

    //funcion que hace el zoom de la camara
    void CameraZoom()
    {

    }


    void Start()
    {
        cam = Camera.main;
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * maxDistanceItObject, Color.yellow);
        //Debug.Log(actionsList[actionsList.Count - 1]);
    }



}

