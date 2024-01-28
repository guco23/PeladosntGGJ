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
    void Awake()
    {
        mySrc = GetComponent<AudioSource>();
    }
  
    public void SetAudio(string name)
    {
        int i = 0;
        while (clipList[i].name != name && i < clipList.Count -1)
        {
            i++;
            //Debug.Log(i);
        }

        if(i < clipList.Count)
        {
            //print(i);
            mySrc.clip = clipList[i];
            mySrc.Play();

        }
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
