using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Sets any values of the Vector3
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            float newX = vector.x;
            float newY = vector.y;
            float newZ = vector.z;

            if (x.HasValue)
            {
                newX = x.Value;
            }
            else 
            {
                newX = vector.x;
            }

            if (y.HasValue)
            {
                newY = y.Value;
            }
            else 
            {
                newY = vector.y;
            }

            if (z.HasValue) 
            {
                newZ = z.Value;
            }
            else
            {
                newZ = vector.z;
            }

            return new Vector3(newX, newY, newZ);
        }

        /// <summary>
        /// Adds to any values of the Vector3
        /// </summary>
        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            float resultX = vector.x;
            float resultY = vector.y;
            float resultZ = vector.z;

            if (x.HasValue)
            {
                resultX += x.Value;
            }

            if (y.HasValue)
            {
                resultY += y.Value;
            }

            if (z.HasValue)
            {
                resultZ += z.Value;
            }

            return new Vector3(resultX, resultY, resultZ);
        }
    }
}