using CCWin;
using SinaWeiboHouseKeeper.IOTools;
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
using WeiboHouseKeeper;

namespace SinaWeiboHouseKeeper.Views
{
    public partial class MainPageView : Skin_DevExpress
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        private void 登录账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginView login = new LoginView();
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {
                UserLable userLable = new UserLable(login.WBLogin.MyCookies, login.WBLogin.Username, login.WBLogin.Password,login.WBLogin.DisplayName);
                if (this.panel1.Controls.Count == 0)
                {
                    userLable.Location = new Point(4, 4);
                }
                else
                {
                    userLable.Location = new Point(4, this.panel1.Controls[this.panel1.Controls.Count - 1].Location.Y + 190 + 6);
                }
                userLable.PublishWeiboEvent += PublishWeiboEvent;
                userLable.UpdateCookiesEvent += UpdateCookiesEvent;
                userLable.SendEmailEvent += SendEmailEvent;
                userLable.WriteLogEvent += WriteLogEvent;
                userLable.UpdateSQLiteEvent += UpdateSQLiteEvent;
                userLable.FollowFansEvent += FollowFansEvent;

                this.panel1.Controls.Add(userLable);
                SqliteTool.CreateDataBase(userLable.DisplayName);
            }
           
        }

        #region userlable事件
        private void FollowFansEvent(object sender, bool isFollow)
        {
            throw new NotImplementedException();
        }
        //更新数据库事件
        private void UpdateSQLiteEvent(object sender)
        {
            throw new NotImplementedException();
        }
        //日志记录事件
        private void WriteLogEvent(object sender, string title, string message)
        {
            throw new NotImplementedException();
        }
        //发送邮件事件
        private void SendEmailEvent(object sender, string message)
        {
            EMailTool.SendMail(((UserLable)sender).DisplayName + "运行错误", message);
        }
        //更新cookie事件
        private void UpdateCookiesEvent(object sender)
        {
            string username = ((UserLable)sender).UserName;
            string password = ((UserLable)sender).Password;

            WeiboLogin login = new WeiboLogin(username, password, false);

            string result = login.UpdateCookies(out bool IsSuccess);
            if (IsSuccess)
            {
                ((UserLable)sender).Cookies = login.MyCookies;
            }
            else
            {
                EMailTool.SendMail("更新cookies失败", String.Format("账号【{0}({1})】更新cookies失败，请检查服务器运行状态！", username, ((UserLable)sender).DisplayName));
            }
            //记录日志
        }
        //发布微博事件
        private void PublishWeiboEvent(object sender, bool isImageWeibo)
        {
            if (isImageWeibo)
            {
                this.PublishAnImageWeibo((UserLable)sender);
            }
            else
            {
                this.PublishAVideoWeibo((UserLable)sender);
            }
        }
        #endregion

        #region 私有方法
        //发布一条图文微博
        private void PublishAnImageWeibo(UserLable userLable)
        {
            if (SqliteTool.GetLaveWeiboCount(SqliteTool.WeiboType.ImageWeibo,userLable.DisplayName) != 0)
            {
                ImageWeibo weibo = SqliteTool.GetARandomImageWeiboIsNotPublished(SqliteTool.WeiboType.ImageWeibo,userLable.DisplayName);

                if (weibo.Pictures == null || weibo.Pictures.Length == 0)
                {
                    UserLog.WriteNormalLog("获取微博失败，类型不明确");
                    return;
                }

                //设置tags
                string weiboText = userLable.IsFrontTagsSet ?
                    userLable.Tags + weibo.WeiboMessage :
                    weibo.WeiboMessage + userLable.Tag;
                WeiboOperateTool.SendAnImageWeibo(userLable.Cookies, weibo.WeiboMessage, weibo.Pictures);
            }
            else
            {
                this.richTextBox1.Text = this.richTextBox1.Text + "微博库已空\n";
            }
        }
        //发布一条视频微博
        private void PublishAVideoWeibo(UserLable userLable)
        {

        }
        #endregion

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
                //int StartCount = SqliteTool.GetLaveWeiboCount(SqliteTool.WeiboType.ImageWeibo);

                //List<ImageWeibo> imageWeibos = WeiboOperate.GetImageWeibos(this.textBoxGetWeibo.Text,out string oid);

                //IOTools.SqliteTool.InsertImageWebos(imageWeibos);

                //int endCount = SqliteTool.GetLaveWeiboCount(SqliteTool.WeiboType.ImageWeibo);

                //UserLog.WriteNormalLog(String.Format("爬取图文微博{0}条", endCount - StartCount), String.Format("被爬取用户ID:{0}", this.textBoxGetWeibo.Text));

                //string requestStr = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "\n" + "获取结束：此次共取得图文微博" + (endCount - StartCount).ToString()+ "条";
                //this.richTextBox1.Text = this.richTextBox1.Text + requestStr + "\n";

                ////uid可以正常获取数据时说明有效，存入数据库
                //if (endCount - StartCount > 0)
                //{
                //    SqliteTool.InsertUidAndOid(this.textBoxGetWeibo.Text,oid);
                //}

                //this.UpdateDisplayDataMessage();
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
    }
}
