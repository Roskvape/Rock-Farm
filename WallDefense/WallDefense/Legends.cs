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
        //public static Dictionary<string, Player> dicPlayerLegend = new Dictionary<string, Player>();

        public static void BuildTileSetLegend()
        {
            MapTile mtGrass = new MapTile("-", "grass", ConsoleColor.DarkGreen, ConsoleColor.Black, true, false);
            MapTile mtBridge = new MapTile("H", "bridge", ConsoleColor.DarkGray, ConsoleColor.Black, true, false);
            MapTile mtStone = new MapTile("*", "stone", ConsoleColor.Gray, ConsoleColor.Black, true, true);
            MapTile mtWater = new MapTile("~", "water", ConsoleColor.Cyan, ConsoleColor.Black, false, false);
            MapTile mtMountain = new MapTile("^", "mountain", ConsoleColor.White, ConsoleColor.Black, false, false);
            MapTile mtWall = new MapTile("#", "wall", ConsoleColor.Gray, ConsoleColor.Black, false, false);
            MapTile mtPlayer = new MapTile("X", "player", ConsoleColor.Red, ConsoleColor.Black, false, false);
            MapTile mtSpawn = new MapTile("@", "spawn", ConsoleColor.Red, ConsoleColor.Black, true, false);
            MapTile mtUnknown = new MapTile("?", "unknown", ConsoleColor.Red, ConsoleColor.Black, true, false);

            dicTileSetLegend.Add("-", mtGrass);
            dicTileSetLegend.Add("H", mtBridge);
            dicTileSetLegend.Add("*", mtStone);
            dicTileSetLegend.Add("~", mtWater);
            dicTileSetLegend.Add("^", mtMountain);
            dicTileSetLegend.Add("#", mtWall);
            dicTileSetLegend.Add("X", mtPlayer);
            dicTileSetLegend.Add("@", mtSpawn);
            dicTileSetLegend.Add("?", mtUnknown);
        }

        //public static void AddPlayerToLegend(string _Token, Player _Player)
        //{
        //    dicPlayerLegend.Add(_Token, _Player);
        //}
    }
}
