﻿using CCWin;
using SinaWeiboHouseKeeper.IOTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public ADFilePathView()
        {
            InitializeComponent();
            this.textBox1.Text = AppConfigRWTool.ReadSetting("FilterADPath");
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "txt文件|*.txt";
            open.Title = "选择广告特征词文件";
            var res = open.ShowDialog();
            this.textBox1.Text = open.FileName;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals(""))
            {
                AppConfigRWTool.WriteSetting("FilterADPath", this.textBox1.Text);
            }
        }
    }
}
