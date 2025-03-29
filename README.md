# Maze of Mysteries: a collocated collaboration game for children 
Developed as a group project for a bachelor's thesis at Gothenburg/Chalmers University, **Maze of Mysteries** is a collaboration game designed for children. The game belongs to the 4-in-1 genre, where players must work together to overcome challenges and clear the game. The focus is on fostering teamwork and problem-solving in a fun, interactive way.

<p align = "center">
<img src="images/gameplay.png" width="50%" />
<br>
Beginning of a game
</p>


## Development

- The game is developed using **Unity** and was specifically designed for **iPads**.
- **Mirror API** is used to handle the **networking** and synchronization between devices.

## How to Install

### Hardware Required

- **1 Mac (for building and deployment)**:
  - A Mac with macOS to build and deploy the game to iPads.
  - **Xcode** installed on the Mac for iOS development and deployment.
  - Must have **Unity** installed.

- **4 iPads (for players)**:
  - Each iPad needs a stable network connection.
  - The iPads cant be too old or it wont be able to install.
  
### How to Deploy the Game to iPads
Follow the guide on how to build an iOS application in Unity:  
[Build an iOS Application](https://docs.unity3d.com/Manual/iphone-BuildProcess.html?utm_source)

## Gameplay
- Currently only one well designed maze is available.

<p align = "center">
<img src="images/maze.png" width="75%" />
<br>
The maze
</p>

### Controls
- Players move with joysticks.

### Game Mechanics
- **Fog of War**: The maze is covered in fog, limiting visibility. Players can only see the area around themselves and their teammates.  
  
- **Blue Walls**: Certain paths are blocked by blue walls, requiring two players to pass. One player must stand on a designated blue spot to lower the wall, allowing the other to proceed.  
  
- **Turtles**: Enemies that chase players when they enter their line of sight.  

- **Diamonds & Victory Condition**:  
  - Players must collect all diamonds and bring them to a designated area to win.  
  - Carrying a diamond slows the player, making teamwork essential—others must distract the turtles.  
  - Turtles move faster than a player carrying a diamond, increasing the challenge.  

- **Player Health & Reviving**:  
  - If a player’s HP reaches 0, they become inactive and must be revived by another player standing on them.  
  - If all players’ HP reach 0, the game is over, and they lose.  



### Setup of game & iPads
1. Tap **"Play"** on the main menu.  
2. Select a lobby: **A** or **B**.  
3. Once all players have selected a lobby, solve the mini-setup puzzle to align the iPads into a square.  
4. The game starts when all players touch their iPad. 



### Known bugs
- **Bug**: Spontaneous death of players.
  - **Possible cause 1**: Turtles becoming invisible when transitioning between iPads. This may result in players being unexpectedly hit by invisible turtles. 
  - **Possible Cause 2**: Turtles may not be properly synchronized between all 4 iPads, leading to unexpected interactions or deaths when the turtles states are not updated correctly across all devices.


## Future work
- **Refine game start criteria**: Currently, the game starts when all iPads are touched, which can happen unintentionally.
- **Expand monster variety**: Introduce new types of monsters for more dynamic gameplay.
- **Add more mazes**: Include additional maze layouts to increase replayability.
- **Explore the possibility of generative maze layout**: Investigate implementing procedurally generated mazes for infinite variety in gameplay.
- **Introduce asymmetric abilities**: Explore unique abilities for each player to encourage diverse strategies.
- **Fix spontaneous death bug**: Address the issue of players dying unexpectedly, possibly related to turtle behavior.
- **Add more obstacles**: Introduce additional environmental challenges to enhance gameplay complexity.

## Gallery 

| **Description**                            | **Image**         |
|--------------------------------------------|-------------------|
| Game menu | <img src="images/start_screen.png" width="50%" />  |
| Puzzle for setup | <img src="images/puzzle.png" width="75%" />  |
| Wall obstacle requiring teamwork | <img src="images/wall_obst.png" width="25%" />  |
| Game over screens | <img src="images/game_over.png" width="100%" />     |
| The "Turtle" | <img src="images/turtle.png" width="50%" />     |
| Designated drop-off area & a diamond | <img src="images/designated_area.png" width="80%" />     |
| A player carrying a diamond| <img src="images/carry_dia.png" width="75%" />     |

