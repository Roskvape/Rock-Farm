using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize Map
            Console.WriteLine("Next map name?");
            string sNextMapName = Console.ReadLine();

            Map.LoadMap(sNextMapName);

            //Map Verification
            Map.PrintMap(Map.mapCurrent);
            Console.WriteLine("Map Width: " + Map.mapCurrent.VisualMapWidth);
            Console.WriteLine("Map Height: " + Map.mapCurrent.VisualMapHeight);
            Console.WriteLine("True Map Width: " + Map.mapCurrent.TrueMapWidth);
            Console.WriteLine("True Map Height: " + Map.mapCurrent.TrueMapHeight);

            //Initialize Tileset Legend
            Legends.BuildTileSetLegend();

            Console.WriteLine("Enter a symbol:");
            string sInput = Console.ReadLine();

            //Tileset Legend verification
            Console.WriteLine(Legends.dicTileSetLegend[sInput].TileSymbol);
            Console.WriteLine(Legends.dicTileSetLegend[sInput].TileName);
            Console.WriteLine(Legends.dicTileSetLegend[sInput].TileForeGroundColor);
            Console.WriteLine(Legends.dicTileSetLegend[sInput].TileBackGroundColor);
            Console.WriteLine(Legends.dicTileSetLegend[sInput].IsPassable);
            Console.WriteLine(Legends.dicTileSetLegend[sInput].IsCollectible);

            Console.ReadKey();

            //Initialize Player
            Console.WriteLine("What's your name?");
            Player playerOne = new Player(Console.ReadLine(), "X");

            //Player Verification
            Console.WriteLine(playerOne.PlayerName);
            Console.WriteLine(playerOne.PlayerToken);
            Console.WriteLine(playerOne.PlayerRow);
            Console.WriteLine(playerOne.PlayerCol);
            Console.WriteLine(playerOne.PlayerUnderlyingTile);

            Console.ReadKey();
        }
    }
}
