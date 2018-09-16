namespace SinaWeiboHouseKeeper.Views
{
    partial class ADFilePathView
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCancel = new CCWin.SkinControl.SkinButton();
            this.buttonOK = new CCWin.SkinControl.SkinButton();
            this.buttonSelect = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(37, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 26);
            this.textBox1.TabIndex = 0;
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
            this.buttonCancel.Location = new System.Drawing.Point(222, 136);
            this.buttonCancel.MouseBack = null;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NormlBack = null;
            this.buttonCancel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonCancel.Size = new System.Drawing.Size(65, 29);
            this.buttonCancel.TabIndex = 8;
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
            this.buttonOK.Location = new System.Drawing.Point(293, 136);
            this.buttonOK.MouseBack = null;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NormlBack = null;
            this.buttonOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonOK.Size = new System.Drawing.Size(65, 29);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Tag = "1";
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackColor = System.Drawing.Color.Transparent;
            this.buttonSelect.BaseColor = System.Drawing.Color.LightGray;
            this.buttonSelect.BorderColor = System.Drawing.Color.Silver;
            this.buttonSelect.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonSelect.DownBack = null;
            this.buttonSelect.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonSelect.Location = new System.Drawing.Point(293, 66);
            this.buttonSelect.MouseBack = null;
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.NormlBack = null;
            this.buttonSelect.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.buttonSelect.Size = new System.Drawing.Size(65, 29);
            this.buttonSelect.TabIndex = 9;
            this.buttonSelect.Tag = "1";
            this.buttonSelect.Text = "浏览";
            this.buttonSelect.UseVisualStyleBackColor = false;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(35, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "*广告特征词文件应为txt格式，关键词之间以“%”分隔。";
            // 
            // ADFilePathView
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(401, 185);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MdiAutoScroll = false;
            this.MinimizeBox = false;
            this.Name = "ADFilePathView";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择广告特征词过滤文件";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private CCWin.SkinControl.SkinButton buttonCancel;
        private CCWin.SkinControl.SkinButton buttonOK;
        private CCWin.SkinControl.SkinButton buttonSelect;
        private System.Windows.Forms.Label label1;
    }
}