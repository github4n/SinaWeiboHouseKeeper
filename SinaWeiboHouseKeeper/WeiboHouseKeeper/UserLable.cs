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
        //微博发布计时器
        private Timer ImageWeiboTimer = new Timer() { Interval = 60000 };
        private Timer VideoWeiboTimer = new Timer() { Interval = 60000 };
        //计时器计数
        private int ImageWeiboCounter = 0;
        private int VideoWeiboCounter = 0;
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


        public UserLable()
        {
            InitializeComponent();
            this.ImageWeiboTimer.Tick += ImageWeiboTimer_Tick;
            this.VideoWeiboTimer.Tick += VideoWeiboTimer_Tick;
        }



        #region 事件
        //视频微博发布事件
        private void VideoWeiboTimer_Tick(object sender, EventArgs e)
        {
            this.VideoWeiboCounter++;
            if (this.VideoWeiboSet.IsRandomPublish)
            {
                if (this.VideoWeiboCounter >= this.VideoWeiboSet.RandomFrequency)
                {
                    this.VideoWeiboCounter = 0;
                    //发布微博
                    this.PublishAVideoWeibo();
                    this.VideoWeiboSet.ReSetRandomFrequency();
                }
            }
            else
            {
                if (this.VideoWeiboCounter >= this.VideoWeiboSet.FixedFrequency)
                {
                    this.VideoWeiboCounter = 0;
                    //发布微博
                    this.PublishAVideoWeibo();
                }
            }
        }
        //图文微博发布事件
        private void ImageWeiboTimer_Tick(object sender, EventArgs e)
        {
            this.ImageWeiboCounter++;
            if (this.ImageWeiboSet.IsRandomPublish)
            {
                if (this.ImageWeiboCounter >= this.ImageWeiboSet.RandomFrequency)
                {
                    this.ImageWeiboCounter = 0;
                    //发布微博
                    this.PublishAnImageWeibo();
                    this.ImageWeiboSet.ReSetRandomFrequency();
                }
            }
            else
            {
                if (this.ImageWeiboCounter >= this.ImageWeiboSet.FixedFrequency)
                {
                    this.ImageWeiboCounter = 0;
                    //发布微博
                    this.PublishAnImageWeibo();
                }
            }
        }
        //设置按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            this.WeiboSet.ShowSettingView(" zzz");
            this.ShowDisplayMessage();
            this.UpdateSettings();
        }
        //发布按钮事件
        private void buttonPublish_Click(object sender, EventArgs e)
        {
            if (this.ImageWeiboSet.IsEnabled || this.VideoWeiboSet.IsEnabled)
            {
                if (this.buttonPublish.Text.Equals("开始发布"))
                {
                    this.buttonPublish.Text = "停止发布";
                    this.buttonPublish.BackColor = Color.Lime;
                    this.buttonSet.Enabled = false;

                    this.StartPublish();
                }
                else
                {
                    this.buttonPublish.Text = "开始发布";
                    this.buttonPublish.BackColor = Color.Gainsboro;
                    this.buttonSet.Enabled = true;

                    this.EndPublish();
                }
            }
            else
            {
                return;
            }


        }
        //退出登录按钮事件
        private void buttonLogOut_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 发布一条图文微博
        /// </summary>
        private void PublishAnImageWeibo()
        {
            //发布一条图文微博
        }

        /// <summary>
        /// 发布一条视频微博
        /// </summary>
        private void PublishAVideoWeibo()
        {
            //发布一条视频微博
        }

        /// <summary>
        /// 开始发布微博
        /// </summary>
        private void StartPublish()
        {
            if (this.ImageWeiboSet.IsEnabled)
            {
                this.ImageWeiboSet.ReSetRandomFrequency();
                this.ImageWeiboTimer.Enabled = true;
            }

            if (this.VideoWeiboSet.IsEnabled)
            {
                this.VideoWeiboSet.ReSetRandomFrequency();
                this.VideoWeiboTimer.Enabled = true;
            }
        }

        /// <summary>
        /// 停止发布微博
        /// </summary>
        private void EndPublish()
        {
            this.ImageWeiboTimer.Enabled = false;
            this.VideoWeiboTimer.Enabled = false;
        }

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
