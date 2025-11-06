// ReportsForm.cs
using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Инициализируем БД
            DatabaseHelper.InitializeDatabase();
            RefreshDataGrid();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            var data = DatabaseHelper.GetData(comboBoxSort.SelectedItem?.ToString() ?? "Timestamp");
            dataGridView1.DataSource = data;
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            var data = DatabaseHelper.GetData(comboBoxSort.SelectedItem?.ToString() ?? "Timestamp");

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Сохранить отчёт как",
                FileName = $"Отчёт_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReportsHelper.GenerateCsvReport(data, saveFileDialog.FileName);
            }
        }
    }
}