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

namespace WeiboHouseKeeper
{
    public partial class UserLable: UserControl
    {
        WeiboSetView WeiboSet = new WeiboSetView();

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WeiboSet.ShowSettingView(" zzz");
            this.ShowDisplayMessage();
        }

        #region
        /// <summary>
        /// 显示设置界面显示的信息
        /// </summary>
        private void ShowDisplayMessage()
        {

            this.Refresh();
        }
        #endregion
    }
}
