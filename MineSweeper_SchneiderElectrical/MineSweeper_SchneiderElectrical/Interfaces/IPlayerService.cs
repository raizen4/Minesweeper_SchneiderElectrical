using MineSweeper_SchneiderElectrical.Models;

namespace MineSweeper_SchneiderElectrical.Interfaces;

public interface IPlayerService
{ 
    Player CreatePlayer(int lives, (int, int) startPosition);
}