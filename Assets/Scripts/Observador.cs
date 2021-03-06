﻿/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Componente parte de la estructura de mensajes
   El Observador es capaz de recibir mensajes del emisor
*/

namespace UCM.IAV.Movimiento
{
    using UnityEngine;

    public class Observador : MonoBehaviour
    {
        // Hay dos tipos de observadores en la práctica: el perro y las ratas

        public void RecibirMensaje(MENSAJE_ID id)
        {
            if (id == MENSAJE_ID.TOCAR_FLAUTA)
            {
                if (gameObject.CompareTag("Perro"))
                {
                    GetComponent<Huir>().enabled = true;
                    GetComponent<Seguir>().enabled = false;
                }
                else
                {
                    GetComponent<Seguir>().enabled = true;
                    GetComponent<EvasionColisiones>().enabled = true;
                    GetComponent<EvasionObstaculos>().enabled = true;
                    GetComponent<Separacion>().enabled = true;
                    GetComponent<Flocking>().enabled = true;
                    GetComponent<Idle>().enabled = false;
                }
            }
            else if (id == MENSAJE_ID.NO_TOCAR_FLAUTA)
            {
                if (gameObject.CompareTag("Perro"))
                {
                    GetComponent<Huir>().enabled = false;
                    GetComponent<Seguir>().enabled = true;
                }
                else
                {
                    GetComponent<Seguir>().enabled = false;
                    GetComponent<EvasionColisiones>().enabled = false;
                    GetComponent<EvasionObstaculos>().enabled = false;
                    GetComponent<Separacion>().enabled = false;
                    GetComponent<Flocking>().enabled = false;
                    GetComponent<Idle>().enabled = true;
                }
            }
        }
    }
}