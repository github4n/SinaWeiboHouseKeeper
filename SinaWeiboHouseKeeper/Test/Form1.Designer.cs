namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.userLable1 = new WeiboHouseKeeper.UserLable();
            this.userLable2 = new WeiboHouseKeeper.UserLable();
            this.SuspendLayout();
            // 
            // userLable1
            // 
            this.userLable1.Location = new System.Drawing.Point(12, 12);
            this.userLable1.MaximumSize = new System.Drawing.Size(0, 170);
            this.userLable1.MinimumSize = new System.Drawing.Size(449, 170);
            this.userLable1.Name = "userLable1";
            this.userLable1.NickName = "groupBox1";
            this.userLable1.Size = new System.Drawing.Size(449, 170);
            this.userLable1.TabIndex = 0;
            // 
            // userLable2
            // 
            this.userLable2.Location = new System.Drawing.Point(12, 188);
            this.userLable2.MaximumSize = new System.Drawing.Size(0, 170);
            this.userLable2.MinimumSize = new System.Drawing.Size(449, 170);
            this.userLable2.Name = "userLable2";
            this.userLable2.NickName = "groupBox1";
            this.userLable2.Size = new System.Drawing.Size(449, 170);
            this.userLable2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 495);
            this.Controls.Add(this.userLable2);
            this.Controls.Add(this.userLable1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WeiboHouseKeeper.UserLable userLable1;
        private WeiboHouseKeeper.UserLable userLable2;
    }
}

