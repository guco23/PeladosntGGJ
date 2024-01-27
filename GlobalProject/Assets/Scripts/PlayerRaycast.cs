using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerRaycast : MonoBehaviour
{
    PlayerManager playerManager;

    PlayerInput playerInput = null;
    //camara
    Camera cam;

    [SerializeField] private CinemachineVirtualCamera camPlayer;

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

    [SerializeField] private float initialView = 60;

    [SerializeField] private float minZoomView = 30;

    [SerializeField] private float zoomSpeed = 1;

    private bool zoomState = false;


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

                //si el objeto es pickeable
                //currentItObject.Action();
                ActionObject actionObject;
                PickeableObject pickeableObject;

                actionObject = currentItObject.GetComponent<ActionObject>();

                if(actionObject != null)
                {
                    actionObject.Action();

                    //cambiar el nombre de la frase por frase personalizada?
                    playerManager.AddAction("interactuas con " + currentItObject.getName());
                }
                else
                {
                    pickeableObject = currentItObject.GetComponent<PickeableObject>();

                    if(pickeableObject != null)
                    {
                        playerManager.AddItem(currentItObject.getName());
                        pickeableObject.Pick();
                    }
                }            
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

            if(currentVisualObject != null)
            {
                zoomState = true;
            }
      
        }
        else
        {
            currentVisualObject = null;
        }

        //print(currentVisualObject);


    }

    public void EndZoom()
    {
        zoomState = false;
    }


    void Start()
    {
        cam = Camera.main;

        playerInput = GetComponent<PlayerInput>();
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        //debug del rayo
        Debug.DrawRay(ray.origin, ray.direction * maxDistanceItObject, Color.yellow);
    }

    private void LateUpdate()
    {

        //MAQUINA DE ESTADOS DEL ZOOM, sacar a componente?

        //si estamos en el estado zoom
        if (zoomState)
        {
            
            playerInput.currentActionMap.actions[3].Disable();
            //mientras no haya llegado al min zoom(estar lo mas cerca posible), nos acercamo
            if (camPlayer.m_Lens.FieldOfView > minZoomView)
            {
                camPlayer.m_Lens.FieldOfView -= zoomSpeed;
            }
            else
            {
                //seteamos el zoom al minimo
                camPlayer.m_Lens.FieldOfView = minZoomView;

                //si hemos dado a un objeto visual
                if (currentVisualObject != null)
                {
                    //añadir a la lista de acciones
                    playerManager.AddAction("mira a " + currentVisualObject.getName());
                    //hacer el zoom de la camara

                    currentVisualObject = null;
                }

            }

        }
        else //si no estamos en el estado zooms
        {
            //si no tenemos el zoom inicial, nos alejamos
            if (camPlayer.m_Lens.FieldOfView < initialView)
            {
                camPlayer.m_Lens.FieldOfView += zoomSpeed;
            }
            else
            {
                playerInput.currentActionMap.actions[3].Enable();

                //si ya tenemos el zoom inicial lo seteamos
                camPlayer.m_Lens.FieldOfView = initialView;
            }
        }


    }



}

