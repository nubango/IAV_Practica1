/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Script auxiliar que dado el input de barra espaciadora
   ejecuta un sonido de flauta
*/

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
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            audioData.Pause();
        }
    }
}
