namespace PokemonConsole
{
    public class Menu
    {
        public List<string> options;

        public Menu(){}
        public Menu(List<string> options)
        {
            this.options = new List<string>();
            foreach(var option in options)
                this.options.Add(option);
        }
    }
}