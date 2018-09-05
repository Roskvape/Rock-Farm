using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{

    class Legends
    {
        public static Dictionary<string, MapTile> dicTileSetLegend = new Dictionary<string, MapTile>();
        public static Dictionary<string, Item> dicItemLegend = new Dictionary<string, Item>();
        //public static Dictionary<string, Player> dicPlayerLegend = new Dictionary<string, Player>();
        public static string sDefaultTile = "-";

        public static void BuildTileSetLegend()
        {
            MapTile mtGrass = new MapTile("-", "grass", "terrain", ConsoleColor.DarkGreen, ConsoleColor.Black, true, false, "You are standing on grass.");
            MapTile mtBridge = new MapTile("H", "bridge", "terrain", ConsoleColor.DarkGray, ConsoleColor.Black, true, false, "You are crossing a bridge.");
            MapTile mtStone = new MapTile("*", "stone", "material", ConsoleColor.Gray, ConsoleColor.Black, true, true, "You found a stone!");
            MapTile mtStonepile = new MapTile("&", "stonepile", "material", ConsoleColor.Gray, ConsoleColor.Black, true, true, "You found pile of stones!");
            MapTile mtHealth = new MapTile("\u00BF", "potion", "consumable", ConsoleColor.Yellow, ConsoleColor.Black, true, true, "You found a health potion!");
            MapTile mtWater = new MapTile("≈", "water", "terrain", ConsoleColor.Blue, ConsoleColor.Black, false, false, "You can't swim!");
            MapTile mtMountain = new MapTile("^", "mountain", "terrain", ConsoleColor.White, ConsoleColor.Black, false, false, "You can't climb mountains!");
            MapTile mtWall = new MapTile("#", "wall", "structure", ConsoleColor.Gray, ConsoleColor.Black, false, false, "You run into a wall. Oof!");
            MapTile mtPlayer = new MapTile("X", "player", "terrain", ConsoleColor.Red, ConsoleColor.Black, false, false, "This is you.");
            MapTile mtSpawn = new MapTile("@", "spawn", "data", ConsoleColor.Red, ConsoleColor.Black, true, false, "This is the spawn point.");
            MapTile mtUnknown = new MapTile("?", "unknown", "who knows", ConsoleColor.Red, ConsoleColor.Black, true, false, "Error: Unknown tile type.");

            dicTileSetLegend.Add("-", mtGrass);
            dicTileSetLegend.Add("H", mtBridge);
            dicTileSetLegend.Add("*", mtStone);
            dicTileSetLegend.Add("&", mtStonepile);
            dicTileSetLegend.Add("\u00BF", mtHealth);
            dicTileSetLegend.Add("≈", mtWater);
            dicTileSetLegend.Add("^", mtMountain);
            dicTileSetLegend.Add("#", mtWall);
            dicTileSetLegend.Add("X", mtPlayer);
            dicTileSetLegend.Add("@", mtSpawn);
            dicTileSetLegend.Add("?", mtUnknown);

        }

        public static void BuildItemLegend()
        {
            Item itemStone = new Item("*", "stone", 1, "material");
            Item itemStonepile = new Item("&", "stones", 4, "material");
            Item itemHealth = new Item("\u00BF", "potion", 1, "consumable");

            dicItemLegend.Add("*", itemStone);
            dicItemLegend.Add("&", itemStonepile);
            dicItemLegend.Add("\u00BF", itemHealth);
        }

        //public static void AddPlayerToLegend(string _Token, Player _Player)
        //{
        //    dicPlayerLegend.Add(_Token, _Player);
        //}
    }
}
