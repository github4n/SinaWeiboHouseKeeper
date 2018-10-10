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
            this.textBoxSendUserName.Text = AppConfigRWTool.ReadSetting("EMailSenderUserName");
            this.textBoxSendPassword.Text = AppConfigRWTool.ReadSetting("EMailSenderPassword");
            this.textBoxRecieveUserName.Text = AppConfigRWTool.ReadSetting("EMailReceiverName");

            this.checkBox1.Checked = AppConfigRWTool.ReadSetting("EmailRportChoose").Equals("false") ? false : true;
            this.comboBox1.SelectedIndex = Convert.ToInt32(AppConfigRWTool.ReadSetting("EmailReportTime"));

            if (!this.checkBox1.Checked)
            {
                this.comboBox1.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!(this.textBoxSendUserName.Text.Equals("") || this.textBoxSendPassword.Text.Equals("") || this.textBoxRecieveUserName.Text.Equals("")))
            {
                AppConfigRWTool.WriteSetting("EMailSenderUserName", this.textBoxSendUserName.Text);
                AppConfigRWTool.WriteSetting("EMailSenderPassword", this.textBoxSendPassword.Text);
                AppConfigRWTool.WriteSetting("EMailReceiverName", this.textBoxRecieveUserName.Text);

                AppConfigRWTool.WriteSetting("EmailReportTime", this.comboBox1.SelectedIndex.ToString());
                AppConfigRWTool.WriteSetting("EmailRportChoose" ,(this.checkBox1.Checked ? "true" : "false"));
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.comboBox1.Enabled = true;
            }
            else
            {
                this.comboBox1.Enabled = false;
            }
        }
    }
}
