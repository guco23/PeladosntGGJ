using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicComponent : MonoBehaviour
{
    public bool _changeMusic = false;

    private bool _firstLoop = true;
    private bool _menuCompleted = false;

    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private AudioSource _playableSource;
    [SerializeField] private AudioSource _effectsSource;

    [SerializeField] private Animator _cortinasAnimator;

    [SerializeField] private float _fadeTime;
    [SerializeField] private float _umbral;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_changeMusic)
        {
            if (_firstLoop)
            {
                _effectsSource.Play();
                _cortinasAnimator.SetBool("Abierto", true);
                _firstLoop = false;
                Debug.Log("Aplausos");
            }
            else
            {
                ChangeToPlayableState();
            }
        }
    }

    public void ChangeToPlayableState()
    {
        if (!_menuCompleted)
        {
            if (_menuSource.volume <= 0 + _umbral)
            {
                _menuSource.volume = 0;
                _menuCompleted = true;
                _playableSource.Play();
                Debug.Log("Menu = 0");
            }

            else
            {
                LerpMenu();
                Debug.Log("Bajo Volumen Menu");
            }
        }

        else
        {
            if (_playableSource.volume >= 1 - _umbral)
            {
                _playableSource.volume = 1;
                _changeMusic = false;
                Debug.Log("Playable  = 1");
            }

            else
            {
                LerpPlayable();
                Debug.Log("Subo Volumen Playable");
            }
        }         
    }

    private void LerpMenu()
    {
        _menuSource.volume = Mathf.Lerp(_menuSource.volume, 0, Time.deltaTime * _fadeTime);
    }

    private void LerpPlayable()
    {
        _playableSource.volume = Mathf.Lerp(_playableSource.volume, 1, Time.deltaTime * _fadeTime);
    }
}
