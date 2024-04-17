using GPT_meeting.Data;

namespace GPT_meeting
{
    internal static class Program
    {
        public static AppState App {  get; private set; }
        public static DataManager DataManager { get; private set; }
        public static Mediator Mediator { get; private set; }

        public static string openAiApiKey = "sk-XXXXXXXXXXXXXXXXXX";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            App = new AppState();
            DataManager = new DataManager();
            Mediator = new Mediator();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}