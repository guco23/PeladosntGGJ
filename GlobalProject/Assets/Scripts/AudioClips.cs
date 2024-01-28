using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public List<AudioClip> clipList;
    private AudioSource mySrc;

    public float timeBetween = 2f;


    // Start is called before the first frame update
    void Start()
    {
        mySrc = GetComponent<AudioSource>();
        //Debug.Log(mySrc.clip.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAudio(string name)
    {
        int i = 0;
        while (clipList[i].name != name && i < clipList.Count -1)
        {
            i++;
            Debug.Log(i);
        }

        if(i < clipList.Count)
        {
            mySrc.clip = clipList[i];
            mySrc.Play();

        }
        //return i != clipList.Count;
    }

    public void PlayOrders(List<string> list)
    {
        StartCoroutine("playQueue",list);
    }
    public IEnumerator playQueue(List<string> list)
    {
        foreach(string s in list)
        {
            SetAudio(s);
            mySrc.Play();
            yield return new WaitForSeconds(mySrc.clip.length + timeBetween);
        }
    }
}
