namespace PotioneerL;

public class Compound : IEquatable<Compound>
{
    public Compound(Reagent positiveReagent, Reagent negativeReagent)
    {
        if (positiveReagent.Polarity != negativeReagent.Polarity)
        {
            PosReagent = positiveReagent;
            NegReagent = negativeReagent;
        }
        else
        {
            throw new ArgumentException("Both reagents have same polarity");
        }
    }

    public override string ToString()
    {
        return $"{nameof(PosReagent)}: {PosReagent}, {nameof(NegReagent)}: {NegReagent}";
    }

    private Reagent PosReagent { get; }
    private Reagent NegReagent { get; }


    public bool Equals(Compound? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return PosReagent.Equals(other.PosReagent) && NegReagent.Equals(other.NegReagent);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Compound)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PosReagent, NegReagent);
    }
}