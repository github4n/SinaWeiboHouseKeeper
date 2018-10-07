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

        private void UpdateSQLiteEvent(object sender)
        {
            throw new NotImplementedException();
        }

        private void WriteLogEvent(object sender, string title, string message)
        {
            throw new NotImplementedException();
        }

        private void SendEmailEvent(object sender, string message)
        {
            throw new NotImplementedException();
        }
        //更新cookie事件
        private void UpdateCookiesEvent(object sender)
        {
            
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
                IOTools.WeiboOperateTool.SendAnImageWeibo(userLable.Cookies, weibo.WeiboMessage, weibo.Pictures);
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
    }
}
