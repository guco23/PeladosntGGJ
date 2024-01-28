using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerManager : MonoBehaviour
{
    public AudioClips audioClips;

    PlayerRaycast playerRaycast;
    PlayerPlaceComponent playerPlaceComponent;

    CooldownComponent cooldownComponent;
    //SERIALIZADAS PARA DEBUG

    //lista de las acciones que se han ido haciendo
    [SerializeField]
    List<string> actionsList = new List<string>();

    Dictionary<string,bool> orders = new Dictionary<string,bool>();
    int ordersLeft;


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
        if (context.action.triggered && context.action.ReadValue<float>() > 0)
        {
            playerRaycast.Zoom();
        }
        else
        {
            playerRaycast.EndZoom();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            string place = playerPlaceComponent.getCurrentPlace();
            //print(place);
            if (place != "")
            {
                cooldownComponent = playerPlaceComponent.getCurrentPlaceComponent().GetComponent<CooldownComponent>();  
                
                if(cooldownComponent != null && cooldownComponent.CanAction())
                {
                    AddAction("saltar_L_" + place);

                    cooldownComponent.ResetCooldown();
                }
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
                cooldownComponent = playerPlaceComponent.getCurrentPlaceComponent().GetComponent<CooldownComponent>();

                if(cooldownComponent != null && cooldownComponent.CanAction())
                {
                    AddAction("agachar_L_" + place);
                    cooldownComponent.ResetCooldown();
                }

            }
        }
    }

    public void AddAction(string actionName)
    {
        actionsList.Add(actionName);
        //chequear si era una de las acciones
        if (orders.ContainsKey(actionName) && orders[actionName] != true)
        {
            orders[actionName] = true;
            ordersLeft--;

            //print("aaaaaaaa");

            if(ordersLeft == 0)
            {
                //print("ya no quedan ordenes"); 
                //llamar al cambio de escena
            }

        }

        
    }
    public void AddItem(string itemName)
    {
        itemsList.Add(itemName);
    }

    private void Start()
    {
        List<string> lista = new List<string>();

        lista.Add("accionar_N_luces");
        lista.Add("accionar_N_polea");
        lista.Add("agachar_L_palacio");

        AddOrders(lista);

        playerRaycast = GetComponent<PlayerRaycast>();
        playerPlaceComponent = GetComponent<PlayerPlaceComponent>();
    }

    public void AddOrders(List<string> ordenenes)
    {
        orders.Clear();

        for(int i = 0; i < ordenenes.Count; i++)
        {
            orders.Add(ordenenes[i], false);
        }
        ordersLeft = ordenenes.Count;

        audioClips.PlayOrders(ordenenes);

    }

    public void SelectNextOrders()
    {
        int timeTolevel = 40;
        int actualTime = 0;

        int maxActions= 10;
        int currentActions= 3;

        float keepOriginalPercentage = 95;

        //cada segundo extra reduce la probabilidad un 0,5%
        if(actualTime > timeTolevel)
        {
            keepOriginalPercentage -= (actualTime - timeTolevel) / 2;
        }
        if(currentActions > maxActions)//cada accion extra la reduce un 2%
        {
            keepOriginalPercentage -= (currentActions - maxActions) * 2;
        }

        //las acciones que esten en true, tendran esa posibilidad, las que esten en false tendran un 0%

        //si no se han elegido 3 acciones, se rellenan aleatoriamente con el resto de acciones que se hayan hecho

        //se vigila que no haya repeticiones de acciones

        //si no hay suficientes acciones aun asi, se crean de forma aleatoria

    }
}

