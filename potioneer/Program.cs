using System;

namespace Potioneer
{
    public enum Trait
    {
        Healing,
        Poisonous,
        Cleansing,
        Dizzying,
        Warming,
        Cooling,
        Gold
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

        public void Increase(double x)
        {
            Amount += x;
        }

        public void Print()
        {
            Console.WriteLine($"{Trait}, {Amount:0.00}");
        }
    }

    public class Herb
    {
        public string Name { get; }
        public Ingredient Main { get; }
        public Ingredient Secondary { get; }
        public Ingredient Terciary { get; }
        public Herb(string name, Trait main, double mainAmount, Trait sec, double secAmount)
        {
            Name = name;
            Main = new Ingredient(main, mainAmount);
            Secondary = new Ingredient(sec, secAmount);
            Terciary = new Ingredient(Trait.Gold, 1 - (mainAmount + secAmount));
        }
        public void Print()
        {
            Console.WriteLine($"\t{Name}");
            //Console.WriteLine($"{Name}, {Main.Trait}");
        }
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
            HerbsList.Add(herb);
            Add(herb.Main);
            Add(herb.Secondary);
            Add(herb.Terciary);
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
            Ingredients.Add(herbIng);
        }

        public int HerbsCount
        {
            get => HerbsList.Count();
        }

        public void Print()
        {
            foreach (var herb in HerbsList)
            {
                herb.Print();
            }
            Console.WriteLine();
            foreach (var ing in Ingredients)
            {
                ing.Print();
            }
        }
    }

    public class Program
    {
        static void WriteLineColored(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        static List<Herb> Initialize()
        {
            var herbs = new List<Herb>
            {
                new Herb("belladonna", Trait.Poisonous, 0.40, Trait.Dizzying, 0.50),
                new Herb("daffodil", Trait.Healing, 0.60, Trait.Dizzying, 0.20),
                new Herb("dahlia", Trait.Healing, 0.30, Trait.Poisonous, 0.30),
                new Herb("mandrake", Trait.Poisonous, 0.90, Trait.Healing, 0.05),
                new Herb("thistle", Trait.Cleansing, 0.50, Trait.Dizzying, 0.15),
                new Herb("wolfsbane", Trait.Poisonous, 0.80, Trait.Cleansing, 0.15)
                //To add:
                //goatweed, poppy, hemp, hop
                //mint, melissa, rosehip, thyme
                //lily-of-the-valley, nettles
            };
            return herbs;
        }

        static void MixTo(string query, List<Herb> herbs, Potion potion)
        {
            foreach (var herb in herbs)
            {
                if (query == herb.Name)
                {
                    potion.MixHerb(herb);
                    return;
                }
            }
            WriteLineColored("Unidentified herb, try something else", ConsoleColor.Red);
        }

        static void Main()
        {
            while (true)
            {
                var newGameFlag = false;
                Console.Clear();
                Console.WriteLine("Welcome!");
                var herbs = Initialize();
                var potion = new Potion();
                while (potion.HerbsCount < 3)
                {
                    WriteLineColored("Enter ingredient name:", ConsoleColor.Yellow);
                    var query = Console.ReadLine();
                    if (query == "help")    //should be printed at the start
                    {
                        Console.WriteLine("Available herbs:");
                        foreach (var herb in herbs)
                            herb.Print();
                        Console.WriteLine();
                        query = Console.ReadLine();
                    }
                    if (query == "q" || query is null)
                        query = herbs[potion.HerbsCount].Name;
                    MixTo(query, herbs, potion);
                }

                WriteLineColored("All 3 herbs successfully added, here they are:", ConsoleColor.Green);
                potion.Print();

                while (!newGameFlag)
                {
                    Console.WriteLine("Want to play again? y/n");
                    var decision = Console.ReadLine();
                    if (decision == "n")
                    {
                        break;
                    }
                    else if (decision == "y")
                    {
                        newGameFlag = true;
                        continue;
                    }
                    else
                    {
                        //Console.Clear();
                        Console.WriteLine("Unknown command");
                    }
                }

                if (!newGameFlag) break;
            }
        }
    }
}