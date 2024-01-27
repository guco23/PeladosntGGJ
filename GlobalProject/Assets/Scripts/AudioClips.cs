using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionCategory
{
    public string name;
    public List<Audio> audios;
}
[System.Serializable]
public struct Audio
{
    public string name;
    public AudioClip clip;
}
public class AudioClips : MonoBehaviour
{
    public List<ActionCategory> clipList;
    private AudioSource mySrc;
    
    // Start is called before the first frame update
    void Start()
    {
        mySrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetAudio(string name)
    {
        
    }
}
