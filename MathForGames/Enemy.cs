using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
   //An enemy octorok
    class Enemy : Actor
    {
        private Actor _target;



        private Sprite _sprite;

        private Vector2 _patrolPointA;
        private Vector2 _patrolPointB;
        private Vector2 _currentPoint;
        private float _speed = 1;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Vector2 PatrolPointA
        {
            get
            {
                return _patrolPointA;
            }
            set
            {
                _patrolPointA = value;
            }
        }

        public Vector2 PatrolPointB
        {
            get
            {
                return _patrolPointB;
            }
            set
            {
                _patrolPointB = value;
            }
        }

       //Default function for enemy class
        public Enemy(float x, float y, Vector2 patrolPointA, Vector2 patrolPointB, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/Octorok.png");
            PatrolPointA = patrolPointA;
            PatrolPointB = patrolPointB;
            _currentPoint = PatrolPointA;
        }

       //Overloaded function of enemy class
        public Enemy(float x, float y, Color rayColor, Vector2 patrolPointA, Vector2 patrolPointB, char icon = ' ')
            : base(x, y, rayColor, icon)
        {

            _sprite = new Sprite("Images/Octorok.png");
            PatrolPointA = patrolPointA;
            PatrolPointB = patrolPointB;
            _currentPoint = PatrolPointA;
        }

        //Checks to see if the player is in sight
        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            //Checks if the target has a value before continuing
            if (Target == null)
                return true;

            //Find the vector representing the distance between the actor and its target
            Vector2 direction =Target.LocalPosition - LocalPosition;
            //Get the magnitude of the distance vector
            float distance = direction.Magnitude;
            //Use the inverse cosine to find the angle of the dot product in radians
            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));

            //Return true if the angle and distance are in range
            if (angle <= maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        /// <summary>
        /// Updates the current location the enemy is traveling to
        /// once its reached a patrol point.
        /// </summary>
        private void UpdatePatrolLocation()
        {
            //Calculate the distance between the current patrol point and the current position
            Vector2 direction = _currentPoint - LocalPosition;
            float distance = direction.Magnitude;

            //Switch to the new patrol point if the enemy is within distance of the current one
            if (_currentPoint == PatrolPointA && distance <= 1)
            {
                _currentPoint = PatrolPointB;
                Rotate(6);
            }
                
            
            else if (_currentPoint == PatrolPointB && distance <= 1)
            {
                _currentPoint = PatrolPointA;
                Rotate(6);
            }
                

            //Calcute new velocity to travel to the next waypoint
            direction = _currentPoint - LocalPosition;
            Velocity = direction.Normalized * Speed;
            
        }

        public override void Update(float deltaTime)
        {
            
            if(CheckTargetInSight(1.5f, 2))
            {

                Target.LocalPosition = new Vector2();
            }
            else
            {
                _rayColor = Color.BLUE;
            }
            
            UpdatePatrolLocation();
            
            base.Update(deltaTime);
        }
      

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
