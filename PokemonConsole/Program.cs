using PokemonConsole;

Game game = new Game();

switch(game.StartGame())
{
    case 1:
        Console.WriteLine("Novo jogo");
        game.NewGame();
        Console.Clear();
        Console.WriteLine($"Bem vindo {game.Player.Name}! Sua jornada começa agora!");
        Console.WriteLine();
        break;
    case 2:
        Console.WriteLine("Carregando Jogo");
        break;
    case 0:
        Console.WriteLine("Saindo...");
        break;
    default:
        Console.WriteLine("Opcao invalida");
        break;
}