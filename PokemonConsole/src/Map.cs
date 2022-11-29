using PokemonConsole;
using Newtonsoft.Json;

namespace PokemonConsole
{
    [Serializable]
    public class Map
    {
        public int map_id { get; set; }
        public string map_name { get; set; }
        public MAPTYPE map_type { get; set; }
        public List<int> map_exits { get; set; }
        public bool map_is_inside { get; set; }
        public int map_outside { get; set; }
        public List<string> map_options { get; set; }
        public List<int> map_npcs { get; set; }

        public Map(){}
        public Map(Map map)
        {
            this.map_id = map.map_id;
            this.map_name = map.map_name;
            this.map_type = map.map_type;
            this.map_outside = map.map_outside;
            this.map_exits = new List<int>();
            this.map_options = new List<string>();
            this.map_npcs = new List<int>();

            Console.WriteLine(this.map_name);
            
            foreach(var option in map.map_options)
                this.map_options.Add(option);
            foreach(var npc in map.map_npcs)
                this.map_npcs.Add(npc);
            foreach(var exit in map.map_exits)
                this.map_exits.Add(exit);
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
        public void ShowTown()
        {
            int option;
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    ShowNpcs(this.map_id);
                    break;
                case 2:
                    //Market();
                    break;
                case 3:
                    //ShowHouses();
                    break;
                case 4:
                    ShowExits(this.map_id);
                    break;
                default:
                    break;
            }
        }
        public void ShowRoute()
        {
            int option;
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Investigar();
                    break;
                case 2:
                    // EcontrarBatalha();
                    break;
                case 3:
                    //ShowNpcs();
                    break;
                case 4:
                    //Saidas();
                    break;
                default:
                    break;
            }
        }
        public void ShowHouse()
        {
            int option;
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    this.Investigar();
                    Console.ReadLine();
                    break;
                case 2:
                    ShowNpcs(this.map_id);
                    break;
                case 3:
                    string file = ".\\data\\map.json";
                    var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
                    Map aux = new Map(map[this.map_outside]);
                    this.map_id = aux.map_id;
                    this.map_name = aux.map_name;
                    this.map_type = aux.map_type;
                    this.map_options.Clear();
                    foreach(var opt in aux.map_options)
                        this.map_options.Add(opt);
                    break;
                default:
                    break;
            }
        }
        public void ShowCave()
        {
            int option;
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Investigar();
                    break;
                case 2:
                    //EncontrarBatalha();
                    break;
                case 3:
                    //ShowNpcs();
                    break;
                case 4:
                    //Saidas();
                    break;
                default:
                    break;
            }
        }
        public void ShowGym()
        {
            int option;
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Investigar();
                    break;
                case 2:
                    // ShowNpcs();
                    break;
                case 3:
                    //EnfrentarLider();
                    break;
                case 4:
                    //Sair
                    break;
                default:
                    break;
            }
        }
        public void Investigar()
        {
            Console.Clear();
            Console.WriteLine("Voce não encontrou nada");
        }
        public void ShowNpcs(int id)
        {
            string file = ".\\data\\map.json";
            var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
            Map aux = new Map(map[id]);
            this.map_name += " Npcs";
            this.map_type = MAPTYPE.NPC;
            this.map_options.Clear();
            
            string file_npc = ".\\data\\npc.json";
            var npcs = JsonConvert.DeserializeObject<List<Npc>>(File.ReadAllText(file_npc));
            foreach(var npc in aux.map_npcs)
                this.map_options.Add(npcs[npc].name);
        }
        public void ReadNpc(List<int> npc_list)
        {
            int option;
            option = int.Parse(Console.ReadLine());

            string file_npc = ".\\data\\npc.json";
            var npcs = JsonConvert.DeserializeObject<List<Npc>>(File.ReadAllText(file_npc));

            //voltar para o mapa
            if(npcs[option-1].id == 0)
            {
                this.map_name = this.map_name.Replace(" Npcs", ""); 
                this.map_options.Clear();

                string file = ".\\data\\map.json";
                var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
                this.map_type = map[this.map_id].map_type;
                foreach(var opt in map[this.map_id].map_options)
                        this.map_options.Add(opt);
                return;
            }
        }
        public void ShowExits(int id)
        {
            string file = ".\\data\\map.json";
            var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
            Map aux = new Map(map[id]);
            this.map_name += " Saidas";
            this.map_type = MAPTYPE.EXIT;
            this.map_options.Clear();
            
            this.map_options.Add("Voltar");
            foreach(var exit in aux.map_exits)
                this.map_options.Add(map[exit].map_name);

        }
        public void ReadExit()
        {
            int option;
            option = int.Parse(Console.ReadLine());

            if(option == 1)
            {
                this.map_name = this.map_name.Replace(" Saidas", ""); 
                this.map_options.Clear();

                string file = ".\\data\\map.json";
                var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
                this.map_type = map[this.map_id].map_type;
                foreach(var opt in map[this.map_id].map_options)
                        this.map_options.Add(opt);
                return;
            }
        }
    }
}