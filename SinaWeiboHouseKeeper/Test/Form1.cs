using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.controls.Add(this.userLable1);

        }

        List<UserControl> controls = new List<UserControl>();

        private void button1_Click(object sender, EventArgs e)
        {

            //WeiboHouseKeeper.UserLable uLabel = new WeiboHouseKeeper.UserLable();

            //uLabel.Location = new Point(4, this.panel1.Controls[this.panel1.Controls.Count - 1].Location.Y + 190 + 6);
            //uLabel.MaximumSize = new Size(0, 170);
            //uLabel.MinimumSize = new Size(449, 190);
            //uLabel.Name = "userLable2";

            //uLabel.Size = new Size(449, 190);

            //this.panel1.Controls.Add(uLabel);

        }
    }
}
