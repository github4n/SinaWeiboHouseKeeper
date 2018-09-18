using CCWin;
using SinaWeiboHouseKeeper.Views;
using SinaWeiboHouseKeeper.WeiboData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinaWeiboHouseKeeper
{
    public partial class HomePageView : Skin_DevExpress
    {
        //图文微博发布频率（分钟）
        private uint imageWeiboFixedTime = 20;
        private uint imageWeiboRandomTimeMin = 0;
        private uint imageWeiboRandomTimeMax = 60;
        //视频微博发布频率（分钟）
        private uint videoWeiboFixedTime = 20;
        private uint videoWeiboRandomTimeMin = 0;
        private uint videoWeiboRandomTimeMax = 60;
        //发布频率计数
        private int imageWeiboCount = 10;
        private int videoWeiboCount = 10;
        //tags设置
        private string tagsText = "";
        private bool isTagsBefore;

        private Random rand = new Random();

        //第一版暂用
        List<ImageWeibo> Weibos = new List<ImageWeibo>();

        WeiboLogin LoginMessage { get; set; }
        public HomePageView(WeiboLogin login)
        {
            InitializeComponent();
            this.LoginMessage = login;
            WeiboOperate.Weibo = login;

            this.FormClosed += HomePageView_FormClosed;

        }

        #region 私有方法
        //清除图文框提示信息
        private void ClearImageWeiboErrorMessage()
        {
            this.labelImageError1.Visible = false;
            this.labelImageError2.Visible = false;
            this.labelImageError3.Visible = false;
        }
        //清除视频框提示信息
        private void ClearVideoWeiboErrorMessage()
        {
            this.labelVideoError1.Visible = false;
            this.labelVideoError2.Visible = false;
            this.labelVideoError3.Visible = false;
        }
        //停止发布图文微博
        private void EndImageWeiboPublish()
        {
            this.groupImage.Enabled = true;
            this.timerImageWeibo.Enabled = false;

        }
        //开始图文微博发布
        private void StartImageWeiboPublish()
        {
            this.ClearImageWeiboErrorMessage();
            this.groupImage.Enabled = false;

            //确定计时范围
            this.UpdateCounter(true);

            this.timerImageWeibo.Enabled = true;

        }
        //停止发布视频微博
        private void EndVideoWeiboPublish()
        {
            this.groupVideo.Enabled = true;
            this.timerVideoWeibo.Enabled = false;
        }
        //开始视频微博发布
        private void StartVideoWeiboPublish()
        {
            this.ClearVideoWeiboErrorMessage();
            this.groupVideo.Enabled = false;

            //确定计时范围
            this.UpdateCounter(false);

            this.timerVideoWeibo.Enabled = true;
        }
        //更新计时器
        private void UpdateCounter(bool isImageWeibo)
        {
            if (isImageWeibo)
            {
                if (this.radioImageFixed.Checked)
                {
                    this.imageWeiboCount = Int32.Parse(this.textBoxImageFixed.Text);
                }
                else if (this.radioImageRandom.Checked)
                {
                    this.imageWeiboCount = rand.Next(Int32.Parse(this.textBoxImageRandom1.Text), Int32.Parse(this.textBoxImageRandom2.Text));
                }
            }
            else
            {
                if (this.radioVideoFixed.Checked)
                {
                    this.videoWeiboCount = Int32.Parse(this.textBoxVideoFixed.Text);
                }
                else if (this.radioVideoRandom.Checked)
                {
                    this.videoWeiboCount = rand.Next(Int32.Parse(this.textBoxVideoRandom1.Text), Int32.Parse(this.textBoxVideoRandom2.Text));
                }
            }
        }
        //发布图文微博
        private void PublishImageWeibo()
        {
            if (this.Weibos.Count != 0)
            {
                ImageWeibo weibo = this.Weibos[0];
                this.Weibos.Remove(weibo);

                //设置tags
                string weiboText = this.isTagsBefore ?
                    this.tagsText + weibo.WeiboMessage :
                    weibo.WeiboMessage + this.tagsText;

                WeiboOperate.SendAnImageWeibo(weiboText, weibo.Pictures);
                this.label12.Text = "剩余微博数：" + this.Weibos.Count.ToString();
            }
            else
            {
                this.richTextBox1.Text = this.richTextBox1.Text + "微博库已空\n";
                this.timerImageWeibo.Enabled = false;
            }
        }
        //发布视频微博
        private void publisVideoWeibo()
        {

        }
        #endregion

        #region 事件
        //退出应用
        private void HomePageView_FormClosed(object sender, FormClosedEventArgs e)
        {
            IOTools.UserLog.WriteNormalLog("退出登录");
            Application.Exit();
        }
        //图文微博固定频率选择
        private void radioImageFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioImageFixed.Checked)
            {
                this.textBoxImageFixed.Enabled = true;

                this.textBoxImageRandom1.Enabled = false;
                this.textBoxImageRandom2.Enabled = false;

                this.ClearImageWeiboErrorMessage();
            }
        }
        //图文微博随机频率设置
        private void radioImageRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioImageRandom.Checked)
            {
                this.textBoxImageRandom1.Enabled = true;
                this.textBoxImageRandom2.Enabled = true;

                this.textBoxImageFixed.Enabled = false;

                this.ClearImageWeiboErrorMessage();
            }
        }
        //图文微博休眠时间设置
        private void checkBoxImageSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxImageSleep.Checked)
            {
                this.comboBoxImage1.Enabled = true;
                this.comboBoxImage2.Enabled = true;
            }
            else
            {
                this.comboBoxImage1.Enabled = false;
                this.comboBoxImage2.Enabled = false;
            }

            this.ClearImageWeiboErrorMessage();
        }
        //视频微博固定频率设置
        private void radioVideoFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioVideoFixed.Checked)
            {
                this.textBoxVideoFixed.Enabled = true;

                this.textBoxVideoRandom1.Enabled = false;
                this.textBoxVideoRandom2.Enabled = false;

                this.ClearVideoWeiboErrorMessage();
            }
        }
        //视频微博随机频率设置
        private void radioVideoRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioVideoRandom.Checked)
            {
                this.textBoxVideoRandom1.Enabled = true;
                this.textBoxVideoRandom2.Enabled = true;

                this.textBoxVideoFixed.Enabled = false;

                this.ClearVideoWeiboErrorMessage();
            }
        }
        //视频微博休眠时间设置
        private void checkBoxVideoSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxVideoSleep.Checked)
            {
                this.comboBoxVideo1.Enabled = true;
                this.comboBoxVideo2.Enabled = true;
            }
            else
            {
                this.comboBoxVideo1.Enabled = false;
                this.comboBoxVideo2.Enabled = false;
            }

            this.ClearVideoWeiboErrorMessage();
        }
        //图文微博发布或停止
        private void ImageButton_Click(object sender, EventArgs e)
        {
            //判断当前发布状态
            if (this.ImageButton.Tag.Equals("1"))
            {
                //发布频率设置检测
                if (this.radioImageFixed.Checked && !this.radioImageRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxImageFixed.Text, out this.imageWeiboFixedTime))
                    {
                        this.labelImageError1.Visible = true;
                        return;
                    }
                }
                else if (!this.radioImageFixed.Checked && this.radioImageRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxImageRandom1.Text, out this.imageWeiboRandomTimeMin) ||
                        !UInt32.TryParse(this.textBoxImageRandom2.Text, out this.imageWeiboRandomTimeMax))
                    {
                        this.labelImageError2.Visible = true;
                        return;
                    }
                    else if (this.imageWeiboRandomTimeMin >= this.imageWeiboRandomTimeMax)
                    {
                        this.labelImageError2.Visible = true;
                        return;
                    }
                }
                else
                {
                    this.labelImageError1.Visible = true;
                    return;
                }

                //休眠时间设置检测
                if (this.checkBoxImageSleep.Checked)
                {
                    if (this.comboBoxImage1.SelectedItem == null || this.comboBoxImage2.SelectedItem == null || this.comboBoxImage1.SelectedIndex >= this.comboBoxImage2.SelectedIndex)
                    {
                        this.labelImageError3.Visible = true;
                        return;
                    }
                }

                this.ImageButton.Tag = "2";
                this.ImageButton.Text = "停止图文微博发布";
                this.ImageButton.BaseColor = Color.LightGreen;

                //开始图文微博发布
                this.StartImageWeiboPublish();
            }
            else
            {
                this.ImageButton.Tag = "1";
                this.ImageButton.Text = "开始图文微博发布";
                this.ImageButton.BaseColor = Color.LightGray;

                //停止发布图文微博
                this.EndImageWeiboPublish();
            }
        }
        //视频微博发布或停止
        private void VideoButton_Click(object sender, EventArgs e)
        {
            //判断当前发布状态
            if (this.VideoButton.Tag.Equals("1"))
            {
                //发布频率设置检测
                if (this.radioVideoFixed.Checked && !this.radioVideoRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxVideoFixed.Text, out this.videoWeiboFixedTime))
                    {
                        this.labelVideoError1.Visible = true;
                        return;
                    }
                }
                else if (!this.radioVideoFixed.Checked && this.radioVideoRandom.Checked)
                {
                    if (!UInt32.TryParse(this.textBoxVideoRandom1.Text, out this.videoWeiboRandomTimeMin) ||
                        !UInt32.TryParse(this.textBoxVideoRandom2.Text, out this.videoWeiboRandomTimeMax))
                    {
                        this.labelVideoError2.Visible = true;
                        return;
                    }
                    else if (this.videoWeiboRandomTimeMin >= this.videoWeiboRandomTimeMax)
                    {
                        this.labelVideoError2.Visible = true;
                        return;
                    }
                }
                else
                {
                    this.labelVideoError1.Visible = true;
                    return;
                }

                //休眠时间设置检测
                if (this.checkBoxVideoSleep.Checked)
                {
                    if (this.comboBoxVideo1.SelectedItem == null || this.comboBoxVideo2.SelectedItem == null || this.comboBoxVideo1.SelectedIndex >= this.comboBoxVideo2.SelectedIndex)
                    {
                        this.labelVideoError3.Visible = true;
                        return;
                    }
                }

                this.VideoButton.Tag = "2";
                this.VideoButton.Text = "停止图文微博发布";
                this.VideoButton.BaseColor = Color.LightGreen;

                //开始图文微博发布
                this.StartVideoWeiboPublish();
            }
            else
            {
                this.VideoButton.Tag = "1";
                this.VideoButton.Text = "开始图文微博发布";
                this.VideoButton.BaseColor = Color.LightGray;

                //停止发布图文微博
                this.EndVideoWeiboPublish();
            }
        }
        //开始爬取微博内容
        private void buttonStartGetWeibo_Click(object sender, EventArgs e)
        {
            if (!this.checkBoxGetImageWeibo.Checked && !this.checkBoxGetVideoWeibo.Checked || this.textBoxGetWeibo.Text.Equals(""))
            {
                return;
            }

            //关闭操作功能
            this.checkBoxGetImageWeibo.Enabled = false;
            this.checkBoxGetVideoWeibo.Enabled = false;
            this.textBoxGetWeibo.Enabled = false;
            this.buttonStartGetWeibo.Enabled = false;

            //获取图文微博
            if (this.checkBoxGetImageWeibo.Checked)
            {
                List<ImageWeibo> imageWeibos = WeiboOperate.GetImageWeibos(this.textBoxGetWeibo.Text);
                this.Weibos.AddRange(imageWeibos);
                string requestStr = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "\n" + "获取结束：此次共取得图文微博" + imageWeibos.Count.ToString() + "条";
                this.richTextBox1.Text = this.richTextBox1.Text + requestStr + "\n";
            }

            //获取视频微博
            if (this.checkBoxGetImageWeibo.Checked)
            {

            }

            //重启界面操作
            this.checkBoxGetImageWeibo.Enabled = true;
            this.checkBoxGetVideoWeibo.Enabled = true;
            this.textBoxGetWeibo.Enabled = true;
            this.buttonStartGetWeibo.Enabled = true;
        }
        //图文定时器
        private void timerImageWeibo_Tick(object sender, EventArgs e)
        {
            if (this.imageWeiboCount <= 0)
            {
                this.PublishImageWeibo();
                this.UpdateCounter(true);
            }
            this.imageWeiboCount--;
        }
        //视频定时器
        private void timerVideoWeibo_Tick(object sender, EventArgs e)
        {
            if (this.videoWeiboCount <= 0)
            {
                this.publisVideoWeibo();
                this.UpdateCounter(false);
            }
            this.videoWeiboCount--;
        }
        //tags设置
        private void tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagsView tags = new TagsView();
            tags.showTagsView(ref this.tagsText, ref this.isTagsBefore);
        }
        //广告特征词过滤设置
        private void ADFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADFilePathView adFilePath = new ADFilePathView();
            adFilePath.FilePath = WeiboOperate.filterADFilePath;
            adFilePath.ShowDialog();
        }
        #endregion


    }
}
