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
using System.Net;

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
        public int AutoFollowCount { get; private set; }
        //是否开启自动取消关注
        private bool IsAutoUnFollow;
        public int AutoUnFollowCount { get; private set; }
        //话题
        public string Tags { get; private set; }
        //话题前置
        public bool IsFrontTagsSet { get; private set; }
        //是否启用休眠时间
        private bool IsSleepTimeSetted;
        private int SleepTimeStart;
        private int SleepTimeEnd;
        //微博发布计时器
        private Timer WeiboTimer = new Timer() { Interval = 60000 };
        //计时器计数
        private int ImageWeiboCounter = 0;
        private int VideoWeiboCounter = 0;
        private int CookiesCounter = 1200;//cookies更新周期20小时
        private int UpdateSQLiteCounter = 1440;
        //微博发布标志
        private bool IsImageWeiboEnabled;
        private bool IsVideoWeiboEnabled;

        //微博剩余数设置
        public string ImageWeiboCount
        {
            set
            {
                this.labelImageCount.Text = value;
                this.Refresh();
            }
        }
        public string VideoWeiboCount
        {
            set
            {
                this.labelVideoCount.Text = value;
                this.Refresh();
            }
        }

        //设置头像
        public Image AvatarImage
        {
            set
            {
                this.pictureBox1.Image = value;
                this.pictureBox1.Refresh();
            }
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public CookieContainer Cookies { get; set; }
        public string DisplayName { get; private set; }
        public string UserId { get; private set; }

        #region 委托事件
        /// <summary>
        /// 发布一条微博
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="isImageWeibo">true:图文微博;false:视频微博</param>
        public delegate void PublishWeiboHandler(object sender ,bool isImageWeibo);
        public event PublishWeiboHandler PublishWeiboEvent;

        /// <summary>
        /// 更新cookies事件
        /// </summary>
        /// <param name="sender"></param>
        public delegate void UpdateCookiesHandler(object sender);
        public event UpdateCookiesHandler UpdateCookiesEvent;

        /// <summary>
        /// 邮件发送事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message">邮件内容</param>
        public delegate void SendEmailHandler(object sender,string message);
        public event SendEmailHandler SendEmailEvent;

        /// <summary>
        /// 写入日志事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="title">标题</param>
        /// <param name="message">日志内容</param>
        public delegate void WriteLogHandler(object sender, string title, string message);
        public event WriteLogHandler WriteLogEvent;

        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="sender"></param>
        public delegate void UpdateSQLiteHandler(object sender);
        public event UpdateSQLiteHandler UpdateSQLiteEvent;

        /// <summary>
        /// 粉丝事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="isFollow">true:关注;false:取消关注</param>
        public delegate void FollowFansHandler(object sender, bool isFollow);
        public event FollowFansHandler FollowFansEvent;
        #endregion

        public UserLable(CookieContainer cookie,string username,string password,string displayName ,string uid)
        {
            InitializeComponent();

            this.UserName = username;
            this.Password = password;
            this.Cookies = cookie;
            this.DisplayName = displayName;
            this.groupBox1.Text = displayName;
            this.UserId = uid;

            this.WeiboTimer.Tick += WeiboTimer_Tick;
            this.WeiboTimer.Enabled = true;
        }



        #region 事件
        //视频、图文微博发送，cookies更新事件
        private void WeiboTimer_Tick(object sender, EventArgs e)
        {
            //视频微博
            if (this.IsVideoWeiboEnabled)
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

            //图文微博
            if (this.IsImageWeiboEnabled)
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

            //cookies更新
            this.CookiesCounter--;
            if (this.CookiesCounter <= 0)
            {
                this.CookiesCounter = 1200;
                this.UpdateCookies();
            }

            //24小时计时
            this.UpdateSQLiteCounter--;
            if (this.UpdateSQLiteCounter <= 0)
            {
                this.UpdateSQLiteCounter = 1440;
                //sqlite更新事件
                UpdateSQLiteEvent(this);
            }
            else if (this.UpdateSQLiteCounter == 480 && this.IsAutoUnFollow && this.IsFansSetted)
            {
                //取消关注
                FollowFansEvent(this, false);
            }
            else if (this.UpdateSQLiteCounter == 960 && this.IsAutoFollow && this.IsFansSetted)
            {
                //关注
                FollowFansEvent(this, true);
            }
        }
        //设置按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            this.WeiboSet.ShowSettingView(this.DisplayName);
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
            PublishWeiboEvent(this, true);
        }

        /// <summary>
        /// 发布一条视频微博
        /// </summary>
        private void PublishAVideoWeibo()
        {
            //发布一条视频微博
            PublishWeiboEvent(this, false);
        }

        private void UpdateCookies()
        {
            //更新cookies事件触发
            UpdateCookiesEvent(this);
        }

        /// <summary>
        /// 开始发布微博
        /// </summary>
        private void StartPublish()
        {
            if (this.ImageWeiboSet.IsEnabled)
            {
                this.ImageWeiboSet.ReSetRandomFrequency();
                this.IsImageWeiboEnabled = true;
            }

            if (this.VideoWeiboSet.IsEnabled)
            {
                this.VideoWeiboSet.ReSetRandomFrequency();
                this.IsVideoWeiboEnabled = true;
            }
        }

        /// <summary>
        /// 停止发布微博
        /// </summary>
        private void EndPublish()
        {
            this.IsImageWeiboEnabled = false;
            this.IsVideoWeiboEnabled = false;
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
