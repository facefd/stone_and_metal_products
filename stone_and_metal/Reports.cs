using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace stone_and_metal
{
    // Локальный класс данных — только для отчётов
    public class ReportItem
    {
        public int Id { get; set; }
        public string Name { get; set; }   // ← Изделия
        public string Value { get; set; }  // ← Цена (как строка)
    }

    public partial class Reports : Form
    {
        private string _databasePath;

        public Reports()
        {
            _databasePath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
            InitializeComponent();
        }

        // === Получение первого подходящего имени таблицы ===
        private string GetFirstUserTableName()
        {
            if (!File.Exists(_databasePath))
            {
                MessageBox.Show("Файл базы данных не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_databasePath};";
            using (var conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    DataTable schemaTable = conn.GetSchema("Tables");
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        // Пропускаем системные таблицы
                        if (!tableName.StartsWith("MSys") && !tableName.StartsWith("~"))
                        {
                            return tableName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении структуры базы:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        // === Загрузка данных из найденной таблицы ===
        private List<ReportItem> LoadReportData(string tableName)
        {
            var list = new List<ReportItem>();
            string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_databasePath};";

            using (var conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    // Пытаемся выбрать нужные столбцы — если их нет, покажем ошибку
                    string sql = $"SELECT [Код], [Изделия], [Цена] FROM [{tableName}]";
                    using (var cmd = new OleDbCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ReportItem
                            {
                                Id = reader["Код"] is DBNull ? 0 : Convert.ToInt32(reader["Код"]),
                                Name = reader["Изделия"]?.ToString() ?? "",
                                Value = reader["Цена"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Ошибка загрузки данных из таблицы '{tableName}':\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return list;
        }

        // === Парсинг цены ===
        private double ParsePrice(string priceString)
        {
            if (string.IsNullOrWhiteSpace(priceString)) return 0;
            string clean = priceString.Replace(" ", "").Replace(",", ".").Replace("₽", "").Trim();
            return double.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out double result) ? result : 0;
        }

        // === Обработчики текстбоксов ===
        private void textBoxFilterName_Enter(object sender, EventArgs e)
        {
            if (textBoxFilterName.Text == "Имя...") textBoxFilterName.Text = "";
        }

        private void textBoxFilterName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFilterName.Text)) textBoxFilterName.Text = "Имя...";
        }

        private void textBoxFilterValue_Enter(object sender, EventArgs e)
        {
            if (textBoxFilterValue.Text == "Значение...") textBoxFilterValue.Text = "";
        }

        private void textBoxFilterValue_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFilterValue.Text)) textBoxFilterValue.Text = "Значение...";
        }

        // === Логика отчётов ===
        private void ComboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = comboBoxReportType.SelectedItem?.ToString();
            textBoxFilterName.Visible = (reportType == "Фильтр по имени");
            textBoxFilterValue.Visible = (reportType == "Фильтр по значению");

            if (!textBoxFilterName.Visible) textBoxFilterName.Text = "Имя...";
            if (!textBoxFilterValue.Visible) textBoxFilterValue.Text = "Значение...";
        }

        private void ButtonGenerateReport_Click(object sender, EventArgs e)
        {
            if (comboBoxReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип отчёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tableName = GetFirstUserTableName();
            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Не удалось определить таблицу для отчётов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var data = LoadReportData(tableName);
            string reportType = comboBoxReportType.SelectedItem.ToString();

            switch (reportType)
            {
                case "Все записи":
                    dataGridView1.DataSource = data;
                    break;
                case "Сумма по значению (если числовые данные)":
                    dataGridView1.DataSource = data
                        .Where(x => !string.IsNullOrEmpty(x.Value))
                        .GroupBy(x => x.Name)
                        .Select(g => new { Изделие = g.Key, ОбщаяСтоимость = g.Sum(x => ParsePrice(x.Value)) })
                        .ToList();
                    break;
                case "Количество по имени":
                    dataGridView1.DataSource = data
                        .GroupBy(x => x.Name)
                        .Select(g => new { Изделие = g.Key, Количество = g.Count() })
                        .ToList();
                    break;
                case "Фильтр по имени":
                    string nameFilter = textBoxFilterName.Text.Trim();
                    if (string.IsNullOrEmpty(nameFilter) || nameFilter == "Имя...")
                    {
                        MessageBox.Show("Введите имя изделия для фильтрации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dataGridView1.DataSource = data
                        .Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.IndexOf(nameFilter, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                    break;
                case "Фильтр по значению":
                    string valueFilter = textBoxFilterValue.Text.Trim();
                    if (string.IsNullOrEmpty(valueFilter) || valueFilter == "Значение...")
                    {
                        MessageBox.Show("Введите значение (например, цену) для фильтрации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dataGridView1.DataSource = data
                        .Where(x => !string.IsNullOrEmpty(x.Value) && x.Value.IndexOf(valueFilter, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                    break;
                default:
                    MessageBox.Show("Неизвестный тип отчёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            comboBoxReportType.Items.AddRange(new[]
            {
                "Все записи",
                "Сумма по значению (если числовые данные)",
                "Количество по имени",
                "Фильтр по имени",
                "Фильтр по значению"
            });

            textBoxFilterName.Visible = false;
            textBoxFilterValue.Visible = false;
        }
    }
}