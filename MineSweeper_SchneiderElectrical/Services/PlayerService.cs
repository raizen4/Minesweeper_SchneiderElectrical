using Minesweeper_SchneiderElectrical.Interfaces;
using Minesweeper_SchneiderElectrical.Models;

namespace Minesweeper_SchneiderElectrical.Services;

//This could be transformed into a factory or a builder if the creation of the player object is more complex and/or
//we need up having multiple implementations of the player object.
public class PlayerService: IPlayerService
{
    public Player CreatePlayer(int lives, (int, int) startPosition)
    {
        return new Player(lives, startPosition);
    }
}