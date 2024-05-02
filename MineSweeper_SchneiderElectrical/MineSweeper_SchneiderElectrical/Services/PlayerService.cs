using MineSweeper_SchneiderElectrical.Interfaces;
using MineSweeper_SchneiderElectrical.Models;

namespace MineSweeper_SchneiderElectrical.Services;

public class PlayerService: IPlayerService
{
    public Player CreatePlayer(int lives, (int, int) startPosition)
    {
        return new Player(lives, startPosition);
    }
}