using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public Animator animator;
    public GameObject player;
    public MusicComponent music;

    void Start()
    {
        menuUI.SetActive(true);
        //for (int i = 0; i < 6; i++) {
        //    player.GetComponent<PlayerInput>().currentActionMap.actions[i].Disable();
        //}
        player.GetComponent<PlayerInput>().currentActionMap.Disable();
    }

    public void PlayGame()
    {
        Debug.Log("play");

        music._changeMusic = true;

        animator.SetBool("Play", true);

        // Desactiva el menú
        menuUI.SetActive(false);

    }

    public void QuitGame()
    {
        GameManager.Instance.Exit();
    }
}
