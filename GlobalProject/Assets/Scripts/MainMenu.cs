using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public Animator animator;

    void Start()
    {
        menuUI.SetActive(true);
    }

    public void PlayGame()
    {
        Debug.Log("play");

        animator.SetBool("Play", true);

        // Desactiva el menú
        menuUI.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
