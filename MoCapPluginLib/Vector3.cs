using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class Vector3
    {
        public static Vector3 FORWARD = new Vector3(0, 0, 1);
        public static Vector3 UP = new Vector3(0, 1, 0);
        public static Vector3 RIGHT = new Vector3(1, 0, 0);

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Vector3()
        {
            x = y = z = 0.0f;
        }

        public Vector3(float xx, float yy, float zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public float Length2()
        {
            return x * x + y * y + z * z;
        }

        public float Dot(Vector3 vector)
        {
            return x * vector.x + y * vector.y + z * vector.z;
        }

        public Vector3 Cross(Vector3 vector)
        {
            return new Vector3 { x = this.y * vector.z - this.z * vector.y, y = this.z * vector.x - this.x * vector.z, z = this.x * vector.y - this.y * vector.x };
        }

        public Vector3 Normalized()
        {
            float len2 = Length2();
            if (len2 == 0f || len2 == 1f)
                return new Vector3 { x = this.x, y = this.y, z = this.z };
            return this * (1f / (float)Math.Sqrt(len2));
        }

        public Vector3 Normalize()
        {
            float len2 = Length2();
            if (len2 == 0f || len2 == 1f)
                return this;
            Vector3 r = this * (1f / (float)Math.Sqrt(len2));
            this.x = r.x;
            this.y = r.y;
            this.z = r.z;
            return this;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { x = lhs.x + rhs.x, y = lhs.y + rhs.y, z = lhs.z + rhs.z };
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { x = lhs.x - rhs.x, y = lhs.y - rhs.y, z = lhs.z - rhs.z };
        }
        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { x = lhs.x * rhs.x, y = lhs.y * rhs.y, z = lhs.z * rhs.z };
        }
        public static Vector3 operator /(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { x = lhs.x / rhs.x, y = lhs.y / rhs.y, z = lhs.z / rhs.z };
        }

        public static Vector3 operator +(Vector3 lhs, float rhs)
        {
            return new Vector3 { x = lhs.x + rhs, y = lhs.y + rhs, z = lhs.z + rhs };
        }
        public static Vector3 operator -(Vector3 lhs, float rhs)
        {
            return new Vector3 { x = lhs.x - rhs, y = lhs.y - rhs, z = lhs.z - rhs };
        }
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3 { x = lhs.x * rhs, y = lhs.y * rhs, z = lhs.z * rhs };
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3 { x = lhs.x / rhs, y = lhs.y / rhs, z = lhs.z / rhs };
        }
    }
}
