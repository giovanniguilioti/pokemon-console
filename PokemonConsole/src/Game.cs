namespace PokemonConsole
{
    public class Game
    {
        public Player Player;
        public Map Map;
        public Menu Menu;
        public void StartGame()
        {
            Console.WriteLine("Bem vindo ao Pokemon Console");
            Console.WriteLine();

            var opt = new List<string>{"1. Novo Jogo", "2. Carregar Jogo", "0. Sair"};
            this.Menu = new Menu(opt);
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