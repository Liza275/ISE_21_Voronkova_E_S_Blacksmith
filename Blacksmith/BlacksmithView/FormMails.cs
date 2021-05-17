using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.BusinessLogics;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BlacksmithView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;

        private bool Next = false;

        private readonly int mailsOnPage = 3;

        private int currentPage = 1;


        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = logic.Read(new MessageInfoBindingModel { Skip = (currentPage - 1) * mailsOnPage, Take = mailsOnPage + 1 });
            Next = !(list.Count() <= mailsOnPage);
            if (Next)
            {
                buttonNext.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
            }
            else
            {
                buttonNext.Text = "Следующая";
                buttonNext.Enabled = false;
            }
            if (list != null)
            {
                dataGridView.DataSource = list.Take(mailsOnPage).ToList();
                dataGridView.Columns[0].Visible = false;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (Next)
            {
                currentPage++;
                textBoxPage.Text = (currentPage).ToString();
                buttonPrev.Enabled = true;
                buttonPrev.Text = (currentPage - 1).ToString();
                LoadData();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 1)
            {
                currentPage--;
                textBoxPage.Text = (currentPage).ToString();
                buttonNext.Enabled = true;
                buttonNext.Text = (currentPage + 1).ToString();
                if (currentPage == 1)
                {
                    buttonPrev.Enabled = false;
                    buttonPrev.Text = "Предыдущая";
                }
                else
                {
                    buttonPrev.Text = (currentPage - 1).ToString();
                }
                LoadData();
            }
        }
    }
}
