using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taburetka
{
    public partial class FormSettings : Form
    {
        SpeechWork speechWork;
        Settings settings;
        Login login;
        FormMain formMain;
        WinLib winLib;
        TwitchWork bot;

        FormSettingsBasic formSettingsBasic;

        FormSettingsLogin formSettingsLogin;
        public FormSettings(SpeechWork _speechWork, Settings _settings, FormMain _formMain, WinLib _winLib, TwitchWork _bot, Login _login)
        {
            InitializeComponent();


            this.settings = _settings;
            this.login = _login;
            this.formMain = _formMain;
            this.speechWork = _speechWork;
            this.winLib = _winLib;
            this.bot = _bot;

            formSettingsBasic = new FormSettingsBasic(settings, login, formMain, winLib);
            formSettingsBasic.MdiParent = this;
            formSettingsBasic.Show();
            formSettingsBasic.Location = new Point(100, 10);

            formSettingsLogin = new FormSettingsLogin(login, bot);
            formSettingsLogin.MdiParent = this;
            formSettingsLogin.Location = new Point(100, 10);

            labelMenuMain.Font = new Font(labelMenuMain.Font, labelMenuMain.Font.Style | FontStyle.Bold);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Control.DefaultBackColor;
                }
            }
        }



        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.SaveSettings();
            login.SaveLogin();
            e.Cancel = true;
            this.Hide();
        }


        //переключение пунктов меню
        #region Menu
        private void labelMenuMain_Click(object sender, EventArgs e)
        {
            formSettingsLogin.Hide();
            formSettingsBasic.Show();
            

            labelMenuLogin.Font = new Font(labelMenuLogin.Font, FontStyle.Regular);
            labelMenuMain.Font = new Font(labelMenuMain.Font, labelMenuMain.Font.Style | FontStyle.Bold);
            labelLoginWarning.Visible = false;
            buttonLoginWarningNo.Visible = false;
            buttonLoginWarningYes.Visible = false;
        }

        private void labelMenuLogin_Click(object sender, EventArgs e)
        {
            labelLoginWarning.Visible = true;
            buttonLoginWarningNo.Visible = true;
            buttonLoginWarningYes.Visible = true;

            formSettingsBasic.Hide();
        }

        private void buttonLoginWarningYes_Click(object sender, EventArgs e)
        {
            formSettingsLogin.Show();

            labelLoginWarning.Visible = false;
            buttonLoginWarningNo.Visible = false;
            buttonLoginWarningYes.Visible = false;

            labelMenuLogin.Font = new Font(labelMenuLogin.Font, labelMenuLogin.Font.Style | FontStyle.Bold);
            labelMenuMain.Font = new Font(labelMenuLogin.Font, FontStyle.Regular);
        }

        #endregion Menu
    }
}
