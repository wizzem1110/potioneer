namespace PotioneerL;

public class Potion
{
    public Potion()
    {
        Reagents = new List<Reagent>();
        // Herbs = new List<Herb>();
        ReactionSpeed = 0;
    }

    // private List<Herb> Herbs { get; }
    private List<Reagent> Reagents { get; }

    public int ReactionSpeed { get; private set; }

    public void AddHerb(Herb herb)
    {
        // Herbs.Add(herb);
        Reagents.Add(herb.MainReagent);
        ReactionSpeed += herb.CatalyticProperty;
    }

    public void RemoveStrongest(int polarity)
    {
        if (Reagents.All(x => x.Polarity != polarity))
            return;
        Reagents.Remove(Reagents.Where(x => x.Polarity == polarity).Max()
                        ?? throw new InvalidOperationException());
    }

    public (int, int)? Finish()
    {
        var reagent1 = Reagents.Where(x => x.Polarity < 0).Max();
        var reagent2 = Reagents.Where(x => x.Polarity > 0).Max();
        return reagent1 is null || reagent2 is null ? null : (reagent1.Id, reagent2.Id);
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}