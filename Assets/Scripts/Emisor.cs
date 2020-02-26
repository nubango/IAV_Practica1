namespace UCM.IAV.Movimiento
{

    using UnityEngine;
    public enum MENSAJE_ID { TOCAR_FLAUTA, NO_TOCAR_FLAUTA };
    public class Emisor : MonoBehaviour
    {
        public Observador[] observadores;

        // Start is called before the first frame update
        public void Start()
        {
            // cogemos todos los observadores de la escena
            observadores = Object.FindObjectsOfType<Observador>();
        }

        public void enviarMensaje(MENSAJE_ID id)
        {
            for (int i = 0; i < observadores.Length; i++)
            {
                observadores[i].recibirMensaje(id);
            }
        }

    }
}
