using Minesweeper_SchneiderElectrical.Models;

namespace Minesweeper_SchneiderElectrical.Interfaces;

public interface IPlayerService
{ 
    Player CreatePlayer(int lives, (int, int) startPosition);
}