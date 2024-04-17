using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_meeting.Data.Entityes
{
    public class ChatMessage
    {
        public AiBot Bot { get; set; }
        public string Text { get; set; }

        public string GetMessagePrefix()
        {
            return Bot is null ? $"{Program.App.UserName}({Program.App.UserRole})" : Bot.GetBotTitle();
        }
    }
}
