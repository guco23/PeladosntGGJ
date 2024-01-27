using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicComponent : MonoBehaviour
{
    [SerializeField] private bool _changeMusic = false;

    private bool _playingMenu = true;

    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private AudioSource _playableSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_changeMusic && _playingMenu)
        {
            Debug.Log("Cambio de Música");
            ChangeToPlayableState();
        }
    }

    private void ChangeToPlayableState()
    {
        _playingMenu = false;
        _menuSource.volume = 0;
        _playableSource.Play();
    }
}
