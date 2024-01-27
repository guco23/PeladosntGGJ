using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComponent : MonoBehaviour
{

    [SerializeField] private AudioClip menuSong;
    [SerializeField] private AudioClip playableSong;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Cambio de Música");
            ChangeToPlayableState();
        }
    }

    private void ChangeToPlayableState()
    {

    }
}
