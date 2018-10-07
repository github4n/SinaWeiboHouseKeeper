namespace SinaWeiboHouseKeeper.Views
{
    partial class MainPageView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.邮件报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.验证码识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCollection = new CCWin.SkinControl.SkinPanel();
            this.groupBoxGetWeibo = new System.Windows.Forms.GroupBox();
            this.buttonStartGetWeibo = new CCWin.SkinControl.SkinButton();
            this.checkBoxGetVideoWeibo = new System.Windows.Forms.CheckBox();
            this.checkBoxGetImageWeibo = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxGetWeibo = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.panelCollection.SuspendLayout();
            this.groupBoxGetWeibo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 34);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录账号ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 登录账号ToolStripMenuItem
            // 
            this.登录账号ToolStripMenuItem.Name = "登录账号ToolStripMenuItem";
            this.登录账号ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.登录账号ToolStripMenuItem.Text = "登录账号";
            this.登录账号ToolStripMenuItem.Click += new System.EventHandler(this.登录账号ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagsToolStripMenuItem,
            this.AdFilterToolStripMenuItem,
            this.邮件报告ToolStripMenuItem,
            this.验证码识别ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // tagsToolStripMenuItem
            // 
            this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
            this.tagsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tagsToolStripMenuItem.Text = "Tags";
            // 
            // AdFilterToolStripMenuItem
            // 
            this.AdFilterToolStripMenuItem.Name = "AdFilterToolStripMenuItem";
            this.AdFilterToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.AdFilterToolStripMenuItem.Text = "广告特征词过滤";
            // 
            // 邮件报告ToolStripMenuItem
            // 
            this.邮件报告ToolStripMenuItem.Name = "邮件报告ToolStripMenuItem";
            this.邮件报告ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.邮件报告ToolStripMenuItem.Text = "邮件报告";
            // 
            // 验证码识别ToolStripMenuItem
            // 
            this.验证码识别ToolStripMenuItem.Name = "验证码识别ToolStripMenuItem";
            this.验证码识别ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.验证码识别ToolStripMenuItem.Text = "Cookie更新";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(7, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 470);
            this.panel1.TabIndex = 3;
            // 
            // panelCollection
            // 
            this.panelCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCollection.BackColor = System.Drawing.Color.Transparent;
            this.panelCollection.Controls.Add(this.groupBoxGetWeibo);
            this.panelCollection.Controls.Add(this.richTextBox1);
            this.panelCollection.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelCollection.DownBack = null;
            this.panelCollection.Location = new System.Drawing.Point(484, 62);
            this.panelCollection.MouseBack = null;
            this.panelCollection.Name = "panelCollection";
            this.panelCollection.NormlBack = null;
            this.panelCollection.Size = new System.Drawing.Size(335, 468);
            this.panelCollection.TabIndex = 4;
            // 
            // groupBoxGetWeibo
            // 
            this.groupBoxGetWeibo.Controls.Add(this.buttonStartGetWeibo);
            this.groupBoxGetWeibo.Controls.Add(this.checkBoxGetVideoWeibo);
            this.groupBoxGetWeibo.Controls.Add(this.checkBoxGetImageWeibo);
            this.groupBoxGetWeibo.Controls.Add(this.label18);
            this.groupBoxGetWeibo.Controls.Add(this.textBoxGetWeibo);
            this.groupBoxGetWeibo.Location = new System.Drawing.Point(3, 304);
            this.groupBoxGetWeibo.Name = "groupBoxGetWeibo";
            this.groupBoxGetWeibo.Size = new System.Drawing.Size(329, 161);
            this.groupBoxGetWeibo.TabIndex = 1;
            this.groupBoxGetWeibo.TabStop = false;
            this.groupBoxGetWeibo.Text = "获取数据";
            // 
            // buttonStartGetWeibo
            // 
            this.buttonStartGetWeibo.BackColor = System.Drawing.Color.Transparent;
            this.buttonStartGetWeibo.BaseColor = System.Drawing.Color.LightGray;
            this.buttonStartGetWeibo.BorderColor = System.Drawing.Color.Silver;
            this.buttonStartGetWeibo.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonStartGetWeibo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStartGetWeibo.DownBack = null;
            this.buttonStartGetWeibo.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonStartGetWeibo.Location = new System.Drawing.Point(85, 121);
            this.buttonStartGetWeibo.MouseBack = null;
            this.buttonStartGetWeibo.Name = "buttonStartGetWeibo";
            this.buttonStartGetWeibo.NormlBack = null;
            this.buttonStartGetWeibo.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonStartGetWeibo.Size = new System.Drawing.Size(109, 29);
            this.buttonStartGetWeibo.TabIndex = 15;
            this.buttonStartGetWeibo.Text = "开始获取";
            this.buttonStartGetWeibo.UseVisualStyleBackColor = false;
            // 
            // checkBoxGetVideoWeibo
            // 
            this.checkBoxGetVideoWeibo.AutoSize = true;
            this.checkBoxGetVideoWeibo.Location = new System.Drawing.Point(154, 92);
            this.checkBoxGetVideoWeibo.Name = "checkBoxGetVideoWeibo";
            this.checkBoxGetVideoWeibo.Size = new System.Drawing.Size(72, 16);
            this.checkBoxGetVideoWeibo.TabIndex = 14;
            this.checkBoxGetVideoWeibo.Text = "视频内容";
            this.checkBoxGetVideoWeibo.UseVisualStyleBackColor = true;
            // 
            // checkBoxGetImageWeibo
            // 
            this.checkBoxGetImageWeibo.AutoSize = true;
            this.checkBoxGetImageWeibo.Location = new System.Drawing.Point(52, 92);
            this.checkBoxGetImageWeibo.Name = "checkBoxGetImageWeibo";
            this.checkBoxGetImageWeibo.Size = new System.Drawing.Size(72, 16);
            this.checkBoxGetImageWeibo.TabIndex = 13;
            this.checkBoxGetImageWeibo.Text = "图文内容";
            this.checkBoxGetImageWeibo.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "待爬取用户ID或个性域名:";
            // 
            // textBoxGetWeibo
            // 
            this.textBoxGetWeibo.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxGetWeibo.Location = new System.Drawing.Point(40, 49);
            this.textBoxGetWeibo.Name = "textBoxGetWeibo";
            this.textBoxGetWeibo.Size = new System.Drawing.Size(209, 30);
            this.textBoxGetWeibo.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(329, 294);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // MainPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(826, 537);
            this.Controls.Add(this.panelCollection);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainPageView";
            this.Text = "MainPageView";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCollection.ResumeLayout(false);
            this.groupBoxGetWeibo.ResumeLayout(false);
            this.groupBoxGetWeibo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 邮件报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 验证码识别ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinPanel panelCollection;
        private System.Windows.Forms.GroupBox groupBoxGetWeibo;
        private CCWin.SkinControl.SkinButton buttonStartGetWeibo;
        private System.Windows.Forms.CheckBox checkBoxGetVideoWeibo;
        private System.Windows.Forms.CheckBox checkBoxGetImageWeibo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxGetWeibo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 登录账号ToolStripMenuItem;
    }
}