using PokemonConsole;
using Newtonsoft.Json;
// using Newtonsoft.Json.Serialization;
// using Newtonsoft.Json.Converters;
// using Newtonsoft.Json.Linq;

string file = "C:\\Users\\giovanni\\Desktop\\ngiovanni\\pokemon-console\\PokemonConsole\\data\\map.json";
Game game = new Game();
game.Menu = new Menu();
game.StartGame();

foreach(var opt in game.Menu.options)
    Console.WriteLine(opt);
    
int option;
option = int.Parse(Console.ReadLine());

switch(option)
{
    case 1:
        game.NewGame();
        var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
        game.Map = new Map(map[1]);
        game.Menu.options.Clear();
        foreach(var opt in game.Map.map_options)
        game.Menu.options.Add(opt);
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
    foreach(var opt in game.Menu.options)
        Console.WriteLine(opt);

    int option_game;
    option_game = int.Parse(Console.ReadLine());

    switch(game.Map.map_type)
    {
        case MAPTYPE.TOWN:
            switch(option_game)
            {

            }
            break;
        case MAPTYPE.ROUTE:
            switch(option_game)
            {
                
            }
            break;
        case MAPTYPE.HOUSE:
            switch(option_game)
            {
                case 1:
                    game.Map.Investigar();
                    Console.ReadLine();
                    break;
                case 2:
                    break;
                case 3:
                    var map = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(file));
                    Map aux = new Map(map[game.Map.map_outside]);
                    game.Map = aux;
                    game.Menu.options.Clear();
                    foreach(var opt in game.Map.map_options)
                    game.Menu.options.Add(opt);
                    break;
            }
            break;
        case MAPTYPE.CAVE:
            switch(option_game)
            {
                
            }
            break;
        case MAPTYPE.GYM:
            switch(option_game)
            {
                
            }
            break;
    }

    // return 0;

}
