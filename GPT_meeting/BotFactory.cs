using GPT_meeting.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_meeting
{
    internal class BotFactory
    {
        public AiBot CreateBot(string name, string promt, string role)
        {
            return new AiBot { Name = name, Promt = promt, Role = role };
        }
    }
}
