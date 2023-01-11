namespace PotioneerL
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

        public override string ToString() => $"{Trait}";
    }
}