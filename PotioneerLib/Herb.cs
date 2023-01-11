namespace PotioneerLib
{
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

        //public void Print() => Console.WriteLine($"- {Name}");

        public override string ToString() => $"{Name}";
    }
}