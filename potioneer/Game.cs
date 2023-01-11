namespace PotioneerL
{
    public class Game
    {
        public List<Herb> HerbsList { get; }
        public List<Potion> ValidPotionList { get; }
        public Game()
        {
            HerbsList = new()
            {
                new Herb("belladonna",  (Trait)2, (Trait)4),
                new Herb("daffodil",    (Trait)1, (Trait)4),
                new Herb("dahlia",      (Trait)1, (Trait)2),
                new Herb("mandrake",    (Trait)2, (Trait)1),
                new Herb("thistle",     (Trait)3, (Trait)4),
                new Herb("wolfsbane",   (Trait)2, (Trait)3),
            };

            ValidPotionList = new();
        }
    }
}