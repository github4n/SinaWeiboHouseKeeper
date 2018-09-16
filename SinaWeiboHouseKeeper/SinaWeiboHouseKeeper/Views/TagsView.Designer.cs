namespace SinaWeiboHouseKeeper.Views
{
    partial class TagsView
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radioBegin = new System.Windows.Forms.RadioButton();
            this.radioAfter = new System.Windows.Forms.RadioButton();
            this.buttonOK = new CCWin.SkinControl.SkinButton();
            this.buttonCancel = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.richTextBox1.Location = new System.Drawing.Point(24, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(298, 99);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // radioBegin
            // 
            this.radioBegin.AutoSize = true;
            this.radioBegin.BackColor = System.Drawing.Color.Transparent;
            this.radioBegin.Checked = true;
            this.radioBegin.Location = new System.Drawing.Point(24, 149);
            this.radioBegin.Name = "radioBegin";
            this.radioBegin.Size = new System.Drawing.Size(47, 16);
            this.radioBegin.TabIndex = 1;
            this.radioBegin.TabStop = true;
            this.radioBegin.Text = "前置";
            this.radioBegin.UseVisualStyleBackColor = false;
            // 
            // radioAfter
            // 
            this.radioAfter.AutoSize = true;
            this.radioAfter.BackColor = System.Drawing.Color.Transparent;
            this.radioAfter.Location = new System.Drawing.Point(87, 149);
            this.radioAfter.Name = "radioAfter";
            this.radioAfter.Size = new System.Drawing.Size(47, 16);
            this.radioAfter.TabIndex = 2;
            this.radioAfter.TabStop = true;
            this.radioAfter.Text = "后置";
            this.radioAfter.UseVisualStyleBackColor = false;
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
            this.buttonOK.Location = new System.Drawing.Point(257, 143);
            this.buttonOK.MouseBack = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormlBack = null;
            this.buttonOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonOK.Size = new System.Drawing.Size(65, 29);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Tag = "1";
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
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
            this.buttonCancel.Location = new System.Drawing.Point(186, 143);
            this.buttonCancel.MouseBack = null;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormlBack = null;
            this.buttonCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonCancel.Size = new System.Drawing.Size(65, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Tag = "1";
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // TagsView
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SinaWeiboHouseKeeper.Properties.Resources.geo_conf;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonCancel;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(349, 178);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioAfter);
            this.Controls.Add(this.radioBegin);
            this.Controls.Add(this.richTextBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagsView";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tags设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton radioBegin;
        private System.Windows.Forms.RadioButton radioAfter;
        private CCWin.SkinControl.SkinButton buttonOK;
        private CCWin.SkinControl.SkinButton buttonCancel;
    }
}