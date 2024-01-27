using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PlayerRaycast playerRaycast;
    PlayerPlaceComponent playerPlaceComponent;

    //SERIALIZADAS PARA DEBUG

    //lista de las acciones que se han ido haciendo
    [SerializeField]
    List<string> actionsList = new List<string>();

    //lista de los objetos que tenemos
    [SerializeField]
    List<string> itemsList = new List<string>();


    public void InteractObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerRaycast.InteractObject();
        }
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerRaycast.Zoom();
        }
        else if(context.canceled)
        {
            playerRaycast.EndZoom();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            string place = playerPlaceComponent.getCurrentPlace();
            print(place);
            if (place != "")
            {
                AddAction("salta en " + place);
            }
        }
    }

    public void Agacharse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            string place = playerPlaceComponent.getCurrentPlace();
            if (place != "")
            {
                AddAction("agachate en " + place);
            }
        }
    }

    public void AddAction(string actionName)
    {
        actionsList.Add(actionName);
    }
    public void AddItem(string itemName)
    {
        itemsList.Add(itemName);
    }

    private void Start()
    {
        playerRaycast = GetComponent<PlayerRaycast>();
        playerPlaceComponent = GetComponent<PlayerPlaceComponent>();
    }
}

