namespace Poti;

public partial class HelpForm : Form
{
    private readonly string help =
        "Help will be later";

    public HelpForm()
    {
        InitializeComponent();
        Size = new Size(400, 200);
        Text = "Help";
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(new Label
        {
            Size = Size,
            Text = help
        });
    }
}