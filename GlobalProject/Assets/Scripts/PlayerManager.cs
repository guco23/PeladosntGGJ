using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerManager : MonoBehaviour
{
    public LevelManager levelManager;
    public AudioClips audioClips;

    PlayerRaycast playerRaycast;
    PlayerPlaceComponent playerPlaceComponent;

    CooldownComponent cooldownComponent;

    public float timeTolevel = 40;
    public int maxActions = 10;
    public float keepOriginalPercentage = 95;

    public int numberOfActions = 3;

    public  List<string> listaTotalAcciones = new List<string>();
    
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

        print(ordenenes);
        audioClips.PlayOrders(ordenenes);

    }

    public void GenerarPrimerasOrdenes()
    {
        List<string> ordenes = new List<string>();

        if (listaTotalAcciones.Count < 3) {

            ordenes.Add("coger_N_sable");
            ordenes.Add("mirar_N_mercado");
            ordenes.Add("saltar_O_caja");
        }
        else
        {
            while(ordenes.Count < numberOfActions)
            {
                int aux = Random.Range(0, listaTotalAcciones.Count);

                //chequear que es una accion distinta a las que ya tenemos seleccionados
                int j = 0;
                while (j < ordenes.Count && ordenes[j] != listaTotalAcciones[aux]) j++;

                //si es distinta
                if (j == ordenes.Count)
                {
                    ordenes.Add(actionsList[aux]);
                }
            }
        }


    }


    public void SelectNextOrders()
    {
        float actualTime = levelManager.getLevelMaxTime() -levelManager.getLevelCurrentTime();

        int currentActions = actionsList.Count;


        float percentageThisIteration = keepOriginalPercentage;

        //cada segundo extra reduce la probabilidad un 0,5%
        if(actualTime > timeTolevel)
        {
            percentageThisIteration -= (actualTime - timeTolevel) / 2;
        }
        if(currentActions > maxActions)//cada accion extra la reduce un 2%
        {
            percentageThisIteration -= (currentActions - maxActions) * 2;
        }

        List<string> nextOrders = new List<string>();

        //las acciones que esten en true, tendran esa posibilidad, las que esten en false tendran un 0%

        foreach (KeyValuePair<string,bool> pair in orders)
        {
            if (pair.Value)
            {
                if (percentageThisIteration > Random.Range(0f, 100f))
                {
                    nextOrders.Add(pair.Key);
                }
            }          
        }


        //si no se han elegido 3 acciones, se rellenan aleatoriamente con el resto de acciones que se hayan hecho

        int i = 0;
        while(nextOrders.Count < numberOfActions)
        {
            int aux = Random.Range(0, actionsList.Count);

            //chequear que es una accion distinta a las que ya tenemos seleccionados
            int j = 0;
            while (j < nextOrders.Count && nextOrders[j] != actionsList[aux]) j++;

            //si es distinta
            if (j == nextOrders.Count)
            {
                nextOrders.Add(actionsList[aux]);
            }


            i++;


            //si no hay suficientes acciones aun asi, se crean de forma aleatoria
            //salimos para no petar por si acaso
            if(i == 1000){
                break;
            }
        }
    }
}

