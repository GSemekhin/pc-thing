namespace Taburetka
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.labelMenuMain = new System.Windows.Forms.Label();
            this.labelMenuLogin = new System.Windows.Forms.Label();
            this.labelLoginWarning = new System.Windows.Forms.Label();
            this.buttonLoginWarningYes = new System.Windows.Forms.Button();
            this.buttonLoginWarningNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMenuMain
            // 
            this.labelMenuMain.AutoSize = true;
            this.labelMenuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMenuMain.Location = new System.Drawing.Point(13, 22);
            this.labelMenuMain.Name = "labelMenuMain";
            this.labelMenuMain.Size = new System.Drawing.Size(85, 20);
            this.labelMenuMain.TabIndex = 29;
            this.labelMenuMain.Text = "Основные";
            this.labelMenuMain.Click += new System.EventHandler(this.labelMenuMain_Click);
            // 
            // labelMenuLogin
            // 
            this.labelMenuLogin.AutoSize = true;
            this.labelMenuLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMenuLogin.Location = new System.Drawing.Point(13, 53);
            this.labelMenuLogin.Name = "labelMenuLogin";
            this.labelMenuLogin.Size = new System.Drawing.Size(55, 20);
            this.labelMenuLogin.TabIndex = 30;
            this.labelMenuLogin.Text = "Логин";
            this.labelMenuLogin.Click += new System.EventHandler(this.labelMenuLogin_Click);
            // 
            // labelLoginWarning
            // 
            this.labelLoginWarning.AutoSize = true;
            this.labelLoginWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoginWarning.Location = new System.Drawing.Point(190, 115);
            this.labelLoginWarning.Name = "labelLoginWarning";
            this.labelLoginWarning.Size = new System.Drawing.Size(459, 31);
            this.labelLoginWarning.TabIndex = 44;
            this.labelLoginWarning.Text = "Это окно показывается на стриме?";
            this.labelLoginWarning.Visible = false;
            // 
            // buttonLoginWarningYes
            // 
            this.buttonLoginWarningYes.Location = new System.Drawing.Point(443, 184);
            this.buttonLoginWarningYes.Name = "buttonLoginWarningYes";
            this.buttonLoginWarningYes.Size = new System.Drawing.Size(75, 23);
            this.buttonLoginWarningYes.TabIndex = 45;
            this.buttonLoginWarningYes.Text = "Нет";
            this.buttonLoginWarningYes.UseVisualStyleBackColor = true;
            this.buttonLoginWarningYes.Visible = false;
            this.buttonLoginWarningYes.Click += new System.EventHandler(this.buttonLoginWarningYes_Click);
            // 
            // buttonLoginWarningNo
            // 
            this.buttonLoginWarningNo.Location = new System.Drawing.Point(264, 183);
            this.buttonLoginWarningNo.Name = "buttonLoginWarningNo";
            this.buttonLoginWarningNo.Size = new System.Drawing.Size(75, 23);
            this.buttonLoginWarningNo.TabIndex = 46;
            this.buttonLoginWarningNo.Text = "Ойи";
            this.buttonLoginWarningNo.UseVisualStyleBackColor = true;
            this.buttonLoginWarningNo.Visible = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(704, 505);
            this.Controls.Add(this.buttonLoginWarningNo);
            this.Controls.Add(this.buttonLoginWarningYes);
            this.Controls.Add(this.labelLoginWarning);
            this.Controls.Add(this.labelMenuLogin);
            this.Controls.Add(this.labelMenuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormSettings";
            this.Text = "Настроечки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelMenuMain;
        private System.Windows.Forms.Label labelMenuLogin;
        private System.Windows.Forms.Label labelLoginWarning;
        private System.Windows.Forms.Button buttonLoginWarningYes;
        private System.Windows.Forms.Button buttonLoginWarningNo;
    }
}