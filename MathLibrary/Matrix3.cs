﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Matrix3
    {
        //This creates the variables for matrix 3
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;


        //This sets the variables for the matrix 3
        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }

        //Sets the rotation matrix for Matrix 3
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3
                ((float)Math.Cos(radians), (float)Math.Sin(radians), 0,

                -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }

        //Sets the translation matrix for matrix 3
        public static Matrix3 CreateTranslation(Vector2 position)
        {
            return new Matrix3
               (
                1, 0, position.X,
                0, 1, position.Y,
                0, 0, 1
                );
        }

        //Creates the scale for matrix 3 with the vector 2 scale
        public static Matrix3 CreateScale(Vector2 scale)
        {
            return new Matrix3
            (
                scale.X, 0, 0,
                0, scale.Y, 0,
                0, 0, 1
            );
        }
         
        //Creates the variables with this. floats
        public Matrix3(float m11, float m12, float m13,
                       float m21, float m22, float m23,
                       float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        //Creates the mulitplication operator for matrix 3
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
                (
                    lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,

                    lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,

                    lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,


                    lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,

                    lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,

                    lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,


                    lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,

                    lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,

                    lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33
                    );


        }

        //Creates the multiplication operator for matrix 3 with vector 3
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.m11 * rhs.X) + (lhs.m12 * rhs.Y) + (lhs.m13 * rhs.Z),
                               (lhs.m21 * rhs.X) + (lhs.m22 * rhs.Y) + (lhs.m23 * rhs.Z),
                               (lhs.m31 * rhs.X) + (lhs.m32 * rhs.Y) + (lhs.m33 * rhs.Z));
        }


        //Creates the addition operator for matrix 3
        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
            (lhs.m11 + rhs.m11 + lhs.m12 + rhs.m21 + lhs.m13 + rhs.m31,

                  lhs.m11 + rhs.m12 + lhs.m12 + rhs.m22 + lhs.m13 + rhs.m32,

                  lhs.m11 + rhs.m13 + lhs.m12 + rhs.m23 + lhs.m13 + rhs.m33,


                  lhs.m21 + rhs.m11 + lhs.m22 + rhs.m21 + lhs.m23 + rhs.m31,

                  lhs.m21 + rhs.m12 + lhs.m22 + rhs.m22 + lhs.m23 + rhs.m32,

                  lhs.m21 + rhs.m13 + lhs.m22 + rhs.m23 + lhs.m23 + rhs.m33,


                  lhs.m31 + rhs.m11 + lhs.m32 + rhs.m21 + lhs.m33 + rhs.m31,

                  lhs.m31 + rhs.m12 + lhs.m32 + rhs.m22 + lhs.m33 + rhs.m32,

                  lhs.m31 + rhs.m13 + lhs.m32 + rhs.m23 + lhs.m33 + rhs.m33
                  );
        }


        //Creates the subtraction operator for matrix 3
        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3
                   (lhs.m11 - rhs.m11 + lhs.m12 - rhs.m21 + lhs.m13 - rhs.m31,

                    lhs.m11 - rhs.m12 + lhs.m12 - rhs.m22 + lhs.m13 - rhs.m32,

                    lhs.m11 - rhs.m13 + lhs.m12 - rhs.m23 + lhs.m13 - rhs.m33,


                    lhs.m21 - rhs.m11 + lhs.m22 - rhs.m21 + lhs.m23 - rhs.m31,

                    lhs.m21 - rhs.m12 + lhs.m22 - rhs.m22 + lhs.m23 - rhs.m32,

                    lhs.m21 - rhs.m13 + lhs.m22 - rhs.m23 + lhs.m23 - rhs.m33,


                    lhs.m31 + rhs.m11 + lhs.m32 + rhs.m21 + lhs.m33 - rhs.m31,

                    lhs.m31 + rhs.m12 + lhs.m32 + rhs.m22 + lhs.m33 - rhs.m32,

                    lhs.m31 + rhs.m13 + lhs.m32 + rhs.m23 + lhs.m33 - rhs.m33);

        }








    }
}
