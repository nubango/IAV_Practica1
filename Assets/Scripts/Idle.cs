/*    
   Copyright MI FLEQUILLO
*/
namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Idle : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        /// 

        float slowRadius = 3;
        float targetRadius = 1;
        float timeToTarget = 0.1f;

        private float currentTime;
        private float targetTime;

        bool inTarget = false;

        private void Start()
        {
            inTarget = true;
        }

        public override Direccion GetDireccion()
        {
            float targetSpeed;
            UnityEngine.Vector3 targetVelocity;

            Direccion result = new Direccion();
            UnityEngine.Bounds suelo = UnityEngine.GameObject.Find("Suelo").GetComponent<UnityEngine.MeshFilter>().mesh.bounds;
            UnityEngine.Vector3 target = UnityEngine.Vector3.zero;
            if (inTarget && currentTime > targetTime)
            {
                target = new UnityEngine.Vector3(UnityEngine.Random.Range(0, suelo.size.x), UnityEngine.Random.Range(0, suelo.size.y), 0);
                inTarget = false;
            }
            
            UnityEngine.Vector3 direction = ( target - transform.position);

            if (direction.magnitude < targetRadius)
            {
                result.lineal = UnityEngine.Vector3.zero;
                result.angular = 0;
                if (!inTarget)
                {
                    inTarget = true;
                    currentTime = UnityEngine.Time.time * 1000;
                    targetTime = currentTime + UnityEngine.Random.Range(1000, 5000);
                }
                else currentTime = UnityEngine.Time.time * 1000;
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
