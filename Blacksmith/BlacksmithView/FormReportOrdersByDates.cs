using BlacksmithBusinessLogic.BusinessLogics;
using BlacksmithBusinessLogic.BindingModels;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using Unity;
using System.Reflection;
using BlacksmithBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BlacksmithView
{
    public partial class FormReportOrdersByDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;

        public FormReportOrdersByDates(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormClientOrders_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }
        [Obsolete]
        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveOrdersByDatesToPdfFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }});
                        MessageBox.Show("Сохранено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("SaveOrdersToPdfFile");
                var dataSource = (List<ReportOrderByDatesViewModel>)method.Invoke(logic, new object[] { });
                ReportDataSource source = new ReportDataSource("DataSetOrdersByDates", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}