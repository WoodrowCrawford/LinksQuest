using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    class Matrix4
    {
        public float m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34;

        public Matrix4()
        {
            m11 = 1; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = 1; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = 0; m34 = 1;
        }

        public static Matrix4 CreateRotation(float radians)
        {
            return new Matrix4
                ((float)Math.Cos(radians), (float)Math.Sin(radians), 0,

                -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }

        public static Matrix4 CreateTranslation(Vector4 position)
        {
            return new Matrix4
               (
                0, 0, 0, position.X,
                0, 1, 0, position.Y,
                0, 0, 1
                );
        }

        public static Matrix4 CreateScale(Vector4 scale)
        {
            return new Matrix4
            (
                scale.X, 0, 0,
                0, scale.Y, 0,
                0, 0, 1
            );
        }


    }
}
