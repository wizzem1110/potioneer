namespace MonoGamePotioneer;

public class Item
{
    public Item(int id, string name, int price, Type type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }

    public Item(string input)
    {
        var splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Id = int.Parse(splittedInput[0]);
        Name = splittedInput[1];
        Price = int.Parse(splittedInput[2]);
        Type = TypeParser.ParseType(splittedInput[3]);
    }

    public Item() : this(-1, "Item", 0, Type.None)
    {
    }

    public int Id { get; }
    public string Name { get; }
    public int Price { get; }
    public Type Type { get; }
}