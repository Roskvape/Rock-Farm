using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class Player
    {
        //Static variables
        //static public int sPlayerRow = 0;
        //static public int sPlayerCol = 0;

        //Private fields of any player
        private string sPlayerName;
        private string sPlayerToken;
        private int iPlayerStartHP = 9;
        private int iPlayerCurrentHP;
        private int iPlayerRow = 0;
        private int iPlayerCol = 0;
        private string sUnderlyingTile = "-";

        //Constructors

        public Player(string _sPlayerName, string _sPlayerToken)
        {
            iPlayerCurrentHP = iPlayerStartHP;
            sPlayerName = _sPlayerName;
            sPlayerToken = _sPlayerToken;
            iPlayerRow = Map.LocateStartingPoint()[0];
            iPlayerCol = Map.LocateStartingPoint()[1];
        }

        //Properties
        public string PlayerName
        {
            get
            {
                return sPlayerName;
            }

            set
            {
                sPlayerName = value;
            }
        }

        public string PlayerToken
        {
            get
            {
                return sPlayerToken;
            }
        }

        public int PlayerHealth
        {
            get
            {
                return iPlayerCurrentHP;
            }

            set
            {
                iPlayerCurrentHP += value;
            }
        }

        public int PlayerRow
        {
            get
            {
                return iPlayerRow;
            }

            set
            {
                iPlayerRow = value;
            }
        }

        public int PlayerCol
        {
            get
            {
                return iPlayerCol;
            }

            set
            {
                iPlayerCol = value;
            }
        }

        public string PlayerUnderlyingTile
        {
            get
            {
                return sUnderlyingTile;
            }

            set
            {
                sUnderlyingTile = value;
            }
        }

        //Methods

        //static public void MovePlayer(ConsoleKey ckDirection, Player pCurrentPlayer)
        //{
        //    //Check map bounds
        //    if ((Player.sPlayerRow > 0 && ConsoleKey.UpArrow == ckDirection)
        //        || (Player.sPlayerRow < (Map.sMap.Count() - 1) && ConsoleKey.DownArrow == ckDirection)
        //        || (Player.sPlayerCol > 0 && ConsoleKey.LeftArrow == ckDirection)
        //        || (Player.sPlayerCol < (Map.sMap[sPlayerRow].Count() - 1) && ConsoleKey.RightArrow == ckDirection))
        //    {
        //        if (ConsoleKey.UpArrow == ckDirection)
        //        {
        //            Map.CheckMapTile(Map.sMap[Player.sPlayerRow - 1][Player.sPlayerCol].TileSymbol);
        //            if (true == Map.sMap[Player.sPlayerRow - 1][Player.sPlayerCol].IsPassable)
        //            {
        //                //Replace player token with underlying tile.
        //                Map.sMap[Player.sPlayerRow][Player.sPlayerCol] = new MapTile(sUnderlyingTile);

        //                //Save next map tile as underlying.
        //                sUnderlyingTile = Map.sMap[Player.sPlayerRow - 1][Player.sPlayerCol].TileSymbol;

        //                //Move player token.
        //                Map.sMap[Player.sPlayerRow -= 1][Player.sPlayerCol] = new MapTile(pCurrentPlayer.sPlayerToken);
        //            }
        //            else
        //            {
        //                //Map.CheckMapTile sets the reason player can't proceed.

        //            }
        //        }
        //        else if (ConsoleKey.DownArrow == ckDirection)
        //        {
        //            Map.CheckMapTile(Map.sMap[Player.sPlayerRow + 1][Player.sPlayerCol].TileSymbol);
        //            if (true == Map.sMap[Player.sPlayerRow + 1][Player.sPlayerCol].IsPassable)
        //            {
        //                Map.sMap[Player.sPlayerRow][Player.sPlayerCol] = new MapTile(sUnderlyingTile);
        //                sUnderlyingTile = Map.sMap[Player.sPlayerRow + 1][Player.sPlayerCol].TileSymbol;
        //                Map.sMap[Player.sPlayerRow += 1][Player.sPlayerCol] = new MapTile(pCurrentPlayer.sPlayerToken);
        //            }
        //            else
        //            {
        //                //Map.CheckMapTile sets the reason player can't proceed.

        //            }

        //        }
        //        else if (ConsoleKey.LeftArrow == ckDirection)
        //        {
        //            Map.CheckMapTile(Map.sMap[Player.sPlayerRow][Player.sPlayerCol - 1].TileSymbol);
        //            if (true == Map.sMap[Player.sPlayerRow][Player.sPlayerCol - 1].IsPassable)
        //            {
        //                Map.sMap[Player.sPlayerRow][Player.sPlayerCol] = new MapTile(sUnderlyingTile);
        //                sUnderlyingTile = Map.sMap[Player.sPlayerRow][Player.sPlayerCol - 1].TileSymbol;
        //                Map.sMap[Player.sPlayerRow][Player.sPlayerCol -= 1] = new MapTile(pCurrentPlayer.sPlayerToken);
        //            }
        //            else
        //            {
        //                //Map.CheckMapTile sets the reason player can't proceed.

        //            }
        //        }
        //        else if (ConsoleKey.RightArrow == ckDirection)
        //        {
        //            Map.CheckMapTile(Map.sMap[Player.sPlayerRow][Player.sPlayerCol + 1].TileSymbol);
        //            if (true == Map.sMap[Player.sPlayerRow][Player.sPlayerCol + 1].IsPassable)
        //            {
        //                Map.sMap[Player.sPlayerRow][Player.sPlayerCol] = new MapTile(sUnderlyingTile);
        //                sUnderlyingTile = Map.sMap[Player.sPlayerRow][Player.sPlayerCol + 1].TileSymbol;
        //                Map.sMap[Player.sPlayerRow][Player.sPlayerCol += 1] = new MapTile(pCurrentPlayer.sPlayerToken);
        //            }
        //            else
        //            {
        //                //Map.CheckMapTile sets the reason player can't proceed.

        //            }
        //        }
        //    }
        //    else
        //    {
        //        UI.sMsg1 = UI.sEdgeOfMap;
        //    }

        //    UI.ReloadUI(pCurrentPlayer);
        //    //sPlayerCoords[0] = sPlayerRow;
        //    //sPlayerCoords[1] = sPlayerCol;
        //}
    }
}

