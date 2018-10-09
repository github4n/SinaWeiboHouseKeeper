namespace SinaWeiboHouseKeeper.Views
{
    partial class EmailSetView
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
            this.textBoxSendUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSendPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRecieveUserName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new CCWin.SkinControl.SkinButton();
            this.buttonOK = new CCWin.SkinControl.SkinButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxSendUserName
            // 
            this.textBoxSendUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxSendUserName.Location = new System.Drawing.Point(145, 53);
            this.textBoxSendUserName.Name = "textBoxSendUserName";
            this.textBoxSendUserName.Size = new System.Drawing.Size(175, 26);
            this.textBoxSendUserName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(30, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "发送邮件账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(30, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "发送邮件密码";
            // 
            // textBoxSendPassword
            // 
            this.textBoxSendPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxSendPassword.Location = new System.Drawing.Point(145, 92);
            this.textBoxSendPassword.Name = "textBoxSendPassword";
            this.textBoxSendPassword.PasswordChar = '*';
            this.textBoxSendPassword.Size = new System.Drawing.Size(175, 26);
            this.textBoxSendPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(30, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "接收邮件账号";
            // 
            // textBoxRecieveUserName
            // 
            this.textBoxRecieveUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxRecieveUserName.Location = new System.Drawing.Point(145, 129);
            this.textBoxRecieveUserName.Name = "textBoxRecieveUserName";
            this.textBoxRecieveUserName.Size = new System.Drawing.Size(175, 26);
            this.textBoxRecieveUserName.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.BaseColor = System.Drawing.Color.LightGray;
            this.buttonCancel.BorderColor = System.Drawing.Color.Silver;
            this.buttonCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.DownBack = null;
            this.buttonCancel.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonCancel.Location = new System.Drawing.Point(182, 210);
            this.buttonCancel.MouseBack = null;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormlBack = null;
            this.buttonCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonCancel.Size = new System.Drawing.Size(65, 29);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Tag = "1";
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.BaseColor = System.Drawing.Color.LightGray;
            this.buttonOK.BorderColor = System.Drawing.Color.Silver;
            this.buttonOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.DownBack = null;
            this.buttonOK.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonOK.Location = new System.Drawing.Point(253, 210);
            this.buttonOK.MouseBack = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormlBack = null;
            this.buttonOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonOK.Size = new System.Drawing.Size(65, 29);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Tag = "1";
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBox1.Location = new System.Drawing.Point(34, 172);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 20);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "每日报告发送时间";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0:00",
            "1:00",
            "2:00",
            "3:00",
            "4:00",
            "5:00",
            "6:00",
            "7:00",
            "8:00",
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.comboBox1.Location = new System.Drawing.Point(211, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 24);
            this.comboBox1.TabIndex = 13;
            // 
            // EmailSetView
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.buttonCancel;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(350, 254);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRecieveUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSendPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSendUserName);
            this.MaximizeBox = false;
            this.MaxSize = new System.Drawing.Size(352, 218);
            this.MinimizeBox = false;
            this.MiniSize = new System.Drawing.Size(352, 218);
            this.Name = "EmailSetView";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "邮件设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSendUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSendPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRecieveUserName;
        private CCWin.SkinControl.SkinButton buttonCancel;
        private CCWin.SkinControl.SkinButton buttonOK;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}