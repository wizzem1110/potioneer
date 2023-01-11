//using System;

//namespace PotioneerL
//{

//    public class MainMain
//    {
//        private static Game game;
//        private static readonly Random rng = new();
//        private static readonly string quitCommand = "quit";
//        private static readonly string helpCommand = "help";
//        private static readonly string clearCommand = "clear";
//        private static readonly string defaultHerbCommand = "q";

//        public static void WriteLineColored(string line, ConsoleColor color)
//        {
//            Console.ForegroundColor = color;
//            Console.WriteLine(line);
//            Console.ResetColor();
//        }

//        private static Herb StringToHerb(string query)
//        {
//            if (query == defaultHerbCommand)
//                return game.HerbsList[rng.Next(game.HerbsList.Count)];
//            foreach (var herb in game.HerbsList)
//            {
//                if (query == herb.Name)
//                {
//                    return herb;
//                }
//            }
//            return null;
//        }

//        //static void PrintHelp()
//        //{
//        //    Console.WriteLine();
//        //    Console.WriteLine("Available herbs:");
//        //    foreach (var herb in game.HerbsList)
//        //        herb.Print();
//        //    Console.WriteLine();
//        //}

//        static bool? QueryProcessing(string query)
//        {
//            if (query is null) return false;
//            if (query == quitCommand) return null;
//            if (query == clearCommand)
//            {
//                Console.Clear();
//                return false;
//            }
//            if (query == helpCommand)
//            {
//                //PrintHelp();
//                return false;
//            }
//            return true;
//        }

//        public static void Main()
//        {
//            game = new Game();

//            while (true)
//            {
//                var newGameFlag = false;
//                Console.Clear();
//                Console.WriteLine("Welcome!");
//                var potion = new Potion();

//                while (potion.HerbsCount < 3)
//                {
//                    WriteLineColored("Enter ingredient name:", ConsoleColor.Yellow);
//                    var query = Console.ReadLine();
//                    var result = QueryProcessing(query);

//                    if (result == false) continue;
//                    if (result == null) return;

//                    var herb = StringToHerb(query);
//                    potion.MixHerb(herb);
//                }

//                Console.WriteLine();
//                if (potion.IsValid())
//                {
//                    Console.WriteLine();
//                    WriteLineColored("Potion is ready, here is what inside:", ConsoleColor.Green);
//                    //potion.Print();
//                }
//                Console.WriteLine();

//                while (!newGameFlag)
//                {
//                    Console.WriteLine("Press ENTER to start again\nEnter \"{0}\" to exit", quitCommand);

//                    if (QueryProcessing(Console.ReadLine()) == null)
//                    {
//                        break;
//                    }
//                    else
//                    {
//                        newGameFlag = true;
//                        continue;
//                    }
//                }

//                if (!newGameFlag) break;
//            }
//        }
//    }
//}