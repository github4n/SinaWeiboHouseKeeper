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

namespace SinaWeiboHouseKeeper.Views
{
    public partial class ADFilePathView : Skin_DevExpress
    {
        public string FilePath
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }

        private string fileName = "";

        public ADFilePathView()
        {
            InitializeComponent();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "txt文件|*.txt";
            open.Title = "选择广告特征词文件";
            var res = open.ShowDialog();
            this.fileName = open.FileName;
            this.textBox1.Text = open.FileName;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.fileName = "";
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!this.fileName.Equals(""))
            {
                WeiboOperate.filterADFilePath = this.fileName;
            }
        }
    }
}
