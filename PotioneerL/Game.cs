namespace PotioneerL;

public class Game
{
    public Game()
    {
        ReagentsList = new List<Reagent>
        {
            new(0, "Death", 4, -1),
            new(1, "Life", 2, 1),
            new(2, "Warmth", 1, 1),
            new(3, "Cold", 2, -1),
            new(4, "Empower", 3, 1)
        };

        HerbsList = new List<Herb>
        {
            new("belladonna", ReagentsList[0], 1),
            new("daffodil", ReagentsList[1]),
            new("dahlia", ReagentsList[2]),
            new("thistle", ReagentsList[2], -1),
            new("wolfsbane", ReagentsList[3]),
            new("mandrake", ReagentsList[4])
        };

        ValidPotions = new Dictionary<(int, int), string>
        {
            { (0, 1), "Resurrection" },
            { (0, 2), "Incineration" },
            { (0, 4), "Raise Dead" },
            { (1, 3), "Stasis" },
            { (2, 3), "Explosion" },
            { (3, 4), "Eternal Winter" }
        };

        CurrentPotion = new Potion();
    }

    public List<Herb> HerbsList { get; }
    private List<Reagent> ReagentsList { get; }
    private Dictionary<(int, int), string> ValidPotions { get; }
    public Potion CurrentPotion { get; private set; }

    public void ResetPotion()
    {
        CurrentPotion = new Potion();
    }

    public string ReturnPotion()
    {
        var key = CurrentPotion.Finish();

        return key is not null
            ? ValidPotions[key.Value]
            : "Blunt";
    }
}