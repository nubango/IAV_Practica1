/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Componente para el envio de mensajes sobre si se está
   pulsando la barra espaciadora o no, principal mecanica del
   jugador
*/

namespace UCM.IAV.Movimiento
{

    using UnityEngine;
    public class TocarFlauta : PlayerBehavior
    {
        private Emisor emisor;
        public void Start()
        {
            emisor = gameObject.GetComponent<Emisor>();
        }
        // Update is called once per frame
        public void Update()
        {
            FluteInput();
        }

        private void FluteInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                emisor.EnviarMensaje(MENSAJE_ID.TOCAR_FLAUTA);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                emisor.EnviarMensaje(MENSAJE_ID.NO_TOCAR_FLAUTA);
            }
        }
    }
}