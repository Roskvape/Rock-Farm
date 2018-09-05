using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class MapTile
    {
        private string sTileSymbol;
        private string sTileName;
        private string sTileType;
        private ConsoleColor ccTileFG;
        private ConsoleColor ccTileBG;
        private bool bPassable;
        private bool bCollectible;
        private string sTileMessage;

        public MapTile(string _sTileSymbol)
        {
            sTileSymbol = Legends.dicTileSetLegend[_sTileSymbol].TileSymbol;
            sTileName = Legends.dicTileSetLegend[_sTileSymbol].TileName;
            sTileType = Legends.dicTileSetLegend[_sTileSymbol].TileType;
            ccTileFG = Legends.dicTileSetLegend[_sTileSymbol].TileForeGroundColor;
            ccTileBG = Legends.dicTileSetLegend[_sTileSymbol].TileBackGroundColor;
            bPassable = Legends.dicTileSetLegend[_sTileSymbol].IsPassable;
            bCollectible = Legends.dicTileSetLegend[_sTileSymbol].IsCollectible;
            sTileMessage = Legends.dicTileSetLegend[_sTileSymbol].TileMessage;
        }

        public MapTile(string _sTileSymbol, string _sTileName, string _sTileType, ConsoleColor _ccTileFG, ConsoleColor _ccTileBG, bool _bPassable, bool _bCollectible, string _sTileMessage)
        {
            sTileSymbol = _sTileSymbol;
            sTileName = _sTileName;
            sTileType = _sTileType;
            ccTileFG = _ccTileFG;
            ccTileBG = _ccTileBG;
            bPassable = _bPassable;
            bCollectible = _bCollectible;
            sTileMessage = _sTileMessage;
        }

        //Properties

        public string TileSymbol
        {
            get
            {
                return sTileSymbol;
            }
        }

        public string TileName
        {
            get
            {
                return sTileName;
            }
        }

        public string TileType
        {
            get
            {
                return sTileType;
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

        public string TileMessage
        {
            get
            {
                return sTileMessage;
            }
        }

        //Methods

        public static Item ConvertMapTileToItem(MapTile _mapTile)
        {
            Item itemNew = new Item(_mapTile.sTileSymbol);
            return itemNew;
        }

    }
}
