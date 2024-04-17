using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPT_meeting.Forms
{
    public partial class NewBotForm : Form
    {
        public string BotName { get; set; } = "Айдос";
        public string Promt { get; set; } = "You are a manager at an outdoor advertising company. You see messages from potential clients and your colleagues and respond to them in a natural way. You must answer only if the question requires your answer, otherwise you must write a BLANK. Accept the order and clarify the details. Communicate in Russian. Your message should contain only direct speech.";
        public string Role { get; set; } = "Менеджер";

        public NewBotForm()
        {
            InitializeComponent();

            textBox1.Text = BotName;
            textBox2.Text = Promt;
            textBox3.Text = Role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BotName = textBox1.Text.Trim();
            Promt = textBox2.Text.Trim();
            Role = textBox3.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
