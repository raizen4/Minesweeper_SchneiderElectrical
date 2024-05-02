using MineSweeper_SchneiderElectrical.Helpers;

namespace MineSweeper_SchneiderElectrical.Models;

public class Player
{
    public int Lives { get; set; }
    public int Moves { get; private set; }
    public bool HasReachedGoal { get; set; }
    public (int, int) Position { get; set; }

    public Player()
    {
        
    }
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