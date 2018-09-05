using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    class Program
    {
        public static Player PlayerOne = new Player();

        public static void Main(string[] args)
        {
            //Map.ImportMap();
            //int[] iStart = Map.LocateStartingPoint();
            //Console.WriteLine("Player starts at row {0} and col {1}", iStart[0], iStart[1]);


            //public static void ConsoleOutputTest()
            //{

            //Console.WriteLine('\u2518');

            //    Console.ReadKey();
            //}


            //Type type = typeof(ConsoleColor);
            //Console.ForegroundColor = ConsoleColor.White;
            //foreach (var name in Enum.GetNames(type))
            //{
            //    Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, name);
            //    Console.WriteLine(name);
            //}
            //Console.BackgroundColor = ConsoleColor.Black;
            //foreach (var name in Enum.GetNames(type))
            //{
            //    Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
            //    Console.WriteLine(name);
            //}

            ////Test MapTile Class
            //string sInput = "";
            //ConsoleKey ckInput = ConsoleKey.E;

            //while (ckInput != ConsoleKey.Escape)
            //{
            //    Console.WriteLine("Enter a symbol to test.");
            //    sInput = Console.ReadLine();
            //    MapTile mtCheck = new MapTile(sInput);
            //    MapTile.TestTile(mtCheck);
            //}


            ConsoleKey ckInput = ConsoleKey.E;

            Console.WriteLine("Please enter your name:");
            PlayerOne.PlayerName = Console.ReadLine();
            Console.WriteLine("Hello, " + PlayerOne.PlayerName + "! You have " + PlayerOne.PlayerHealth + " health.");
            Console.WriteLine("You will be represented as \"" + PlayerOne.PlayerToken + "\" on the screen.");
            Console.WriteLine("Use the arrow keys to navigate the map.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Map.ImportMap();
            //Map.PrintMap();
            //Console.ReadKey();

            //Spawn player
            Player.sPlayerRow = Map.iStart[0];
            Player.sPlayerCol = Map.iStart[1];
            Map.sMap[Player.sPlayerRow][Player.sPlayerCol] = new MapTile(PlayerOne.PlayerToken);
            UI.ReloadUI(PlayerOne);

            while (ckInput != ConsoleKey.Escape)
            {
                ckInput = Console.ReadKey().Key;
                if (ConsoleKey.UpArrow == ckInput || ConsoleKey.DownArrow == ckInput || ConsoleKey.LeftArrow == ckInput || ConsoleKey.RightArrow == ckInput)
                {
                    Player.MovePlayer(ckInput, PlayerOne);
                }

            }
            if (ckInput == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.ReadKey();
        }
    }
}
