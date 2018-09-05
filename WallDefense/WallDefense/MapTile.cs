using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class MapTile
    {
        private string sTileString;
        private string sTileName;
        private ConsoleColor ccTileFG;
        private ConsoleColor ccTileBG;
        private bool bPassable;
        private bool bCollectible;

        public MapTile(string _sTileString)
        {


            sTileString = _sTileString;
            sTileName = "stuff";
            ccTileFG = ConsoleColor.DarkGreen;
            ccTileBG = ConsoleColor.Black;
            bPassable = true;
            bCollectible = false;
        }

        public MapTile(string _sTileString, string _sTileName, ConsoleColor _ccTileFG, ConsoleColor _ccTileBG, bool _bPassable, bool _bCollectible)
        {
            sTileString = _sTileString;
            sTileName = _sTileName;
            ccTileFG = _ccTileFG;
            ccTileBG = _ccTileBG;
            bPassable = _bPassable;
            bCollectible = _bCollectible;
        }

        //Properties
        public string TileSymbol
        {
            get
            {
                return sTileString;
            }
        }

        public string TileName
        {
            get
            {
                return sTileName;
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

    }
}
