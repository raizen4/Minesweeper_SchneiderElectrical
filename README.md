# Minesweeper_SchneiderElectrical
# Minesweeper Console Game
This is a simple implementation of the classic Minesweeper game in a console application using C# and .NET Core. The game allows the player to navigate a grid filled with hidden mines, trying to reach the other side of the board while avoiding the mines.

# Running the Game
To run the game, execute the following command:
dotnet run

This will start the game and prompt you to choose a starting position on the board.
Gameplay
When the game starts, you will be prompted to choose a starting position on the board (top-left, top-right, bottom-left, or bottom-right).
After selecting the starting position, the game will display the current board state, your position, the number of lives remaining, and the number of moves made.
You can move your character by entering the direction (up, down, left, right) when prompted.
If you move to a cell containing a mine, you will lose a life.
The goal is to reach the opposite corner of the board from your starting position while avoiding mines.
The game ends when you either reach the goal or run out of lives.

# Unit Tests
The project includes unit tests for the GameBoardService and GameService classes. To run the tests, execute the following command:
dotnet test

This will run all the unit tests and display the results in the console.

# Project Structure
The project follows the principles of SOLID design and uses dependency injection and inversion of control to manage dependencies. Here's a brief overview of the project structure:
- GameBoardService: Responsible for generating the game board, placing mines, and validating player moves on the board.
- PlayerService: Responsible for creating player's state.
- GameService: Handles the game logic, including player input, move validation, and game state updates.
- Player: Represents the player's state and provides methods for making moves.
- GameBoard: Represents the game board and provides methods for setting and getting cells.
- GameBoardCell: Represents a single cell on the game board and stores information about whether it contains a mine or not.
- DirectionHelper: A helper class for converting direction strings to position tuples.
