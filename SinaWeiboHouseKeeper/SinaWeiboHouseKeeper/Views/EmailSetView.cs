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
    public partial class EmailSetView : Skin_DevExpress
    {
        public EmailSetView()
        {
            InitializeComponent();
            this.textBoxSendUserName.Text = ConfigurationManager.AppSettings["EMailSenderUserName"];
            this.textBoxSendPassword.Text = ConfigurationManager.AppSettings["EMailSenderPassword"];
            this.textBoxRecieveUserName.Text = ConfigurationManager.AppSettings["EMailReceiverName"];
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!(this.textBoxSendUserName.Text.Equals("") || this.textBoxSendPassword.Text.Equals("") || this.textBoxRecieveUserName.Text.Equals("")))
            {
                AppConfigRWTool.WriteConfig("EMailSenderUserName", this.textBoxSendUserName.Text);
                AppConfigRWTool.WriteConfig("EMailSenderPassword", this.textBoxSendPassword.Text);
                AppConfigRWTool.WriteConfig("EMailReceiverName", this.textBoxRecieveUserName.Text);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
