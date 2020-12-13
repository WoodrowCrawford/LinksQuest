using System;
using System.Security.Cryptography.X509Certificates;

namespace MathLibrary
{
    //Sets the variables
    public class Vector2
    {
        private float _x;
        private float _y;


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

        //Gets the magnitude for vector 2
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);

            }
        }

        //Returns a normalized version of vector 2
        public Vector2 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        
        //Sets the values for vector 2 to 0
        public Vector2()
        {
            _x = 0;
            _y = 0;
        }

        
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Returns the normalized version of a the vector passed in.
        /// </summary>
        /// <param name="vector">The vector that will be normalized</param>
        /// <returns></returns>
        public static Vector2 Normalize(Vector2 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector2();

            return (vector/vector.Magnitude);
        }

        /// <summary>
        /// Returns the dot product of the two vectors given.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        //Makes the addition operator for vector 2
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X += rhs.X, lhs.Y += rhs.Y);
        }

        //Makes the subtraction operator for vector 2
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        //Creates the multiplication operator for vector 2
        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X * scalar, lhs.Y * scalar);
        }

        //Creates the division operator for vector 2 
        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X / scalar, lhs.Y / scalar);
        }



    }
}
