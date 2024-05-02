using MineSweeper_SchneiderElectrical.Helpers;
using MineSweeper_SchneiderElectrical.Interfaces;
using MineSweeper_SchneiderElectrical.Models;

namespace MineSweeper_SchneiderElectrical.Services;

public class GameService : IGameService
{
    private readonly IPlayerService _playerService;
    private readonly IGameBoardService _gameBoardService;
    private Player _player;
    private (int, int) _goalPosition;

    public GameService(IPlayerService playerService, IGameBoardService gameBoardService)
    {
        _playerService = playerService;
        _gameBoardService = gameBoardService;
    }

     public void StartGame(int boardSize)
    {
        var startPosition = AskPlayerStartPosition(boardSize);
        _gameBoardService.GenerateBoard(boardSize);
        _goalPosition = _gameBoardService.GetGoalPosition(boardSize, startPosition);
        
        _player = _playerService.CreatePlayer(3, startPosition);

        while (_player is { Lives: > 0, HasReachedGoal: false })
        {
            Console.WriteLine($"Current Position: {_player.Position}, Lives: {_player.Lives}, Moves: {_player.Moves}");
            Console.Write("Enter move (up, down, left, right): ");
            var move = Console.ReadLine();
            if (move == null)
            {
                break;
            }
            var attemptedNewPosition = DirectionHelper.DirectionToPositionConverter(move, _player.Position);
            
            if (_gameBoardService.IsPlayerMoveOnTheGameBoardValid(boardSize, attemptedNewPosition))
            {
                var newPosition = _player.MakeMove(move);
                var currentCell = _gameBoardService.GetGameBoardCell(newPosition.Item1, newPosition.Item2);
                if (currentCell.IsMine)
                {
                    _player.Lives--;
                    Console.WriteLine("You hit a mine. You lose a life.");
                }
                else if (newPosition == _goalPosition)
                {
                    _player.HasReachedGoal = true;
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Player is out of bounds.");
            }
            DrawGameBoard(boardSize);
        }

        Console.WriteLine(_player.HasReachedGoal
            ? $"Congratulations! You reached the goal in {_player.Moves} moves. Your total score is {_player.Moves}"
            : "Game Over! You ran out of lives.");
    }

    public (int, int) AskPlayerStartPosition(int boardSize)
    {
        int startPositionChoice;
        Console.Write("Choose starting position (1: top-left, 2: top-right, 3: bottom-left, 4: bottom-right): ");
        startPositionChoice = int.Parse(Console.ReadLine());
        (int, int) startPosition = startPositionChoice switch
        {
            1 => (0, 0),
            2 => (0, boardSize - 1),
            3 => (boardSize - 1, 0),
            4 => (boardSize - 1, boardSize - 1),
            _ => throw new ArgumentException("Invalid starting position choice.")
        };
        return startPosition;
    }
    
    private void DrawGameBoard(int size)
    {
        Console.WriteLine("Game Board:");
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (_player.Position == (row, col))
                {
                    Console.Write("P ");
                }
                else if (_goalPosition == (row, col))
                {
                    Console.Write("G ");
                }
                else
                {
                    Console.Write("X ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Lives: {_player.Lives}, Moves: {_player.Moves}");
        Console.WriteLine();
    }
}