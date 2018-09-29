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

namespace WeiboHouseKeeper.View
{
    public partial class WeiboSetView : Skin_DevExpress
    {
        public WeiboSetView()
        {
            InitializeComponent();
        }


        #region 事件
        #region 功能模块选中事件
        private void checkBoxImage_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxImage.Checked)
            {
                this.groupImage.Enabled = true;
            }
            else
            {
                this.groupImage.Enabled = false;
            }
        }

        private void checkBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxVideo.Checked)
            {
                this.groupVideo.Enabled = true;
            }
            else
            {
                this.groupVideo.Enabled = false;
            }
        }

        private void checkBoxFans_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxFans.Checked)
            {
                this.groupBoxFans.Enabled = true;
            }
            else
            {
                this.groupBoxFans.Enabled = false;
            }
        }
        #endregion

        //窗口关闭事件
        private void buttonOK_Click(object sender, EventArgs e)
        {
            //图文微博设置模块校验
            if (this.checkBoxImage.Checked)
            {
                if (this.radioImageFixed.Checked)
                {

                }
                else
                {

                }
            }

            //视频微博设置模块校验
            if (this.checkBoxVideo.Checked)
            {

            }

            //吸粉模块校验
            if (this.checkBoxFans.Checked)
            {

            }

            //休眠事件校验
            if (this.checkBoxSleepTime.Checked)
            {

            }

            this.Close();
        }
        #endregion
    }
}
