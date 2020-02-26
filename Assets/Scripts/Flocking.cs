/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonsalo Alba Durán
   Nuria Bango Iglesias
   Marcos Linares (?)
*/

namespace UCM.IAV.Movimiento
{
    public class Flocking : ComportamientoAgente
    {

        private Flocking[] bandada;

        private void Start()
        {
            bandada = FindObjectsOfType<Flocking>();
        }

        public Flocking[] GetArrayOfObjects()
        {
            return bandada;
        }

        public Agente GetAgente() { return agente; }

    }
}
