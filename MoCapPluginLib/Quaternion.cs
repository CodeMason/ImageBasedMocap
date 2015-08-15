using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class Quaternion
    {
        public static Quaternion IDENTITY = new Quaternion();

        /// W coordinate.
        public float w_;
        /// X coordinate.
        public float x_;
        /// Y coordinate.
        public float y_;
        /// Z coordinate.
        public float z_;

        /// Construct an identity quaternion.
        public Quaternion() {
            w_ = 1.0f;
            x_ = 0.0f;
            y_ = 0.0f;
            z_ = 0.0f;
        }

        /// Copy-construct from another quaternion.
        public Quaternion(Quaternion quat) {
            w_ = quat.w_;
            x_ = quat.x_;
            y_ = quat.y_;
            z_ = quat.z_;
        }

        /// Construct from values.
        public Quaternion(float w, float x, float y, float z) {
            w_ = w;
            x_ = x;
            y_ = y;
            z_ = z;
        }

        /// Construct from a float array.
        public Quaternion(float[] data) {
            w_ = data[0];
            x_ = data[1];
            y_ = data[2];
            z_ = data[3];
        }

        /// Construct from an angle (in degrees) and axis.
        public Quaternion(float angle, Vector3 axis)
        {
            FromAngleAxis(angle, axis);
        }

        /// Construct from an angle (in degrees, for Urho2D).
        public Quaternion(float angle)
        {
            FromAngleAxis(angle, Vector3.FORWARD);
        }

        /// Construct from Euler angles (in degrees.)
        public Quaternion(float x, float y, float z)
        {
            FromEulerAngles(x, y, z);
        }

        /// Construct from the rotation difference between two direction vectors.
        public Quaternion(Vector3 start, Vector3 end)
        {
            FromRotationTo(start, end);
        }

        /// Construct from orthonormal axes.
        public Quaternion(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
        {
            FromAxes(xAxis, yAxis, zAxis);
        }

        /// Construct from a rotation matrix.
        public Quaternion(Matrix3 matrix)
        {
            FromRotationMatrix(matrix);
        }

        /// Assign from another quaternion.
        public Quaternion Set(Quaternion rhs)
        {
            w_ = rhs.w_;
            x_ = rhs.x_;
            y_ = rhs.y_;
            z_ = rhs.z_;
            return this;
        }

        /// Add-assign a quaternion.
        public static Quaternion operator +(Quaternion lhs, Quaternion rhs)
        {
            Quaternion ret = new Quaternion(lhs);
            ret.w_ += rhs.w_;
            ret.x_ += rhs.x_;
            ret.y_ += rhs.y_;
            ret.z_ += rhs.z_;
            return ret;
        }

        /// Multiply-assign a scalar.
        public static Quaternion operator *(Quaternion lhs, float rhs)
        {
            Quaternion ret = new Quaternion(lhs);
            ret.w_ *= rhs;
            ret.x_ *= rhs;
            ret.y_ *= rhs;
            ret.z_ *= rhs;
            return lhs;
        }

        /// Return negation.
        public static Quaternion operator -(Quaternion lhs) { 
            return new Quaternion(-lhs.w_, -lhs.x_, -lhs.y_, -lhs.z_); 
        }

        /// Subtract a quaternion.
        public static Quaternion operator -(Quaternion lhs, Quaternion rhs) { 
            return new Quaternion(lhs.w_ - rhs.w_, lhs.x_ - rhs.x_, lhs.y_ - rhs.y_, lhs.z_ - rhs.z_); 
        }

        /// Multiply a quaternion.
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion(
                lhs.w_ * rhs.w_ - lhs.x_ * rhs.x_ - lhs.y_ * rhs.y_ - lhs.z_ * rhs.z_,
                lhs.w_ * rhs.x_ + lhs.x_ * rhs.w_ + lhs.y_ * rhs.z_ - lhs.z_ * rhs.y_,
                lhs.w_ * rhs.y_ + lhs.y_ * rhs.w_ + lhs.z_ * rhs.x_ - lhs.x_ * rhs.z_,
                lhs.w_ * rhs.z_ + lhs.z_ * rhs.w_ + lhs.x_ * rhs.y_ - lhs.y_ * rhs.x_
            );
        }

        /// Multiply a Vector3.
        public static Vector3 operator *(Quaternion lhs, Vector3 rhs)
        {
            Vector3 qVec = new Vector3(lhs.x_, lhs.y_, lhs.z_);
            Vector3 cross1 = qVec.Cross(rhs);
            Vector3 cross2 = qVec.Cross(cross1);

            return rhs + (cross1 * lhs.w_ + cross2) * 2.0f;
        }

        /// Define from an angle (in degrees) and axis.
        public void FromAngleAxis(float angle, Vector3 axis)
        {
            Vector3 normAxis = axis.Normalized();
            angle *= MathUtils.degreesToRadians2;
            float sinAngle = (float)Math.Sin(angle);
            float cosAngle = (float)Math.Cos(angle);

            w_ = cosAngle;
            x_ = normAxis.x * sinAngle;
            y_ = normAxis.y * sinAngle;
            z_ = normAxis.z * sinAngle;
        }
        /// Define from Euler angles (in degrees.)
        public void FromEulerAngles(float x, float y, float z)
        {
            // Order of rotations: Z first, then X, then Y (mimics typical FPS camera with gimbal lock at top/bottom)
            x *= MathUtils.degreesToRadians2;
            y *= MathUtils.degreesToRadians2;
            z *= MathUtils.degreesToRadians2;
            float sinX = (float)Math.Sin(x);
            float cosX = (float)Math.Cos(x);
            float sinY = (float)Math.Sin(y);
            float cosY = (float)Math.Cos(y);
            float sinZ = (float)Math.Sin(z);
            float cosZ = (float)Math.Cos(z);

            w_ = cosY * cosX * cosZ + sinY * sinX * sinZ;
            x_ = cosY * sinX * cosZ + sinY * cosX * sinZ;
            y_ = sinY * cosX * cosZ - cosY * sinX * sinZ;
            z_ = cosY * cosX * sinZ - sinY * sinX * cosZ;
        }
        /// Define from the rotation difference between two direction vectors.
        public void FromRotationTo(Vector3 start, Vector3 end)
        {
            Vector3 normStart = start.Normalized();
            Vector3 normEnd = end.Normalized();
            float d = normStart.Dot(normEnd);

            if (d > -1.0f + MathUtils.FLOAT_ROUNDING_ERROR)
            {
                Vector3 c = normStart.Cross(normEnd);
                float s = (float)Math.Sqrt((1.0f + d) * 2.0f);
                float invS = 1.0f / s;

                x_ = c.x * invS;
                y_ = c.y * invS;
                z_ = c.z * invS;
                w_ = 0.5f * s;
            }
            else
            {
                Vector3 axis = Vector3.RIGHT.Cross(normStart);
                if (axis.Length() < MathUtils.FLOAT_ROUNDING_ERROR)
                    axis = Vector3.UP.Cross(normStart);

                FromAngleAxis(180.0f, axis);
            }
        }
        /// Define from orthonormal axes.
        public void FromAxes(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
        {
            Matrix3 matrix = new Matrix3(
                xAxis.x, yAxis.x, zAxis.x,
                xAxis.y, yAxis.y, zAxis.y,
                xAxis.z, yAxis.z, zAxis.z
            );

            FromRotationMatrix(matrix);
        }
        /// Define from a rotation matrix.
        public void FromRotationMatrix(Matrix3 matrix)
        {
            float t = matrix.m00_ + matrix.m11_ + matrix.m22_;

            if (t > 0.0f)
            {
                float invS = 0.5f / (float)Math.Sqrt(1.0f + t);

                x_ = (matrix.m21_ - matrix.m12_) * invS;
                y_ = (matrix.m02_ - matrix.m20_) * invS;
                z_ = (matrix.m10_ - matrix.m01_) * invS;
                w_ = 0.25f / invS;
            }
            else
            {
                if (matrix.m00_ > matrix.m11_ && matrix.m00_ > matrix.m22_)
                {
                    float invS = 0.5f / (float)Math.Sqrt(1.0f + matrix.m00_ - matrix.m11_ - matrix.m22_);

                    x_ = 0.25f / invS;
                    y_ = (matrix.m01_ + matrix.m10_) * invS;
                    z_ = (matrix.m20_ + matrix.m02_) * invS;
                    w_ = (matrix.m21_ - matrix.m12_) * invS;
                }
                else if (matrix.m11_ > matrix.m22_)
                {
                    float invS = 0.5f / (float)Math.Sqrt(1.0f + matrix.m11_ - matrix.m00_ - matrix.m22_);

                    x_ = (matrix.m01_ + matrix.m10_) * invS;
                    y_ = 0.25f / invS;
                    z_ = (matrix.m12_ + matrix.m21_) * invS;
                    w_ = (matrix.m02_ - matrix.m20_) * invS;
                }
                else
                {
                    float invS = 0.5f / (float)Math.Sqrt(1.0f + matrix.m22_ - matrix.m00_ - matrix.m11_);

                    x_ = (matrix.m02_ + matrix.m20_) * invS;
                    y_ = (matrix.m12_ + matrix.m21_) * invS;
                    z_ = 0.25f / invS;
                    w_ = (matrix.m10_ - matrix.m01_) * invS;
                }
            }
        }
        /// Define from a direction to look in and an up direction. Return true if successful, or false if would result in a NaN, in which case the current value remains.
        public bool FromLookRotation(Vector3 direction, Vector3 upDirection)
        {
            Vector3 forward = direction.Normalized();
            Vector3 v = forward.Cross(upDirection).Normalized();
            Vector3 up = v.Cross(forward);
            Vector3 right = up.Cross(forward);

            Quaternion ret = new Quaternion();
            ret.FromAxes(right, up, forward);

            if (!ret.IsNaN())
            {
                this.Set(ret);
                return true;
            }
            else
                return false;
        }

        /// Normalize to unit length.
        public void Normalize()
        {
            float lenSquared = LengthSquared();
            if (!MathUtils.FloatEquals(lenSquared, 1.0f) && lenSquared > 0.0f)
            {
                float invLen = 1.0f / (float)Math.Sqrt(lenSquared);
                w_ *= invLen;
                x_ *= invLen;
                y_ *= invLen;
                z_ *= invLen;
            }
        }

        /// Return normalized to unit length.
        public Quaternion Normalized()
        {
            float lenSquared = LengthSquared();
            if (!MathUtils.FloatEquals(lenSquared, 1.0f) && lenSquared > 0.0f)
            {
                float invLen = 1.0f / (float)Math.Sqrt(lenSquared);
                return this * invLen;
            }
            else
                return this;
        }

        /// Return inverse.
        public Quaternion Inverse()
        {
            float lenSquared = LengthSquared();
            if (lenSquared == 1.0f)
                return Conjugate();
            else if (lenSquared >= MathUtils.FLOAT_ROUNDING_ERROR)
                return Conjugate() * (1.0f / lenSquared);
            else
                return IDENTITY;
        }

        /// Return squared length.
        public float LengthSquared() { return w_ * w_ + x_ * x_ + y_ * y_ + z_ * z_; }

        /// Calculate dot product.
        public float DotProduct(Quaternion rhs) { 
            return w_ * rhs.w_ + x_ * rhs.x_ + y_ * rhs.y_ + z_ * rhs.z_; 
        }

        /// Test for equality with another quaternion with epsilon.
        public bool Equals(Quaternion rhs)
        {
            return MathUtils.FloatEquals(w_, rhs.w_) && MathUtils.FloatEquals(x_, rhs.x_) && MathUtils.FloatEquals(y_, rhs.y_) && MathUtils.FloatEquals(z_, rhs.z_);
        }

        /// Return whether is NaN.
        public bool IsNaN() { 
            return w_ == float.NaN || x_ == float.NaN || y_ == float.NaN || z_ == float.NaN;
        }

        /// Return conjugate.
        public Quaternion Conjugate() { 
            return new Quaternion(w_, -x_, -y_, -z_); 
        }

        /// Return Euler angles in degrees.
        public Vector3 EulerAngles()
        {
            // Derivation from http://www.geometrictools.com/Documentation/EulerAngles.pdf
            // Order of rotations: Z first, then X, then Y
            float check = 2.0f * (-y_ * z_ + w_ * x_);

            if (check < -0.995f)
            {
                return new Vector3(
                    -90.0f,
                    0.0f,
                    (float)-Math.Atan2(2.0f * (x_ * z_ - w_ * y_), 1.0f - 2.0f * (y_ * y_ + z_ * z_)) * MathUtils.radiansToDegrees
                );
            }
            else if (check > 0.995f)
            {
                return new Vector3(
                    90.0f,
                    0.0f,
                    (float)Math.Atan2(2.0f * (x_ * z_ - w_ * y_), 1.0f - 2.0f * (y_ * y_ + z_ * z_)) * MathUtils.radiansToDegrees
                );
            }
            else
            {
                return new Vector3(
                    (float)Math.Asin(check) * MathUtils.radiansToDegrees,
                    (float)Math.Atan2(2.0f * (x_ * z_ + w_ * y_), 1.0f - 2.0f * (x_ * x_ + y_ * y_)) * MathUtils.radiansToDegrees,
                    (float)Math.Atan2(2.0f * (x_ * y_ + w_ * z_), 1.0f - 2.0f * (x_ * x_ + z_ * z_)) * MathUtils.radiansToDegrees
                );
            }
        }

        /// Return yaw angle in degrees.
        public float YawAngle()
        {
            return EulerAngles().y;
        }

        /// Return pitch angle in degrees.
        public float PitchAngle()
        {
            return EulerAngles().x;
        }
        /// Return roll angle in degrees.
        public float RollAngle()
        {
            return EulerAngles().z;
        }
        /// Return the rotation matrix that corresponds to this quaternion.
        public Matrix3 RotationMatrix()
        {
            return new Matrix3(
                1.0f - 2.0f * y_ * y_ - 2.0f * z_ * z_,
                2.0f * x_ * y_ - 2.0f * w_ * z_,
                2.0f * x_ * z_ + 2.0f * w_ * y_,
                2.0f * x_ * y_ + 2.0f * w_ * z_,
                1.0f - 2.0f * x_ * x_ - 2.0f * z_ * z_,
                2.0f * y_ * z_ - 2.0f * w_ * x_,
                2.0f * x_ * z_ - 2.0f * w_ * y_,
                2.0f * y_ * z_ + 2.0f * w_ * x_,
                1.0f - 2.0f * x_ * x_ - 2.0f * y_ * y_
            );
        }
        /// Spherical interpolation with another quaternion.
        public Quaternion Slerp(Quaternion rhs, float t)
        {
            float cosAngle = DotProduct(rhs);
            // Enable shortest path rotation
            if (cosAngle < 0.0f)
            {
                cosAngle = -cosAngle;
                rhs = -rhs;
            }

            float angle = (float)Math.Acos(cosAngle);
            float sinAngle = (float)Math.Sin(angle);
            float t1, t2;

            if (sinAngle > 0.001f)
            {
                float invSinAngle = 1.0f / sinAngle;
                t1 = (float)Math.Sin((1.0f - t) * angle) * invSinAngle;
                t2 = (float)Math.Sin(t * angle) * invSinAngle;
            }
            else
            {
                t1 = 1.0f - t;
                t2 = t;
            }

            return this * t1 + rhs * t2;
        }
        /// Normalized linear interpolation with another quaternion.
        public Quaternion Nlerp(Quaternion rhs, float t, bool shortestPath = false)
        {
            Quaternion result;
            float fCos = DotProduct(rhs);
            if (fCos < 0.0f && shortestPath)
                result = (this) + (((-rhs) - (this)) * t);
            else
                result = (this) + ((rhs - (this)) * t);
            result.Normalize();
            return result;
        }

        /// Return as string.
        public override string ToString()
        {
            return x_ + " " + y_ + " " + z_ + " " + w_;
        }
    }
}
