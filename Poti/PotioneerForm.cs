using PotioneerL;

namespace Poti;

public partial class PotioneerForm : Form
{
    private const int Indent = 80;
    private static readonly Size ButtonSize = new(100, 30);
    private static readonly Size FormSize = new(640, 480);
    private static readonly Size LayoutSize = new(120, 480);

    private static string _text = "";
    private readonly List<Button> buttons = new();

    private readonly Label output = new()
    {
        Location = new Point(240, 20),
        Size = new Size(215, 100),
        BackColor = Color.White,
        Font = new Font(FontFamily.GenericSerif, 12),
        TextAlign = ContentAlignment.MiddleCenter,
        Text = _text,
        BorderStyle = BorderStyle.FixedSingle
    };

    private readonly Action<Label> updateOutput = x => x.Text = _text;

    public PotioneerForm()
    {
        InitializeComponent();
        Size = FormSize;
        Text = "POTIONEER!!";
        Location = new Point(0, 0);
        StartPosition = FormStartPosition.CenterScreen;

        var game = new Game();

        var herbs = game.HerbsList;

        var primaryButtonCount = herbs.Count;

        var herbLayoutPanel = new FlowLayoutPanel
        {
            Location = new Point(120, 0),
            Size = LayoutSize,
            FlowDirection = FlowDirection.TopDown
        };
        Controls.Add(herbLayoutPanel);

        var systemLayoutPanel = new FlowLayoutPanel
        {
            Location = new Point(0, 0),
            Size = LayoutSize,
            FlowDirection = FlowDirection.TopDown
        };
        Controls.Add(systemLayoutPanel);

        var potionLayoutPanel = new FlowLayoutPanel
        {
            Location = new Point(240, 120),
            Size = LayoutSize,
            FlowDirection = FlowDirection.TopDown
        };
        Controls.Add(potionLayoutPanel);

        var listLayoutPanel = new FlowLayoutPanel
        {
            Location = new Point(240 + output.Width, 0),
            Size = LayoutSize,
            FlowDirection = FlowDirection.TopDown
        };
        Controls.Add(listLayoutPanel);

        var list = new ListBox
        {
            Location = new Point(10, (primaryButtonCount + 4) * 20 + Indent),
            Size = new Size(100, 100)
        };

        for (var i = 0; i <= herbs.Count - 1; i++)
        {
            var b = new Button
            {
                Text = herbs[i].ToString(),
                Size = ButtonSize
            };

            buttons.Add(b);
            herbLayoutPanel.Controls.Add(b);

            var j = i;

            buttons[j].Click += (_, _) =>
            {
                game.CurrentPotion.AddHerb(herbs[j]);
                list.Items.Add(herbs[j].ToString());
                updateOutput(output);
            };
        }

        var ngButton = new Button
        {
            Text = "New Game",
            Size = ButtonSize
        };

        var resetButton = new Button
        {
            Text = "Reset",
            Size = ButtonSize,
            ForeColor = Color.Red
        };

        var helpButton = new Button
        {
            Text = "Help",
            Size = ButtonSize
        };

        var mixButton = new Button
        {
            Text = "Mix!",
            Size = ButtonSize,
            BackColor = Color.LightGreen
        };

        var listName = new Label
        {
            Text = "List of Herbs:",
            Location = new Point(10, (primaryButtonCount + 3) * 20 + Indent),
            Size = ButtonSize,
            ForeColor = Color.DarkGreen,
            TextAlign = ContentAlignment.MiddleLeft
        };

        Controls.Add(output);

        listLayoutPanel.Controls.Add(listName);
        listLayoutPanel.Controls.Add(list);

        systemLayoutPanel.Controls.Add(ngButton);
        systemLayoutPanel.Controls.Add(helpButton);

        potionLayoutPanel.Controls.Add(mixButton);
        potionLayoutPanel.Controls.Add(resetButton);

        var help = new HelpForm();
        helpButton.Click += (_, _) =>
        {
            var a = help.IsDisposed ? help = new HelpForm() : help;
            a.Show();
            a.Focus();
        };

        ngButton.Click += (_, _) =>
        {
            game = new Game();
            list.Items.Clear();
            updateOutput(output);
        };

        mixButton.Click += (_, _) =>
        {
            var potionName = game.ReturnPotion();
            output.Text = $"You have found {potionName} potion!";
            list.Items.Clear();
            game.ResetPotion();
        };

        resetButton.Click += (_, _) =>
        {
            _text = "";
            list.Items.Clear();
            updateOutput(output);
            game.ResetPotion();
        };
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }
}