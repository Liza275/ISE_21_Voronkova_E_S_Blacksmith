using BlacksmithBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;

namespace BlacksmithView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;

        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            Program.ConfigGrid(logic.Read(null), dataGridView);
        }
    }
}
