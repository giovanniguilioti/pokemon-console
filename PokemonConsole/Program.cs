using PokemonConsole;
using Newtonsoft.Json;
// using Newtonsoft.Json.Serialization;
// using Newtonsoft.Json.Converters;
// using Newtonsoft.Json.Linq;

string file = ".\\data\\map.json";
Game game = new Game();
game.StartGame();

int option;
option = int.Parse(Console.ReadLine());

switch(option)
{
    case 1:
        game.NewGame();
        var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
        game.Map = new Map(map[1]);
        break;
    case 2:
        game.LoadGame();
        break;
    case 0:
        return 0;
}

while(true)
{
    game.Map.ShowMap();

    int count = 1;
    foreach(var opt in game.Map.map_options)
    {
        Console.WriteLine(count + ". " + opt);
        count++;
    }

    switch(game.Map.map_type)
    {
        case MAPTYPE.TOWN:
            game.Map.ShowTown();
            break;
        case MAPTYPE.ROUTE:
            game.Map.ShowRoute();
            break;
        case MAPTYPE.HOUSE:
            game.Map.ShowHouse();
            break;
        case MAPTYPE.CAVE:
            game.Map.ShowCave();
            break;
        case MAPTYPE.GYM:
            game.Map.ShowGym();
            break;
        case MAPTYPE.NPC:
            game.Map.ReadNpc(game.Map.map_npcs);
            break;
        case MAPTYPE.EXIT:
            game.Map.ReadExit();
            break;
        case MAPTYPE.HOUSE_INTERIOR:
            game.Map.ReadHouses();
            break;
        default:
            break;
    }
}
