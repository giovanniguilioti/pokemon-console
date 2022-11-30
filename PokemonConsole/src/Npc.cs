namespace PokemonConsole
{
    [Serializable]
    public class Npc
    {
        public int id { get; set; }
        public string name { get; set; }
        public string dialog { get; set; }
        public Npc(){}
        public Npc(Npc npc)
        {
            this.id = npc.id;
            this.name = npc.name;
            this.dialog = npc.dialog;
        }
        public void ShowDialog()
        {
            Console.WriteLine(this.name + ": " + this.dialog);
            Console.ReadLine();
        }
    }
}