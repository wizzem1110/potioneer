using System;

namespace Potioneer
{
    public enum Trait
    {
        Water,
        Healing,
        Poisonous,
        Cleansing,
        Dizzying,
        Warming,
        Cooling
        //some placeholders here
    }

    public class Ingredient
    {
        public Trait Trait { get; }
        public double Amount { get; private set; }
        public Ingredient(Trait t, double a)
        {
            Trait = t;
            Amount = a;
        }

        public Ingredient(Ingredient ing)
        {
            Trait = ing.Trait;
            Amount = ing.Amount;
        }

        public void Increase(double x) => Amount += x;

        public void Print() => Console.WriteLine($"{Trait}, {Amount:0.00}");
    }

    public class Herb
    {
        private static readonly Random rng = new();
        public string Name { get; }
        public Ingredient Primary { get; }
        public Ingredient Secondary { get; }
        public Ingredient Terciary { get; }
        public Herb(string name, Trait main, Trait sec)
        {
            Name = name;
            var mainAmount = 0.25 + rng.NextDouble() * 0.25;
            var secAmount = 0.25 - rng.NextDouble() * 0.25;
            Primary = new Ingredient(main, Math.Round(mainAmount, 2));
            Secondary = new Ingredient(sec, Math.Round(secAmount, 2));
            Terciary = new Ingredient(Trait.Water, 1 - (mainAmount + secAmount));
        }

        public void Print() => Console.WriteLine($"- {Name}");
    }

    public class Potion
    {
        private List<Herb> HerbsList { get; set; }
        private List<Ingredient> Ingredients { get; set; }

        public Potion()
        {
            HerbsList = new List<Herb>();
            Ingredients = new List<Ingredient>();
        }

        public void MixHerb(Herb herb)
        {
            if (herb == null)
                Program.WriteLineColored("Unidentified herb", ConsoleColor.Red);
            
            else
            {
                HerbsList.Add(herb);
                Add(herb.Primary);
                Add(herb.Secondary);
                Add(herb.Terciary);
            }
        }

        private void Add(Ingredient herbIng)
        {
            foreach (var ing in Ingredients)
            {
                if (ing.Trait == herbIng.Trait)
                {
                    ing.Increase(herbIng.Amount);
                    return;
                }
            }
            Ingredients.Add(new Ingredient(herbIng));
        }

        public int HerbsCount => HerbsList.Count;

        public bool IsValid()
        {
            var sum = 0.0;
            foreach (var ing in Ingredients)
            {
                if (ing.Trait != Trait.Water)
                {
                    sum += ing.Amount;
                }
            }
            foreach (var ing in Ingredients)
            {
                if (ing.Trait != Trait.Water && ing.Amount / sum > 0.5)
                {
                    Program.WriteLineColored($"You have found {ing.Trait} potion!", ConsoleColor.Magenta);
                    return true;
                }
            }
            Program.WriteLineColored("You found an invalid potion", ConsoleColor.Red);
            return false;
        }

        public void Print()
        {
            foreach (var herb in HerbsList)
                herb.Print();
            Console.WriteLine();
            foreach (var ing in Ingredients)
                if (ing.Trait != Trait.Water) ing.Print();
        }
    }

    public class Game
    {
        public List<Herb> HerbsList { get; }
        public List<Potion> ValidPotionList { get; }
        public Game()
        {
            HerbsList = new()
            {
                new Herb("belladonna",  (Trait)2, (Trait)4),
                new Herb("daffodil",    (Trait)1, (Trait)4),
                new Herb("dahlia",      (Trait)1, (Trait)2),
                new Herb("mandrake",    (Trait)2, (Trait)1),
                new Herb("thistle",     (Trait)3, (Trait)4),
                new Herb("wolfsbane",   (Trait)2, (Trait)3),
            };

            ValidPotionList = new();
        }
    }

    public class Program
    {
        private static Game game;
        private static readonly Random rng = new();
        private static readonly string quitCommand = "quit";
        private static readonly string helpCommand = "help";
        private static readonly string clearCommand = "clear";
        private static readonly string defaultHerbCommand = "q";

        public static void WriteLineColored(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        private static Herb StringToHerb(string query)
        {
            if (query == defaultHerbCommand)
                return game.HerbsList[rng.Next(game.HerbsList.Count)];
            foreach (var herb in game.HerbsList)
            {
                if (query == herb.Name)
                {
                    return herb;
                }
            }
            return null;
        }

        static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Available herbs:");
            foreach (var herb in game.HerbsList)
                herb.Print();
            Console.WriteLine();
        }

        static bool? QueryProcessing(string query)
        {
            if (query is null) return false;
            if (query == quitCommand) return null;
            if (query == clearCommand)
            {
                Console.Clear();
                return false;
            }
            if (query == helpCommand)
            {
                PrintHelp();
                return false;
            }
            return true;
        }

        static void Main()
        {
            game = new Game();

            while (true)
            {
                var newGameFlag = false;
                Console.Clear();
                Console.WriteLine("Welcome!");
                var potion = new Potion();

                while (potion.HerbsCount < 3)
                {
                    WriteLineColored("Enter ingredient name:", ConsoleColor.Yellow);
                    var query = Console.ReadLine();
                    var result = QueryProcessing(query);

                    if (result == false) continue;
                    if (result == null) return;

                    var herb = StringToHerb(query);
                    potion.MixHerb(herb);
                }

                Console.WriteLine();
                if (potion.IsValid())
                {
                    Console.WriteLine();
                    WriteLineColored("Potion is ready, here is what inside:", ConsoleColor.Green);
                    potion.Print();
                }
                Console.WriteLine();

                while (!newGameFlag)
                {
                    Console.WriteLine("Press ENTER to start again\nEnter \"{0}\" to exit", quitCommand);

                    if (QueryProcessing(Console.ReadLine()) == null)
                    {
                        break;
                    }
                    else
                    {
                        newGameFlag = true;
                        continue;
                    }
                }

                if (!newGameFlag) break;
            }
        }
    }
}