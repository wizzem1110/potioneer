using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotioneerG
{
    public partial class HelpForm : Form
    {
        readonly string help =
            "Help will be later";
        public HelpForm()
        {
            InitializeComponent();
            Size = new Size(400, 200);
            Text = "Help";
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(new Label()
            {
                Size = this.Size,
                Text = help
            });
        }
    }
}
