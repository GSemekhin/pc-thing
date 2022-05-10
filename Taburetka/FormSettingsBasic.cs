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
    public partial class FormSettingsBasic : Form
    {
        Settings settings;
        Login login;

        FormMain formMain;

        WinLib winLib;

        public FormSettingsBasic(Settings _settings, Login _login, FormMain _formMain, WinLib _winLib)
        {
            InitializeComponent();

            settings = _settings;
            login = _login;

            formMain = _formMain;

            winLib = _winLib;

            checkBoxRunOnStartup.Checked = winLib.CheckStartup();

            trackBarVolume.Value = settings.Volume;
            trackBarVolume.TickFrequency = 10;
            labelVolume.Text = "Громкость: " + trackBarVolume.Value;

            trackBarOpacity.TickFrequency = 10;

            checkBoxOnlyHighlighted.Checked = settings.OnlyHighlighted;
            checkBoxHideToTray.Checked = settings.HideToTray;
            checkBoxLaunchMinimized.Checked = settings.LaunchMinimizied;

            trackBarLatency.Value = settings.Latency;
            labelLatency.Text = "Задержка: " + trackBarLatency.Value + " сек";

            trackBarOpacity.Value = (int)settings.Opacity;
            labelOpacity.Text = "Прозрачность: " + trackBarOpacity.Value;
            formMain.SetOpacity(trackBarOpacity.Value / 100.0);


            //Цветовая схема
            if (settings.IsStandart == true)
            {
                radioButtonStandart.Checked = true;
                radioButtonPink.Checked = false;
            }
            else
            {
                radioButtonStandart.Checked = false;
                radioButtonPink.Checked = true;
            }

            #region Voices
            comboBoxVoices.DropDownStyle = ComboBoxStyle.DropDownList;

            settings.CurrentVoice = "duo";

            //Добавление голосов
            Dictionary<string, string> Voices = new Dictionary<string, string>();
            Voices.Add("duo", "Дуэт");
            Voices.Add("alena", "Алёна");
            Voices.Add("filipp", "Филипп");
            Voices.Add("oksana", "Оксана");
            Voices.Add("jane", "Дарья");
            Voices.Add("omazh", "Ольга");
            Voices.Add("zahar", "Захар");
            Voices.Add("ermil", "Эмиль");

            comboBoxVoices.DataSource = new BindingSource(Voices, null);
            comboBoxVoices.DisplayMember = "Value";
            comboBoxVoices.ValueMember = "Key";
            #endregion Voices


        }

        private void checkBoxOnlyHighlighted_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOnlyHighlighted.Checked == true)
            {
                settings.OnlyHighlighted = true;
            }
            else
            {
                settings.OnlyHighlighted = false;
            }
        }

        private void trackBarLatency_Scroll(object sender, EventArgs e)
        {
            settings.Latency = trackBarLatency.Value;
            labelLatency.Text = "Задержка: " + trackBarLatency.Value + " сек";
        }

        private void comboBoxVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.CurrentVoice = ((KeyValuePair<string, string>)comboBoxVoices.SelectedItem).Key;
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            settings.Opacity = trackBarOpacity.Value;
            formMain.SetOpacity(trackBarOpacity.Value / 100.0);
            labelOpacity.Text = "Прозрачность: " + trackBarOpacity.Value;
        }

        private void checkBoxRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRunOnStartup.Checked == true)
            {
                winLib.AddToStartup();
            }
            else
            {
                winLib.RemoveFromStartup();
            }
        }

        private void checkBoxHideToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHideToTray.Checked == true)
            {
                settings.HideToTray = true;
            }
            else
            {
                settings.HideToTray = false;
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            labelVolume.Text = "Громкость: " + trackBarVolume.Value;
            settings.Volume = trackBarVolume.Value;
        }

        private void radioButtonStandart_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStandart.Checked == true)
            {
                settings.Theme = 1;
                radioButtonPink.Checked = false;
                settings.IsStandart = true;
                formMain.SetStandart();
            }
        }

        private void radioButtonPink_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPink.Checked == true)
            {
                settings.Theme = 2;
                radioButtonStandart.Checked = false;
                settings.IsStandart = false;
                formMain.SetPink();
            }
        }


    }
}
