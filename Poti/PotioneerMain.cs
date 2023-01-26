namespace Poti;

internal static class PotioneerMain
{
    /// <summary>
    ///     Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var form = new PotioneerForm();
        Application.Run(form);
    }
}