using Microsoft.Extensions.DependencyInjection;
using MineSweeper_SchneiderElectrical.Interfaces;
using MineSweeper_SchneiderElectrical.Services;

namespace MineSweeper_SchneiderElectrical;

internal static class Program
{
    private static void Main(string[] args)
    {
        var services = CreateServices();
        var game = new GameService(services.GetRequiredService<IPlayerService>(), services.GetRequiredService<IGameBoardService>());
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