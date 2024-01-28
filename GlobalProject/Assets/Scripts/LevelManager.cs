using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] private float levelMaxTime = 5;
    private float currentTime;

    [SerializeField] private Transform mainUI;
    [SerializeField] private Transform pauseUI;

    public TMP_Text text;

    public List<GameObject> lights;
    
    public float getLevelMaxTime() { return levelMaxTime; }
    public float getLevelCurrentTime() { return currentTime; }

    public void SwitchLights()
    {
        for(int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(!lights[i].activeInHierarchy);
        }
    }

    public void SetPauseMenu(bool active)
    {
        mainUI.gameObject.SetActive(!active);
        pauseUI.gameObject.SetActive(active);
    }

    void Awake()
    {
        currentTime = levelMaxTime;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time: " +  string.Format("{0:00}:{1:00}", currentTime / 60, currentTime % 60);
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            GameManager.Instance.LoadScene("MainScene");
        }
    }
}
