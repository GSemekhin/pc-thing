using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;
using System.Drawing;
using TwitchLib.PubSub;
using System.Windows.Forms;
using TwitchLib.PubSub.Events;
using TwitchLib.Api.Helix;
using TwitchLib.Communication.Events;

namespace Taburetka
{

    public class TwitchWork
    {
        TwitchClient client;
        FormMain formMain;
        SpeechWork speechWork;
        Settings settings;
        Login login;

        TwitchAPI api;

        private TwitchPubSub clientPubSub;

        public delegate void MethodContainerStreamUp();
        public event MethodContainerStreamUp onStreamUpEvent;


        System.Timers.Timer reconnectChatTimer;
        System.Timers.Timer reconnectPubSubTimer;

        
        public TwitchWork(FormMain formMain, SpeechWork speechWork, Settings settings, Login login)
        {
            this.formMain = formMain;
            this.speechWork = speechWork;
            this.settings = settings;
            this.login = login;



            LoginToAPI();
            LoginToChat();
            LoginToPubSub();

            Task.Run(() =>
            {
                if (GetChannelState(login.TargetChannel).Result == true)
                {
                    settings.StreamOnline = true;
                    onStreamUpEvent?.Invoke();
                    this.formMain.BeginInvoke((MethodInvoker)(() => formMain.ShowMainFormWitoutFocus()));
                }
            });

        }
        #region PubSubEvents
        private void onRewardRedeemed(object sender, OnRewardRedeemedArgs e)
        {
            if (e.RewardTitle.Equals("Ровнее спинку!") && (e.Status.Equals("UNFULFILLED")))
            {
                
                try
                {
                    speechWork.AddAlert(e.RewardId.ToString(), "", e.RewardTitle, e.DisplayName, Color.Black);
                }
                catch { }
            }
            else
            if (e.RewardTitle.Equals("Хенд мейд куки") && (e.Status.Equals("UNFULFILLED")))
            {
                string answer = e.DisplayName + " становится фулл печеней boouchEComfort boouchEComfort boouchEComfort";

                speechWork.AddMessage("test" + DateTime.Now.ToString("ddMMyyyyHHmmss"), answer, e.DisplayName, Color.Black, true);
                answer = "boouchEsubHype boouchEsubHype boouchEsubHype";
                speechWork.AddMessage("test" + DateTime.Now.ToString("ddMMyyyyHHmmss"), answer, e.DisplayName, Color.Black, true);
            }
        }
        public void LoginToPubSub()
        {
            //Таймер переподключения
            reconnectPubSubTimer = new System.Timers.Timer();
            reconnectPubSubTimer.AutoReset = true;
            reconnectPubSubTimer.Interval = 5 * 1000;
            reconnectPubSubTimer.Elapsed += OnReconnectPubSubTimerElapsed;
            reconnectPubSubTimer.Enabled = true;

            ConnectToPubSub();
        }
        public void ConnectToPubSub()
        {
            try
            {
                clientPubSub = new TwitchPubSub();
                clientPubSub.OnPubSubServiceConnected += onPubSubServiceConnected;
                clientPubSub.OnRewardRedeemed += onRewardRedeemed;
                clientPubSub.OnPubSubServiceClosed += OnPubSubServiceClosed;
                clientPubSub.OnStreamUp += onStreamUp;
                clientPubSub.OnStreamDown += onStreamDown;

                clientPubSub.Connect();
            }
            catch
            {

            }
        }

        public void DisconnectFromPubSub()
        {
            try
            {
                clientPubSub.Disconnect();
            }
            catch
            {

            }
        }
        private void onStreamUp(object sender, OnStreamUpArgs e)
        {
            onStreamUpEvent?.Invoke();
            settings.StreamOnline = true;
            this.formMain.BeginInvoke((MethodInvoker)(() => formMain.ShowMainFormWitoutFocus()));
        }

        private void onStreamDown(object sender, OnStreamDownArgs e)
        {
            settings.StreamOnline = false;

        }

        private void onPubSubServiceConnected(object sender, EventArgs e)
        {
            try
            {
                clientPubSub.ListenToVideoPlayback(getUserId(login.TargetChannel).Result);
                clientPubSub.ListenToRewards(getUserId(login.TargetChannel).Result);

                clientPubSub.SendTopics(login.AccessToken);
                reconnectPubSubTimer.Enabled = false;
            }
            catch
            {

            }

        }
        private void OnPubSubServiceClosed(object sender, EventArgs e)
        {
            
            try
            {
                clientPubSub.OnPubSubServiceConnected -= onPubSubServiceConnected;
                clientPubSub.OnPubSubServiceClosed -= OnPubSubServiceClosed;
                clientPubSub.OnStreamUp -= onStreamUp;
                clientPubSub.OnStreamDown -= onStreamDown;
                reconnectPubSubTimer.Elapsed -= OnReconnectPubSubTimerElapsed;
                reconnectPubSubTimer.Dispose();

                LoginToPubSub();
            }
            catch
            {

            }
        }

        private void OnReconnectPubSubTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ConnectToPubSub();
        }

        #endregion PubSubEvents

        #region Chat
        public void LoginToChat()
        {
            try
            {
                ConnectionCredentials credentials = new ConnectionCredentials(login.BotName, login.AccessToken);
                client = new TwitchClient();
                client.Initialize(credentials);


                //События чата твича
                client.OnMessageReceived += Client_OnMessageReceived;
                client.OnConnected += Client_OnConnected;
                client.OnDisconnected += Client_OnDisconnected;
                client.OnJoinedChannel += Client_OnJoinedChannel;

                //Таймер переподключения
                reconnectChatTimer = new System.Timers.Timer();
                reconnectChatTimer.AutoReset = true;
                reconnectChatTimer.Interval = 5 * 1000;
                reconnectChatTimer.Elapsed += OnReconnectChatTimerElapsed;
                reconnectChatTimer.Enabled = true;
            }
            catch
            {

            }
            ConnectToChat();
        }


        public void ConnectToChat()
        {
            try
            {
                client.Connect();
            }
            catch
            {
                client.OnMessageReceived -= Client_OnMessageReceived;
                client.OnConnected -= Client_OnConnected;
                client.OnDisconnected -= Client_OnDisconnected;
                client.OnJoinedChannel -= Client_OnJoinedChannel;

                reconnectChatTimer.Elapsed -= OnReconnectChatTimerElapsed;
                reconnectChatTimer.Dispose();

                LoginToChat();
            }
        }

        public void DisconnectFromChat()
        {
            try
            {
                client.Disconnect();
            }
            catch
            {

            }
        }
        private void Client_OnDisconnected(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            try
            {
                foreach (JoinedChannel channel in client.JoinedChannels)
                {
                    client.LeaveChannel(channel);
                }

            }
            catch
            {

            }
            ConnectToChat();
        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {

            speechWork.AddMessage(e.ChatMessage.Id, e.ChatMessage.Message, e.ChatMessage.DisplayName, e.ChatMessage.Color, e.ChatMessage.IsHighlighted);
        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            try
            {
                client.JoinChannel(login.TargetChannel);
            }
            catch
            {

            }
        }

        private async void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            var temp = await speechWork.AddMessage("test" + DateTime.Now.ToString("ddMMyyyyHHmmss"), "ой, кажется, работает", e.Channel, Color.Black, true);
        }

        private void OnReconnectChatTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (client.IsConnected)
            {
                //logs.WriteLog(DateTime.UtcNow.ToString() + " Вызвали поддержание жизни бота, он подключен");
            }
            else
            {
                try
                {
                    client.Disconnect();
                }
                catch
                {
                    //logs.WriteLog("! " + DateTime.UtcNow.ToString() + " Вызвали поддержание жизни бота, он не подключен, не получилось переподключиться - ошибка");
                }
                if (client.IsConnected)
                {
                    //logs.WriteLog(DateTime.UtcNow.ToString() + " Вызвали поддержание жизни бота, он переподключился");
                }
                else
                {
                    //logs.WriteLog("! " + DateTime.UtcNow.ToString() + " Вызвали поддержание жизни бота, он не переподключился");
                }
            }
            if (client.JoinedChannels.Count == 0)
            {
                //logs.WriteLog("! " + DateTime.UtcNow.ToString() + " Проверили количество подключенных каналов - ноль");
                try
                {
                    client.Disconnect();
                }
                catch { }
            }
            else
            {
                //logs.WriteLog(DateTime.UtcNow.ToString() + " Проверили количество подключенных каналов - не ноль");
            }
        }
        #endregion Chat

        #region API
        public void LoginToAPI()
        {
            try
            {
                api = new TwitchAPI();
                api.Settings.ClientId = login.ClientId;
                api.Settings.AccessToken = login.AccessToken;
                api.Helix.Users.GetUsersAsync(logins: new List<string>() { login.TargetChannel });
            }
            catch { }
        }
        private async Task<string> getUserId(string channelName)
        {
            try
            {
                TwitchLib.Api.Helix.Models.Users.GetUsers.GetUsersResponse pup = await api.Helix.Users.GetUsersAsync(logins: new List<string>() { channelName });
                string answer = pup.Users[0].Id;
                return answer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> GetChannelState(string channelName)
        {
            try
            {
                TwitchLib.Api.Helix.Models.Streams.GetStreams.GetStreamsResponse pup = await api.Helix.Streams.GetStreamsAsync(userLogins: new List<string>() { channelName });
                if (pup.Streams.Count() != 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion API

        
    }

}

