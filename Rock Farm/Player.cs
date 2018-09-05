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
        public static Player playerOne;

        //static public int sPlayerRow = 0;
        //static public int sPlayerCol = 0;

        //Private fields of any player
        private string sPlayerName;
        private string sPlayerToken;
        private int iPlayerStartHP = 9;
        private int iPlayerCurrentHP;
        private int iPlayerRow = 0;
        private int iPlayerCol = 0;
        private MapTile mtTileUnderPlayer = new MapTile(Legends.sDefaultTile);
        private List<Item> itemPlayerInventory = new List<Item>(9);

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
                UpdatePlayerHPUI();
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

        public MapTile TileUnderPlayer
        {
            get
            {
                return mtTileUnderPlayer;
            }
            set
            {
                mtTileUnderPlayer = value;
            }
        }

        public List<Item> PlayerInventory
        {
            get
            {
                return itemPlayerInventory;
            }
        }

        //Methods
        public static void CreatePlayer()
        {
            playerOne = new Player("Player Name", "X");
        }

        private void UpdatePlayerHPUI()
        {
            int iCurLeft = Console.CursorLeft;
            int iCurTop = Console.CursorTop;
            Console.SetCursorPosition(2, Map.mapCurrent.VisualMapHeight + 5);
            UI.UIHPColor(Player.playerOne);
            Console.SetCursorPosition(iCurLeft, iCurTop);
        }

        private void UpdatePlayerInvUI()
        {
            int iCurLeft = Console.CursorLeft;
            int iCurTop = Console.CursorTop;
            Console.SetCursorPosition(2 + Map.mapCurrent.VisualMapWidth -6, Map.mapCurrent.VisualMapHeight + 5);
            UI.UIInvColor(Player.playerOne);
            Console.SetCursorPosition(iCurLeft, iCurTop);
        }

        public bool AddItemToInventory(Item _newItem)
        {
            if (itemPlayerInventory.Count + _newItem.ItemSize < itemPlayerInventory.Capacity)
            {
                if ("&" == _newItem.ItemSymbol)
                {
                    for (int i = 0; i < _newItem.ItemSize; i++)
                    {
                        itemPlayerInventory.Add(new Item("*"));
                    }
                }
                else
                {
                    itemPlayerInventory.Add(_newItem);
                }

                UpdatePlayerInvUI();
                UI.uiDefault.Message2 = ($"You pick up the {_newItem.ItemName}.");
                return true;
            }
            else
            {
                UI.uiDefault.Message2 = UI.sInvFull;
                return false;
            }
        }

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

