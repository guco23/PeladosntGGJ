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
            // Desactiva manualmente la cinem�tica de la c�mara al inicio
            virtualCamera.enabled = false;
        }
    }

    public void PlayGame()
    {
        Debug.Log("play");

        // Desactiva el men�
        menuUI.SetActive(false);

        // Activa tanto el smoothPath como la virtualCamera al presionar "Play Game"
        if (smoothPath != null)
        {
            smoothPath.gameObject.SetActive(true);
        }

        if (virtualCamera != null)
        {
            // Activa manualmente la cinem�tica de la c�mara al presionar "Play Game"
            virtualCamera.enabled = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
