using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeiboHouseKeeper.View;
using WeiboControl;

namespace WeiboHouseKeeper
{
    public partial class UserLable : UserControl
    {
        private WeiboSetView WeiboSet = new WeiboSetView();

        //图文微博设置
        private WeiboSet ImageWeiboSet = new WeiboSet();
        //视频微博设置
        private WeiboSet VideoWeiboSet = new WeiboSet();
        //是否开启粉丝功能
        private bool IsFansSetted;
        //是否开启自动关注
        private bool IsAutoFollow;
        private int AutoFollowCount;
        //是否开启自动取消关注
        private bool IsAutoUnFollow;
        private int AutoUnFollowCount;
        //话题
        private string Tags;
        //话题前置
        private bool IsFrontTagsSet;
        //是否启用休眠时间
        private bool IsSleepTimeSetted;
        private int SleepTimeStart;
        private int SleepTimeEnd;

        public UserLable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 微博昵称
        /// </summary>
        public string NickName
        {
            get
            {
                return this.groupBox1.Text;
            }
            set
            {
                this.groupBox1.Text = value;
            }

        }

        #region 事件
        //设置事件
        private void button1_Click(object sender, EventArgs e)
        {
            this.WeiboSet.ShowSettingView(" zzz");
            this.ShowDisplayMessage();
            this.UpdateSettings();
        }
        //发布事件
        private void buttonPublish_Click(object sender, EventArgs e)
        {
            if (this.ImageWeiboSet.IsEnabled || this.VideoWeiboSet.IsEnabled)
            {
                if (this.buttonPublish.Text.Equals("开始发布"))
                {
                    this.buttonPublish.Text = "停止发布";
                    this.buttonPublish.BackColor = Color.Lime;

                    this.buttonSet.Enabled = false;
                }
                else
                {
                    this.buttonPublish.Text = "开始发布";
                    this.buttonPublish.BackColor = Color.Gainsboro;
                    this.buttonSet.Enabled = true;
                }
            }
            else
            {
                return;
            }
        }
        //退出登录事件
        private void buttonLogOut_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 更新设置数据
        /// </summary>
        private void UpdateSettings()
        {
            this.ImageWeiboSet.IsEnabled = this.WeiboSet.IsImageWeiboEnabled;
            this.ImageWeiboSet.IsRandomPublish = !this.WeiboSet.IsImageWeiboFixed;
            this.ImageWeiboSet.FixedFrequency = Convert.ToInt32(this.WeiboSet.ImageWeiboFixedTime);
            this.ImageWeiboSet.RandomFrequencyMin = Convert.ToInt32(this.WeiboSet.ImageWeiboRandomTimeMin);
            this.ImageWeiboSet.RandomFrequencyMax = Convert.ToInt32(this.WeiboSet.ImageWeiboRandomTimeMax);
            this.VideoWeiboSet.IsEnabled = this.WeiboSet.IsVideoWeiboEnabled;
            this.VideoWeiboSet.IsRandomPublish = !this.WeiboSet.IsVideoWeiboFixed;
            this.VideoWeiboSet.FixedFrequency = Convert.ToInt32(this.WeiboSet.VideoWeiboFixedTime);
            this.VideoWeiboSet.RandomFrequencyMin = Convert.ToInt32(this.WeiboSet.VideoWeiboRandomTimeMin);
            this.VideoWeiboSet.RandomFrequencyMax = Convert.ToInt32(this.WeiboSet.VideoWeiboRandomTimeMax);
            this.IsFansSetted = this.WeiboSet.IsAutoFansEnabled;
            this.IsAutoFollow = this.WeiboSet.IsAutoFollowEnabled;
            this.IsAutoUnFollow = this.WeiboSet.IsAutoUnFollowEnabled;
            this.AutoFollowCount = Convert.ToInt32(this.WeiboSet.AutoFollowCount);
            this.AutoUnFollowCount = Convert.ToInt32(this.WeiboSet.AutoUnFollowCount);
            this.Tags = this.WeiboSet.FixedTags;
            this.IsFrontTagsSet = !this.WeiboSet.IsBackTag;
            this.IsSleepTimeSetted = this.WeiboSet.IsSleepTimeEnabled;
            this.SleepTimeStart = this.WeiboSet.SleepTmieStart;
            this.SleepTimeEnd = this.WeiboSet.SleepTimeEnd;
        }

        /// <summary>
        /// 显示设置界面显示的信息
        /// </summary>
        private void ShowDisplayMessage()
        {
            this.ShowSettingMessage();
            this.ShowSQLiteData();
            this.Refresh();
        }

        /// <summary>
        /// 设置内容显示
        /// </summary>
        private void ShowSettingMessage()
        {
            //图文微博发布频率
            if (this.WeiboSet.IsImageWeiboEnabled)
            {
                if (this.WeiboSet.IsImageWeiboFixed)
                {
                    this.labelImageFrequency.Text = this.WeiboSet.ImageWeiboFixedTime + " 条/分钟";
                }
                else
                {
                    this.labelImageFrequency.Text = this.WeiboSet.ImageWeiboRandomTimeMin +
                        "~" +
                        this.WeiboSet.ImageWeiboRandomTimeMax + " 条/分钟";
                }
            }
            else
            {
                this.labelImageFrequency.Text = "未开启";
            }

            //视频微博发布频率
            if (this.WeiboSet.IsVideoWeiboEnabled)
            {
                if (this.WeiboSet.IsVideoWeiboFixed)
                {
                    this.labelVideoFrequency.Text = this.WeiboSet.VideoWeiboFixedTime + " 条/分钟";
                }
                else
                {
                    this.labelVideoFrequency.Text = this.WeiboSet.VideoWeiboRandomTimeMin +
                        "~" +
                        this.WeiboSet.VideoWeiboRandomTimeMax + " 条/分钟";
                }
            }
            else
            {
                this.labelVideoFrequency.Text = "未开启";
            }

            //休眠时间
            if (this.WeiboSet.IsSleepTimeEnabled)
            {
                this.labelSleepTime.Text = String.Format("{0}:00 - {1}:00", this.WeiboSet.SleepTmieStart, this.WeiboSet.SleepTimeEnd);
            }
            else
            {
                this.labelSleepTime.Text = "未开启";
            }

            //自动关注
            if (this.WeiboSet.IsAutoFansEnabled)
            {
                if (this.WeiboSet.IsAutoFollowEnabled)
                {
                    this.labelAutoFollow.Text = this.WeiboSet.AutoFollowCount + " 人/次";
                }
                else
                {
                    this.labelAutoFollow.Text = "未开启";
                }

                if (this.WeiboSet.IsAutoUnFollowEnabled)
                {
                    this.labelAutoUnFollow.Text = this.WeiboSet.AutoUnFollowCount + " 人/次";
                }
                else
                {
                    this.labelAutoUnFollow.Text = "未开启";
                }
            }
            else
            {
                this.labelAutoFollow.Text = "未开启";
                this.labelAutoUnFollow.Text = "未开启";
            }
        }

        /// <summary>
        /// 显示数据库数据余量
        /// </summary>
        private void ShowSQLiteData()
        {

        }
        #endregion
    }
}
