using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//El probable que no funciona bien xd
//Parte de la máquina de estados me la he pasado por el papo y es probable que esté un poco roto
[RequireComponent(typeof(CooldownComponent))]
public class ObstacleComponent : MonoBehaviour
{
    [SerializeField]
    [Tooltip("El tag identificador del el obstaculo")]
    string obstacleTag;

    bool middle;
    GameObject enter1;
    GameObject enter2;

    CooldownComponent cooldown;
    
    [SerializeField]
    [Tooltip("True saltando, false agachando")]
    private bool saltando;

    private void Start()
    {
        cooldown = GetComponent<CooldownComponent>();
        enter1 = null;
        enter2 = null;
    }

    //Una maquina de estado para los triggers que si se cumple indica al player o lo que vaya a ser que tiene que eso que ha superado un obstaculo
    internal void notifyEnter(GameObject o, bool isMiddle)
    {
        //Cuando el jugador 
        if (isMiddle)
        {
            middle = true;
        }
        else if (enter1 == null)
        {
            enter1 = o;
        }
        else if(middle)
        {
            enter2 = o;
        }
    }

    internal void notifyExit(GameObject o, bool isMiddle,Collider player)
    {
        //Cuando se sale del middle
        if (isMiddle)
        {
            //Caso de que sales por el otro trigger
            if(enter2 != null && enter2 != enter1) {
                //OBSTUCALO SUPERADO! aqui hay que poner la llamada a lo que sea

                if (cooldown.CanAction())
                {

                    if (saltando)
                    {
                        player.GetComponent<PlayerManager>().AddAction("saltar_O_" + obstacleTag);

                    }
                    else
                    {
                        player.GetComponent<PlayerManager>().AddAction("agachar_O_" + obstacleTag);
                    }

                    cooldown.ResetCooldown();
                }
                

                enter1 = null;
            }
            /*Está el caso de si vuelve a pasar antes de salir de enter2 pero nos da igual
            * porque sólo nor importa comprobarlo una vez*/
            enter2 = null;
            middle = false;
        }
        else if(enter2 == null && !middle)//Caso de que sales por el mismo trigger
        {
            enter1 = null;
            enter2 = null;
        }

    }

}
