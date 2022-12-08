using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    class NimMath
    {
        /// <summary>
        /// Linear interpolation
        /// the result gets clampet to 
        /// firstFloat: Min
        /// secondFloat: Max
        /// </summary>
        public static float Lerp(float firstFloat, float secondFloat, float by)
        {
            by /= 1000;
            float result = Clamp(firstFloat * (1 - by) + secondFloat * by, firstFloat, secondFloat);
            return result;
        }

        /// <summary>
        /// Linear interpolation
        /// the result is unclamped
        /// </summary>
        public static float LerpUnclamped(float firstFloat, float secondFloat, float by)
        {
            by /= 1000;
            return firstFloat * (1 - by) + secondFloat * by;
        }

        /// <summary>
        /// Clamps val
        /// </summary>
        public static float Clamp(float val, float min, float max)
        {
            if (val < min)
                return min;
            if (val > max)
                return max;

            return val;
        }
    }
}
