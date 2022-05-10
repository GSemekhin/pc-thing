using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taburetka
{
    public class Settings
    {

        #region settings
        private int volume;
        private int latency;
        private double opacity;
        private int formLocationX;
        private int formLocationY;
        private int formHeight;
        private int formWidth;
        private int theme;
        private bool isStandart;

        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    volume = value;
                }
            }
        }
        public int Latency
        {
            get
            {
                return latency;
            }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    latency = value;
                }
            }
        }

        public double Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                if (value >= 10.0 && value <= 100.0)
                {
                    opacity = value;
                }
            }
        }
        public bool OnlyHighlighted { get; set; }
        public string CurrentVoice { get; set; }
        public bool StreamOnline { get; set; }
        public bool HideToTray { get; set; }
        public bool LaunchMinimizied { get; set; }
        public int FormHeight
        {
            get
            {
                return formHeight;
            }
            set
            {
                if ((value > 200) && (value < 1920))
                {
                    formHeight = value;
                }
                else
                {
                    formHeight = 400;
                }
            }
        }
        public int FormWidth
        {
            get
            {
                return formWidth;
            }
            set
            {
                if ((value > 200) && (value < 1080))
                {
                    formWidth = value;
                }
                else
                {
                    formWidth = 650;
                }
            }
        }
        public int FormLocationX
        {
            get
            {
                return formLocationX;
            }
            set
            {
                if (value > 0 && value < 3800)
                {
                    formLocationX = value;
                }
            }
        }

        public int FormLocationY
        {
            get
            {
                return formLocationY;
            }
            set
            {
                if (value > 0 && value < 1050)
                {
                    formLocationY = value;
                }
            }
        }
        public bool IsStandart
        {
            get
            {
                return isStandart;
            }
            set
            {
                isStandart = value;
            }
        }

        public int Theme
        {
            get
            {
                return theme;
            }
            set
            {
                if (value == 1)
                {
                    theme = value;
                    isStandart = true;
                }
                else if (value == 2)
                {
                    theme = value;
                    isStandart = false;
                }
                else
                {
                    theme = value;
                    isStandart = true;
                }
            }
        }

        #endregion settings

        

        public Settings()
        {
            Volume = 50;
            Latency = 0;
            Opacity = 100.0;
            OnlyHighlighted = true;
            HideToTray = true;
            LaunchMinimizied = true;
            FormHeight = 400;
            FormWidth = 650;
            FormLocationX = 200;
            FormLocationY = 200;
            Theme = 200;

            LoadSettings();
        }

        public void SaveSettings()
        {
            try
            {
                SettingsStructure settings = new SettingsStructure
                {
                    Volume = this.Volume,
                    Latency = this.Latency,
                    Opacity = (int)this.Opacity,
                    OnlyHighlighted = this.OnlyHighlighted,
                    HideToTray = this.HideToTray,
                    LaunchMinimizied = this.LaunchMinimizied,
                    FormHeight = formHeight,
                    FormWidth = formWidth,
                    FormLocationX = this.FormLocationX,
                    FormLocationY = this.FormLocationY,
                    Theme = this.Theme
                };
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                using (var writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"..\", "settings.json")))
                {
                    writer.Write(json);
                }


            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public void LoadSettings()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"..\", "settings.json")))
            {
                try
                {
                    string jsonFromFile;
                    Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                    using (var reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"..\", "settings.json")))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }

                    dynamic JsonFromFileDynamic = JsonConvert.DeserializeObject(jsonFromFile);

                    try
                    {
                        Volume = JsonFromFileDynamic.Volume;
                    }
                    catch { Volume = 50; }

                    try
                    {
                        Latency = JsonFromFileDynamic.Latency;
                    }
                    catch { Latency = 0; }

                    try
                    {
                        Opacity = JsonFromFileDynamic.Opacity;
                    }
                    catch { Opacity = 100; }

                    try
                    {
                        OnlyHighlighted = JsonFromFileDynamic.OnlyHighlighted;
                    }
                    catch { OnlyHighlighted = true; }

                    try
                    {
                        HideToTray = JsonFromFileDynamic.HideToTray;
                    }
                    catch { HideToTray = true; }

                    try
                    {
                        LaunchMinimizied = JsonFromFileDynamic.LaunchMinimizied;
                    }
                    catch { LaunchMinimizied = true; }

                    try
                    {
                        FormHeight = JsonFromFileDynamic.FormHeight;
                    }
                    catch { FormHeight = 400; }

                    try
                    {
                        FormWidth = JsonFromFileDynamic.FormWidth;
                    }
                    catch { FormWidth = 650; }

                    try
                    {
                        FormLocationX = JsonFromFileDynamic.FormLocationX;
                    }
                    catch { FormLocationX = 200; }

                    try
                    {
                        FormLocationY = JsonFromFileDynamic.FormLocationY;
                    }
                    catch { FormLocationY = 200; }

                    try
                    {
                        Theme = JsonFromFileDynamic.Theme;
                    }
                    catch { Theme = 1; }

                }
                catch
                {
                    //файл настроек не открылся или не прочитался
                }
            }
            else
            {
                //файла настроек нет
                SaveSettings();
            }
        }

        public void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }
}
