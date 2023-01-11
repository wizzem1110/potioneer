namespace PotioneerL
{
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
                MainMain.WriteLineColored("Unidentified herb", ConsoleColor.Red);
            
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
                    MainMain.WriteLineColored($"You have found {ing.Trait} potion!", ConsoleColor.Magenta);
                    return true;
                }
            }
            MainMain.WriteLineColored("You found an invalid potion", ConsoleColor.Red);
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
}