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
            if (currentPage > 1)
            { buttonPrev.Text = (currentPage - 1).ToString(); }
        
            if (list != null)
            {
                Program.ConfigGrid(list.Take(mailsOnPage).ToList(), dataGridView);
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

        private void textBoxPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPage.Text != "")
                {
                    int currentPageValue = Convert.ToInt32(textBoxPage.Text);

                    if (currentPageValue < 1)
                    {
                        throw new Exception();
                    }

                    int stringsCountOnPage = logic.Read(new MessageInfoBindingModel
                    {
                        Skip=(currentPageValue - 1),Take= mailsOnPage
                    }).Count;

                    if (stringsCountOnPage == 0)
                    {
                        throw new Exception();
                    }

                    currentPage = currentPageValue;
                    LoadData();
                }
            }
            catch (Exception)
            {
                textBoxPage.Text = currentPage.ToString();
            }
        }
    }
}
