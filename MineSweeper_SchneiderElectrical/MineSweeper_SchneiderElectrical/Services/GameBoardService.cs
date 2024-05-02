using MineSweeper_SchneiderElectrical.Interfaces;
using MineSweeper_SchneiderElectrical.Models;

namespace MineSweeper_SchneiderElectrical.Services;

public class GameBoardService : IGameBoardService
{
    private GameBoard _gameBoard;
    
    public GameBoard GenerateBoard(int size)
    {
        _gameBoard = new GameBoard(size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var cell = new GameBoardCell();
                if (Random.Shared.Next(0, 2) == 1)
                {
                    cell.IsMine = true;
                }

                _gameBoard.SetCell(i, j, cell);
            }
        }

        return _gameBoard;
    }
    
    public (int, int) GetGoalPosition(int size, (int, int) startPosition)
    {
        if (startPosition == (0, 0))
            return (size - 1, size - 1);

        if (startPosition == (0, size - 1))
            return (size - 1, 0);

        if (startPosition == (size - 1, 0))
            return (0, size - 1);

        return (0, 0);
    }

    public bool IsPlayerMoveOnTheGameBoardValid(int size, (int, int)? currentPlayerPosition)
    {
        if (currentPlayerPosition == null)
        {
            return false;
        }
        
        var row = currentPlayerPosition.Value.Item1;
        var column = currentPlayerPosition.Value.Item2;

        return !((row < 0 || row >= size) || (column < 0 || column >= size));
    }
    
    public GameBoardCell GetGameBoardCell(int row, int column)
    {
        return _gameBoard.GetCell(row, column);
    }
}