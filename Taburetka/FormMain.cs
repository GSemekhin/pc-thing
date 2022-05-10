using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;




namespace Taburetka
{
    public partial class FormMain : Form
    {
        System.Timers.Timer pauseTimer;
        bool kostilTimerForPause;

        Settings settings;
        TwitchWork bot;
        SpeechWork speechWork;
        FormSettings formSettings;
        Login login;

        WinLib winLib;
        bool topMost = false;


        public FormMain()
        {

            InitializeComponent();
            settings = new Settings();
            login = new Login();

            speechWork = new SpeechWork(this, settings, login);
            bot = new TwitchWork(this, speechWork, settings, login);
            winLib = new WinLib(settings);
            formSettings = new FormSettings(speechWork, settings, this, winLib, bot, login);

            FormBorderStyle = FormBorderStyle.None;
        }

        public void SetData(string message)
        {
            if (textBoxMessage.InvokeRequired)
                textBoxMessage.Invoke(new Action<string>((s) => textBoxMessage.Text = s), message);
            else
                textBoxMessage.Text = message;
        }

        public void SetOpacity(double opacity)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action<double>((_opacity) => this.Opacity = _opacity), opacity);
            else
                this.Opacity = opacity;
        }

        public void SetDataTestBox(string message)
        {
            if (richTextBoxTest.InvokeRequired)
                richTextBoxTest.Invoke(new Action<string>((s) => richTextBoxTest.Text = s), message);
            else
                richTextBoxTest.Text = message;
        }

        public void SetMainFormVisible()
        {


            Show();
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
            this.Height = settings.FormHeight;
            this.Width = settings.FormWidth;
        }

        public void ShowMainFormWitoutFocus()
        {
            winLib.ShouWindowWitoutFocus(this.Handle);
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            buttonPause.Image = Properties.Resources.PlayBlack16;
            buttonPause.ImageAlign = ContentAlignment.MiddleCenter;


            pauseTimer = new System.Timers.Timer();
            pauseTimer.Interval = 2000;
            pauseTimer.Elapsed += new System.Timers.ElapsedEventHandler(pauseTimer_Elapsed);
            pauseTimer.AutoReset = true;
            pauseTimer.Enabled = true;

            this.Location = new Point(settings.FormLocationX, settings.FormLocationY);
            this.Height = settings.FormHeight;
            this.Width = settings.FormWidth;

            if (settings.IsStandart == true)
            {
                SetStandart();
            }
            else
            {
                SetPink();
            }
        }

        #region Timer for change play button
        private async void pauseTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (settings.IsStandart == true)
            {
                if (kostilTimerForPause == false)
                {
                    buttonPause.Image = Properties.Resources.PlayBlackFull16;
                    kostilTimerForPause = true;
                }
                else
                {
                    buttonPause.Image = Properties.Resources.PlayBlack16;
                    kostilTimerForPause = false;
                }
            }
            else
            {
                if (kostilTimerForPause == false)
                {
                    buttonPause.Image = Properties.Resources.PlayPinkFull16;
                    kostilTimerForPause = true;
                }
                else
                {
                    buttonPause.Image = Properties.Resources.PlayPink16;
                    kostilTimerForPause = false;
                }
            }
        }
        #endregion Timer for change play button

        #region Buttons

        #region Pause button
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (settings.IsStandart == true)
            {
                if (speechWork.Pause == false)
                {
                    buttonPause.Image = Properties.Resources.PlayBlack16;
                    speechWork.Pause = true;
                    pauseTimer.Start();
                }
                else
                {
                    buttonPause.Image = Properties.Resources.PauseBlack16;
                    speechWork.Pause = false;
                    pauseTimer.Stop();
                }
            }
            else
            {
                if (speechWork.Pause == false)
                {
                    buttonPause.Image = Properties.Resources.PlayPink16;
                    speechWork.Pause = true;
                    pauseTimer.Start();
                }
                else
                {
                    buttonPause.Image = Properties.Resources.PausePink16;
                    speechWork.Pause = false;
                    pauseTimer.Stop();
                }
            }
        }
        #endregion Pause button

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            speechWork.Skip = true;
        }


        private void trackBarVolume_Scroll_1(object sender, EventArgs e)
        {
            settings.Volume = trackBarVolume.Value;
        }



        private void buttonSettings_Click(object sender, EventArgs e)
        {
            formSettings.Show();
        }


        private void buttonTopMost_Click(object sender, EventArgs e)
        {
            if (!topMost)
            {
                winLib.SetTopMost(this.Handle);
                topMost = true;
            }
            else
            {
                winLib.CancelTopMost(this.Handle);
                topMost = false;
            }
        }

        private void buttonAddTestMessage_Click(object sender, EventArgs e)
        {
            if (textBoxTestMessage.Visible == false)
            {
                textBoxTestMessage.Visible = true;
                buttonAddTestMessageToTTS.Visible = true;
                textBoxMessage.Location = new Point(textBoxMessage.Location.X, textBoxMessage.Location.Y + 110);
                textBoxTestMessage.Text = "";
            }
            else
            {
                textBoxTestMessage.Visible = false;
                buttonAddTestMessageToTTS.Visible = false;
                textBoxMessage.Location = new Point(textBoxMessage.Location.X, textBoxMessage.Location.Y - 110);
            }
        }

        private async void buttonAddTestMessageToTTS_Click(object sender, EventArgs e)
        {
            textBoxTestMessage.Visible = false;
            buttonAddTestMessageToTTS.Visible = false;
            textBoxMessage.Location = new Point(textBoxMessage.Location.X, textBoxMessage.Location.Y - 110);

            var temp = await speechWork.AddMessage("test" + DateTime.Now.ToString("ddMMyyyyHHmmss"), textBoxTestMessage.Text, "testMessageSender", Color.Black, true);
        }

        #region StandartButtons
        //Выход
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Сохранение настроек при закрытии
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.FormHeight = this.Height;
            settings.FormWidth = this.Width;
            settings.FormLocationX = this.Location.X;
            settings.FormLocationY = this.Location.Y;
            settings.SaveSettings();
        }
        //Сворачивание
        private void buttonHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            if ((settings.StreamOnline == false) && (settings.HideToTray == true))
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }
        //Перетаскивание окна
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                winLib.DragWindow(this.Handle);
            }
        }
        //Изменение размера
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                const int resizeArea = 10;
                Point cursorPosition = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                if (cursorPosition.X >= ClientSize.Width - resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        //Клик по панели задач
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        #endregion StandartButtons

        #endregion Buttons
        private void textBoxMessage_MouseDown(object sender, MouseEventArgs e)
        {
            if (settings.IsStandart == true)
            {
                buttonPause.Image = Properties.Resources.PlayBlack16;
            }
            else
            {
                buttonPause.Image = Properties.Resources.PlayPink16;
            }

            speechWork.Pause = true;
            pauseTimer.Start();
        }

        private async void textBoxTestMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxTestMessage.Visible = false;
                buttonAddTestMessageToTTS.Visible = false;
                textBoxMessage.Location = new Point(textBoxMessage.Location.X, textBoxMessage.Location.Y - 110);

                var temp = await speechWork.AddMessage("test" + DateTime.Now.ToString("ddMMyyyyHHmmss"), textBoxTestMessage.Text, "testMessageSender", Color.Black, true);
            }
        }


        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (settings.LaunchMinimizied == true)
            {
                WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                //Hide();
                notifyIcon.Visible = true;
            }
            this.Height = settings.FormHeight;
            this.Width = settings.FormWidth;
            if (settings.IsStandart == true)
            {
                SetStandart();
            }
            else
            {
                SetPink();
            }
        }

        #region SetTheme
        public void SetStandart()
        {

            if (speechWork.Pause == true)
            {
                buttonPause.Image = Properties.Resources.PlayBlack16;
            }
            else
            {
                buttonPause.Image = Properties.Resources.PauseBlack16;
            }
            buttonPause.ImageAlign = ContentAlignment.MiddleCenter;
            buttonPause.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonPause.FlatAppearance.BorderSize = 0;
            buttonPause.FlatStyle = FlatStyle.Flat;

            buttonHide.Image = Properties.Resources.HideBlack16;
            buttonHide.ImageAlign = ContentAlignment.MiddleCenter;
            buttonHide.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonHide.FlatAppearance.BorderSize = 0;
            buttonHide.FlatStyle = FlatStyle.Flat;

            buttonExit.Image = Properties.Resources.ExitBlack16;
            buttonExit.ImageAlign = ContentAlignment.MiddleCenter;
            buttonExit.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;

            buttonSettings.Image = Properties.Resources.SettingsBlack16;
            buttonSettings.ImageAlign = ContentAlignment.MiddleCenter;
            buttonSettings.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = FlatStyle.Flat;

            buttonSkip.Image = Properties.Resources.SkipBlack16;
            buttonSkip.ImageAlign = ContentAlignment.MiddleCenter;
            buttonSkip.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonSkip.FlatAppearance.BorderSize = 0;
            buttonSkip.FlatStyle = FlatStyle.Flat;

            buttonAddTestMessage.Image = Properties.Resources.AddBlack16;
            buttonAddTestMessage.ImageAlign = ContentAlignment.MiddleCenter;
            buttonAddTestMessage.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonAddTestMessage.FlatAppearance.BorderSize = 0;
            buttonAddTestMessage.FlatStyle = FlatStyle.Flat;

            buttonTopMost.Image = Properties.Resources.PinBlack16;
            buttonTopMost.ImageAlign = ContentAlignment.MiddleCenter;
            buttonTopMost.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonTopMost.FlatAppearance.BorderSize = 0;
            buttonTopMost.FlatStyle = FlatStyle.Flat;

            buttonAddTestMessageToTTS.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            buttonAddTestMessageToTTS.ForeColor = ColorTranslator.FromHtml("#000000");
            buttonAddTestMessageToTTS.FlatAppearance.BorderSize = 0;
            buttonAddTestMessageToTTS.FlatStyle = FlatStyle.Flat;

            this.BackColor = ColorTranslator.FromHtml("#f0f0f0");

            textBoxMessage.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            textBoxMessage.ForeColor = ColorTranslator.FromHtml("#000000");

            textBoxTestMessage.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            textBoxTestMessage.ForeColor = ColorTranslator.FromHtml("#000000");

        }
        public void SetPink()
        {

            if (speechWork.Pause == true)
            {
                buttonPause.Image = Properties.Resources.PlayPink16;
            }
            else
            {
                buttonPause.Image = Properties.Resources.PausePink16;
            }
            buttonPause.ImageAlign = ContentAlignment.MiddleCenter;
            buttonPause.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonPause.FlatAppearance.BorderSize = 0;
            buttonPause.FlatStyle = FlatStyle.Flat;

            buttonHide.Image = Properties.Resources.HidePink16;
            buttonHide.ImageAlign = ContentAlignment.MiddleCenter;
            buttonHide.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonHide.FlatAppearance.BorderSize = 0;
            buttonHide.FlatStyle = FlatStyle.Flat;

            buttonExit.Image = Properties.Resources.ExitPink16;
            buttonExit.ImageAlign = ContentAlignment.MiddleCenter;
            buttonExit.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;

            buttonSettings.Image = Properties.Resources.SettingsPink16;
            buttonSettings.ImageAlign = ContentAlignment.MiddleCenter;
            buttonSettings.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = FlatStyle.Flat;

            buttonSkip.Image = Properties.Resources.SkipPink16;
            buttonSkip.ImageAlign = ContentAlignment.MiddleCenter;
            buttonSkip.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonSkip.FlatAppearance.BorderSize = 0;
            buttonSkip.FlatStyle = FlatStyle.Flat;

            buttonAddTestMessage.Image = Properties.Resources.AddPink16;
            buttonAddTestMessage.ImageAlign = ContentAlignment.MiddleCenter;
            buttonAddTestMessage.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonAddTestMessage.FlatAppearance.BorderSize = 0;
            buttonAddTestMessage.FlatStyle = FlatStyle.Flat;

            buttonTopMost.Image = Properties.Resources.PinPink16;
            buttonTopMost.ImageAlign = ContentAlignment.MiddleCenter;
            buttonTopMost.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonTopMost.FlatAppearance.BorderSize = 0;
            buttonTopMost.FlatStyle = FlatStyle.Flat;

            buttonAddTestMessageToTTS.BackColor = ColorTranslator.FromHtml("#ffdad9");
            buttonAddTestMessageToTTS.ForeColor = ColorTranslator.FromHtml("#b05252");
            buttonAddTestMessageToTTS.FlatAppearance.BorderSize = 0;
            buttonAddTestMessageToTTS.FlatStyle = FlatStyle.Flat;

            this.BackColor = ColorTranslator.FromHtml("#ffdad9");

            textBoxMessage.BackColor = ColorTranslator.FromHtml("#ffe4e1");
            textBoxMessage.ForeColor = ColorTranslator.FromHtml("#b05252");

            textBoxTestMessage.BackColor = ColorTranslator.FromHtml("#ffe4e1");
            textBoxTestMessage.ForeColor = ColorTranslator.FromHtml("#b05252");

        }


        #endregion SetTheme

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon.Visible = false;
                WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                
                
            }
        }
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void clickOnTaskbar(object sender, EventArgs e)
        {
            if (WindowState.HasFlag(FormWindowState.Minimized))
            {
                notifyIcon.Visible = false;
                WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;

            }
            else
            {
                if (settings.StreamOnline == true)
                {
                    WindowState = FormWindowState.Minimized;
                }
                else if (settings.HideToTray == false)
                {
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    Hide();
                    notifyIcon.Visible = true;
                }

            }
        }
    }

}
