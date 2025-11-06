using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace stone_and_metal
{
    // Только partial — поля и InitializeComponent уже в Reports.Designer.cs
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        // === Обязательные обработчики для placeholder (чтобы не было CS1061) ===
        private void textBoxFilterName_Enter(object sender, EventArgs e)
        {
            if (textBoxFilterName.Text == "Имя...")
                textBoxFilterName.Text = "";
        }

        private void textBoxFilterName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFilterName.Text))
                textBoxFilterName.Text = "Имя...";
        }

        private void textBoxFilterValue_Enter(object sender, EventArgs e)
        {
            if (textBoxFilterValue.Text == "Значение...")
                textBoxFilterValue.Text = "";
        }

        private void textBoxFilterValue_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFilterValue.Text))
                textBoxFilterValue.Text = "Значение...";
        }

        // === Логика отчётов ===
        private void ComboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = comboBoxReportType.SelectedItem?.ToString();
            textBoxFilterName.Visible = (reportType == "Фильтр по имени");
            textBoxFilterValue.Visible = (reportType == "Фильтр по значению");

            if (!textBoxFilterName.Visible) textBoxFilterName.Text = "";
            if (!textBoxFilterValue.Visible) textBoxFilterValue.Text = "";
        }

        private void ButtonGenerateReport_Click(object sender, EventArgs e)
        {
            if (comboBoxReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип отчёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = comboBoxReportType.SelectedItem.ToString();
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
                case "Фильтр по имени":
                    FilterByName();
                    break;
                case "Фильтр по значению":
                    FilterByValue();
                    break;
                default:
                    MessageBox.Show("Неизвестный тип отчёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var validData = data.Where(x => double.TryParse(x.Value, out _)).ToList();
            if (!validData.Any())
            {
                MessageBox.Show("Нет числовых значений для суммирования.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewReports.DataSource = new List<object>();
                return;
            }

            var aggregated = validData
                .GroupBy(x => x.Name)
                .Select(g => new { Name = g.Key, Сумма = g.Sum(x => Convert.ToDouble(x.Value)) })
                .ToList();

            dataGridViewReports.DataSource = aggregated;
        }

        private void ShowCountByName()
        {
            var data = DatabaseHelper.GetData();
            var aggregated = data
                .GroupBy(x => x.Name)
                .Select(g => new { Name = g.Key, Количество = g.Count() })
                .ToList();

            dataGridViewReports.DataSource = aggregated;
        }

        private void FilterByName()
        {
            string filter = textBoxFilterName.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Введите имя для фильтрации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Совместимо с .NET Framework (C# 7.3)
            var data = DatabaseHelper.GetData();
            var filtered = data.Where(x => x.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            dataGridViewReports.DataSource = filtered;
        }

        private void FilterByValue()
        {
            string filter = textBoxFilterValue.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Введите значение для фильтрации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var data = DatabaseHelper.GetData();
            var filtered = data.Where(x => x.Value.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            dataGridViewReports.DataSource = filtered;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
        }
    }
}