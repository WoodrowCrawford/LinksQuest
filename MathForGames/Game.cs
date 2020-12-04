using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;


        /// Used to set the value of game over.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }



        /// Returns the scene at the index given.
        /// Returns an empty scene if the index is out of bounds
        public static Scene GetScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return new Scene();

            return _scenes[index];
        }



        /// Returns the scene that is at the index of the current scene index
        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }


        /// Adds the given scene to the array of scenes.
        /// <returns>The index the scene was placed at. Returns -1 if
        /// the scene is null</returns>
        public static int AddScene(Scene scene)
        {
            //If the scene is null then return before running any other logic
            if (scene == null)
                return -1;

            //Create a new temporary array that one size larger than the original
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy values from old array into new array
            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //Store the current index
            int index = _scenes.Length;

            //Sets the scene at the new index to be the scene passed in
            tempArray[index] = scene;

            //Set the old array to the tmeporary array
            _scenes = tempArray;

            return index;
        }

        /// <summary>
        /// Finds the instance of the scene given that inside of the array
        /// and removes it
        /// </summary>
        /// <param name="scene">The scene that will be removed</param>
        /// <returns>If the scene was successfully removed</returns>
        public static bool RemoveScene(Scene scene)
        {
            //If the scene is null then return before running any other logic
            if (scene == null)
                return false;

            bool sceneRemoved = false;

            //Create a new temporary array that is one less than our original array
            Scene[] tempArray = new Scene[_scenes.Length - 1];

            //Copy all scenes except the scene we don't want into the new array
            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            //If the scene was successfully removed set the old array to be the new array
            if(sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }



        /// Sets the current scene in the game to be the scene at the given index
        public static void SetCurrentScene(int index)
        {
            //If the index is not within the range of the the array return
            if (index < 0 || index >= _scenes.Length)
                return;

            //Call end for the previous scene before changing to the new one
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            //Update the current scene index
            _currentSceneIndex = index;
        }



        /// Returns true while a key is being pressed
        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }


        /// Returns true while if key was pressed once
        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1024, 760, "Link's Quest");
            Raylib.SetTargetFPS(60);

            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Link's Quest";

            //Create a new scene for our actors to exist in
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();


            //This is the background for the game
            Room room = new Room(16, 13, '^');
            scene1.AddActor(room);
            room.SetScale(33, 33);

            //Create the actors to add to our scene

            Enemy octorok1 = new Enemy(8, 5, Color.GREEN, new Vector2(9,5), new Vector2(14, 7), '■');
            Enemy octorok2 = new Enemy(19, 5, Color.GREEN, new Vector2(19, 5), new Vector2(23, 5), '■');
            Enemy octorok3 = new Enemy(19, 20, Color.GREEN, new Vector2(19, 20), new Vector2(19, 20), '■');
            Player player = new Player(0, 1,Color.BLUE, '#', ConsoleColor.Red);




            //Initialize the enmies starting values

            octorok1.Speed = 1;
            octorok1.Target = player;
            octorok1.SetScale(10, 10);

            octorok2.Speed = 1;
            octorok2.Target = player;
            octorok2.SetScale(10, 10);

            octorok3.Speed = 1;
            octorok3.Target = player;
            octorok3.SetScale(10, 10);


           

            //Set player's starting speed
            player.Speed = 5;
            //Sets the player size and rotation
            player.SetTranslate(new Vector2(10, 19));
            player.SetRotation(0);
            player.SetScale(2, 2);

            //Adds or removes children



            //Add actors to the scenes
            scene1.AddActor(player);
            scene1.AddActor(octorok1);
            scene1.AddActor(octorok2);
            scene1.AddActor(octorok3);

            
            //Sets the starting scene index and adds the scenes to the scenes array
            int startingSceneIndex = 0;
            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            //Sets the current scene to be the starting scene index
            SetCurrentScene(startingSceneIndex);
        }



        
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);

            
            
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLUE);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            //Call start for all objects in game
            Start();

            //Loops the game until either the game is set to be over or the window closes
            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                //Stores the current time between frames
                float deltaTime = Raylib.GetFrameTime();
                //Call update for all objects in game
                Update(deltaTime);
                //Call draw for all objects in game
                Draw();
                //Clear the input stream for the console window
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }
            End();

            
        }
    }
}
