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
    public partial class FormSettingsLogin : Form
    {
        Login login;

        TwitchWork bot;

        public FormSettingsLogin(Login _login, TwitchWork _bot)
        {
            InitializeComponent();

            login = _login;
            bot = _bot;

            textBoxBotName.Text = login.BotName;
            textBoxAccessToken.Text = login.AccessToken;
            textBoxClientId.Text = login.ClientId;
            textBoxTtsToken.Text = login.TtsToken;
            textBoxDBAdress.Text = login.BDAdress;
            textBoxDBUser.Text = login.BDUser;
            textBoxDBPassword.Text = login.BDPassword;
            textBoxDBTable.Text = login.BDTable;
            textBoxTargetChannel.Text = login.TargetChannel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            login.BotName = textBoxBotName.Text;
            login.AccessToken = textBoxAccessToken.Text;
            login.ClientId = textBoxClientId.Text;
            login.TtsToken = textBoxTtsToken.Text;
            login.BDAdress = textBoxDBAdress.Text;
            login.BDUser = textBoxDBUser.Text;
            login.BDPassword = textBoxDBPassword.Text;
            login.BDTable = textBoxDBTable.Text;
            login.TargetChannel = textBoxTargetChannel.Text;

            bot.DisconnectFromChat();
            bot.DisconnectFromPubSub();

            login.SaveLogin();
        }
    }
}
