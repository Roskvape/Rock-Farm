using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class PlayerActions
    {
        static public void MovePlayer(ConsoleKey ckDirection, Player pCurrentPlayer)
        {
            int pRowOld = Player.playerOne.PlayerRow;
            int pColOld = Player.playerOne.PlayerCol;
            int pRowOldScreen = pRowOld + 4;
            int pColOldScreen = (pColOld*2) +3;

            int pRowDestination = pRowOld;
            int pColDestination = pColOld;
            int pRowDestinationScreen = pRowDestination + 4;
            int pColDestinationScreen = (pColDestination*2) +3;

            //Set destination coords
            switch (ckDirection)
            {
                case ConsoleKey.UpArrow:
                    pRowDestination -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    pRowDestination += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    pColDestination -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    pColDestination += 1;
                    break;
                default:
                    break;
            }

            //Check map bounds
            if (pRowDestination >= 0
                && pRowDestination < Map.mapCurrent.MapData.Count()
                && pColDestination >= 0
                && pColDestination < Map.mapCurrent.MapData[pRowDestination].Count())
            {
                Map.CheckMapTile(Map.mapCurrent.MapData[pRowDestination][pColDestination].TileSymbol);

                //Clear previous tile's message 2
                UI.uiDefault.Message2 = "";

                if (true == Map.mapCurrent.MapData[pRowDestination][pColDestination].IsCollectible)
                {

                    if (Player.playerOne.AddItemToInventory(MapTile.ConvertMapTileToItem(Map.mapCurrent.MapData[pRowDestination][pColDestination])))
                    {
                        Map.ReplaceTile(new MapTile(Legends.sDefaultTile), pRowDestination, pColDestination); 
                    }
                }
                if (true == Map.mapCurrent.MapData[pRowDestination][pColDestination].IsPassable)
                {


                    //Replace player token with underlying tile.
                    Map.ReplaceTile(Player.playerOne.TileUnderPlayer, pRowOld, pColOld);

                    //Save next map tile as underlying.
                    Player.playerOne.TileUnderPlayer = Map.mapCurrent.MapData[pRowDestination][pColDestination];

                    //Move player token.
                    Map.ReplaceTile(new MapTile(Player.playerOne.PlayerToken), pRowDestination, pColDestination);

                    //Update Player Row and Col
                    Player.playerOne.PlayerRow = pRowDestination;
                    Player.playerOne.PlayerCol = pColDestination;
                }
                else
                {
                    //Map.CheckMapTile sets the reason player can't proceed.
                }
            }
            else
            {
                UI.uiDefault.Message1 = UI.sEdgeOfMap;
            }
            Console.Write("\b");

            ////Check map bounds
            //if ((Player.playerOne.PlayerRow > 0 && ConsoleKey.UpArrow == ckDirection)
            //    || (Player.playerOne.PlayerRow < (Map.mapCurrent.MapData.Count() - 1) && ConsoleKey.DownArrow == ckDirection)
            //    || (Player.playerOne.PlayerCol > 0 && ConsoleKey.LeftArrow == ckDirection)
            //    || (Player.playerOne.PlayerCol < (Map.mapCurrent.MapData[Player.playerOne.PlayerRow].Count() - 1) && ConsoleKey.RightArrow == ckDirection))
            //{
            //    if (ConsoleKey.UpArrow == ckDirection)
            //    {
            //        Map.CheckMapTile(Map.mapCurrent.MapData[Player.playerOne.PlayerRow - 1][Player.playerOne.PlayerCol].TileSymbol);
            //        if (true == Map.mapCurrent.MapData[Player.playerOne.PlayerRow - 1][Player.playerOne.PlayerCol].IsPassable)
            //        {
            //            //Replace player token with underlying tile.
            //            Map.ReplaceTile(Player.playerOne.TileUnderPlayer, Player.playerOne.PlayerRow, Player.playerOne.PlayerCol);

            //            //Save next map tile as underlying.
            //            Player.playerOne.TileUnderPlayer = Map.mapCurrent.MapData[Player.playerOne.PlayerRow - 1][Player.playerOne.PlayerCol];

            //            //Move player token.
            //            Map.ReplaceTile(new MapTile(Player.playerOne.PlayerToken), Player.playerOne.PlayerRow -= 1, Player.playerOne.PlayerCol);
            //        }
            //        else
            //        {
            //            //Map.CheckMapTile sets the reason player can't proceed.

            //        }
            //    }
            //    else if (ConsoleKey.DownArrow == ckDirection)
            //    {
            //        Map.CheckMapTile(Map.mapCurrent.MapData[Player.playerOne.PlayerRow + 1][Player.playerOne.PlayerCol].TileSymbol);
            //        if (true == Map.mapCurrent.MapData[Player.playerOne.PlayerRow + 1][Player.playerOne.PlayerCol].IsPassable)
            //        {
            //            Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol] = new MapTile(Player.playerOne.PlayerUnderlyingTile);
            //            Player.playerOne.PlayerUnderlyingTile = Map.mapCurrent.MapData[Player.playerOne.PlayerRow + 1][Player.playerOne.PlayerCol].TileSymbol;
            //            Map.mapCurrent.MapData[Player.playerOne.PlayerRow += 1][Player.playerOne.PlayerCol] = new MapTile(Player.playerOne.PlayerToken);
            //        }
            //        else
            //        {
            //            //Map.CheckMapTile sets the reason player can't proceed.

            //        }

            //    }
            //    else if (ConsoleKey.LeftArrow == ckDirection)
            //    {
            //        Map.CheckMapTile(Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol - 1].TileSymbol);
            //        if (true == Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol - 1].IsPassable)
            //        {
            //            Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol] = new MapTile(Player.playerOne.PlayerUnderlyingTile);
            //            Player.playerOne.PlayerUnderlyingTile = Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol - 1].TileSymbol;
            //            Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol -= 1] = new MapTile(Player.playerOne.PlayerToken);
            //        }
            //        else
            //        {
            //            //Map.CheckMapTile sets the reason player can't proceed.

            //        }
            //    }
            //    else if (ConsoleKey.RightArrow == ckDirection)
            //    {
            //        Map.CheckMapTile(Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol + 1].TileSymbol);
            //        if (true == Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol + 1].IsPassable)
            //        {
            //            Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol] = new MapTile(Player.playerOne.PlayerUnderlyingTile);
            //            Player.playerOne.PlayerUnderlyingTile = Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol + 1].TileSymbol;
            //            Map.mapCurrent.MapData[Player.playerOne.PlayerRow][Player.playerOne.PlayerCol += 1] = new MapTile(Player.playerOne.PlayerToken);
            //        }
            //        else
            //        {
            //            //Map.CheckMapTile sets the reason player can't proceed.

            //        }
            //    }
            //}
            //else
            //{
            //    UI.sMsg1 = UI.sEdgeOfMap;
            //}

            //UI.ReloadUI(pCurrentPlayer);

        }
    }
}
