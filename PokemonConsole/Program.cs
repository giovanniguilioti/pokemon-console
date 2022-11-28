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
    foreach(var opt in game.Map.map_options)
        Console.WriteLine(opt);

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
    }

    // return 0;

}
