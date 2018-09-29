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

        #region 各功能效果设置
        //图文微博发布频率设置事件
        private void radioImageFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioImageFixed.Checked)
            {
                this.textBoxImageFixed.Enabled = true;
                this.textBoxImageRandom1.Enabled = false;
                this.textBoxImageRandom2.Enabled = false;
            }
            else
            {
                this.textBoxImageFixed.Enabled = false;
                this.textBoxImageRandom1.Enabled = true;
                this.textBoxImageRandom2.Enabled = true;
            }
        }

        //视频微博发布频率设置事件
        private void radioVideoFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioVideoFixed.Checked)
            {
                this.textBoxVideoFixed.Enabled = true;
                this.textBoxVideoRandom1.Enabled = false;
                this.textBoxVideoRandom2.Enabled = false;
            }
            else
            {
                this.textBoxVideoFixed.Enabled = false;
                this.textBoxVideoRandom1.Enabled = true;
                this.textBoxVideoRandom2.Enabled = true;
            }
        }

        //自动关注效果设置事件
        private void checkBoxAutoFollow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAutoFollow.Checked)
            {
                this.textBoxAutoFollowCount.Enabled = true;
            }
            else
            {
                this.textBoxAutoFollowCount.Enabled = false;
            }
        }

        //自动取消关注效果设置
        private void checkBoxAutoUnFollow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAutoUnFollow.Checked)
            {
                this.textBoxAutoUnFollowCount.Enabled = true;
            }
            else
            {
                this.textBoxAutoUnFollowCount.Enabled = false;
            }
        }

        //休眠时间效果设置
        private void checkBoxSleepTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSleepTime.Checked)
            {
                this.comboBox1.Enabled = true;
                this.comboBox2.Enabled = true;
            }
            else
            {
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
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
