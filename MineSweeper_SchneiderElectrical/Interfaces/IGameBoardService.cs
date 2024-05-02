using MineSweeper_SchnaiderElectric.Models;

namespace MineSweeper_SchnaiderElectric.Interfaces;

public interface IGameBoardService
{
    GameBoard GenerateBoard(int size);
    GameBoardCell GetGameBoardCell(int row, int column);

    (int, int) GetGoalPosition(int size, (int, int) startPosition);
    
    bool IsPlayerMoveOnTheGameBoardValid(int size, (int, int)? playerAttemptedNewPosition);
}