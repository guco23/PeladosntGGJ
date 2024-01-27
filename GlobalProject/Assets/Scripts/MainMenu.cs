using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public CinemachineSmoothPath smoothPath;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        menuUI.SetActive(true);

        if (smoothPath != null)
        {
            smoothPath.gameObject.SetActive(false);
        }

        if (virtualCamera != null)
        {
            // Desactiva manualmente la cinemática de la cámara al inicio
            virtualCamera.enabled = false;
        }
    }

    public void PlayGame()
    {
        Debug.Log("play");

        // Desactiva el menú
        menuUI.SetActive(false);

        // Activa tanto el smoothPath como la virtualCamera al presionar "Play Game"
        if (smoothPath != null)
        {
            smoothPath.gameObject.SetActive(true);
        }

        if (virtualCamera != null)
        {
            // Activa manualmente la cinemática de la cámara al presionar "Play Game"
            virtualCamera.enabled = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
