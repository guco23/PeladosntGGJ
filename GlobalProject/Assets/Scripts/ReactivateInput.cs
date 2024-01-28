using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ReactivateInput : MonoBehaviour
{
    public GameObject player;
    public LevelManager levelManager;
    public GameObject inGameUI;

    public void vuelveElFckingInputPuñeta()
    {
        player.GetComponent<PlayerInput>().currentActionMap.Enable();
        
        levelManager.enabled = true;

        inGameUI.SetActive(true);
    }
}
