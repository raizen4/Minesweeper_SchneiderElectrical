using MineSweeper_SchneiderElectrical.Services;
using Xunit;

namespace UnitTests.Services;

public class GameBoardServiceTests
{
    [Fact]
    public void GenerateBoard_ShouldCreateBoardWithCorrectSize()
    {
        // Arrange
        int boardSize = 5;
        var gameBoardService = new GameBoardService();

        // Act
        var gameBoard = gameBoardService.GenerateBoard(boardSize);

        // Assert
        Assert.NotNull(gameBoard);
        Assert.Equal(boardSize, gameBoard.Size);
    }

    [Fact]
    public void GenerateBoard_ShouldPopulateBoardWithMinesCorrectlyBasedOnSize()
    {
        // Arrange
        int boardSize = 5;
        var gameBoardService = new GameBoardService();

        // Act
        var gameBoard = gameBoardService.GenerateBoard(boardSize);

        // Assert
        bool hasMines = false;
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                var cell = gameBoard.GetCell(i, j);
                if (cell.IsMine)
                {
                    hasMines = true;
                    break;
                }
            }
        }

        Assert.True(hasMines, "Board should have at least one mine");
    }

    [Theory]
    [InlineData(0, 0, 4, 4)]
    [InlineData(0, 4, 4, 0)]
    [InlineData(4, 0, 0, 4)]
    [InlineData(4, 4, 0, 0)]
    public void GetGoalPosition_ShouldReturnCorrectGoalPosition(int startRow, int startCol, int expectedGoalRow, int expectedGoalCol)
    {
        // Arrange
        int boardSize = 5;
        var gameBoardService = new GameBoardService();
        var startPosition = (startRow, startCol);

        // Act
        var goalPosition = gameBoardService.GetGoalPosition(boardSize, startPosition);

        // Assert
        Assert.Equal((expectedGoalRow, expectedGoalCol), goalPosition);
    }

    [Theory]
    [InlineData(5, 0, 0, true)]
    [InlineData(5, 4, 4, true)]
    [InlineData(5, -1, 0, false)]
    [InlineData(5, 0, 5, false)]
    [InlineData(5, null, null, false)]
    public void IsPlayerMoveOnTheGameBoardValid_ShouldReturnCorrectResult(int boardSize, int? row, int? col, bool expected)
    {
        // Arrange
        var gameBoardService = new GameBoardService();
        (int, int)? currentPlayerPosition = row.HasValue && col.HasValue ? (row.Value, col.Value) : null;

        // Act
        var result = gameBoardService.IsPlayerMoveOnTheGameBoardValid(boardSize, currentPlayerPosition);

        // Assert
        Assert.Equal(expected, result);
    }
}