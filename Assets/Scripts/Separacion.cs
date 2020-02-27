/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonsalo Alba Durán
   Nuria Bango Iglesias
   Marcos Linares (?)
*/

namespace UCM.IAV.Movimiento
{
    public class Separacion : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>

        public float maxAcceleration;
        public float threshold;
        public float decayCoefficient;
        public Seguir f;

        public void Start()
        {
            f = GetComponent<Seguir>();
        }


        public override Direccion GetDireccion()
        {
            Direccion result = new Direccion();
            UnityEngine.Vector3 direction;

            if (f.getOnTarget())
                return result;

            foreach (Flocking target in FindObjectsOfType<Flocking>())
            {
                if (target != this)
                {
                    direction = -1 * (target.transform.position - transform.position);
                    float distance = direction.magnitude;

                    if (distance < threshold)
                    {
                        // strange of repulsion
                        float strength = UnityEngine.Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                        direction.Normalize();

                        result.lineal += strength * direction;
                    }
                }

            }
            //result.lineal.y = 0;
            return result;
        }
    }
}
