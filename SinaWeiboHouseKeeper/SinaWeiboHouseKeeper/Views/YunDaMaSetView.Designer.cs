namespace SinaWeiboHouseKeeper.Views
{
    partial class YunDaMaSetView
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
            this.buttonCancel = new CCWin.SkinControl.SkinButton();
            this.buttonOK = new CCWin.SkinControl.SkinButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            this.buttonCancel.Location = new System.Drawing.Point(188, 134);
            this.buttonCancel.MouseBack = null;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormlBack = null;
            this.buttonCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonCancel.Size = new System.Drawing.Size(65, 29);
            this.buttonCancel.TabIndex = 17;
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
            this.buttonOK.Location = new System.Drawing.Point(259, 134);
            this.buttonOK.MouseBack = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormlBack = null;
            this.buttonOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonOK.Size = new System.Drawing.Size(65, 29);
            this.buttonOK.TabIndex = 16;
            this.buttonOK.Tag = "1";
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(36, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "云打码密码";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxPassword.Location = new System.Drawing.Point(151, 90);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(175, 26);
            this.textBoxPassword.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(36, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "云打码账号";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("宋体", 12F);
            this.textBoxUsername.Location = new System.Drawing.Point(151, 53);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(175, 26);
            this.textBoxUsername.TabIndex = 12;
            // 
            // YunDaMaSetView
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.buttonCancel;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(363, 185);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUsername);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YunDaMaSetView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "云打码Cookies更新设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton buttonCancel;
        private CCWin.SkinControl.SkinButton buttonOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
    }
}