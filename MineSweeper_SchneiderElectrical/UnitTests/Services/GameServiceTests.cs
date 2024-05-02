using MineSweeper_SchneiderElectrical.Interfaces;
using MineSweeper_SchneiderElectrical.Models;
using MineSweeper_SchneiderElectrical.Services;
using Moq;
using Xunit;

namespace UnitTests.Services;

public class GameServiceTests
{
    [Fact]
    public void StartGame_ShouldCreatePlayerAndGameBoard()
    {
        // Arrange
        int boardSize = 5;
        var goalPosition = (4, 4);
        var mockPlayerService = new Mock<IPlayerService>();
        var mockGameBoardService = new Mock<IGameBoardService>();
        var mockPlayer = new Mock<Player>();
        var mockGameBoard = new Mock<GameBoard>();

        mockPlayerService.Setup(ps => ps.CreatePlayer(It.IsAny<int>(), It.IsAny<(int, int)>()))
            .Returns(mockPlayer.Object);

        mockGameBoardService.Setup(gbs => gbs.GenerateBoard(It.IsAny<int>()))
            .Returns(mockGameBoard.Object);

        mockGameBoardService.Setup(gbs => gbs.GetGoalPosition(It.IsAny<int>(), It.IsAny<(int, int)>()))
            .Returns(goalPosition);

        var gameService = new GameService(mockPlayerService.Object, mockGameBoardService.Object);

        // Mock user input for starting position
        var inputString = "1";
        var inputStream = new MemoryStream();
        var writer = new StreamWriter(inputStream);
        writer.Write(inputString);
        writer.Flush();
        inputStream.Position = 0;
        Console.SetIn(new StreamReader(inputStream));

        // Act
        gameService.StartGame(boardSize);

        // Assert
        mockPlayerService.Verify(ps => ps.CreatePlayer(It.IsAny<int>(), It.IsAny<(int, int)>()), Times.Once);
        mockGameBoardService.Verify(gbs => gbs.GenerateBoard(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void StartGame_ShouldUpdatePlayerPositionAndLivesOnMineHit()
    {
        // Arrange
        int boardSize = 5;
        var startPosition = (0, 0);
        var goalPosition = (4, 4);
        var minePosition = (1, 0);
        var mockPlayerService = new Mock<IPlayerService>();
        var mockGameBoardService = new Mock<IGameBoardService>();
        var testPlayer = new Player(3, startPosition);
        var mockGameBoard = new Mock<GameBoard>();

        mockPlayerService.Setup(ps => ps.CreatePlayer(It.IsAny<int>(), It.IsAny<(int, int)>()))
            .Returns(testPlayer);

        mockGameBoardService.Setup(gbs => gbs.GenerateBoard(It.IsAny<int>()))
            .Returns(mockGameBoard.Object);

        mockGameBoardService.Setup(gbs => gbs.GetGoalPosition(It.IsAny<int>(), It.IsAny<(int, int)>()))
            .Returns(goalPosition);

        mockGameBoardService.Setup(gbs => gbs.IsPlayerMoveOnTheGameBoardValid(It.IsAny<int>(), It.IsAny<(int, int)?>()))
            .Returns(true);

        mockGameBoardService.Setup(gbs => gbs.GetGameBoardCell(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(new GameBoardCell { IsMine = true });

        var gameService = new GameService(mockPlayerService.Object, mockGameBoardService.Object);

        // Mock user input for starting position and move direction
        var inputString = "1\ndown";
        var inputStream = new MemoryStream();
        var writer = new StreamWriter(inputStream);
        writer.Write(inputString);
        writer.Flush();
        inputStream.Position = 0;
        Console.SetIn(new StreamReader(inputStream));

        // Act
        gameService.StartGame(boardSize);

        // Assert
        Assert.True(testPlayer.Lives == 2);
        Assert.True(testPlayer.Position == minePosition);
    }
    
    [Fact]
    public void StartGame_ShouldUpdatePlayerPositionOnValidMove()
    {
        // Arrange
        int boardSize = 5;
        var startPosition = (0, 0);
        var goalPosition = (4, 4);
        var finalPosition = (1, 1);
        var mockPlayerService = new Mock<IPlayerService>();
        var mockGameBoardService = new Mock<IGameBoardService>();
        var testPlayer = new Player(3, startPosition);
        var mockGameBoard = new Mock<GameBoard>();

        mockPlayerService.Setup(ps => ps.CreatePlayer(It.IsAny<int>(), It.IsAny<(int, int)>()))
            .Returns(testPlayer);

        mockGameBoardService.Setup(gbs => gbs.GenerateBoard(It.IsAny<int>()))
            .Returns(mockGameBoard.Object);

        mockGameBoardService.Setup(gbs => gbs.GetGoalPosition(It.IsAny<int>(), It.IsAny<(int, int)>()))
            .Returns(goalPosition);

        mockGameBoardService.Setup(gbs => gbs.IsPlayerMoveOnTheGameBoardValid(It.IsAny<int>(), It.IsAny<(int, int)?>()))
            .Returns(true);

        mockGameBoardService.Setup(gbs => gbs.GetGameBoardCell(0, 1))
            .Returns(new GameBoardCell { IsMine = false });
        mockGameBoardService.Setup(gbs => gbs.GetGameBoardCell(1, 1))
            .Returns(new GameBoardCell { IsMine = false });

        var gameService = new GameService(mockPlayerService.Object, mockGameBoardService.Object);

        // Mock user input for starting position and move direction
        var inputString = "1\nright\ndown";
        var inputStream = new MemoryStream();
        var writer = new StreamWriter(inputStream);
        writer.Write(inputString);
        writer.Flush();
        inputStream.Position = 0;
        Console.SetIn(new StreamReader(inputStream));

        // Act
        gameService.StartGame(boardSize);

        // Assert
        Assert.True(testPlayer.Lives == 3);
        Assert.True(testPlayer.Position == finalPosition);
    }
}
