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
        // lista de potenciales targets
        UnityEngine.GameObject[] kinematic;
        public float threshold;
        public float decayCoefficient;

        public override Direccion GetDireccion()
        {
            float targetSpeed;
            UnityEngine.Vector3 targetVelocity;

            Direccion result = new Direccion();

            foreach (UnityEngine.GameObject target in kinematic)
            {
                UnityEngine.Vector3 direction = target.transform.position - transform.position;
                float distance = direction.magnitude;

                if (distance < threshold)
                {
                    // strange of repulsion
                    float strength = UnityEngine.Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                    direction.Normalize();

                    result.lineal += strength * direction;
                }
            }
            
            return result;
        }
    }
}
