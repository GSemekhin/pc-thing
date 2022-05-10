namespace Taburetka
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.richTextBoxTest = new System.Windows.Forms.RichTextBox();
            this.textBoxTestMessage = new System.Windows.Forms.TextBox();
            this.buttonAddTestMessageToTTS = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAddTestMessage = new System.Windows.Forms.Button();
            this.buttonTopMost = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonSkip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.contextMenuStripNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMessage.Location = new System.Drawing.Point(12, 31);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.ShortcutsEnabled = false;
            this.textBoxMessage.Size = new System.Drawing.Size(605, 274);
            this.textBoxMessage.TabIndex = 0;
            this.textBoxMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxMessage_MouseDown);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(31, 0);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(25, 25);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarVolume.Location = new System.Drawing.Point(93, 0);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(180, 45);
            this.trackBarVolume.TabIndex = 10;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Visible = false;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll_1);
            // 
            // richTextBoxTest
            // 
            this.richTextBoxTest.Location = new System.Drawing.Point(25, 403);
            this.richTextBoxTest.Name = "richTextBoxTest";
            this.richTextBoxTest.Size = new System.Drawing.Size(384, 206);
            this.richTextBoxTest.TabIndex = 13;
            this.richTextBoxTest.Text = "";
            this.richTextBoxTest.Visible = false;
            // 
            // textBoxTestMessage
            // 
            this.textBoxTestMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTestMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTestMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTestMessage.Location = new System.Drawing.Point(12, 31);
            this.textBoxTestMessage.Multiline = true;
            this.textBoxTestMessage.Name = "textBoxTestMessage";
            this.textBoxTestMessage.Size = new System.Drawing.Size(606, 100);
            this.textBoxTestMessage.TabIndex = 15;
            this.textBoxTestMessage.Visible = false;
            this.textBoxTestMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTestMessage_KeyDown);
            // 
            // buttonAddTestMessageToTTS
            // 
            this.buttonAddTestMessageToTTS.Location = new System.Drawing.Point(279, 0);
            this.buttonAddTestMessageToTTS.Name = "buttonAddTestMessageToTTS";
            this.buttonAddTestMessageToTTS.Size = new System.Drawing.Size(50, 25);
            this.buttonAddTestMessageToTTS.TabIndex = 16;
            this.buttonAddTestMessageToTTS.Text = "ляля!";
            this.buttonAddTestMessageToTTS.UseVisualStyleBackColor = true;
            this.buttonAddTestMessageToTTS.Visible = false;
            this.buttonAddTestMessageToTTS.Click += new System.EventHandler(this.buttonAddTestMessageToTTS_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Taburetka";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStripNotifyIcon
            // 
            this.contextMenuStripNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.contextMenuStripNotifyIcon.Name = "contextMenuStripNotifyIcon";
            this.contextMenuStripNotifyIcon.Size = new System.Drawing.Size(121, 26);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHide.Location = new System.Drawing.Point(580, 0);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(25, 25);
            this.buttonHide.TabIndex = 18;
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(605, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(25, 25);
            this.buttonExit.TabIndex = 17;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAddTestMessage
            // 
            this.buttonAddTestMessage.Location = new System.Drawing.Point(0, 0);
            this.buttonAddTestMessage.Name = "buttonAddTestMessage";
            this.buttonAddTestMessage.Size = new System.Drawing.Size(25, 25);
            this.buttonAddTestMessage.TabIndex = 14;
            this.buttonAddTestMessage.UseVisualStyleBackColor = true;
            this.buttonAddTestMessage.Click += new System.EventHandler(this.buttonAddTestMessage_Click);
            // 
            // buttonTopMost
            // 
            this.buttonTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTopMost.Location = new System.Drawing.Point(549, 0);
            this.buttonTopMost.Name = "buttonTopMost";
            this.buttonTopMost.Size = new System.Drawing.Size(25, 25);
            this.buttonTopMost.TabIndex = 12;
            this.buttonTopMost.UseVisualStyleBackColor = true;
            this.buttonTopMost.Click += new System.EventHandler(this.buttonTopMost_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(518, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(25, 25);
            this.buttonSettings.TabIndex = 11;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonSkip
            // 
            this.buttonSkip.Location = new System.Drawing.Point(62, 0);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(25, 25);
            this.buttonSkip.TabIndex = 3;
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 423);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAddTestMessageToTTS);
            this.Controls.Add(this.textBoxTestMessage);
            this.Controls.Add(this.buttonAddTestMessage);
            this.Controls.Add(this.richTextBoxTest);
            this.Controls.Add(this.buttonTopMost);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonSkip);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.trackBarVolume);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Taburetka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.contextMenuStripNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonTopMost;
        private System.Windows.Forms.RichTextBox richTextBoxTest;
        private System.Windows.Forms.Button buttonAddTestMessage;
        private System.Windows.Forms.TextBox textBoxTestMessage;
        private System.Windows.Forms.Button buttonAddTestMessageToTTS;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}

