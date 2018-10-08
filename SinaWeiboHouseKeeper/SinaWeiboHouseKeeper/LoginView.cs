using CCWin;
using SinaWeiboHouseKeeper.IOTools;
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
    public partial class LoginView : Skin_DevExpress
    {
        public WeiboLogin WBLogin { get; private set; }

        public LoginView()
        {
            InitializeComponent();

            this.UpdateViewStyle();
        }

        #region 私有方法
        //更新界面显示效果
        private void UpdateViewStyle()
        {
            //隐藏验证码窗口
            this.skinPanel1.Visible = false;

        }

        //登录
        private void StartLogin()
        {
            WBLogin = new WeiboLogin(this.UserNameBox.Text, this.PasswordBox.Text, this.skinCheckBox1.Checked);

            if (this.skinCheckBox1.Checked && !this.skinPanel1.Visible)
            {
                this.CancelButton.Enabled = false;
                this.PasswordBox.Enabled = false;
                this.UserNameBox.Enabled = false;
                this.OkButton.Text = "验证";

                this.skinPanel1.Visible = true;
                this.skinPictureBox1.Image = WBLogin.Start();

                this.skinPictureBox1.Click += SkinPictureBox1_Click;
            }
            else
            {
                string result = WBLogin.End();
                if (result.Equals("0"))
                {
                    //登录成功
                    this.ClosePage();
                }
                else if (result.Equals("2070") || result.Equals("4096"))
                {
                    //验证码错误或者为空
                    this.skinCheckBox1.Checked = true;
                    this.PinBox.BackColor = Color.Red;

                }
                else if (result.Equals("101&") || result.Equals("4049"))
                {
                    //密码错误
                    this.UserNameBox.BackColor = Color.Red;
                    this.PasswordBox.BackColor = Color.Red;
                }
                else
                {
                    MessageBox.Show("未知错误！", "提示");
                }
            }
        }

        //登陆成功。打开首页
        private void ClosePage()
        {
            //创建用户文件夹并记录登陆日志
            UserLog.CreateUserLog(WBLogin.DisplayName);
            UserLog.WriteNormalLog(WBLogin.DisplayName,this.WBLogin.DisplayName + " 登陆成功","账号：" + this.UserNameBox.Text);

            this.Close();
            this.DialogResult = DialogResult.OK;
        }


        #endregion

        #region 事件
        //取消按键
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //登录验证
        private void OkButton_Click(object sender, EventArgs e)
        {
            //无验证码登录
            if (!this.OkButton.Text.Equals("验证"))
            {
                if (this.UserNameBox.Text.Equals("") || this.PasswordBox.Text.Equals(""))
                {
                    this.UserNameBox.BackColor = Color.Red;
                    this.PasswordBox.BackColor = Color.Red;
                }
                else
                {
                    this.UserNameBox.BackColor = Color.Transparent;
                    this.PasswordBox.BackColor = Color.Transparent;

                    this.StartLogin();
                }
            }
            else
            {
                if (this.PinBox.Text.Equals(""))
                {
                    this.PinBox.BackColor = Color.Red;
                }
                else
                {
                    this.PinBox.BackColor = Color.Transparent;

                    string result = WBLogin.End(this.PinBox.Text);

                    if (result == "0")
                    {
                        //登录成功
                        this.ClosePage();
                    }
                    else if (result == "2070")
                    {
                        //验证码错误
                        this.skinPictureBox1.Image = WBLogin.GetPIN();
                        this.PinBox.Text = "";
                        this.PinBox.BackColor = Color.Red;
                    }
                    else if (result == "101&")
                    {
                        //密码错误
                        this.skinPanel1.Visible = false;
                        this.PinBox.Text = "";
                        this.UserNameBox.BackColor = Color.Red;
                        this.PasswordBox.BackColor = Color.Red;
                        this.OkButton.Text = "确定";

                        this.UserNameBox.Enabled = true;
                        this.PasswordBox.Enabled = true;
                        this.CancelButton.Enabled = true;
                    }
                    else if (result == "4069")
                    {
                        MessageBox.Show("体验期已过，请验证邮箱", "提示");
                    }
                    else
                    {
                        MessageBox.Show("未知错误", "提示");
                    }
                }
            }
        }

        //验证码刷新
        private void SkinPictureBox1_Click(object sender, EventArgs e)
        {
            this.skinPictureBox1.Image = WBLogin.GetPIN();
        }

        #endregion
    }
}
