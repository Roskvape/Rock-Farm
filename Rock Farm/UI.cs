using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class UI
    {
        //Static variables
        public static UI uiDefault;

        //Special Prefab Sidebars
        public const string sSideBarLeft = " " + sSideBarSymbol;
        public const string sSideBarRight = sSideBarSymbol + "\n";

        //Game Title
        public static string sGameTitle = "Stone Collector".ToUpper();

        //Fixed messages
        public static readonly string sEdgeOfMap = "You can't walk off the map!";
        public static readonly string sInvFull = "You can't carry any more.";
        public static readonly string sMove = "Use arrow keys to move.";

        //Private fields of any UI
        private string sMessage1 = sMove;
        private string sMessage2 = "";
        private Object[] sMenu = new Object[] { "UIMenu", ConsoleColor.DarkGray, ConsoleColor.White };

        //Special UI Characters
        private const string sTopLeft = "\u250C";
        private const string sTopRight = "\u2510";
        private const string sMidLeft = "\u255E";
        private const string sMidRight = "\u2561";
        private const string sBottomLeft = "\u2514";
        private const string sBottomRight = "\u2518";
        private const string sSideBarSymbol = "\u2502";

        //Constructors
        public UI()
        {

        }

        //Properties
        public string Message1
        {
            get
            {
                return sMessage1;
            }
            set
            {
                sMessage1 = value;
                UpdateMessage1();
            }
        }

        public string Message2
        {
            get
            {
                return sMessage2;
            }
            set
            {
                sMessage2 = value;
                UpdateMessage2();
            }
        }

        public string UIMenu
        {
            get
            {
                return (string)sMenu[0];
            }
        }

        //Methods
        public static void CreateUI()
        {
            uiDefault = new UI();
        }

        //public static void UIVerification(UI _UI)
        //{
        //    //Print public
        //    Console.WriteLine(sSideBarLeft);
        //    Console.WriteLine(sSideBarRight);
        //    Console.WriteLine(sGameTitle);

        //    //Print private
        //    Console.WriteLine(_UI.Message1);
        //    Console.WriteLine(_UI.Message2);
        //    Console.WriteLine(_UI.UIMenu);

        //    //Print const
        //    Console.WriteLine(sTopLeft);
        //    Console.WriteLine(sTopRight);
        //    Console.WriteLine(sMidLeft);
        //    Console.WriteLine(sMidRight);
        //    Console.WriteLine(sBottomLeft);
        //    Console.WriteLine(sBottomRight);
        //    Console.WriteLine(sSideBarSymbol);
        //}

        public static void ReloadUI(UI _ui)
        {
            Console.Clear();
            LoadUI(_ui);
        }

        public static void LoadUI(UI _ui)
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
            Map.PrintMap(Map.mapCurrent);

            //Bottom border
            Console.Write(UIHorizontalBorderBuilder("mid", "double"));


            //Stats
            // Console.Write(UIAddBorders($"{pCurrentPlayer.PlayerHealth}HP | 9/9INV"));
            Console.Write(sSideBarLeft);
            UIHPColor(Player.playerOne);
            Console.Write("HP");
            for (int i = 0; i < (Map.mapCurrent.VisualMapWidth - 9); i++)
            {
                Console.Write(" ");
            }
            UIInvColor(Player.playerOne);
            Console.Write("/9INV");
            Console.Write(sSideBarRight);

            //Messages
            Console.Write(UIHorizontalBorderBuilder("mid", "double"));
            Console.Write(UIAddBorders(_ui.sMessage1));
            Console.Write(UIAddBorders(_ui.sMessage2));
            Console.Write(UIHorizontalBorderBuilder("mid", "single"));

            Console.Write(sSideBarLeft);
            UIColor(UIPadding((string)_ui.sMenu[0]), (ConsoleColor)_ui.sMenu[1], (ConsoleColor)_ui.sMenu[2]);
            Console.Write(sSideBarRight);

            Console.Write(UIHorizontalBorderBuilder("bottom", "single"));

        }

        //Methods for updating messages
        private void UpdateMessage1()
        {
            int iCurLeft = Console.CursorLeft;
            int iCurTop = Console.CursorTop;
            Console.SetCursorPosition(0, Map.mapCurrent.VisualMapHeight + 7);
            Console.Write(UIAddBorders(sMessage1));
            Console.SetCursorPosition(iCurLeft, iCurTop);
        }

        private void UpdateMessage2()
        {
            int iCurLeft = Console.CursorLeft;
            int iCurTop = Console.CursorTop;
            Console.SetCursorPosition(0, Map.mapCurrent.VisualMapHeight + 8);
            Console.Write(UIAddBorders(sMessage2));
            Console.SetCursorPosition(iCurLeft, iCurTop);
        }

        //Methods for printing in color
        public static void UIColor(string sText, ConsoleColor sBGColor, ConsoleColor sFGColor)
        {
            Console.BackgroundColor = sBGColor;
            Console.ForegroundColor = sFGColor;
            Console.Write(sText);
            Console.ResetColor();
        }

        public static void UIHPColor(Player pCurrentPlayer)
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

        public static void UIInvColor(Player pCurrentPlayer)
        {
            if (9 == pCurrentPlayer.PlayerInventory.Count)
            {
                UIColor(Convert.ToString(pCurrentPlayer.PlayerInventory.Count), ConsoleColor.Black, ConsoleColor.Red);
            }
            if (9 > pCurrentPlayer.PlayerInventory.Count && 6 < pCurrentPlayer.PlayerInventory.Count)
            {
                UIColor(Convert.ToString(pCurrentPlayer.PlayerInventory.Count), ConsoleColor.Black, ConsoleColor.DarkYellow);
            }
            if (6 >= pCurrentPlayer.PlayerInventory.Count)
            {
                UIColor(Convert.ToString(pCurrentPlayer.PlayerInventory.Count), ConsoleColor.Black, ConsoleColor.Green);
            }
        }

        //Methods for printing borders
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

            for (int i = 0; i < ((Map.mapCurrent.VisualMapWidth - sInput.Length) / 2); i++)
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
            for (int i = 0; i < Map.mapCurrent.VisualMapWidth; i++)
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
