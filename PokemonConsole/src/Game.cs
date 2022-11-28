namespace PokemonConsole
{
    public class Game
    {
        public Player Player;
        public Map Map;
        public void StartGame()
        {
            Console.WriteLine("Bem vindo ao Pokemon Console");
            Console.WriteLine();
            Console.WriteLine("1. Novo Jogo");
            Console.WriteLine("2. Carregar Jogo");
            Console.WriteLine("3. Sair");
        }
        public void NewGame()
        {
            Console.Clear();
            Console.WriteLine("Escolha o nome de seu personagem: ");
            this.Player = new Player(Console.ReadLine());
        }

        public void LoadGame()
        {

        }
        public void Exit()
        {

        }

    }
}