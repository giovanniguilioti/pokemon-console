namespace PokemonConsole
{
    public class Player
    {
        public string? Name { get; set; }
        public Pokemon[] Pokemon = new Pokemon[6];

        public Player(){}
        public Player(string name){this.Name = name;}
    }
}