using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingeltoneButtonConector : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameManager.Instance.LoadScene(sceneName);
    }
    public void Exit()
    {
        GameManager.Instance.Exit();
    }
    public void PauseGame()
    {
        GameManager.Instance.PauseGame();
    }
}
