using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class Program
    {

        static void Initializer()
        {
            //Initialize Legends
            Legends.BuildTileSetLegend();
            Legends.BuildItemLegend();

            //Initialize Map
            //Console.WriteLine("Next map name?");
            //string sNextMapName = Console.ReadLine();

            Map.LoadMap("MapData.txt");

            //Initialize Player
            Player.CreatePlayer();

            //Spawn Player
            Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol] = new MapTile(Player.playerOne.PlayerToken);

            //Initialize UI
            UI.CreateUI();

            UI.ReloadUI(UI.uiDefault);

        }



        static void Main(string[] args)
        {
            ConsoleKey ckInput = ConsoleKey.E;
            Initializer();

            while (ckInput != ConsoleKey.Escape)
            {
                ckInput = Console.ReadKey().Key;
                if (ConsoleKey.UpArrow == ckInput || ConsoleKey.DownArrow == ckInput || ConsoleKey.LeftArrow == ckInput || ConsoleKey.RightArrow == ckInput)
                {
                    PlayerActions.MovePlayer(ckInput, Player.playerOne);
                }

            }
            if (ckInput == ConsoleKey.Escape)
            {
                UI.uiDefault.Message1 = "wooooot";
                UI.uiDefault.Message2 = "bam";
                //Environment.Exit(0);
            }

            Console.ReadKey();
        }

        //static void VerificationJunk()
        //{
        //    //Map Verification
        //    Map.PrintMap(Map.mapCurrent);
        //    Console.WriteLine("Map Width: " + Map.mapCurrent.VisualMapWidth);
        //    Console.WriteLine("Map Height: " + Map.mapCurrent.VisualMapHeight);
        //    Console.WriteLine("True Map Width: " + Map.mapCurrent.TrueMapWidth);
        //    Console.WriteLine("True Map Height: " + Map.mapCurrent.TrueMapHeight);

        //    //Tileset Legend verification
        //    Console.WriteLine("Enter a symbol:");
        //    string sInput = Console.ReadLine();
        //    Console.WriteLine(Legends.dicTileSetLegend[sInput].TileSymbol);
        //    Console.WriteLine(Legends.dicTileSetLegend[sInput].TileName);
        //    Console.WriteLine(Legends.dicTileSetLegend[sInput].TileForeGroundColor);
        //    Console.WriteLine(Legends.dicTileSetLegend[sInput].TileBackGroundColor);
        //    Console.WriteLine(Legends.dicTileSetLegend[sInput].IsPassable);
        //    Console.WriteLine(Legends.dicTileSetLegend[sInput].IsCollectible);

        //    //Replace Map Tile Verfication
        //    Map.ReplaceTile(new MapTile("@"), 0, 0);

        //    //Player Verification
        //    Console.WriteLine(playerOne.PlayerName);
        //    Console.WriteLine(playerOne.PlayerToken);
        //    Console.WriteLine(playerOne.PlayerRow);
        //    Console.WriteLine(playerOne.PlayerCol);
        //    Console.WriteLine(playerOne.PlayerUnderlyingTile);

        //    //Player Health Verfication
        //    Player.playerOne.PlayerHealth = -3;

        ////Inventory Verfication
        //for (int i = 0; i< 10; i++)
        //{
        //    if (Player.playerOne.AddItemToInventory(new Item("Stone", 1, "stone")))
        //    {

        //        Console.WriteLine("Stone added to inventory!"); 
        //    }
        //    else
        //    {

        //    }
        //}

        //foreach (Item x in Player.playerOne.PlayerInventory)
        //{
        //    Console.WriteLine(x.ItemName);
        //}
        //Console.WriteLine(Player.playerOne.PlayerInventory.Count);

        //}
    }
}
