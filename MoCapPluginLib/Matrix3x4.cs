using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class Matrix3x4
    {
        public float m00_;
        public float m01_;
        public float m02_;
        public float m03_;
        public float m10_;
        public float m11_;
        public float m12_;
        public float m13_;
        public float m20_;
        public float m21_;
        public float m22_;
        public float m23_;

        /// Construct an identity matrix.
        public Matrix3x4() {
            m00_ = 1.0f;
            m01_ = 0.0f;
            m02_ = 0.0f;
            m03_ = 0.0f;
            m10_ = 0.0f;
            m11_ = 1.0f;
            m12_ = 0.0f;
            m13_ = 0.0f;
            m20_ = 0.0f;
            m21_ = 0.0f;
            m22_ = 1.0f;
            m23_ = 0.0f;
        }

        /// Copy-construct from another matrix.
        public Matrix3x4(Matrix3x4 matrix) {
            m00_ = matrix.m00_;
            m01_ = matrix.m01_;
            m02_ = matrix.m02_;
            m03_ = matrix.m03_;
            m10_ = matrix.m10_;
            m11_ = matrix.m11_;
            m12_ = matrix.m12_;
            m13_ = matrix.m13_;
            m20_ = matrix.m20_;
            m21_ = matrix.m21_;
            m22_ = matrix.m22_;
            m23_ = matrix.m23_;
        }

        /// Copy-construct from a 3x3 matrix and set the extra elements to identity.
        public Matrix3x4(Matrix3 matrix) {
            m00_ = matrix.m00_;
            m01_ = matrix.m01_;
            m02_ = matrix.m02_;
            m03_ = 0.0f;
            m10_ = matrix.m10_;
            m11_ = matrix.m11_;
            m12_ = matrix.m12_;
            m13_ = 0.0f;
            m20_ = matrix.m20_;
            m21_ = matrix.m21_;
            m22_ = matrix.m22_;
            m23_ = 0.0f;
        }

        /// Copy-construct from a 4x4 matrix which is assumed to contain no projection.
        public Matrix3x4(Matrix4 matrix) {
            m00_ = matrix.m00_;
            m01_ = matrix.m01_;
            m02_ = matrix.m02_;
            m03_ = matrix.m03_;
            m10_ = matrix.m10_;
            m11_ = matrix.m11_;
            m12_ = matrix.m12_;
            m13_ = matrix.m13_;
            m20_ = matrix.m20_;
            m21_ = matrix.m21_;
            m22_ = matrix.m22_;
            m23_ = matrix.m23_;
        }

        // Construct from values.
        public Matrix3x4(float v00, float v01, float v02, float v03,
                  float v10, float v11, float v12, float v13,
                  float v20, float v21, float v22, float v23) {
            m00_ = v00;
            m01_ = v01;
            m02_ = v02;
            m03_ = v03;
            m10_ = v10;
            m11_ = v11;
            m12_ = v12;
            m13_ = v13;
            m20_ = v20;
            m21_ = v21;
            m22_ = v22;
            m23_ = v23;
        }

        /// Construct from a float array.
        public Matrix3x4(float[] data) {
            m00_ = data[0];
            m01_ = data[1];
            m02_ = data[2];
            m03_ = data[3];
            m10_ = data[4];
            m11_ = data[5];
            m12_ = data[6];
            m13_ = data[7];
            m20_ = data[8];
            m21_ = data[9];
            m22_ = data[10];
            m23_ = data[11];
        }

        /// Construct from translation, rotation and uniform scale.
        public Matrix3x4(Vector3 translation, Quaternion rotation, float scale)
        {

        }
        /// Construct from translation, rotation and nonuniform scale.
        public Matrix3x4(Vector3 translation, Quaternion rotation, Vector3 scale)
        {

        }

        /// Assign from another matrix.
        public Matrix3x4 Set(Matrix3x4 rhs)
        {
            m00_ = rhs.m00_;
            m01_ = rhs.m01_;
            m02_ = rhs.m02_;
            m03_ = rhs.m03_;
            m10_ = rhs.m10_;
            m11_ = rhs.m11_;
            m12_ = rhs.m12_;
            m13_ = rhs.m13_;
            m20_ = rhs.m20_;
            m21_ = rhs.m21_;
            m22_ = rhs.m22_;
            m23_ = rhs.m23_;
            return this;
        }

        /// Assign from a 3x3 matrix and set the extra elements to identity.
        public Matrix3x4 Set(Matrix3 rhs)
        {
            m00_ = rhs.m00_;
            m01_ = rhs.m01_;
            m02_ = rhs.m02_;
            m03_ = 0.0f;
            m10_ = rhs.m10_;
            m11_ = rhs.m11_;
            m12_ = rhs.m12_;
            m13_ = 0.0f;
            m20_ = rhs.m20_;
            m21_ = rhs.m21_;
            m22_ = rhs.m22_;
            m23_ = 0.0f;
            return this;
        }

        /// Assign from a 4x4 matrix which is assumed to contain no projection.
        //public Matrix3x4 Set(Matrix4 rhs)
        //{
        //    m00_ = rhs.m00_;
        //    m01_ = rhs.m01_;
        //    m02_ = rhs.m02_;
        //    m03_ = rhs.m03_;
        //    m10_ = rhs.m10_;
        //    m11_ = rhs.m11_;
        //    m12_ = rhs.m12_;
        //    m13_ = rhs.m13_;
        //    m20_ = rhs.m20_;
        //    m21_ = rhs.m21_;
        //    m22_ = rhs.m22_;
        //    m23_ = rhs.m23_;
        //    return *this;
        //}

        /// Multiply a Vector3 which is assumed to represent position.
        public static Vector3 operator *(Matrix3x4 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs.m00_ * rhs.x + lhs.m01_ * rhs.y + lhs.m02_ * rhs.z + lhs.m03_),
                (lhs.m10_ * rhs.x + lhs.m11_ * rhs.y + lhs.m12_ * rhs.z + lhs.m13_),
                (lhs.m20_ * rhs.x + lhs.m21_ * rhs.y + lhs.m22_ * rhs.z + lhs.m23_)
            );
        }

        /// Add a matrix.
        public static Matrix3x4 operator +(Matrix3x4 lhs, Matrix3x4 rhs)
        {
            return new Matrix3x4(
                lhs.m00_ + rhs.m00_,
                lhs.m01_ + rhs.m01_,
                lhs.m02_ + rhs.m02_,
                lhs.m03_ + rhs.m03_,
                lhs.m10_ + rhs.m10_,
                lhs.m11_ + rhs.m11_,
                lhs.m12_ + rhs.m12_,
                lhs.m13_ + rhs.m13_,
                lhs.m20_ + rhs.m20_,
                lhs.m21_ + rhs.m21_,
                lhs.m22_ + rhs.m22_,
                lhs.m23_ + rhs.m23_
            );
        }

        /// Subtract a matrix.
        public static Matrix3x4 operator -(Matrix3x4 lhs, Matrix3x4 rhs)
        {
            return new Matrix3x4(
                lhs.m00_ - rhs.m00_,
                lhs.m01_ - rhs.m01_,
                lhs.m02_ - rhs.m02_,
                lhs.m03_ - rhs.m03_,
                lhs.m10_ - rhs.m10_,
                lhs.m11_ - rhs.m11_,
                lhs.m12_ - rhs.m12_,
                lhs.m13_ - rhs.m13_,
                lhs.m20_ - rhs.m20_,
                lhs.m21_ - rhs.m21_,
                lhs.m22_ - rhs.m22_,
                lhs.m23_ - rhs.m23_
            );
        }

        /// Multiply with a scalar.
        public static Matrix3x4 operator *(Matrix3x4 lhs, float rhs)
        {
            return new Matrix3x4(
                lhs.m00_ * rhs,
                lhs.m01_ * rhs,
                lhs.m02_ * rhs,
                lhs.m03_ * rhs,
                lhs.m10_ * rhs,
                lhs.m11_ * rhs,
                lhs.m12_ * rhs,
                lhs.m13_ * rhs,
                lhs.m20_ * rhs,
                lhs.m21_ * rhs,
                lhs.m22_ * rhs,
                lhs.m23_ * rhs
            );
        }

        /// Multiply a matrix.
        public static Matrix3x4 operator *(Matrix3x4 lhs, Matrix3x4 rhs)
        {
            return new Matrix3x4(
                lhs.m00_ * rhs.m00_ + lhs.m01_ * rhs.m10_ + lhs.m02_ * rhs.m20_,
                lhs.m00_ * rhs.m01_ + lhs.m01_ * rhs.m11_ + lhs.m02_ * rhs.m21_,
                lhs.m00_ * rhs.m02_ + lhs.m01_ * rhs.m12_ + lhs.m02_ * rhs.m22_,
                lhs.m00_ * rhs.m03_ + lhs.m01_ * rhs.m13_ + lhs.m02_ * rhs.m23_ + lhs.m03_,
                lhs.m10_ * rhs.m00_ + lhs.m11_ * rhs.m10_ + lhs.m12_ * rhs.m20_,
                lhs.m10_ * rhs.m01_ + lhs.m11_ * rhs.m11_ + lhs.m12_ * rhs.m21_,
                lhs.m10_ * rhs.m02_ + lhs.m11_ * rhs.m12_ + lhs.m12_ * rhs.m22_,
                lhs.m10_ * rhs.m03_ + lhs.m11_ * rhs.m13_ + lhs.m12_ * rhs.m23_ + lhs.m13_,
                lhs.m20_ * rhs.m00_ + lhs.m21_ * rhs.m10_ + lhs.m22_ * rhs.m20_,
                lhs.m20_ * rhs.m01_ + lhs.m21_ * rhs.m11_ + lhs.m22_ * rhs.m21_,
                lhs.m20_ * rhs.m02_ + lhs.m21_ * rhs.m12_ + lhs.m22_ * rhs.m22_,
                lhs.m20_ * rhs.m03_ + lhs.m21_ * rhs.m13_ + lhs.m22_ * rhs.m23_ + lhs.m23_
            );
        }

        /// Multiply a 4x4 matrix.
        public static Matrix4 operator *(Matrix3x4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                lhs.m00_ * rhs.m00_ + lhs.m01_ * rhs.m10_ + lhs.m02_ * rhs.m20_ + lhs.m03_ * rhs.m30_,
                lhs.m00_ * rhs.m01_ + lhs.m01_ * rhs.m11_ + lhs.m02_ * rhs.m21_ + lhs.m03_ * rhs.m31_,
                lhs.m00_ * rhs.m02_ + lhs.m01_ * rhs.m12_ + lhs.m02_ * rhs.m22_ + lhs.m03_ * rhs.m32_,
                lhs.m00_ * rhs.m03_ + lhs.m01_ * rhs.m13_ + lhs.m02_ * rhs.m23_ + lhs.m03_ * rhs.m33_,
                lhs.m10_ * rhs.m00_ + lhs.m11_ * rhs.m10_ + lhs.m12_ * rhs.m20_ + lhs.m13_ * rhs.m30_,
                lhs.m10_ * rhs.m01_ + lhs.m11_ * rhs.m11_ + lhs.m12_ * rhs.m21_ + lhs.m13_ * rhs.m31_,
                lhs.m10_ * rhs.m02_ + lhs.m11_ * rhs.m12_ + lhs.m12_ * rhs.m22_ + lhs.m13_ * rhs.m32_,
                lhs.m10_ * rhs.m03_ + lhs.m11_ * rhs.m13_ + lhs.m12_ * rhs.m23_ + lhs.m13_ * rhs.m33_,
                lhs.m20_ * rhs.m00_ + lhs.m21_ * rhs.m10_ + lhs.m22_ * rhs.m20_ + lhs.m23_ * rhs.m30_,
                lhs.m20_ * rhs.m01_ + lhs.m21_ * rhs.m11_ + lhs.m22_ * rhs.m21_ + lhs.m23_ * rhs.m31_,
                lhs.m20_ * rhs.m02_ + lhs.m21_ * rhs.m12_ + lhs.m22_ * rhs.m22_ + lhs.m23_ * rhs.m32_,
                lhs.m20_ * rhs.m03_ + lhs.m21_ * rhs.m13_ + lhs.m22_ * rhs.m23_ + lhs.m23_ * rhs.m33_,
                rhs.m30_,
                rhs.m31_,
                rhs.m32_,
                rhs.m33_
            );
        }

        /// Set translation elements.
        public void SetTranslation(Vector3 translation)
        {
            m03_ = translation.x;
            m13_ = translation.y;
            m23_ = translation.z;
        }

        /// Set rotation elements from a 3x3 matrix.
        public void SetRotation(Matrix3 rotation)
        {
            m00_ = rotation.m00_;
            m01_ = rotation.m01_;
            m02_ = rotation.m02_;
            m10_ = rotation.m10_;
            m11_ = rotation.m11_;
            m12_ = rotation.m12_;
            m20_ = rotation.m20_;
            m21_ = rotation.m21_;
            m22_ = rotation.m22_;
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

        /// Return the combined rotation and scaling matrix.
        public Matrix3 ToMatrix3()
        {
            return new Matrix3(
                m00_,
                m01_,
                m02_,
                m10_,
                m11_,
                m12_,
                m20_,
                m21_,
                m22_
            );
        }

        /// Convert to a 4x4 matrix by filling in an identity last row.
        public Matrix4 ToMatrix4()
        {
            return new Matrix4(
                m00_,
                m01_,
                m02_,
                m03_,
                m10_,
                m11_,
                m12_,
                m13_,
                m20_,
                m21_,
                m22_,
                m23_,
                0.0f,
                0.0f,
                0.0f,
                1.0f
            );
        }

        /// Return the rotation matrix with scaling removed.
        public Matrix3 RotationMatrix()
        {
            Vector3 invScale = new Vector3(
                1.0f / (float)Math.Sqrt(m00_ * m00_ + m10_ * m10_ + m20_ * m20_),
                1.0f / (float)Math.Sqrt(m01_ * m01_ + m11_ * m11_ + m21_ * m21_),
                1.0f / (float)Math.Sqrt(m02_ * m02_ + m12_ * m12_ + m22_ * m22_)
            );

            return ToMatrix3().Scaled(invScale);
        }

        /// Return the translation part.
        public Vector3 Translation()
        {
            return new Vector3(
                m03_,
                m13_,
                m23_
            );
        }

        /// Return the rotation part.
        public Quaternion Rotation() { return new Quaternion(RotationMatrix()); }

        /// Return the scaling part.
        public Vector3 Scale()
        {
            return new Vector3(
                (float)Math.Sqrt(m00_ * m00_ + m10_ * m10_ + m20_ * m20_),
                (float)Math.Sqrt(m01_ * m01_ + m11_ * m11_ + m21_ * m21_),
                (float)Math.Sqrt(m02_ * m02_ + m12_ * m12_ + m22_ * m22_)
            );
        }

        /// Test for equality with another matrix with epsilon.
        public bool Equals(Matrix3x4 rhs)
        {
            return true;
        }

        /// Return decomposition to translation, rotation and scale.
        public void Decompose(out Vector3 translation, out Quaternion rotation, out Vector3 scale)
        {
            translation = new Vector3();
            translation.x = m03_;
            translation.y = m13_;
            translation.z = m23_;

            scale = new Vector3();
            scale.x = (float)Math.Sqrt(m00_ * m00_ + m10_ * m10_ + m20_ * m20_);
            scale.y = (float)Math.Sqrt(m01_ * m01_ + m11_ * m11_ + m21_ * m21_);
            scale.z = (float)Math.Sqrt(m02_ * m02_ + m12_ * m12_ + m22_ * m22_);

            Vector3 invScale = new Vector3(1.0f / scale.x, 1.0f / scale.y, 1.0f / scale.z);
            rotation = new Quaternion(ToMatrix3().Scaled(invScale));
        }

        /// Return inverse.
        public Matrix3x4 Inverse()
        {
            float det = m00_ * m11_ * m22_ +
                m10_ * m21_ * m02_ +
                m20_ * m01_ * m12_ -
                m20_ * m11_ * m02_ -
                m10_ * m01_ * m22_ -
                m00_ * m21_ * m12_;

            float invDet = 1.0f / det;
            Matrix3x4 ret = new Matrix3x4();

            ret.m00_ = (m11_ * m22_ - m21_ * m12_) * invDet;
            ret.m01_ = -(m01_ * m22_ - m21_ * m02_) * invDet;
            ret.m02_ = (m01_ * m12_ - m11_ * m02_) * invDet;
            ret.m03_ = -(m03_ * ret.m00_ + m13_ * ret.m01_ + m23_ * ret.m02_);
            ret.m10_ = -(m10_ * m22_ - m20_ * m12_) * invDet;
            ret.m11_ = (m00_ * m22_ - m20_ * m02_) * invDet;
            ret.m12_ = -(m00_ * m12_ - m10_ * m02_) * invDet;
            ret.m13_ = -(m03_ * ret.m10_ + m13_ * ret.m11_ + m23_ * ret.m12_);
            ret.m20_ = (m10_ * m21_ - m20_ * m11_) * invDet;
            ret.m21_ = -(m00_ * m21_ - m20_ * m01_) * invDet;
            ret.m22_ = (m00_ * m11_ - m10_ * m01_) * invDet;
            ret.m23_ = -(m03_ * ret.m20_ + m13_ * ret.m21_ + m23_ * ret.m22_);

            return ret;
        }

        /// Return as string.
        public override String ToString()
        {
            return m00_ + " " + m01_ + " " + m02_ + " " + m03_ + "" +
            m10_ + " " + m11_ + " " + m12_ + " " + m13_ + "" +
            m20_ + " " + m21_ + " " + m22_ + " " + m23_;
        }
    }
}
