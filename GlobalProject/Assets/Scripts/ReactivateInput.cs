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
    public PlayerManager playerManager;

    public void vuelveElFckingInputPuñeta()
    {
        player.GetComponent<PlayerInput>().currentActionMap.Enable();
        
        levelManager.enabled = true;

        inGameUI.SetActive(true);

        playerManager.GenerarPrimerasOrdenes();

        GameManager.Instance.GenenateComands();
    }
}
