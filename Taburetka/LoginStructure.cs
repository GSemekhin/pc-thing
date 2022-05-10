using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taburetka
{
    class LoginStructure
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
    }
}
