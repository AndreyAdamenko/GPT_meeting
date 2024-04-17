using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_meeting.Data.Entityes
{
    public class AiBot
    {
        public string Name { get; set; }
        public string Promt { get; set; }
        public string Role { get; set; }

        public string BotTitle => GetBotTitle();

        public string GetBotTitle()
        {
            return $"{Name}({Role})";
        }
    }
}
