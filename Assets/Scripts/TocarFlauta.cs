namespace UCM.IAV.Movimiento
{

    using UnityEngine;
    public class TocarFlauta : PlayerBehavior
    {
        private Emisor emisor;
        void Start()
        {
            emisor = gameObject.GetComponent<Emisor>();
        }
        // Update is called once per frame
        void Update()
        {
            input();
        }

        private void input()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Tocando la flauta");
                emisor.enviarMensaje(MENSAJE_ID.TOCAR_FLAUTA);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("No tocando la flauta");
                emisor.enviarMensaje(MENSAJE_ID.NO_TOCAR_FLAUTA);
            }

        }
    }
}