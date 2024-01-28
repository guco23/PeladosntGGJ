using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{       
    static GameManager instance;
    static public GameManager Instance { get { return instance; } }

    public List<string> ordenesList;

    public int NumOrdenes = 2;

    private int numPlayers = 2;
    private int actualPlayer = 0;
    private bool GamePaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += updateNewScene;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        //Debug.Log("Tu Vieja");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCursorState()
    {
       //Cursor.visible = !Cursor.visible;
    }

    public void updateOrdersList(List<string> list)
    {
        ordenesList.Clear();
        for(int i = 0; i < list.Count; i++)
        {
            ordenesList.Add(list[i]);
        }  
    }
    public void LoadScene(string sceneName)
    {
        NumOrdenes++;
        updateOrdersList(PlayerManager.instance.SelectNextOrders());
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
    public void SetPlayeNum(string number)
    {
        numPlayers = int.Parse(number);
        //Debug.Log("Numero de players " + numPlayers);
    }
    void updateNewScene(Scene scene, LoadSceneMode mode)
    {
        
        //Debug.Log(scene.name +" " + actualPlayer + " "+ numPlayers);

        //cambiar por el nombre de la escena principal
        if(scene.name == "MainScene")
        {
            ++actualPlayer;
            PlayerManager.instance.AddOrders(ordenesList);
        }
        if (actualPlayer > numPlayers && scene.name != "EndScene")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
    public void PauseGame(InputAction.CallbackContext call)
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (GamePaused)
        {
            Time.timeScale = 1;
            GamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            GamePaused = true;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
