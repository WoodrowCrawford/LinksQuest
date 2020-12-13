using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    //Sets the variables
    public class Vector4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _w;

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
                _y = value;
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

        //Sets the W value
        public float W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }

        //Returns the magnitude of vector 4
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
            }
        }

        //Returns a normalized version of the given vector
        public Vector4 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        //Sets all the variables to be 0 
        public Vector4()
        {
            _x = 0;
            _y = 0;
            _z = 0;
            _w = 0;
        }

        
        public Vector4(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        //Returns a normalized version of vector 4
        public static Vector4 Normalize(Vector4 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector4();

            return (vector/vector.Magnitude);
        }

        //Returns the dot product of the 2 vectors given
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z) + (lhs.W * rhs.W);
        }

        //Return the cross product of the 2 vectors given
        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.Y * rhs.Z) - (lhs.Z * rhs.Y), (lhs.Z * rhs.X) - (lhs.X * rhs.Z), (lhs.X * rhs.Y) - (lhs.Y * rhs.X), 0);
        }

        //Makes the addition operator for vector 4
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X += rhs.X, lhs.Y += rhs.Y, lhs.Z += rhs.Z, lhs.W += rhs.W);
        }

        //Makes the subtraction operator for vector 4
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        //Creates the multiplication operator for vector 4
        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.W * scalar);
        }

        //Creates the multiplication operator for vector 4 with the scalar first
        public static Vector4 operator *(float scalar, Vector4 lhs)
        {
            return new Vector4(scalar * lhs.X, scalar * lhs.Y, scalar * lhs.Z, scalar * lhs.W);
        }

        //Creates the division operator for vector 4
        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar, lhs.W / scalar);
        }
    }
}
