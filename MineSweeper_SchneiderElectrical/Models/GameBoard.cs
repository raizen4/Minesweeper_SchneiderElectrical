namespace Minesweeper_SchneiderElectrical.Models;

public class GameBoard
{
    private GameBoardCell[,] _cells;

    public GameBoard(int size)
    {
        _cells = new GameBoardCell[size, size];
    }

    public void SetCell(int row, int column, GameBoardCell cell)
    {
        _cells[row, column] = cell;
    }

    public GameBoardCell GetCell(int row, int column)
    {
        return _cells[row, column];
    }
}