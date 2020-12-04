using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    //The background the actors will be in
    class Room : Actor
    {
        private Sprite _sprite;

        //Default function for the room class
        public Room(float x, float y, char icon)
            : base(x, y, icon)
        {
            _sprite = new Sprite("Images/Map.png");
        }

        //Draws the sprite to the screen
        public override void Draw()
        {
            _sprite.Draw(_globalTransform);

            base.Draw();
        }
    }
}

