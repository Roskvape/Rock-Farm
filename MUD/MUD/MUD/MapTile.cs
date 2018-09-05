using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    class MapTile
    {
        private string sTileString;
        private ConsoleColor ccTileFG;
        private ConsoleColor ccTileBG;
        private bool bPassable;
        private bool bCollectible;
        private int iTileType;

        //Constructor
        public MapTile(string sTile)
        {
            switch (sTile)
            {
                //Grass
                case "-":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.DarkGreen;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = true;
                    bCollectible = false;
                    iTileType = 0;
                    break;

                //Bridge
                case "H":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.DarkGray;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = true;
                    bCollectible = false;
                    iTileType = 1;
                    break;

                //Stone
                case "*":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.Gray;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = true;
                    bCollectible = true;
                    iTileType = 2;
                    break;

                //Water
                case "~":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.Cyan;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = false;
                    bCollectible = false;
                    iTileType = 3;
                    break;

                //Mountain
                case "^":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.White;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = false;
                    bCollectible = false;
                    iTileType = 4;
                    break;

                //Wall
                case "#":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.Gray;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = false;
                    bCollectible = false;
                    iTileType = 5;
                    break;

                //Player
                case "X":
                    sTileString = sTile;
                    ccTileFG = ConsoleColor.Red;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = false;
                    bCollectible = false;
                    iTileType = 6;
                    break;

                //Unknown
                default:
                    sTileString = "?";
                    ccTileFG = ConsoleColor.Red;
                    ccTileBG = ConsoleColor.Black;
                    bPassable = false;
                    bCollectible = false;
                    iTileType = 999;
                    break;
            }
        }

        //Properties
        public string TileSymbol
        {
            get
            {
                return sTileString;
            }
        }

        public ConsoleColor TileForeGroundColor
        {
            get
            {
                return ccTileFG;
            }
        }

        public ConsoleColor TileBackGroundColor
        {
            get
            {
                return ccTileBG;
            }
        }

        public bool IsPassable
        {
            get
            {
                return bPassable;
            }
        }

        public bool IsCollectible
        {
            get
            {
                return bCollectible;
            }
        }
        public int TileType
        {
            get
            {
                return iTileType;
            }
        }

        //Methods
        public static void TileSwap(int iRow, int iCol, MapTile mtNew)
        {
            Map.sMap[iRow][iCol] = mtNew;
        }

        public static void TileRevert(int iRow, int iCol)
        {
            MapTile mtOld = new MapTile(Map.sMapTemp[iRow][iCol]);
            Map.sMap[iRow][iCol] = mtOld;
        }


    }
}
