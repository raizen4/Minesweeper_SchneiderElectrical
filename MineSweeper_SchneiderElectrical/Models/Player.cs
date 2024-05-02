using MineSweeper_SchnaiderElectric.Helpers;

namespace MineSweeper_SchnaiderElectric.Models;

public class Player
{
    public int Lives { get; set; }
    public int Moves { get; private set; }
    public bool HasReachedGoal { get; set; }
    public (int, int) Position { get; private set; }

    public Player(int lives, (int, int) startPosition)
    {
        Lives = lives;
        Moves = 0;
        Position = startPosition;
        HasReachedGoal = false;
    }

    public (int, int) MakeMove(string direction)
    {
        var newPos = DirectionHelper.DirectionToPositionConverter(direction, Position);
        Position = ((int, int))newPos;
        Moves++;
        return Position;
    }
}