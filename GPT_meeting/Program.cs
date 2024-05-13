using GPT_meeting.Data;
using GPT_meeting.Data.Entityes;
using System.Text.Json;

namespace GPT_meeting
{
    internal static class Program
    {
        public static AppState App { get; private set; }
        public static DataManager DataManager { get; private set; }
        public static Mediator Mediator { get; private set; }

        public static string openAiApiKey = "sk-XXXXXXXXXXXXXXXXXX";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var user = JsonSerializer.Deserialize<User>(File.ReadAllText("User.json"));
            var bots = JsonSerializer.Deserialize<List<AiBot>>(File.ReadAllText("Bots.json"));

            App = new AppState(bots, "gpt-3.5-turbo", 500, user.Name, user.Role);
            DataManager = new DataManager();
            Mediator = new Mediator();

            openAiApiKey = File.ReadAllText("ApiKey.txt").Trim();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        class User
        {
            public string Name { get; set; }
            public string Role { get; set; }
        }
    }
}