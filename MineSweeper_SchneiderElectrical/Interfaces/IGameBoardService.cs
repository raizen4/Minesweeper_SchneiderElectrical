using Minesweeper_SchneiderElectrical.Models;

namespace Minesweeper_SchneiderElectrical.Interfaces;

public interface IGameBoardService
{
    GameBoard GenerateBoard(int size);
    GameBoardCell GetGameBoardCell(int row, int column);

    (int, int) GetGoalPosition(int size, (int, int) startPosition);
    
    bool IsPlayerMoveOnTheGameBoardValid(int size, (int, int)? playerAttemptedNewPosition);
}