// Reports.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class Reports : Form
    {
        private DataGridView dataGridViewReports;
        private ComboBox comboBoxReportType;
        private Button buttonGenerateReport;

        public Reports()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Отчёты";
            this.Size = new System.Drawing.Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;

            // ComboBox для выбора типа отчёта
            this.comboBoxReportType = new ComboBox();
            this.comboBoxReportType.Items.Add("Все записи");
            this.comboBoxReportType.Items.Add("Сумма по значению (если числовые данные)");
            this.comboBoxReportType.Items.Add("Количество по имени");
            this.comboBoxReportType.SelectedIndex = 0;
            this.comboBoxReportType.Location = new System.Drawing.Point(12, 12);
            this.comboBoxReportType.Size = new System.Drawing.Size(200, 21);

            // Кнопка генерации отчёта
            this.buttonGenerateReport = new Button();
            this.buttonGenerateReport.Text = "Сформировать";
            this.buttonGenerateReport.Location = new System.Drawing.Point(220, 12);
            this.buttonGenerateReport.Size = new System.Drawing.Size(100, 23);
            this.buttonGenerateReport.Click += ButtonGenerateReport_Click;

            // DataGridView для отображения отчёта
            this.dataGridViewReports = new DataGridView();
            this.dataGridViewReports.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewReports.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.ReadOnly = true;

            // Добавляем элементы на форму
            this.Controls.Add(this.comboBoxReportType);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.dataGridViewReports);
        }

        private void ButtonGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = comboBoxReportType.SelectedItem?.ToString();

            switch (reportType)
            {
                case "Все записи":
                    ShowAllData();
                    break;
                case "Сумма по значению (если числовые данные)":
                    ShowSumByValue();
                    break;
                case "Количество по имени":
                    ShowCountByName();
                    break;
                default:
                    MessageBox.Show("Выберите тип отчёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ShowAllData()
        {
            var data = DatabaseHelper.GetData();
            dataGridViewReports.DataSource = data;
        }

        private void ShowSumByValue()
        {
            var data = DatabaseHelper.GetData();
            // Предположим, что Value — это числовое значение
            var aggregatedData = data
                .Where(x => double.TryParse(x.Value, out _)) // Только числовые значения
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    SumValue = g.Sum(x => double.Parse(x.Value))
                })
                .ToList();

            dataGridViewReports.DataSource = aggregatedData;
        }

        private void ShowCountByName()
        {
            var data = DatabaseHelper.GetData();
            var aggregatedData = data
                .GroupBy(x => x.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .ToList();

            dataGridViewReports.DataSource = aggregatedData;
        }
    }
}