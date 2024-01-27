using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CooldownComponent))]
public class ActionObject : MonoBehaviour
{

    //evento de la accion del objeto en cuestion
    [SerializeField]
    private UnityEvent evento;
    
    public void Action()
    {
        evento.Invoke();       
    }


}

