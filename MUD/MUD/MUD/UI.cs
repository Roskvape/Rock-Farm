using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    class UI
    {
        //Game Title
        public static string sGameTitle = "Magic Mud".ToUpper();

        //Fixed Messages
        public static readonly string sDefaultMoving = "Use arrow keys to move.";
        public static readonly string sImpassable = "You can't move there!";
        public static readonly string sEdgeOfMap = "You can't walk off the map!";
        public static readonly string sWater = "You can't swim!";
        public static readonly string sMountain = "You can't climb mountains!";
        public static readonly string sStone = "You picked up a stone!";
        public static readonly string sWall = "This is a wall!";

        //Dynamic Messages
        public static string sMsg1 = sDefaultMoving;
        public static Object[] sPlayerTag = new Object[] { Program.PlayerOne.PlayerName, ConsoleColor.DarkGray, ConsoleColor.White };
        public static string sMsg2 = "I can say stuff, too.";

        //Special UI Characters
        private const string sTopLeft = "\u250C";
        private const string sTopRight = "\u2510";
        private const string sMidLeft = "\u255E";
        private const string sMidRight = "\u2561";
        private const string sBottomLeft = "\u2514";
        private const string sBottomRight = "\u2518";
        private const string sSideBarSymbol = "\u2502";

        //Special Prefab Sidebars
        public const string sSideBarLeft = " \u2502";
        public const string sSideBarRight = "\u2502\n";

        public static void ReloadUI(Player pCurrentPlayer)
        {
            Console.Clear();
            LoadUI(pCurrentPlayer);
        }

        private static void UIColor(string sText, ConsoleColor sBGColor, ConsoleColor sFGColor)
        {
            Console.BackgroundColor = sBGColor;
            Console.ForegroundColor = sFGColor;
            Console.Write(sText);
            Console.ResetColor();
        }

        private static void UIHPColor(Player pCurrentPlayer)
        {
            if (9 <= pCurrentPlayer.PlayerHealth)
            {
                UIColor(Convert.ToString(pCurrentPlayer.PlayerHealth), ConsoleColor.Black, ConsoleColor.Green);
            }
            if (9 > pCurrentPlayer.PlayerHealth && 4 < pCurrentPlayer.PlayerHealth)
            {
                UIColor(Convert.ToString(pCurrentPlayer.PlayerHealth), ConsoleColor.Black, ConsoleColor.DarkYellow);
            }
            if (4 >= pCurrentPlayer.PlayerHealth)
            {
                UIColor(Convert.ToString(pCurrentPlayer.PlayerHealth), ConsoleColor.Black, ConsoleColor.Red);
            }
        }

        private static void UIInvColor(int iInv)
        {
            if (9 == iInv)
            {
                UIColor(Convert.ToString(iInv), ConsoleColor.Black, ConsoleColor.Red);
            }
            if (9 > iInv && 6 < iInv)
            {
                UIColor(Convert.ToString(iInv), ConsoleColor.Black, ConsoleColor.DarkYellow);
            }
            if (6 >= iInv)
            {
                UIColor(Convert.ToString(iInv), ConsoleColor.Black, ConsoleColor.Green);
            }
        }

        public static void LoadUI(Player pCurrentPlayer)
        {
            //Game Title
            Console.Write(UIHorizontalBorderBuilder("top", "double"));
            Console.Write(sSideBarLeft);
            UIColor(UIPadding(sGameTitle), ConsoleColor.DarkGray, ConsoleColor.White);
            Console.Write(sSideBarRight);
            Console.Write(UIHorizontalBorderBuilder("bottom", "double"));

            //Top border
            Console.Write(UIHorizontalBorderBuilder("top", "single"));


            //Map with left and right borders
            Map.PrintMap();

            //Bottom border
            Console.Write(UIHorizontalBorderBuilder("mid", "double"));


            //Stats
            // Console.Write(UIAddBorders($"{pCurrentPlayer.PlayerHealth}HP | 9/9INV"));
            Console.Write(sSideBarLeft);
            UIHPColor(pCurrentPlayer);
            Console.Write("HP");
            for (int i = 0; i < (Map.iMapWidth - 9); i++)
            {
                Console.Write(" ");
            }
            UIInvColor(7);
            Console.Write("/9INV");
            Console.Write(sSideBarRight);

            //Messages
            Console.Write(UIHorizontalBorderBuilder("mid", "double"));
            Console.Write(UIAddBorders(UI.sMsg1));
            Console.Write(UIAddBorders(UI.sMsg2));
            Console.Write(UIHorizontalBorderBuilder("mid", "single"));

            Console.Write(sSideBarLeft);
            UIColor(UIPadding((string)sPlayerTag[0]), (ConsoleColor)sPlayerTag[1], (ConsoleColor)sPlayerTag[2]);
            Console.Write(sSideBarRight);

            Console.Write(UIHorizontalBorderBuilder("bottom", "single"));
        }

        public static string UIMapFormatting(string sMapLine)
        {
            string sMapLineFormatted = $"{sSideBarLeft}{sMapLine}{sSideBarRight}";
            return sMapLineFormatted;
        }

        public static string UIPadding(string sInput)
        {
            string sPaddedMsg = "";
            string sPaddingLeft = "";
            string sPaddingRight = "";

            for (int i = 0; i < ((Map.iMapWidth - sInput.Length) / 2); i++)
            {
                sPaddingLeft += " ";
            }

            if (sInput.Length % 2 == 0)
            {
                sPaddingRight = sPaddingLeft + " ";
            }
            else
            {
                sPaddingRight = sPaddingLeft;
            }

            sPaddedMsg = $"{sPaddingLeft}{sInput}{sPaddingRight}";
            return sPaddedMsg;
        }

        public static string UIAddBorders(string sInput)
        {
            string sMsgWithBorders = $"{sSideBarLeft}{UI.UIPadding(sInput)}{sSideBarRight}";
            return sMsgWithBorders;
        }

        public static string UIBorderSpan(string sStyle)
        {
            string sBorderSpan = "";
            for (int i = 0; i < Map.iMapWidth; i++)
            {
                if (sStyle == "single")
                {
                    sBorderSpan = $"{sBorderSpan}\u2500";
                }
                else
                {
                    sBorderSpan = $"{sBorderSpan}\u2550";
                }
            }
            return sBorderSpan;
        }

        public static string UIHorizontalBorderBuilder(string sDividerPosition, string sDividerStyle)
        {
            string sHorizBorder = "";

            switch (sDividerPosition)
            {
                case "top":
                    sHorizBorder = $" {sTopLeft}{UIBorderSpan(sDividerStyle)}{sTopRight}\n";
                    break;
                case "mid":
                    sHorizBorder = $" {sMidLeft}{UIBorderSpan(sDividerStyle)}{sMidRight}\n";
                    break;
                case "bottom":
                    sHorizBorder = $" {sBottomLeft}{UIBorderSpan(sDividerStyle)}{sBottomRight}\n";
                    break;
                default:
                    sHorizBorder = $"no{UIBorderSpan(sDividerStyle)}no\n";
                    break;
            }

            return sHorizBorder;
        }

    }
}
