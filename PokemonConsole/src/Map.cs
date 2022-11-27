using Newtonsoft.Json;

namespace PokemonConsole
{
    [Serializable]
    public class Map
    {
        public int map_id { get; set; }
        public string map_name { get; set; }
        public MAPTYPE map_type { get; set; }
        public int map_top { get; set; }
        public int map_right { get; set; }
        public int map_bottom { get; set; }
        public int map_left { get; set; }
        public bool map_is_inside { get; set; }
        public int map_outside { get; set; }
        public List<string> map_options { get; set; }

        public Map(){}
        public Map(Map map)
        {
            this.map_name = map.map_name;
            this.map_type = map.map_type;
            this.map_outside = map.map_outside;
            this.map_options = new List<string>();

            Console.WriteLine(this.map_name);
            
            foreach(var option in map.map_options)
                this.map_options.Add(option);
        }
        public Map(int id, string name)
        {
            this.map_id = id;
            this.map_name = name;
        }
        public void ShowMap()
        {
            Console.Clear();
            Console.WriteLine(this.map_name);
        }

        public void Investigar()
        {
            Console.Clear();
            Console.WriteLine("Voce não encontrou nada");
        }

        public void GoOutside(Game game, int where)
        {
            string file = "C:\\Users\\giovanni\\Desktop\\ngiovanni\\pokemon-console\\PokemonConsole\\data\\map.json";
            game.Map.map_options.Clear();
            var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
            var new_map = new Map(map[where]);
            game.Map = new_map;
            game.Menu.options.Clear();
            foreach(var opt in game.Map.map_options)
                game.Menu.options.Add(opt);
        }
    }
}