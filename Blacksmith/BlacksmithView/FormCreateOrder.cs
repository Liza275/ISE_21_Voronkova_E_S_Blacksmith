using BlacksmithBusinessLogic.BindingModels;
using BlacksmithBusinessLogic.BusinessLogics;
using BlacksmithBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
namespace BlacksmithView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ManufactureLogic _logicM;
        private readonly OrderLogic _logicO;
        private readonly ClientLogic _logicClient;
        public FormCreateOrder(ManufactureLogic logicP, ClientLogic logicClient, OrderLogic logicO)
        {
            InitializeComponent();
            _logicM = logicP;
            _logicO = logicO;
            _logicClient = logicClient;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)//прописать логику
        {
            try
            {
                List<ManufactureViewModel> list = _logicM.Read(null);
                var clients = _logicClient.Read(null);
                if (list != null)
                {
                    ComboBoxManufacture.DisplayMember = "ManufactureName";
                    ComboBoxManufacture.ValueMember = "Id";
                    ComboBoxManufacture.DataSource = list;
                    ComboBoxManufacture.SelectedItem = null;
                    comboBoxClients.DataSource = clients;
                    comboBoxClients.DisplayMember = "ClientFIO";
                    comboBoxClients.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (ComboBoxManufacture.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(ComboBoxManufacture.SelectedValue);
                    ManufactureViewModel manufacture = _logicM.Read(new ManufactureBindingModel
                    {
                        Id
                    = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * manufacture?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxManufacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ComboBoxManufacture.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    ManufactureId = Convert.ToInt32(ComboBoxManufacture.SelectedValue),
                    ClientId=(int)comboBoxClients.SelectedValue,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }
    }
}
