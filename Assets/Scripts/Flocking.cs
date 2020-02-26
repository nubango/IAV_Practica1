/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonsalo Alba Durán
   Nuria Bango Iglesias
   Marcos Linares (?)
*/

namespace UCM.IAV.Movimiento
{
    using UnityEngine;
    public class Flocking : MonoBehaviour
    {

        private Flocking[] bandada;

        public void Start()
        {
            bandada = FindObjectsOfType<Flocking>();
        }

        public Flocking[] GetArrayOfObjects()
        {
            return bandada;
        }

        public Agente GetAgente() 
        {
            return gameObject.GetComponent<Agente>();
        }

    }
}
