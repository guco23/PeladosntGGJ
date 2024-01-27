using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] private float levelMaxTime = 5;
    private float currentTime;

    
    public TMP_Text text;

    
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
        text.text = "Time: "+  string.Format("{0:00}:{1:00}", currentTime / 60, currentTime % 60);
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            Debug.Log(currentTime);
            GameManager.Instance.LoadScene("MainScene");
        }
    }
}
