using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public static class MathUtils
    {
        public static float FLOAT_ROUNDING_ERROR = 0.000001f; // 32 bits
	    public static float PI = 3.1415927f;
	    public static float PI2 = PI * 2;

	    public static float E = 2.7182818f;

	    public static float radFull = PI * 2;
	    public static float degFull = 360;

	    /** multiply by this to convert from radians to degrees */
	    public static float radiansToDegrees = 180f / PI;
	    public static float radDeg = radiansToDegrees;
	    /** multiply by this to convert from degrees to radians */
	    public static float degreesToRadians = PI / 180.0f;
        public static float degreesToRadians2 = PI / 360.0f;
	    public static float degRad = degreesToRadians;

        public static bool FloatEquals(float left, float right)
        {
            return left > right - FLOAT_ROUNDING_ERROR && left < right + FLOAT_ROUNDING_ERROR;
        }
    }
}
