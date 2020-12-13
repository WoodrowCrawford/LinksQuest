using System;
using System.Security.Cryptography.X509Certificates;

namespace MathLibrary
{
    //Sets the variables
    public class Vector3
    {
        private float _x;
        private float _y;
        private float _z;

        //Sets the X value
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        //Sets the Y value
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _x = value;
            }
        }

        //Sets the Z value
        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        //Gets the magnitude for vector 3
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        //Returns a normalized verson of a vector
        public Vector3 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        //Sets the value for vector 3 to 0
        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        //Returns a normalized verson of vector 3
        public static Vector3 Normalize(Vector3 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector3();

            return (vector/vector.Magnitude);
        }

        //Returns the dot product of the two vectors given
        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        //Returns the cross product of the 2 vectors given
        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.Y * rhs.Z) - (lhs.Z * rhs.Y), (lhs.Z * rhs.X) - (lhs.X * rhs.Z), (lhs.X * rhs.Y) - (lhs.Y * rhs.X));
        }


        //Makes the addition operator for vector 3
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X += rhs.X, lhs.Y += rhs.Y, lhs.Z += rhs.Z);
        }


        //Makes the subtraction operator for vector 3
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }


        //Creates the multiplication operator for vector 3
        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar);
        }


        //Creates the multiplication operator for vector 3 with the scalar first
        public static Vector3 operator *(float scalar, Vector3 lhs)
        {
            return new Vector3(scalar * lhs.X, scalar * lhs.Y, scalar * lhs.Z);
        }

        //Creates the division operator for vector 3
        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar);
        }


    }
}
