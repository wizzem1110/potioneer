using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            HerbsList.Add(herb);
            Add(herb.Primary);
            Add(herb.Secondary);
            Add(herb.Terciary);
        }

        private void Add(Ingredient herbIng)
        {
            foreach (var ing in Ingredients)
            {
                if (ing.Trait != 0 && (int)ing.Trait == -(int)herbIng.Trait)
                {
                    Add(new Ingredient(0, ing.Amount + herbIng.Amount));
                    Ingredients.Remove(ing);
                    return;
                }

                if (ing.Trait == herbIng.Trait)
                {
                    ing.Increase(herbIng.Amount);
                    return;
                }
            }
            Ingredients.Add(new Ingredient(herbIng));
        }

        public void Distill()
        {
            foreach (var ing in Ingredients)
                if (ing.Trait == 0)
                {
                    Ingredients.Remove(ing);
                    return;
                }
        }

        public int HerbsCount => HerbsList.Count;

        public (string S, Color C) Output()
        {
            var inv = ("You found an invalid potion", Color.Red);

            if (Ingredients.Count <= 1)
                return inv;

            var trait = Ingredients
                .Where(x => Math.Abs(x.Amount - Ingredients.Select(y => y.Amount).Max()) < 10e-3)
                .Select(x => x.Trait)
                .FirstOrDefault();

            return trait == 0 ? inv : ($"You have found {trait} potion!", Color.Magenta);
        }

        public override string ToString() => Ingredients.Select(x => x.Amount).Max().ToString();
    }
}