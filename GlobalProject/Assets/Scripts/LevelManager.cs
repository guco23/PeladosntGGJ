using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] private float levelMaxTime = 5;
    private float currentTime;
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
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            Debug.Log(currentTime);
            GameManager.Instance.LoadScene("MainScene");
        }
    }
}
