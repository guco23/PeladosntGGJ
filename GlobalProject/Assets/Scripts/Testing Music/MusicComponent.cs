using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicComponent : MonoBehaviour
{
    [SerializeField] private bool _changeMusic = false;

    private bool _playingPlayableMusic = false;

    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private AudioSource _playableSource;
    [SerializeField] private AudioSource _effectsSource;

    [SerializeField] private float _fadeTime;
    [SerializeField] private float _umbral = 0.001f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_changeMusic && _menuSource.volume >= 0)
        {
            if (!_playingPlayableMusic)
            {
                _playableSource.Play();
                _effectsSource.Play();
                _playingPlayableMusic = true;
            }
            Debug.Log("Cambio de Música");
            ChangeToPlayableState();
        }
    }

    private void ChangeToPlayableState()
    {
        _menuSource.volume = Mathf.Lerp(_menuSource.volume, 0, Time.deltaTime * _fadeTime);
        _playableSource.volume = Mathf.Lerp(_playableSource.volume, 1, Time.deltaTime * _fadeTime);

        if (_menuSource.volume <= 0 + _umbral)
        {
            _menuSource.volume = 0;
            _playableSource.volume = 1;
            _changeMusic = false;
        }

    }
}
