namespace MineSweeper_SchnaiderElectric.Helpers;

public static class DirectionHelper
{
    public static (int,int)? DirectionToPositionConverter(string? direction, (int,int) position)
    {
        var row = position.Item1;
        var column = position.Item2;
        
        if (direction == null)
            return null;
        
        switch (direction)
        {
            case "up":
                row--;
                break;
            case "down":
                row++;
                break;
            case "left":
                column--;
                break;
            case "right":
                column++;
                break;
            default:
                return  position;
        }

        return (row, column);
    }
}