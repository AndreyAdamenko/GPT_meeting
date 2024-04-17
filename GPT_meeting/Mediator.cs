using GPT_meeting.Data.Entityes;
using GPT_meeting.Forms;
using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPT_meeting
{
    internal class Mediator
    {
        public void CreateNewBot()
        {
            var addForm = new NewBotForm();

            var dialogResult = addForm.ShowDialog();

            if (dialogResult != DialogResult.OK) return;


            Program.App.Bots.Add(new AiBot
            {
                Name = addForm.BotName,
                Promt = addForm.Promt,
                Role = addForm.Role,
            });
        }

        internal async Task AddUserMessage(string message)
        {
            Program.App.Messages.Add(new Data.Entityes.ChatMessage { Text = message });

            await IterateAsync();
        }

        public async Task IterateAsync()
        {
            APIAuthentication aPIAuthentication = new APIAuthentication(Program.openAiApiKey);
            OpenAIAPI openAiApi = new OpenAIAPI(aPIAuthentication);

            foreach (var bot in Program.App.Bots)
            {
                List<OpenAI_API.Chat.ChatMessage> messages = new List<OpenAI_API.Chat.ChatMessage> {
                    new OpenAI_API.Chat.ChatMessage(ChatMessageRole.System, bot.Promt)
                };

                foreach (var msg in Program.App.Messages.TakeLast(1 + Program.App.Bots.Count*2))
                {
                    var isUser = msg.Bot is null;

                    var role = !isUser ? ChatMessageRole.Assistant : ChatMessageRole.User;

                    var msgPref = isUser ? $"{Program.App.UserName}({Program.App.UserRole})" : $"{msg.Bot.Name}({msg.Bot.Role})";

                    var curMsg = $"{msgPref}: {msg.Text}";

                    messages.Add(new OpenAI_API.Chat.ChatMessage { Role = role, TextContent = curMsg });
                }

                var completionRequest = new ChatRequest
                {
                    Model = Program.App.Model,
                    MaxTokens = Program.App.MaxTokens,
                    Messages = messages,
                    Temperature = 0.8
                };

                var completionResult = await openAiApi.Chat.CreateChatCompletionAsync(completionRequest);
                var generatedText = completionResult.Choices[0].Message.TextContent;

                if (generatedText.Contains("BLANK")) continue;

                var cleanedMsg = CleanMsg(generatedText, "):");

                var botAnswer = new Data.Entityes.ChatMessage { Bot = bot, Text = cleanedMsg };

                Program.App.Messages.Add(botAnswer);
            }
        }

        private string CleanMsg(string text, string filter)
        {
            int index = text.IndexOf(filter);

            if (index != -1)
            {
                return text.Substring(index + 2).Trim();
            }

            return text;
        }
    }
}
