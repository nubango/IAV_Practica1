/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Comportamiento extra para la camara que sigue a un target
   En este caso será el avatar para poder seguirlo continuamente
*/

namespace UCM.IAV.Movimiento
{
    using UnityEngine;

    public class TargetCamera: MonoBehaviour
    {
        public GameObject target;
        private Vector3 posicionRelativa;

        public void Start()
        {
            posicionRelativa = transform.position - target.transform.position;
        }

        public void LateUpdate()
        {
            transform.position = target.transform.position + posicionRelativa;
        }
    }
}
