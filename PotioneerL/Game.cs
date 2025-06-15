using System.ComponentModel;

namespace MonoGamePotioneer;

using static Utility;

public class Game : INotifyPropertyChanged
{
    private const string DefaultPath = "data.txt";

    public Game(string path)
    {
        Data = ReadData(path);
    }

    public Game() : this(DefaultPath)
    {
    }

    protected internal List<Item> Data { get; }
    public event PropertyChangedEventHandler? PropertyChanged;

    private List<Item> ReadData(string path)
    {
        return ReadFile(path)
            .Select(entry => new Item(entry))
            .ToList();
    }
}