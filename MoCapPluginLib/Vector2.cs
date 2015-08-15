using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public float Angle(Vector2 rhs)
        {
            float angle = (float)Math.Atan2(y, x) * MathUtils.radiansToDegrees;
            if (angle < 0)
                angle += 360;
            return angle;
        }



        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }

        public float Length()
        {
            return (float)Math.Sqrt(Dot(this));
        }

        public float Length2()
        {
            return Dot(this);
        }

        public float Cross(Vector2 v)
        {
            return this.x * v.y - this.y * v.x;
        }

        public Vector2 Lerp(Vector2 target, float alpha)
        {
            float invAlpha = 1.0f - alpha;
            this.x = (x * invAlpha) + (target.x * alpha);
            this.y = (y * invAlpha) + (target.y * alpha);
            return this;
        }

        public Vector2 Normalized()
        {
            float len = Length();
            if (len != 0)
                return new Vector2 { x = this.x / len, y = this.y / len };
            return new Vector2 { x = this.x, y = this.y };
        }

        public Vector2 Normalize()
        {
            float len = Length();
            if (len != 0)
            {
                x /= len;
                y /= len;
            }
            return this;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { x = lhs.x + rhs.x, y = lhs.y + rhs.y };
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { x = lhs.x - rhs.x, y = lhs.y - rhs.y };
        }
        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { x = lhs.x * rhs.x, y = lhs.y * rhs.y };
        }
        public static Vector2 operator /(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { x = lhs.x / rhs.x, y = lhs.y / rhs.y };
        }

        public static Vector2 operator +(Vector2 lhs, float rhs)
        {
            return new Vector2 { x = lhs.x + rhs, y = lhs.y + rhs };
        }
        public static Vector2 operator -(Vector2 lhs, float rhs)
        {
            return new Vector2 { x = lhs.x - rhs, y = lhs.y - rhs };
        }
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2 { x = lhs.x * rhs, y = lhs.y * rhs };
        }
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2 { x = lhs.x / rhs, y = lhs.y / rhs };
        }

        public Vector2 Rotate(float degrees)
        {
            return RotateRad(degrees * MathUtils.degreesToRadians);
        }

        public Vector2 RotateRad(float radians)
        {
            float cos = (float)Math.Cos(radians);
            float sin = (float)Math.Sin(radians);

            float newX = this.x * cos - this.y * sin;
            float newY = this.x * sin + this.y * cos;

            this.x = newX;
            this.y = newY;

            return this;
        }
    }
}
