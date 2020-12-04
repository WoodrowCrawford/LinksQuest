# Math for games

## Game name: Link's Quest
### How to play: 
- Use the WASD keys to move around the map and try not to get caught by the Octoroks. The game is not be won at the moment.

## Classes
- Player: This is the main class that the player uses. The sprite for this class is Link.
    - #### Variables in Player:
      - Speed: Makes the player movement speed increase or decrease.
      - Sprite: This makes the player icon to be any downloaded sprite.
     - #### Functions in player:
      - public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White): This is the default function that makes a player.
      - public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White): This is the overloaded fuction of a player.
      - public override void Update(float deltaTime) :This is used to always get the WASD input commands




