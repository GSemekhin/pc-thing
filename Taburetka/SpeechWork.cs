using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taburetka
{
    public class SpeechWork
    {
        Settings settings;
        Login login;
        List<MessageForSpeech> messages = new List<MessageForSpeech>();
        FormMain formMain;
        bool isPlaying;

        public bool Pause = true;
        public bool Skip = false;


        public string appPath;

        public SpeechWork(FormMain formMain, Settings settings, Login login)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            appPath = Environment.CurrentDirectory;

            this.formMain = formMain;
            isPlaying = false;

            this.settings = settings;
            this.login = login;

            Tts("1", "test" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "ermil");
            Task.Run(() => Playing());
        }

        public async Task<int> AddMessage(string messageId, string messageText, string senderName, System.Drawing.Color messageColor, bool messageHighlighted)
        {


            if (settings.OnlyHighlighted == true && messageHighlighted == true)
            {
                formMain.SetData(senderName + ":" + Environment.NewLine + messageText);
                formMain.SetDataTestBox(senderName + ":" + Environment.NewLine + messageText);
                var temp = await Tts(messageText, messageId, settings.CurrentVoice);
                messages.Add(new MessageForSpeech(Path.Combine(Environment.CurrentDirectory, @"..\temp", messageId) + ".ogg", messageText, senderName, messageColor, messageHighlighted, messageId));
            }
            else if (settings.OnlyHighlighted == false)
            {
                formMain.SetData(senderName + ":" + Environment.NewLine + messageText);
                formMain.SetDataTestBox(senderName + ":" + Environment.NewLine + messageText);
                var temp = await Tts(messageText, messageId, settings.CurrentVoice);
                messages.Add(new MessageForSpeech(Path.Combine(Environment.CurrentDirectory, @"..\temp", messageId) + ".ogg", messageText, senderName, messageColor, messageHighlighted, messageId));
            }

            return 0;

        }
        public async Task<int> AddAlert(string alertId, string alertName, string alertTitle, string senderName, System.Drawing.Color messageColor)
        {


            
                formMain.SetData(senderName + ":" + Environment.NewLine + "Применяет награду " + alertTitle);
                messages.Add(new MessageForSpeech(Path.Combine(appPath, @"..\Rewards", "spinka") + ".mp3", alertTitle, senderName, messageColor, messageId: alertId));
            
            return 0;
        }

        public void Playing()
        {
            while (true)
            {
                if (messages.Count != 0)
                {
                    while (isPlaying || Pause)
                    {
                        Thread.Sleep(200);
                    }
                    isPlaying = true;
                    PlayingSpeech(messages[0].filePath);
                    messages.RemoveAt(0);
                }
                Thread.Sleep(200);
            }
        }


        #region Playing
        public bool PlayingSpeech(string filePath)
        {

            Thread.Sleep(settings.Latency*1000);

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            var libDirectory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, @"..\libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            var mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory);

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            mediaPlayer.SetMedia(new Uri(filePath));
            mediaPlayer.EndReached += MediaPlayer_EndReached;
            mediaPlayer.Audio.Volume = settings.Volume;

            mediaPlayer.Play();
            while (isPlaying)
            {
                if (Skip)
                {
                    mediaPlayer.Stop();
                    Skip = false;
                    isPlaying = false;
                    return false;
                }
                if (Pause)
                {
                    mediaPlayer.Pause();
                    mediaPlayer.Position = 0;
                    while (Pause)
                    {
                        Thread.Sleep(200);
                    }
                    mediaPlayer.Play();
                }
                mediaPlayer.Audio.Volume = settings.Volume;
                Thread.Sleep(200);
            }
            return false;
        }
        #endregion Playing

        #region TTS
        public async Task<int> Tts(string answer, string messageId, string voice)
        {
            string apiToken = login.TtsToken;


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Api-Key " + apiToken);

            if (voice == "duo")
            {
                voice = new Random().Next(2) == 0 ? "alena" : "filipp";
            }

            var values = new Dictionary<string, string>
                    {
                        { "text", answer },
                        { "lang", "ru-RU" },
                        {"voice", voice},
                    };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://tts.api.cloud.yandex.net/speech/v1/tts:synthesize", content);
            var responseBytes = await response.Content.ReadAsByteArrayAsync();

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, @"..\temp", messageId) + ".ogg", responseBytes);
            return 0;
        }
        #endregion TTS
        private void MediaPlayer_EndReached(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            isPlaying = false;
            Skip = false;

        }

        public void PlayAlert()
        {

        }
    }
}
