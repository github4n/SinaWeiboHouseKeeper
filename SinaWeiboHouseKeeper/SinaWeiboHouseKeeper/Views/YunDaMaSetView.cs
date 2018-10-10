using CCWin;
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
    public partial class YunDaMaSetView : Skin_DevExpress
    {
        public YunDaMaSetView()
        {
            InitializeComponent();
            this.textBoxUsername.Text = AppConfigRWTool.ReadSetting("YunDaMaUserName");

            //假数据
            if (this.textBoxUsername.Text.Equals("") || AppConfigRWTool.ReadSetting("YunDaMaUserName").Equals(""))
            {
                this.textBoxPassword.Text = "";
            }
            else
            {
                this.textBoxPassword.Text = "%%%%%%%%%%%%%";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!(this.textBoxUsername.Text.Equals("") || this.textBoxPassword.Text.Equals("")))
            {
                AppConfigRWTool.WriteSetting("YunDaMaUserName", this.textBoxUsername.Text);

                if (!this.textBoxPassword.Text.Equals("%%%%%%%%%%%%%"))
                {
                    //密码以Md5形式存储
                    AppConfigRWTool.WriteSetting("YunDaMaPasswordMd5", MD5EncryptTool.MD5Encrypt(this.textBoxPassword.Text));
                }
            }
        }
    }
}
