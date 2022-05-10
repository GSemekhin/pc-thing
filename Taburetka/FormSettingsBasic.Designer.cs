
namespace Taburetka
{
    partial class FormSettingsBasic
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
            this.checkBoxOnlyHighlighted = new System.Windows.Forms.CheckBox();
            this.labelLatency = new System.Windows.Forms.Label();
            this.trackBarLatency = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.checkBoxRunOnStartup = new System.Windows.Forms.CheckBox();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.checkBoxLaunchMinimized = new System.Windows.Forms.CheckBox();
            this.checkBoxHideToTray = new System.Windows.Forms.CheckBox();
            this.radioButtonStandart = new System.Windows.Forms.RadioButton();
            this.radioButtonPink = new System.Windows.Forms.RadioButton();
            this.comboBoxVoices = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLatency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxOnlyHighlighted
            // 
            this.checkBoxOnlyHighlighted.AutoSize = true;
            this.checkBoxOnlyHighlighted.Location = new System.Drawing.Point(69, 12);
            this.checkBoxOnlyHighlighted.Name = "checkBoxOnlyHighlighted";
            this.checkBoxOnlyHighlighted.Size = new System.Drawing.Size(190, 17);
            this.checkBoxOnlyHighlighted.TabIndex = 0;
            this.checkBoxOnlyHighlighted.Text = "Озвучивать только выделенные";
            this.checkBoxOnlyHighlighted.UseVisualStyleBackColor = true;
            this.checkBoxOnlyHighlighted.CheckedChanged += new System.EventHandler(this.checkBoxOnlyHighlighted_CheckedChanged);
            // 
            // labelLatency
            // 
            this.labelLatency.AutoSize = true;
            this.labelLatency.Location = new System.Drawing.Point(66, 41);
            this.labelLatency.Name = "labelLatency";
            this.labelLatency.Size = new System.Drawing.Size(61, 13);
            this.labelLatency.TabIndex = 1;
            this.labelLatency.Text = "Задержка:";
            // 
            // trackBarLatency
            // 
            this.trackBarLatency.LargeChange = 1;
            this.trackBarLatency.Location = new System.Drawing.Point(69, 57);
            this.trackBarLatency.Name = "trackBarLatency";
            this.trackBarLatency.Size = new System.Drawing.Size(180, 45);
            this.trackBarLatency.TabIndex = 2;
            this.trackBarLatency.Scroll += new System.EventHandler(this.trackBarLatency_Scroll);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(66, 105);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(65, 13);
            this.labelVolume.TabIndex = 3;
            this.labelVolume.Text = "Громкость:";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(66, 169);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(82, 13);
            this.labelOpacity.TabIndex = 4;
            this.labelOpacity.Text = "Прозрачность:";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(69, 121);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(180, 45);
            this.trackBarVolume.TabIndex = 5;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // checkBoxRunOnStartup
            // 
            this.checkBoxRunOnStartup.AutoSize = true;
            this.checkBoxRunOnStartup.Location = new System.Drawing.Point(69, 236);
            this.checkBoxRunOnStartup.Name = "checkBoxRunOnStartup";
            this.checkBoxRunOnStartup.Size = new System.Drawing.Size(191, 17);
            this.checkBoxRunOnStartup.TabIndex = 6;
            this.checkBoxRunOnStartup.Text = "Запускать при запуске Windows";
            this.checkBoxRunOnStartup.UseVisualStyleBackColor = true;
            this.checkBoxRunOnStartup.CheckedChanged += new System.EventHandler(this.checkBoxRunOnStartup_CheckedChanged);
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(69, 185);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Minimum = 10;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(180, 45);
            this.trackBarOpacity.TabIndex = 7;
            this.trackBarOpacity.Value = 100;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_Scroll);
            // 
            // checkBoxLaunchMinimized
            // 
            this.checkBoxLaunchMinimized.AutoSize = true;
            this.checkBoxLaunchMinimized.Location = new System.Drawing.Point(69, 259);
            this.checkBoxLaunchMinimized.Name = "checkBoxLaunchMinimized";
            this.checkBoxLaunchMinimized.Size = new System.Drawing.Size(128, 17);
            this.checkBoxLaunchMinimized.TabIndex = 8;
            this.checkBoxLaunchMinimized.Text = "Запускать свёрнуто";
            this.checkBoxLaunchMinimized.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideToTray
            // 
            this.checkBoxHideToTray.AutoSize = true;
            this.checkBoxHideToTray.Location = new System.Drawing.Point(69, 282);
            this.checkBoxHideToTray.Name = "checkBoxHideToTray";
            this.checkBoxHideToTray.Size = new System.Drawing.Size(231, 17);
            this.checkBoxHideToTray.TabIndex = 9;
            this.checkBoxHideToTray.Text = "Сворачивать в трей, если стрим офлайн";
            this.checkBoxHideToTray.UseVisualStyleBackColor = true;
            this.checkBoxHideToTray.CheckedChanged += new System.EventHandler(this.checkBoxHideToTray_CheckedChanged);
            // 
            // radioButtonStandart
            // 
            this.radioButtonStandart.AutoSize = true;
            this.radioButtonStandart.Location = new System.Drawing.Point(69, 318);
            this.radioButtonStandart.Name = "radioButtonStandart";
            this.radioButtonStandart.Size = new System.Drawing.Size(84, 17);
            this.radioButtonStandart.TabIndex = 10;
            this.radioButtonStandart.TabStop = true;
            this.radioButtonStandart.Text = "Стандартно";
            this.radioButtonStandart.UseVisualStyleBackColor = true;
            this.radioButtonStandart.CheckedChanged += new System.EventHandler(this.radioButtonStandart_CheckedChanged);
            // 
            // radioButtonPink
            // 
            this.radioButtonPink.AutoSize = true;
            this.radioButtonPink.Location = new System.Drawing.Point(69, 341);
            this.radioButtonPink.Name = "radioButtonPink";
            this.radioButtonPink.Size = new System.Drawing.Size(275, 17);
            this.radioButtonPink.TabIndex = 11;
            this.radioButtonPink.TabStop = true;
            this.radioButtonPink.Text = "Можно, чтобы всё было в нежно-розовом цвете?";
            this.radioButtonPink.UseVisualStyleBackColor = true;
            this.radioButtonPink.CheckedChanged += new System.EventHandler(this.radioButtonPink_CheckedChanged);
            // 
            // comboBoxVoices
            // 
            this.comboBoxVoices.FormattingEnabled = true;
            this.comboBoxVoices.Location = new System.Drawing.Point(69, 375);
            this.comboBoxVoices.Name = "comboBoxVoices";
            this.comboBoxVoices.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVoices.TabIndex = 12;
            this.comboBoxVoices.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoices_SelectedIndexChanged);
            // 
            // FormSettingsBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.comboBoxVoices);
            this.Controls.Add(this.radioButtonPink);
            this.Controls.Add(this.radioButtonStandart);
            this.Controls.Add(this.checkBoxHideToTray);
            this.Controls.Add(this.checkBoxLaunchMinimized);
            this.Controls.Add(this.trackBarOpacity);
            this.Controls.Add(this.checkBoxRunOnStartup);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.trackBarLatency);
            this.Controls.Add(this.labelLatency);
            this.Controls.Add(this.checkBoxOnlyHighlighted);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSettingsBasic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormSettingsBasic";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLatency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOnlyHighlighted;
        private System.Windows.Forms.Label labelLatency;
        private System.Windows.Forms.TrackBar trackBarLatency;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.CheckBox checkBoxRunOnStartup;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.CheckBox checkBoxLaunchMinimized;
        private System.Windows.Forms.CheckBox checkBoxHideToTray;
        private System.Windows.Forms.RadioButton radioButtonStandart;
        private System.Windows.Forms.RadioButton radioButtonPink;
        private System.Windows.Forms.ComboBox comboBoxVoices;
    }
}