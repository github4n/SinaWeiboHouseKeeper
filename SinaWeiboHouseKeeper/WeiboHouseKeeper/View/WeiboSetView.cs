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
        #region 属性等
        //图文微博固定频率
        private uint imageWeiboFixedTime = 20;
        public string ImageWeiboFixedTime
        {
            get
            {
                return this.imageWeiboFixedTime.ToString();
            }
        }

        //图文微博随机频率下限
        private uint imageWeiboRandomTimeMin = 1;
        public string ImageWeiboRandomTimeMin
        {
            get
            {
                return this.imageWeiboRandomTimeMin.ToString();
            }
        }

        //图文微博随机频率上限
        private uint imageWeiboRandomTimeMax = 60;
        public string ImageWeiboRandomTimeMax
        {
            get
            {
                return this.imageWeiboRandomTimeMax.ToString();
            }
        }

        //视频微博固定频率
        private uint videoWeiboFixedTime = 20;
        public string VideoWeiboFixedTime
        {
            get
            {
                return this.videoWeiboFixedTime.ToString();
            }
        }

        //视频微博随机频率下限
        private uint videoWeiboRandomTimeMin = 1;
        public string VideoWeiboRandomTimeMin
        {
            get
            {
                return this.videoWeiboRandomTimeMin.ToString();
            }
        }

        //视频微博随机频率上限
        private uint videoWeiboRandomTimeMax = 60;
        public string VideoWeiboRandomTimeMax
        {
            get
            {
                return this.videoWeiboRandomTimeMax.ToString();
            }
        }

        //每次自动关注人数
        private uint autoFollowConut = 10;
        public string AutoFollowCount
        {
            get
            {
                return this.autoFollowConut.ToString();
            }
        }

        //每次自动取消关注数
        private uint autoUnFollowCount = 10;
        public string AutoUnFollowCount
        {
            get
            {
                return this.autoUnFollowCount.ToString();
            }
        }

        //休眠时间起始
        private int sleepStartIndex = 23;
        public int SleepTmieStart
        {
            get
            {
                return this.sleepStartIndex;
            }
        }
        //休眠时间结束
        private int sleepEndIndex = 5;
        public int SleepTimeEnd
        {
            get
            {
                return this.sleepEndIndex;
            }
        }

        //固定tags
        [DefaultValue("")]
        public string FixedTags { get; private set; }

        //tags前置or后置
        public bool IsBackTag { get; private set; }

        //是否启用图文微博
        public bool IsImageWeiboEnabled { get; private set; }

        //是否启用视频微博
        public bool IsVideoWeiboEnabled { get; private set; }

        //是否启用吸粉功能
        public bool IsAutoFansEnabled { get; private set; }

        //是否启用休眠时间
        public bool IsSleepTimeEnabled { get; private set; }

        //图片微博固定频率或者随机频率
        public bool IsImageWeiboFixed { get; private set; }

        //视频微博固定频率或者随机频率
        public bool IsVideoWeiboFixed { get; private set; }

        //自动关注启用
        public bool IsAutoFollowEnabled { get; private set; }

        //自动取消关注启用
        public bool IsAutoUnFollowEnabled { get; private set; }

        #endregion

        public WeiboSetView()
        {
            InitializeComponent();

            //设置默认值
            this.IsImageWeiboFixed = true;
            this.IsVideoWeiboFixed = true;
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
                    if (!UInt32.TryParse(this.textBoxImageFixed.Text, out uint outInt))
                    {
                        this.labelImageError1.Visible = true;
                        isValid = false;
                    }

                    if (outInt > 0)
                    {
                        this.imageWeiboFixedTime = outInt;
                    }
                }
                else if (!this.radioImageFixed.Checked && this.radioImageRandom.Checked)
                {
                    uint outInt1 = 0;
                    uint outInt2 = 0;
                    if (!UInt32.TryParse(this.textBoxImageRandom1.Text, out outInt1) ||
                        !UInt32.TryParse(this.textBoxImageRandom2.Text, out outInt2))
                    {
                        this.labelImageError2.Visible = true;
                        isValid = false;
                    }
                    else if (outInt1 >= outInt2)
                    {
                        this.labelImageError2.Visible = true;
                        isValid = false;
                    }

                    if(isValid)
                    {
                        this.imageWeiboRandomTimeMin = outInt1;
                        this.imageWeiboRandomTimeMax = outInt2;
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
                    if (!UInt32.TryParse(this.textBoxVideoFixed.Text, out uint outInt))
                    {
                        this.labelVideoError1.Visible = true;
                        isValid = false;
                    }

                    if (outInt > 0)
                    {
                        this.videoWeiboFixedTime = outInt;
                    }
                }
                else if (!this.radioVideoFixed.Checked && this.radioVideoRandom.Checked)
                {
                    uint outUint1 = 0;
                    uint outUint2 = 0;
                    if (!UInt32.TryParse(this.textBoxVideoRandom1.Text, out outUint1) ||
                        !UInt32.TryParse(this.textBoxVideoRandom2.Text, out outUint2))
                    {
                        this.labelVideoError2.Visible = true;
                        isValid = false;
                    }
                    else if (outUint1 >= outUint2)
                    {
                        this.labelVideoError2.Visible = true;
                        isValid = false;
                    }

                    if (isValid)
                    {
                        this.videoWeiboRandomTimeMin = outUint1;
                        this.videoWeiboRandomTimeMax = outUint2;
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
        /// 吸粉模块设置有效性验证
        /// </summary>
        /// <returns></returns>
        private bool IsFansSettingValid()
        {
            bool isValid = true;
            if (this.checkBoxFans.Checked)
            {
                if (this.checkBoxAutoFollow.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxAutoFollowCount.Text, out uint outInt))
                    {
                        this.labelFollowError.Visible = true;
                        isValid = false;
                    }

                    if (outInt > 0)
                    {
                        this.autoFollowConut = outInt;
                    }
                }

                if (this.checkBoxAutoUnFollow.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxAutoUnFollowCount.Text, out uint outInt))
                    {
                        this.labelUnFollowError.Visible = true;
                        isValid = false;
                    }

                    if (outInt > 0)
                    {
                        this.autoUnFollowCount = outInt;
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// 休眠时间设置有效性验证
        /// </summary>
        /// <returns></returns>
        private bool IsSleepTimeSettingValid()
        {
            bool isValid = true;
            if (this.checkBoxSleepTime.Checked)
            {
                if (this.comboBox1.SelectedItem == null || this.comboBox2.SelectedItem == null || this.comboBox1.SelectedIndex == this.comboBox2.SelectedIndex)
                {
                    this.labelSleepTimeError.Visible = true;
                    isValid = false;
                }
                else
                {
                    this.sleepStartIndex = this.comboBox1.SelectedIndex;
                    this.sleepEndIndex = this.comboBox2.SelectedIndex;
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
            this.labelFollowError.Visible = false;
            this.labelUnFollowError.Visible = false;
            this.labelSleepTimeError.Visible = false;
        }

        //窗口打开时初始化显示数据
        private void DisplayDafaultData()
        {
            this.textBoxImageFixed.Text = this.ImageWeiboFixedTime;
            this.textBoxImageRandom1.Text = this.ImageWeiboRandomTimeMin;
            this.textBoxImageRandom2.Text = this.ImageWeiboRandomTimeMax;

            this.textBoxVideoFixed.Text = this.VideoWeiboFixedTime;
            this.textBoxVideoRandom1.Text = this.VideoWeiboRandomTimeMin;
            this.textBoxVideoRandom2.Text = this.VideoWeiboRandomTimeMax;

            this.textBoxAutoFollowCount.Text = this.AutoFollowCount;
            this.textBoxAutoUnFollowCount.Text = this.AutoUnFollowCount;

            this.textBoxFixedTags.Text = this.FixedTags;

            if (this.IsBackTag)
            {
                this.radioButtonTagsBack.Checked = true;
            }
            else
            {
                this.radioButtonTagsFront.Checked = true;
            }

            this.comboBox1.SelectedIndex = this.SleepTmieStart;
            this.comboBox2.SelectedIndex = this.SleepTimeEnd;

            this.checkBoxImage.Checked = this.IsImageWeiboEnabled;
            this.checkBoxVideo.Checked = this.IsVideoWeiboEnabled;
            this.checkBoxFans.Checked = this.IsAutoFansEnabled;
            this.checkBoxSleepTime.Checked = this.IsSleepTimeEnabled;
            this.checkBoxAutoFollow.Checked = this.IsAutoFollowEnabled;
            this.checkBoxAutoUnFollow.Checked = this.IsAutoUnFollowEnabled;

            if (this.IsImageWeiboFixed)
            {
                this.radioImageFixed.Checked = true;
            }
            else
            {
                this.radioImageRandom.Checked = true;
            }

            if (this.IsVideoWeiboFixed)
            {
                this.radioVideoFixed.Checked = true;
            }
            else
            {
                this.radioVideoRandom.Checked = true;
            }
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 显示设置界面
        /// </summary>
        /// <param name="nickName">用户昵称</param>
        public void ShowSettingView( string nickName)
        {
            this.Text = nickName + " —— 设置";

            //显示默认信息
            this.DisplayDafaultData();
            //清除错误提示
            this.HideErrorPoint();

            this.ShowDialog();
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
            if (!this.IsImageWeiboSettingValid() ||
                !this.IsVideoWeiboSettingValid() ||
                !this.IsFansSettingValid() ||
                !this.IsSleepTimeSettingValid())
            {
                return;
            }
            else
            {
                this.IsImageWeiboEnabled = this.checkBoxImage.Checked;
                this.IsVideoWeiboEnabled = this.checkBoxVideo.Checked;
                this.IsAutoFansEnabled = this.checkBoxFans.Checked;
                this.IsSleepTimeEnabled = this.checkBoxSleepTime.Checked;
                this.IsAutoFollowEnabled = this.checkBoxAutoFollow.Checked;
                this.IsAutoUnFollowEnabled = this.checkBoxAutoUnFollow.Checked;
                this.IsImageWeiboFixed = this.radioImageFixed.Checked;
                this.IsVideoWeiboFixed = this.radioVideoFixed.Checked;
                this.IsBackTag = this.radioButtonTagsBack.Checked;

                this.FixedTags = this.textBoxFixedTags.Text;
            }

            this.Close();
        }
        #endregion


    }
}
