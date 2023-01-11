namespace PotioneerLib
{
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

        //public void Print() => Console.WriteLine($"{Trait}, {Amount:0.00}");

        public override string ToString() => $"{Trait}";  //$"{Trait}, {Amount:0.00}";
    }
}