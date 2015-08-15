using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class Matrix4
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
        public float m30_;
        public float m31_;
        public float m32_;
        public float m33_;

        /// Construct an identity matrix.
        public Matrix4() {
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
            m30_ = 0.0f;
            m31_ = 0.0f;
            m32_ = 0.0f;
            m33_ = 1.0f;
        }

        /// Copy-construct from another matrix.
        public Matrix4(Matrix4 matrix) {
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
            m30_ = matrix.m30_;
            m31_ = matrix.m31_;
            m32_ = matrix.m32_;
            m33_ = matrix.m33_;
        }

        /// Copy-cnstruct from a 3x3 matrix and set the extra elements to identity.
        public Matrix4(Matrix3 matrix) {
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
            m30_ = 0.0f;
            m31_ = 0.0f;
            m32_ = 0.0f;
            m33_ = 1.0f;
        }

        // Construct from values.
        public Matrix4(float v00, float v01, float v02, float v03,
                float v10, float v11, float v12, float v13,
                float v20, float v21, float v22, float v23,
                float v30, float v31, float v32, float v33) {
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
            m30_ = v30;
            m31_ = v31;
            m32_ = v32;
            m33_ = v33;
        }

        /// Construct from a float array.
        public Matrix4(float[] data) {
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
            m30_ = data[12];
            m31_ = data[13];
            m32_ = data[14];
            m33_ = data[15];
        }

        /// Assign from another matrix.
        public void Set(Matrix4 rhs)
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
            m30_ = rhs.m30_;
            m31_ = rhs.m31_;
            m32_ = rhs.m32_;
            m33_ = rhs.m33_;
        }

        /// Assign from a 3x3 matrix. Set the extra elements to identity.
        public void Set(Matrix3 rhs)
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
            m30_ = 0.0f;
            m31_ = 0.0f;
            m32_ = 0.0f;
            m33_ = 1.0f;
        }

        /// Multiply a Vector3 which is assumed to represent position.
        public static Vector3 operator *(Matrix4 lhs, Vector3 rhs)
        {
            float invW = 1.0f / (lhs.m30_ * rhs.x + lhs.m31_ * rhs.y + lhs.m32_ * rhs.z + lhs.m33_);

            return new Vector3(
                (lhs.m00_ * rhs.x + lhs.m01_ * rhs.y + lhs.m02_ * rhs.z + lhs.m03_) * invW,
                (lhs.m10_ * rhs.x + lhs.m11_ * rhs.y + lhs.m12_ * rhs.z + lhs.m13_) * invW,
                (lhs.m20_ * rhs.x + lhs.m21_ * rhs.y + lhs.m22_ * rhs.z + lhs.m23_) * invW
            );
        }

        /// Add a matrix.
        public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
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
                lhs.m23_ + rhs.m23_,
                lhs.m30_ + rhs.m30_,
                lhs.m31_ + rhs.m31_,
                lhs.m32_ + rhs.m32_,
                lhs.m33_ + rhs.m33_
            );
        }

        /// Subtract a matrix.
        public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
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
                lhs.m23_ - rhs.m23_,
                lhs.m30_ - rhs.m30_,
                lhs.m31_ - rhs.m31_,
                lhs.m32_ - rhs.m32_,
                lhs.m33_ - rhs.m33_
            );
        }

        /// Multiply with a scalar.
        public static Matrix4 operator *(Matrix4 lhs, float rhs)
        {
            return new Matrix4(
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
                lhs.m23_ * rhs,
                lhs.m30_ * rhs,
                lhs.m31_ * rhs,
                lhs.m32_ * rhs,
                lhs.m33_ * rhs
            );
        }

        /// Multiply a matrix.
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
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
                lhs.m30_ * rhs.m00_ + lhs.m31_ * rhs.m10_ + lhs.m32_ * rhs.m20_ + lhs.m33_ * rhs.m30_,
                lhs.m30_ * rhs.m01_ + lhs.m31_ * rhs.m11_ + lhs.m32_ * rhs.m21_ + lhs.m33_ * rhs.m31_,
                lhs.m30_ * rhs.m02_ + lhs.m31_ * rhs.m12_ + lhs.m32_ * rhs.m22_ + lhs.m33_ * rhs.m32_,
                lhs.m30_ * rhs.m03_ + lhs.m31_ * rhs.m13_ + lhs.m32_ * rhs.m23_ + lhs.m33_ * rhs.m33_
            );
        }

        /// Multiply with a 3x4 matrix.
        public static Matrix4 operator *(Matrix4 lhs, Matrix3x4 rhs)
        {
            return new Matrix4(
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
                lhs.m20_ * rhs.m03_ + lhs.m21_ * rhs.m13_ + lhs.m22_ * rhs.m23_ + lhs.m23_,
                lhs.m30_ * rhs.m00_ + lhs.m31_ * rhs.m10_ + lhs.m32_ * rhs.m20_,
                lhs.m30_ * rhs.m01_ + lhs.m31_ * rhs.m11_ + lhs.m32_ * rhs.m21_,
                lhs.m30_ * rhs.m02_ + lhs.m31_ * rhs.m12_ + lhs.m32_ * rhs.m22_,
                lhs.m30_ * rhs.m03_ + lhs.m31_ * rhs.m13_ + lhs.m32_ * rhs.m23_ + lhs.m33_
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

        // Set scaling elements.
        public void SetScale(Vector3 scale)
        {
            m00_ = scale.x;
            m11_ = scale.y;
            m22_ = scale.z;
        }

        // Set uniform scaling elements.
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

        /// Return the scaling part
        public Vector3 Scale() 
        {
            return new Vector3(
                (float)Math.Sqrt(m00_ * m00_ + m10_ * m10_ + m20_ * m20_),
                (float)Math.Sqrt(m01_ * m01_ + m11_ * m11_ + m21_ * m21_),
                (float)Math.Sqrt(m02_ * m02_ + m12_ * m12_ + m22_ * m22_)
            );
        }

        /// Return transpose
        public Matrix4 Transpose()
        {
            return new Matrix4(
                m00_,
                m10_,
                m20_,
                m30_,
                m01_,
                m11_,
                m21_,
                m31_,
                m02_,
                m12_,
                m22_,
                m32_,
                m03_,
                m13_,
                m23_,
                m33_
            );
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
        public Matrix4 Inverse()
        {
            float v0 = m20_ * m31_ - m21_ * m30_;
            float v1 = m20_ * m32_ - m22_ * m30_;
            float v2 = m20_ * m33_ - m23_ * m30_;
            float v3 = m21_ * m32_ - m22_ * m31_;
            float v4 = m21_ * m33_ - m23_ * m31_;
            float v5 = m22_ * m33_ - m23_ * m32_;

            float i00 = (v5 * m11_ - v4 * m12_ + v3 * m13_);
            float i10 = -(v5 * m10_ - v2 * m12_ + v1 * m13_);
            float i20 = (v4 * m10_ - v2 * m11_ + v0 * m13_);
            float i30 = -(v3 * m10_ - v1 * m11_ + v0 * m12_);

            float invDet = 1.0f / (i00 * m00_ + i10 * m01_ + i20 * m02_ + i30 * m03_);

            i00 *= invDet;
            i10 *= invDet;
            i20 *= invDet;
            i30 *= invDet;

            float i01 = -(v5 * m01_ - v4 * m02_ + v3 * m03_) * invDet;
            float i11 = (v5 * m00_ - v2 * m02_ + v1 * m03_) * invDet;
            float i21 = -(v4 * m00_ - v2 * m01_ + v0 * m03_) * invDet;
            float i31 = (v3 * m00_ - v1 * m01_ + v0 * m02_) * invDet;

            v0 = m10_ * m31_ - m11_ * m30_;
            v1 = m10_ * m32_ - m12_ * m30_;
            v2 = m10_ * m33_ - m13_ * m30_;
            v3 = m11_ * m32_ - m12_ * m31_;
            v4 = m11_ * m33_ - m13_ * m31_;
            v5 = m12_ * m33_ - m13_ * m32_;

            float i02 = (v5 * m01_ - v4 * m02_ + v3 * m03_) * invDet;
            float i12 = -(v5 * m00_ - v2 * m02_ + v1 * m03_) * invDet;
            float i22 = (v4 * m00_ - v2 * m01_ + v0 * m03_) * invDet;
            float i32 = -(v3 * m00_ - v1 * m01_ + v0 * m02_) * invDet;

            v0 = m21_ * m10_ - m20_ * m11_;
            v1 = m22_ * m10_ - m20_ * m12_;
            v2 = m23_ * m10_ - m20_ * m13_;
            v3 = m22_ * m11_ - m21_ * m12_;
            v4 = m23_ * m11_ - m21_ * m13_;
            v5 = m23_ * m12_ - m22_ * m13_;

            float i03 = -(v5 * m01_ - v4 * m02_ + v3 * m03_) * invDet;
            float i13 = (v5 * m00_ - v2 * m02_ + v1 * m03_) * invDet;
            float i23 = -(v4 * m00_ - v2 * m01_ + v0 * m03_) * invDet;
            float i33 = (v3 * m00_ - v1 * m01_ + v0 * m02_) * invDet;

            return new Matrix4(
                i00, i01, i02, i03,
                i10, i11, i12, i13,
                i20, i21, i22, i23,
                i30, i31, i32, i33);
        }

        /// Return as string.
        public override String ToString()
        {
            return  m00_ + " " + m01_ + " " + m02_ + " " + m03_ + "" +
                    m10_ + " " + m11_ + " " + m12_ + " " + m13_ + "" +
                    m20_ + " " + m21_ + " " + m22_ + " " + m23_ + "" +
                    m30_ + " " + m31_ + " " + m32_ + " " + m33_;
        }

        /// Zero matrix.
        //static const Matrix4 ZERO;
        /// Identity matrix.
        public static Matrix4 IDENTITY = new Matrix4();
        public static Matrix4 ZERO = new Matrix4(
            0.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 0.0f);
    }
}
