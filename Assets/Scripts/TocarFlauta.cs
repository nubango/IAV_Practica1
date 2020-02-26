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
            input();
        }

        private void input()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                emisor.enviarMensaje(MENSAJE_ID.TOCAR_FLAUTA);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                emisor.enviarMensaje(MENSAJE_ID.NO_TOCAR_FLAUTA);
            }

        }
    }
}