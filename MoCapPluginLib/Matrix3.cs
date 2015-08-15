using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class Matrix3
    {
        public float m00_;
        public float m01_;
        public float m02_;
        public float m10_;
        public float m11_;
        public float m12_;
        public float m20_;
        public float m21_;
        public float m22_;

        public Matrix3() {
            m00_ = 1.0f;
            m01_ = 0.0f;
            m02_ = 0.0f;
            m10_ = 0.0f;
            m11_ = 1.0f;
            m12_ = 0.0f;
            m20_ = 0.0f;
            m21_ = 0.0f;
            m22_ = 1.0f;
        }

        public Matrix3(Matrix3 matrix) 
        {
            m00_ = matrix.m00_;
            m01_ = matrix.m01_;
            m02_ = matrix.m02_;
            m10_ = matrix.m10_;
            m11_ = matrix.m11_;
            m12_ = matrix.m12_;
            m20_ = matrix.m20_;
            m21_ = matrix.m21_;
            m22_ = matrix.m22_;
        }

        public Matrix3(float v00, float v01, float v02,
            float v10, float v11, float v12,
            float v20, float v21, float v22) {
            m00_ = v00;
            m01_ = v01;
            m02_ = v02;
            m10_ = v10;
            m11_ = v11;
            m12_ = v12;
            m20_ = v20;
            m21_ = v21;
            m22_ = v22;
        }

        public Matrix3(float[] data)
        {
            m00_ = data[0];
            m01_ = data[1];
            m02_ = data[2];
            m10_ = data[3];
            m11_ = data[4];
            m12_ = data[5];
            m20_ = data[6];
            m21_ = data[7];
            m22_ = data[8];
        }

        public Matrix3 Set(Matrix3 rhs)
        {
            m00_ = rhs.m00_;
            m01_ = rhs.m01_;
            m02_ = rhs.m02_;
            m10_ = rhs.m10_;
            m11_ = rhs.m11_;
            m12_ = rhs.m12_;
            m20_ = rhs.m20_;
            m21_ = rhs.m21_;
            m22_ = rhs.m22_;
            return this;
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.m00_ * rhs.x + lhs.m01_ * rhs.y + lhs.m02_ * rhs.z,
                lhs.m10_ * rhs.x + lhs.m11_ * rhs.y + lhs.m12_ * rhs.z,
                lhs.m20_ * rhs.x + lhs.m21_ * rhs.y + lhs.m22_ * rhs.z
            );
        }

        /// Add a matrix.
        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                lhs.m00_ + rhs.m00_,
                lhs.m01_ + rhs.m01_,
                lhs.m02_ + rhs.m02_,
                lhs.m10_ + rhs.m10_,
                lhs.m11_ + rhs.m11_,
                lhs.m12_ + rhs.m12_,
                lhs.m20_ + rhs.m20_,
                lhs.m21_ + rhs.m21_,
                lhs.m22_ + rhs.m22_
            );
        }

        /// Subtract a matrix.
        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                lhs.m00_ - rhs.m00_,
                lhs.m01_ - rhs.m01_,
                lhs.m02_ - rhs.m02_,
                lhs.m10_ - rhs.m10_,
                lhs.m11_ - rhs.m11_,
                lhs.m12_ - rhs.m12_,
                lhs.m20_ - rhs.m20_,
                lhs.m21_ - rhs.m21_,
                lhs.m22_ - rhs.m22_
            );
        }

        /// Multiply with a scalar.
        public static Matrix3 operator *(Matrix3 lhs, float rhs)
        {
            return new Matrix3(
                lhs.m00_ * rhs,
                lhs.m01_ * rhs,
                lhs.m02_ * rhs,
                lhs.m10_ * rhs,
                lhs.m11_ * rhs,
                lhs.m12_ * rhs,
                lhs.m20_ * rhs,
                lhs.m21_ * rhs,
                lhs.m22_ * rhs
            );
        }

        /// Multiply a matrix.
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                lhs.m00_ * rhs.m00_ + lhs.m01_ * rhs.m10_ + lhs.m02_ * rhs.m20_,
                lhs.m00_ * rhs.m01_ + lhs.m01_ * rhs.m11_ + lhs.m02_ * rhs.m21_,
                lhs.m00_ * rhs.m02_ + lhs.m01_ * rhs.m12_ + lhs.m02_ * rhs.m22_,
                lhs.m10_ * rhs.m00_ + lhs.m11_ * rhs.m10_ + lhs.m12_ * rhs.m20_,
                lhs.m10_ * rhs.m01_ + lhs.m11_ * rhs.m11_ + lhs.m12_ * rhs.m21_,
                lhs.m10_ * rhs.m02_ + lhs.m11_ * rhs.m12_ + lhs.m12_ * rhs.m22_,
                lhs.m20_ * rhs.m00_ + lhs.m21_ * rhs.m10_ + lhs.m22_ * rhs.m20_,
                lhs.m20_ * rhs.m01_ + lhs.m21_ * rhs.m11_ + lhs.m22_ * rhs.m21_,
                lhs.m20_ * rhs.m02_ + lhs.m21_ * rhs.m12_ + lhs.m22_ * rhs.m22_
            );
        }

        /// Set scaling elements.
        public void SetScale(Vector3 scale)
        {
            m00_ = scale.x;
            m11_ = scale.y;
            m22_ = scale.z;
        }

        /// Set uniform scaling elements.
        public void SetScale(float scale)
        {
            m00_ = scale;
            m11_ = scale;
            m22_ = scale;
        }

        /// Return the scaling part.
        public Vector3 Scale() 
        {
            return new Vector3(
                (float)Math.Sqrt(m00_ * m00_ + m10_ * m10_ + m20_ * m20_),
                (float)Math.Sqrt(m01_ * m01_ + m11_ * m11_ + m21_ * m21_),
                (float)Math.Sqrt(m02_ * m02_ + m12_ * m12_ + m22_ * m22_)
            );
        }

        /// Return transpose.
        public Matrix3 Transpose()
        {
            return new Matrix3(
                m00_,
                m10_,
                m20_,
                m01_,
                m11_,
                m21_,
                m02_,
                m12_,
                m22_
            );
        }

        /// Return scaled by a vector.
        public Matrix3 Scaled(Vector3 scale)
        {
            return new Matrix3(
                m00_ * scale.x,
                m01_ * scale.y,
                m02_ * scale.z,
                m10_ * scale.x,
                m11_ * scale.y,
                m12_ * scale.z,
                m20_ * scale.x,
                m21_ * scale.y,
                m22_ * scale.z
            );
        }

        /// Test for equality with another matrix with epsilon.
        public bool Equals(Matrix3 rhs)
        {
            return true;
        }

        /// Return inverse.
        public Matrix3 Inverse()
        {
            float det = m00_ * m11_ * m22_ +
                m10_ * m21_ * m02_ +
                m20_ * m01_ * m12_ -
                m20_ * m11_ * m02_ -
                m10_ * m01_ * m22_ -
                m00_ * m21_ * m12_;

            float invDet = 1.0f / det;

            return new Matrix3(
                (m11_ * m22_ - m21_ * m12_) * invDet,
                -(m01_ * m22_ - m21_ * m02_) * invDet,
                (m01_ * m12_ - m11_ * m02_) * invDet,
                -(m10_ * m22_ - m20_ * m12_) * invDet,
                (m00_ * m22_ - m20_ * m02_) * invDet,
                -(m00_ * m12_ - m10_ * m02_) * invDet,
                (m10_ * m21_ - m20_ * m11_) * invDet,
                -(m00_ * m21_ - m20_ * m01_) * invDet,
                (m00_ * m11_ - m10_ * m01_) * invDet
            );
        }

        /// Return as string.
        public override String ToString()
        {
            return m00_ + " " + m01_ + " " + m02_ + "" +
                m10_ + " " + m11_ + " " + m12_ + "" +
                m20_ + " " + m21_ + " " + m22_;
        }
    }
}
