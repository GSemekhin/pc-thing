using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taburetka
{
    class MessageForSpeech
    {
        public string senderName;
        public System.Drawing.Color senderColor;
        public string messageText;
        public string messageId;
        public string filePath;
        public bool messageHighlighted;


        public MessageForSpeech(string filePath, string messageText, string senderName, System.Drawing.Color senderColor, bool messageHighlighted = true, string messageId = "")
        {
            this.senderName = senderName;
            this.senderColor = senderColor;
            this.messageText = messageText;
            this.messageId = messageId;
            this.filePath = filePath;
            this.messageHighlighted = messageHighlighted;
        }
    }
}
