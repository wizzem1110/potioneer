using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PotioneerG;
using PotioneerL;

namespace PotioneerG
{
    public partial class PotioneerForm : Form
    {
        static Size bSize = new Size(100, 20);
        static Size fSize = new Size(640, 480);

        const int indent = 80;

        Game game;

        static string text = "";

        readonly Label output = new Label()
        {
            Location = new Point(160, 10),
            Size = new Size(200, 100),
            BackColor = Color.White,
            Font = new Font(FontFamily.GenericSerif, 12),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = text,
            BorderStyle = BorderStyle.FixedSingle,
        };

        readonly Action<Label> UpdateOutput = (x) => x.Text = text;

        List<Button> Buttons = new List<Button>();

        public PotioneerForm()
        {
            InitializeComponent();
            Size = fSize;
            Text = "POTIONEER!!";
            Location = new Point(0, 0);
            StartPosition = FormStartPosition.CenterScreen;

            game = new Game();

            var herbs = game.HerbsList;

            var primaryButtonCount = herbs.Count;

            var list = new ListBox
            {
                Location = new Point(10, (primaryButtonCount + 4) * 20 + indent),
                Size = new Size(100, 100)
            };

            for (var i = 0; i <= herbs.Count - 1; i++)
            {
                var b = new Button()
                {
                    Text = herbs[i].ToString(),
                    Location = new Point(10, i * 20 + 40),
                    Size = bSize
                };

                Buttons.Add(b);
                Controls.Add(b);

                var j = i;

                Buttons[j].Click += (s, e) =>
                {
                    game.CurrentPotion.MixHerb(herbs[j]);
                    list.Items.Add(herbs[j].ToString());
                    UpdateOutput(output);
                };
            }

            var ngButton = new Button()
            {
                Text = "New Game",
                Location = new Point(10, 10),
                Size = bSize
            };

            var resetButton = new Button()
            {
                Text = "Reset",
                Location = new Point(10, primaryButtonCount * 20 + indent),
                Size = bSize,
                ForeColor = Color.Red
            };

            var helpButton = new Button()
            {
                Text = "Help",
                Location = new Point(10, (primaryButtonCount + 1) * 20 + indent),
                Size = bSize
            };

            var mixButton = new Button()
            {
                Text = "Mix!",
                Location = new Point(10, (primaryButtonCount) * 20 + indent / 2),
                Size = bSize,
                BackColor = Color.LightGreen
            };

            var listName = new Label()
            {
                Text = "List of Herbs:",
                Location = new Point(10, (primaryButtonCount + 3) * 20 + indent),
                Size = bSize,
                ForeColor = Color.DarkGreen,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Controls.Add(output);
            Controls.Add(resetButton);
            Controls.Add(helpButton);
            Controls.Add(list);
            Controls.Add(listName);
            Controls.Add(mixButton);
            Controls.Add(ngButton);

            helpButton.Click += (s, e) => new HelpForm().ShowDialog();

            ngButton.Click += (s, e) =>
            {
                game = new Game();
                list.Items.Clear();
                UpdateOutput(output);
            };

            mixButton.Click += (s, e) =>
            {
                game.CurrentPotion.Distill();
                var (S, C) = game.CurrentPotion.Output();
                output.Text = S;
                output.ForeColor = C;
                list.Items.Clear();
                game.ResetPotion();
            };

            resetButton.Click += (s, e) =>
            {
                text = "";
                list.Items.Clear();
                UpdateOutput(output);
                game.ResetPotion();
            };
        }
    }
}