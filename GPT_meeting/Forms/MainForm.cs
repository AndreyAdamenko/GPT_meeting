using GPT_meeting.Data.Entityes;

namespace GPT_meeting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            listBox1.DataSource = Program.App.Bots;
            listBox1.DisplayMember = nameof(AiBot.BotTitle);

            KeyDown += (x, y) =>
            {
                if (y.KeyCode != Keys.Enter) return;

                button1.PerformClick();
            };

            Program.App.Messages.ListChanged += (x, y) =>
            {
                textBox2.Clear();

                GenerateChatHistory();
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Mediator.CreateNewBot();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var message = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(message)) return;

            await Program.Mediator.AddUserMessage(message);

            textBox1.Clear();
        }

        private void GenerateChatHistory()
        {
            foreach (var msg in Program.App.Messages)
            {
                textBox2.Text += $"{msg.GetMessagePrefix()}: {msg.Text}\r\n";
            }
        }
    }
}
