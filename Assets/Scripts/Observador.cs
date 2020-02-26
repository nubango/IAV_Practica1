﻿namespace UCM.IAV.Movimiento
{

    using UnityEngine;

    public class Observador : MonoBehaviour
    {
        // Hay dos tipos de observadores en la práctica: el perro y las ratas

        public void recibirMensaje(MENSAJE_ID id)
        {
            if (id == MENSAJE_ID.TOCAR_FLAUTA)
            {
                Debug.Log("MENSAJE RECIBIDO DE TOCAR FLAUTA");
                if (gameObject.CompareTag("Perro"))
                {
                    GetComponent<Huir>().enabled = true;
                }
                else
                {

                }
            }
            else if (id == MENSAJE_ID.NO_TOCAR_FLAUTA)
            {
                Debug.Log("MENSAJE RECIBIDO DE NO TOCAR FLAUTA");
                if (gameObject.CompareTag("Perro"))
                {
                    GetComponent<Huir>().enabled = false;
                }
                else
                {

                }
            }
        }
    }
}