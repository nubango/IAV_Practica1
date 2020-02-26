namespace UCM.IAV.Movimiento
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class camFollow : MonoBehaviour
    {
        public GameObject personaje;
        private Vector3 posicionRelativa;
        // Start is called before the first frame update
        void Start()
        {
            posicionRelativa = transform.position - personaje.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LateUpdate()
        {
            transform.position = personaje.transform.position + posicionRelativa;
        }
    }
}
