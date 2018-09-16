using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinaWeiboHouseKeeper.Views
{
    public partial class TagsView : Skin_DevExpress
    {
        private bool isOk;

        public TagsView()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.isOk = true;
        }

        public void showTagsView(ref string tagText,ref bool isBeforeTag)
        {
            this.richTextBox1.Text = tagText;
            this.ShowDialog();
            if (this.isOk)
            {
                tagText = this.richTextBox1.Text;
                isBeforeTag = this.radioBegin.Checked;
            }
        }
    }
}
