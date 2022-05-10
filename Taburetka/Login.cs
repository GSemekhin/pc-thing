using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taburetka
{
    public class Login
    {
        public string BotName { get; set; }
        public string AccessToken { get; set; }
        public string ClientId { get; set; }
        public string TtsToken { get; set; }
        public string BDAdress { get; set; }
        public string BDUser { get; set; }
        public string BDPassword { get; set; }
        public string BDTable { get; set; }
        public string TargetChannel { get; set; }

        public Login()
        {
            LoadLogin();
        }

        public void SaveLogin()
        {
            try
            {
                LoginStructure login = new LoginStructure
                {
                    BotName = this.BotName,
                    AccessToken = Encrypt(this.AccessToken),
                    ClientId = Encrypt(this.ClientId),
                    TtsToken = Encrypt(this.TtsToken),
                    BDAdress = this.BDAdress,
                    BDUser = this.BDUser,
                    BDPassword = Encrypt(this.BDPassword),
                    BDTable = this.BDTable,
                    TargetChannel = this.TargetChannel

                };
                string json = JsonConvert.SerializeObject(login, Formatting.Indented);

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                using (var writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"..\", "login.json")))
                {
                    writer.Write(json);
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
        public void LoadLogin()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"..\", "login.json")))
            {
                try
                {
                    string jsonFromFile;
                    Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                    using (var reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"..\", "login.json")))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }

                    dynamic JsonFromFileDynamic = JsonConvert.DeserializeObject(jsonFromFile);
                    try
                    {
                        BotName = JsonFromFileDynamic.BotName;
                    }
                    catch { BotName = null; }

                    try
                    {
                        AccessToken = Decrypt(JsonFromFileDynamic.AccessToken.Value);
                    }
                    catch { AccessToken = null; }

                    try
                    {
                        ClientId = Decrypt(JsonFromFileDynamic.ClientId.Value);
                    }
                    catch { ClientId = null; }

                    try
                    {
                        TtsToken = Decrypt(JsonFromFileDynamic.TtsToken.Value);
                    }
                    catch { TtsToken = null; }

                    try
                    {
                        BDAdress = JsonFromFileDynamic.BDAdress;
                    }
                    catch { BDAdress = null; }

                    try
                    {
                        BDUser = JsonFromFileDynamic.BDUser;
                    }
                    catch { BDUser = null; }

                    try
                    {
                        BDPassword = Decrypt(JsonFromFileDynamic.BDPassword.Value);
                    }

                    catch { BDPassword = null; }

                    try
                    {
                        BDTable = JsonFromFileDynamic.BDTable;
                    }
                    catch { BDTable = null; }

                    try
                    {
                        TargetChannel = JsonFromFileDynamic.TargetChannel;
                    }
                    catch { TargetChannel = null; }
                }
                catch
                {
                    //проблема с файлом логинов
                }
            }
            else
            {
                //нет файла логинов
            }
        }
        public string Encrypt(string data)
        {
            StringBuilder temp = new StringBuilder(35);
            temp.Append(data);
            temp.Insert(0, temp[2]);
            temp.Insert(1, temp[4]);
            temp.Insert(2, temp[2]);
            temp.Insert(3, temp[4]);
            temp.Remove(4, 4);

            return temp.ToString();
        }
        public string Decrypt(string data)
        {
            StringBuilder temp = new StringBuilder(35);
            temp.Append(data);
            temp.Insert(0, temp[2]);
            temp.Insert(1, temp[4]);
            temp.Insert(2, temp[2]);
            temp.Insert(3, temp[4]);
            temp.Remove(4, 4);

            return temp.ToString();
        }
    }
}
