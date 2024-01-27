using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//El probable que no funciona bien xd
//Parte de la máquina de estados me la he pasado por el papo y es probable que esté un poco roto
public class ObstacleComponent : MonoBehaviour
{
    bool middle;
    GameObject enter1;
    GameObject enter2;

    private void Start()
    {
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
        } else if(middle)
        {
            enter2 = o;
        }
    }

    internal void notifyExit(GameObject o, bool isMiddle)
    {
        //Cuando se sale del middle
        if (isMiddle)
        {
            //Caso de que sales por el otro trigger
            if(enter2 != null && enter2 != enter1) {
                //OBSTUCALO SUPERADO!
                enter1 = null;
            }
            /*Está el caso de si vuelve a pasar antes de salir de enter2 pero nos da igual
            * porque sólo nor importa comprobarlo una vez*/
            enter2 = null;
        } else if(enter2 == null)//Caso de que sales por el mismo trigger
        {
            enter1 = null;
        }
        middle = false;
    }

}
