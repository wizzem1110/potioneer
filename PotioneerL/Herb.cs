namespace PotioneerL;

public class Herb
{
    public Herb(string name, Reagent reagent, int catalyticProp)
    {
        Name = name;
        MainReagent = reagent;
        CatalyticProperty = catalyticProp;
    }

    public Herb(string name, Reagent reagent)
    {
        Name = name;
        MainReagent = reagent;
        CatalyticProperty = 0;
    }

    public string Name { get; }
    public Reagent MainReagent { get; }

    public int CatalyticProperty { get; }

    public override string ToString()
    {
        return Name;
    }

    /*private static readonly Random Rng = new();

    public Herb(string name, Trait main, Trait sec)
    {
        Name = name;
        var mainAmount = 0.25 + Rng.NextDouble() * 0.25;
        var secAmount = 0.25 - Rng.NextDouble() * 0.25;
        Primary = new Ingredient(main, Math.Round(mainAmount, 5));
        Secondary = new Ingredient(sec, Math.Round(secAmount, 5));
        Terciary = new Ingredient(Trait.Water, 1 - (mainAmount + secAmount));
    }

    public string Name { get; }
    public Ingredient Primary { get; }
    public Ingredient Secondary { get; }
    public Ingredient Terciary { get; }
*/
}