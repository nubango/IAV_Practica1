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
