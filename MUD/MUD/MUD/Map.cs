using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    class Map
    {
        public static string[] sMapData = System.IO.File.ReadAllLines("MapData.txt");
        public static string[][] sMapTemp = new string[sMapData.Count()][];
        public static MapTile[][] sMap = new MapTile[sMapData.Count()][];
        public static int iMapWidth = 0;
        public static int[] iStart = new int[] { 0, 0 };

        public static void ImportMap()
        {
            int iMapReadIncrementer = 0;

            foreach (string s in sMapData)
            {
                sMapTemp[iMapReadIncrementer] = s.Split(' ');
                iMapReadIncrementer++;
            }
            iMapWidth = (sMapTemp[0].Count() * 2) + 1;

            //Console.WriteLine(sMapTemp.Length);
            //Console.WriteLine(sMapTemp[0].Length);
            //Console.WriteLine(sMapTemp.Count());
            //Console.WriteLine(sMapTemp[0].Count());
            //Console.ReadKey();
            ConvertMapToMapTiles();
        }

        public static void ConvertMapToMapTiles()
        {
            for (int row = 0; row < sMapTemp.Length; row++)
            {
                sMap[row] = new MapTile[sMapTemp[0].Length];
                for (int col = 0; col < sMapTemp[0].Length; col++)
                {
                    sMap[row][col] = new MapTile(sMapTemp[row][col]);
                }
            }
            //Console.WriteLine(sMap.Length);
            //Console.WriteLine(sMap[0].Length);
            //Console.WriteLine(sMap.Count());
            //Console.WriteLine(sMap[0].Count());
            //Console.ReadKey();
            iStart = LocateStartingPoint();
        }

        public static void PrintMap()
        {
            //Map with left and right borders
            for (int i = 0; i < sMap.Length; i++)
            {
                Console.Write(UI.sSideBarLeft);
                Console.Write(" ");

                for (int x = 0; x < sMap[i].Count(); x++)
                {
                    Console.ForegroundColor = sMap[i][x].TileForeGroundColor;
                    Console.BackgroundColor = sMap[i][x].TileBackGroundColor;
                    Console.Write(sMap[i][x].TileSymbol);
                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.Write(UI.sSideBarRight);
            }
        }

        public static int CheckMapTile(string sSymbol)
        {
            //0 = Passable, non-interactable
            //1 = Passable, interactable
            //2 = Impassable, non-interactable
            //3 = Impassable, interactable
            switch (sSymbol)
            {
                case "#":
                    UI.sMsg1 = UI.sWall;
                    return 3;
                case "^":
                    UI.sMsg1 = UI.sMountain;
                    return 2;
                case "~":
                    UI.sMsg1 = UI.sWater;
                    return 2;
                case "*":
                    UI.sMsg1 = UI.sStone;
                    return 1;
                default:
                    UI.sMsg1 = UI.sDefaultMoving;
                    return 0;
            }
        }

        public static int[] LocateStartingPoint()
        {
            int[] iPlayerStartCoords = { 0, 0 };
            int iStartRow = 0;
            int iStartCol = 0;

            for (int i = 0; i < sMapTemp.Length; i++)
            {

                if (-1 != Array.IndexOf(sMapTemp[i], "@"))
                {
                    iStartRow = i;
                    iStartCol = Array.IndexOf(sMapTemp[i], "@");
                    break;
                }
            }

            iPlayerStartCoords[0] = iStartRow;
            iPlayerStartCoords[1] = iStartCol;

            return iPlayerStartCoords;
        }

        //public static int CheckMapTile(string sTile)
        //{
        //    //0 = Passable, non-interactable
        //    //1 = Passable, interactable
        //    //2 = Impassable, non-interactable
        //    //3 = Impassable, interactable

        //    switch (sTile)
        //    {
        //        case "#":
        //            UI.sMsg1 = UI.sWall;
        //            return 3;
        //        case "^":
        //            UI.sMsg1 = UI.sMountain;
        //            return 2;
        //        case "~":
        //            UI.sMsg1 = UI.sWater;
        //            return 2;
        //        case "*":
        //            UI.sMsg1 = UI.sStone;
        //            return 1;
        //        default:
        //            UI.sMsg1 = UI.sDefaultMoving;
        //            return 0;
        //    }

        //}

        //public static void PrintMap()
        //{

        //    //Map with left and right borders
        //    for (int i = 0; i < sMap.Length; i++)
        //    {
        //        Console.Write(" " + '\u2502' + " ");
        //        for (int x = 0; x < sMap[i].Count(); x++)
        //        {
        //            Console.Write(sMap[i][x] + " ");
        //        }
        //        Console.Write('\u2502' + "\n");
        //    }
        //}

        //public static void PrintMapASCII()
        //{
        //    Console.Write(" ");
        //    for (int i = 0; i < ((sMap[0].Count() * 2) + 2); i++)
        //    {
        //        Console.Write("_");
        //    }
        //    Console.Write("\n");
        //    for (int i = 0; i < sMap.Length; i++)
        //    {
        //        Console.Write(" |");
        //        for (int x = 0; x < sMap[i].Count(); x++)
        //        {
        //            Console.Write(sMap[i][x] + " ");
        //        }
        //        Console.Write("|\n");
        //    }
        //    Console.Write(" ");
        //    for (int i = 0; i < ((sMap[0].Count() * 2) + 2); i++)
        //    {
        //        Console.Write("=");
        //    }
        //    Console.Write("\n");
        //}
    }
}
