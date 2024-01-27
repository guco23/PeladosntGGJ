using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    static GameManager instance;
    static public GameManager Instance { get { return instance; } }


    private int numPlayers;
    private int actualPlayer = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += updateNewScene;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tu Vieja");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SetPlayeNum(string number)
    {
        numPlayers = int.Parse(number);
        Debug.Log("Numero de players " + numPlayers);
    }
    void updateNewScene(Scene scene, LoadSceneMode mode)
    {
        
        Debug.Log(scene.name +" " + actualPlayer + " "+ numPlayers);
        ++actualPlayer;
        if (actualPlayer > numPlayers)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
