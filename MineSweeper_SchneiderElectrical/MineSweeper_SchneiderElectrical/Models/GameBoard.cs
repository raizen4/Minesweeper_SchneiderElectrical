namespace MineSweeper_SchneiderElectrical.Models;

public class GameBoard
{
    private GameBoardCell[,] _cells;
    public int Size { get; set; }

    public GameBoard(int size)
    {
        Size = size;
        _cells = new GameBoardCell[Size, Size];
    }
    
    public GameBoard()
    {
        
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