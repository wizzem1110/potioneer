namespace MonoGamePotioneer;

public abstract class TypeParser
{
    public static Type ParseType(string type)
    {
        return type switch
        {
            "Herb" => Type.Herb,
            "Metal" => Type.Metal,
            "Nonmetal" => Type.Nonmetal,
            "Mineral" => Type.Mineral,
            "Concoction" => Type.Concoction,
            "Alloy" => Type.Alloy,
            _ => Type.None
        };
    }
}