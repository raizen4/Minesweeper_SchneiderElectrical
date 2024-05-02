using Microsoft.Extensions.DependencyInjection;
using Minesweeper_SchneiderElectrical.Interfaces;
using Minesweeper_SchneiderElectrical.Services;

namespace Minesweeper_SchneiderElectrical;

internal static class Program
{
    private static void Main(string[] args)
    {
        var services = CreateServices();
        var game = new GameService(services.GetRequiredService<PlayerService>(), services.GetRequiredService<GameBoardService>());
        game.StartGame(5);
    }

    private static ServiceProvider CreateServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGameBoardService, GameBoardService>()
            .AddSingleton<IPlayerService, PlayerService>()
            .AddSingleton<IGameService, GameService>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}