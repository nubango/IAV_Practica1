using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FluteSound : MonoBehaviour
{
    AudioSource audioData;

    public void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioData.Play(0);
            Debug.Log("started");
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            audioData.Pause();
        }
    }
}
