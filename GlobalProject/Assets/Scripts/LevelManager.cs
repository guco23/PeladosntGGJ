using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] private float levelMaxTime = 5;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = levelMaxTime;
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
