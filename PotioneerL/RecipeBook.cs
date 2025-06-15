namespace MonoGamePotioneer;

using static Utility;

public class RecipeBook
{
    private const string DefaultPath = "recipes.txt";

    public RecipeBook(string path)
    {
        Recipes = ReadData(path);
    }

    public RecipeBook() : this(DefaultPath)
    {
    }

    private Dictionary<(int, int), int> Recipes { get; }

    private static Dictionary<(int, int), int> ReadData(string path)
    {
        var dict = new Dictionary<(int, int), int>();
        var data = ReadFile(path);
        foreach (var entry in data)
        {
            var ids = entry
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var value = ids[^1];
            var key = (ids[0], ids[1]);
            dict.Add(key, value);
        }

        return dict;
    }

    public int Make((int, int) key)
    {
        if (Recipes.ContainsKey(key))
            return Recipes[key];
        throw new ArgumentException("No recipe with such ingredients");
    }
}