using System.CodeDom.Compiler;
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

    [SerializeField]
    private List<AudioClip> audioClipList;

    private List<string> ordersList;

    public int NumOrdenes = 2;

    private int numPlayers = 3;
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
        else
        {
            Destroy(this);
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
        ordenesList = list;
    }
    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        switch (sceneName) {
            case "MainScene":
            NumOrdenes++;
            updateOrdersList(PlayerManager.instance.SelectNextOrders());
                break;
        }
        
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
    public void SetPlayeNum(string number)
    {
        numPlayers = int.Parse(number);
    }
    /// <summary>
    /// Metodo que actua como Start para el gameManager
    /// Se suscribe a un evento que se llama al terminar de cargar una escena
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void updateNewScene(Scene scene, LoadSceneMode mode)
    {
        
        Debug.Log(scene.name +" " + actualPlayer + " "+ numPlayers);

        //cambiar por el nombre de la escena principal
        if(scene.name == "MainScene")
        {
            ++actualPlayer;
            PlayerManager.instance.AddOrders(ordenesList);
        }

        //si estoy en el ultimo jugador 
        if (actualPlayer == numPlayers && scene.name != "EndScene")
        {
            actualPlayer = 0;
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


    /// <summary>
    /// Crea las ordenes para la pirmera iteracion
    /// </summary>
    public void GenenateComands()
    {
        List<string> list = new List<string>();
        while(list.Count < NumOrdenes)
        {
            int aux = Random.Range(0, audioClipList.Count);

            Debug.Log(aux);
            //garantizamos que no son repetidos
            //while () aux = Random.Range(0, audioClipList.Count-1);

            list.Add(audioClipList[aux].name);
        }
        ordenesList = list;
    }

    public AudioClip GetOrderClip(string name)
    {
        int i = 0;
        while (audioClipList[i].name != name && i < audioClipList.Count - 1)
        {
            i++;
        }
        if(i > audioClipList.Count - 1)
            Debug.LogError("El audio no se encontró en la lista de clips");

        return audioClipList[i];
    }
}
