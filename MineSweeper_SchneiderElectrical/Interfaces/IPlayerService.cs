using MineSweeper_SchnaiderElectric.Models;
namespace MineSweeper_SchnaiderElectric.Interfaces;

public interface IPlayerService
{ 
    Player CreatePlayer(int lives, (int, int) startPosition);
}