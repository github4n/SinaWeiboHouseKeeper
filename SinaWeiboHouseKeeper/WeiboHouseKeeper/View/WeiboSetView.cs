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
        //图文微博固定频率
        private uint imageWeiboFixedTime = 20;
        public uint ImageWeiboFixedTime
        {
            get
            {
                return this.imageWeiboFixedTime;
            }
        }

        //图文微博随机频率下限
        private uint imageWeiboRandomTimeMin = 0;
        public uint ImageWeiboRandomTimeMin
        {
            get
            {
                return this.imageWeiboRandomTimeMin;
            }
        }

        //图文微博随机频率上限
        private uint imageWeiboRandomTimeMax = 60;
        public uint ImageWeiboRandomTimeMax
        {
            get
            {
                return this.imageWeiboRandomTimeMax;
            }
        }

        //视频微博固定频率
        private uint videoWeiboFixedTime = 20;
        public uint VideoWeiboFixedTime
        {
            get
            {
                return this.videoWeiboFixedTime;
            }
        }

        //视频微博随机频率下限
        private uint videoWeiboRandomTimeMin = 0;
        public uint VideoWeiboRandomTimeMin
        {
            get
            {
                return this.videoWeiboRandomTimeMin;
            }
        }

        //视频微博随机频率上限
        private uint videoWeiboRandomTimeMax = 60;
        public uint VideoWeiboRandomTimeMax
        {
            get
            {
                return this.videoWeiboRandomTimeMax;
            }
        }

        //每次自动关注人数
        private uint autoFollowConut = 0;
        public uint AutoFollowCount
        {
            get
            {
                return this.autoFollowConut;
            }
        }

        //每次自动取消关注数
        private uint autoUnFollowCount = 0;
        public uint AutoUnFollowCount
        {
            get
            {
                return this.autoUnFollowCount;
            }
        }


        public WeiboSetView()
        {
            InitializeComponent();
        }

        #region 私有方法
        /// <summary>
        /// 图文模块有效设置校验
        /// </summary>
        /// <returns>true:当前设置有效</returns>
        private bool IsImageWeiboSettingValid()
        {
            bool isValid = true;
            if (this.checkBoxImage.Checked)
            {
                if (this.radioImageFixed.Checked && !this.radioImageRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxImageFixed.Text, out this.imageWeiboFixedTime))
                    {
                        this.labelImageError1.Visible = true;
                        isValid = false;
                    }
                }
                else if (!this.radioImageFixed.Checked && this.radioImageRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxImageRandom1.Text, out this.imageWeiboRandomTimeMin) ||
                        !UInt32.TryParse(this.textBoxImageRandom2.Text, out this.imageWeiboRandomTimeMax))
                    {
                        this.labelImageError2.Visible = true;
                        isValid = false;
                    }
                    else if (this.imageWeiboRandomTimeMin >= this.imageWeiboRandomTimeMax)
                    {
                        this.labelImageError2.Visible = true;
                        isValid = false;
                    }
                }
                else
                {
                    this.labelImageError1.Visible = true;
                    isValid = false;
                }
            }
            return isValid;
        }

        /// <summary>
        /// 视频模块有效设置校验
        /// </summary>
        /// <returns>true:当前设置有效; false:设置无效</returns>
        private bool IsVideoWeiboSettingValid()
        {
            bool isValid = true;
            if (this.checkBoxVideo.Checked)
            {
                if (this.radioVideoFixed.Checked && !this.radioVideoRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxVideoFixed.Text, out this.videoWeiboFixedTime))
                    {
                        this.labelVideoError1.Visible = true;
                        isValid = false;
                    }
                }
                else if (!this.radioVideoFixed.Checked && this.radioVideoRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxVideoRandom1.Text, out this.videoWeiboRandomTimeMin) ||
                        !UInt32.TryParse(this.textBoxVideoRandom2.Text, out this.videoWeiboRandomTimeMax))
                    {
                        this.labelVideoError2.Visible = true;
                        isValid = false;
                    }
                    else if (this.videoWeiboRandomTimeMin >= this.videoWeiboRandomTimeMax)
                    {
                        this.labelVideoError2.Visible = true;
                        isValid = false;
                    }
                }
                else
                {
                    this.labelVideoError1.Visible = true;
                    isValid = false;
                }
            }
            return isValid;
        }

        /// <summary>
        ///清除所有错误提示
        /// </summary>
        private void HideErrorPoint()
        {
            this.labelImageError1.Visible = false;
            this.labelImageError2.Visible = false;
            this.labelVideoError1.Visible = false;
            this.labelVideoError2.Visible = false;
        }

        #endregion

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
            if (!this.IsImageWeiboSettingValid() || !this.IsVideoWeiboSettingValid())
            {
                return;
            }
            else
            {
                this.HideErrorPoint();
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
