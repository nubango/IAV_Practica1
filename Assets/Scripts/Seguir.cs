/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Seguir : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        /// 

        public float slowRadius;
        public float targetRadius;
        public float timeToTarget;

        public override Direccion GetDireccion()
        {
            float targetSpeed;
            UnityEngine.Vector3 targetVelocity;

            Direccion result = new Direccion();
            UnityEngine.Vector3 direction = (objetivo.transform.position - transform.position);

            if (direction.magnitude < targetRadius)
            {
                result.lineal = UnityEngine.Vector3.zero;
                result.angular = 0;
                return result;
            }
            if (direction.magnitude < slowRadius)
            {
                targetSpeed = agente.velocidadMax * (direction.magnitude / slowRadius);
            }
            else targetSpeed = agente.velocidadMax;

            targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;


            //Acceleration to target velocity
            result.lineal = targetVelocity - agente.velocidad;
            result.lineal /= timeToTarget;

            //Check if accel. is over max
            if (result.lineal.magnitude > agente.aceleracionMax)
            {
                result.lineal.Normalize();
                result.lineal *= agente.aceleracionMax;
            }

            result.angular = 0;
            return result;
        }
    }
}
