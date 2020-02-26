﻿/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonsalo Alba Durán
   Nuria Bango Iglesias
   Marcos Linares (?)
*/

namespace UCM.IAV.Movimiento
{
    public class EvasionColisiones : ComportamientoAgente
    {
        public float maxAcceleration;
        public float radius;

        public Direccion GetNewDireccion()
        {
            Direccion result = new Direccion();
            UnityEngine.Vector3 direction;

            

            Flocking firstTarget = null;

            float shortestTime = float.MaxValue;
            float firstMinSeparation = 0;
            float firstDistance = 0;
            float relativeSpeed;
            float timeToCollision;
            float distance;

            UnityEngine.Vector3 relativePos = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 relativeVel = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 firstRelativePos = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 firstRelativeVel = UnityEngine.Vector3.zero;

            foreach (Flocking target in gameObject.GetComponent<Flocking>().GetArrayOfObjects())
            {
                
                if (target != this)
                {
                    // TIME TO COLLISION
                    relativePos = (target.transform.position - transform.position);
                    relativeVel = target.GetAgente().velocidad - agente.velocidad;
                    relativeSpeed = relativeVel.magnitude;
                    timeToCollision = UnityEngine.Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);

                    //CHECK IF COLLISION
                    distance = relativePos.magnitude;
                    float minSeparation = distance - relativeSpeed * timeToCollision;
                    if (minSeparation < 2 * radius) return result; // If not collision, return previous result from class Separation

                    //CHECK IF SHORTEST
                    if(timeToCollision > 0 && timeToCollision < shortestTime)
                    {
                        shortestTime = timeToCollision;
                        firstTarget = target;
                        firstMinSeparation = minSeparation;
                        firstDistance = distance;
                        firstRelativePos = relativePos;
                        firstRelativeVel = relativeVel;
                    }
                }
            }

            //IF NO TARGET, EXIT
            if (!firstTarget) return result;

            //IF CURRENT OR FUTURE COLLISION, STEERING
            if(firstMinSeparation <= 0 || firstDistance < 2 * radius)
            {
                relativePos = firstTarget.transform.position - transform.position;
            }
            else
            {
                relativePos = firstRelativePos + (firstRelativeVel * shortestTime);
            }

            relativePos.Normalize();

            result.lineal = relativePos * maxAcceleration;
            result.angular = 0;

            return result;
        }


    }
}