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

        public float slowRadius = 3;
        public float targetRadius = 1;
        public float timeToTarget = 0.1f;

        private float currentTime;
        private float targetTime;

        bool inTarget = false;

        public UnityEngine.Bounds suelo;
        public UnityEngine.Vector3 target;
        public void Start()
        {
            inTarget = true;

            currentTime = UnityEngine.Time.time;
            targetTime = currentTime + UnityEngine.Random.Range(1, 5);

            suelo = UnityEngine.GameObject.Find("Suelo").GetComponent<UnityEngine.MeshFilter>().mesh.bounds;
                target = new UnityEngine.Vector3(UnityEngine.Random.Range(-suelo.size.x * 10, suelo.size.x * 10), 0, UnityEngine.Random.Range(-suelo.size.z * 10, suelo.size.z * 10));
        }

        public override Direccion GetDireccion()
        {
            float targetSpeed;
            UnityEngine.Vector3 targetVelocity;

            Direccion result = new Direccion();

            if (currentTime > targetTime)
            {
                target = new UnityEngine.Vector3(UnityEngine.Random.Range(-suelo.size.x * 10, suelo.size.x * 10), 0, UnityEngine.Random.Range(-suelo.size.z * 10, suelo.size.z * 10));
                inTarget = false;
                currentTime = UnityEngine.Time.time;
                targetTime = currentTime + UnityEngine.Random.Range(3, 7);
            }

            currentTime = UnityEngine.Time.time;

            UnityEngine.Vector3 direction = (target - transform.position);

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
