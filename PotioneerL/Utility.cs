namespace MonoGamePotioneer;

public static class Utility
{
    public static List<string> ReadFile(string path)
    {
        return File.ReadAllLines(path).ToList();
    }
}