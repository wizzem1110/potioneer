namespace PotioneerL;

public class Reagent : IComparable<Reagent>
{
    public Reagent(int id, string name, int strength, int polarity)
    {
        Id = id;
        Name = name;
        Strength = strength;
        Polarity = polarity;
    }

    public Reagent(Reagent reagent) : this(reagent.Id, reagent.Name, reagent.Strength, reagent.Polarity) { }

    public Reagent() : this(-1, "default", 0, 0) { }

    public int Id { get; }

    public string Name { get; }

    public int Strength { get; }

    public int Polarity { get; }

    public int CompareTo(Reagent? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Strength.CompareTo(other.Strength);
    }
}