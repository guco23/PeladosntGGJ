using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReactivateInput : MonoBehaviour
{
    public GameObject player;

    public void vuelveElFckingInputPu�eta()
    {
        player.GetComponent<PlayerInput>().currentActionMap.Enable();
    }
}
