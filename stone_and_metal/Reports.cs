// Reports.cs — обновлённая версия по ТЗ
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class Reports : Form
    {
        private string _dbPath;

        public Reports()
        {
            InitializeComponent();
            _dbPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            comboBoxReportType.Items.Clear();
            comboBoxReportType.Items.AddRange(new[]
            {
                "Изделия, производимые сейчас",
                "Заказы за период",
                "Изделия с максимальным доходом за период"
            });
            dateTimeFrom.Value = DateTime.Now.AddMonths(-1);
            dateTimeTo.Value = DateTime.Now;
        }

        private void comboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool showDateRange = comboBoxReportType.SelectedItem?.ToString() != "Изделия, производимые сейчас";
            labelDateRange.Visible = showDateRange;
            dateTimeFrom.Visible = showDateRange;
            dateTimeTo.Visible = showDateRange;
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            if (comboBoxReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип отчёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = comboBoxReportType.SelectedItem.ToString();

            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();

                    if (reportType == "Изделия, производимые сейчас")
                    {
                        string sql = @"
                            SELECT Id, Name AS [Название], Category AS [Категория], Description AS [Описание]
                            FROM Products
                            WHERE IsProducedNow = True";
                        var dt = new DataTable();
                        using (var adapter = new OleDbDataAdapter(sql, conn))
                            adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else if (reportType == "Заказы за период")
                    {
                        DateTime from = dateTimeFrom.Value.Date;
                        DateTime to = dateTimeTo.Value.Date.AddDays(1).AddSeconds(-1);

                        string sql = @"
                            SELECT 
                                o.Id AS [№ заказа],
                                p.Name AS [Изделие],
                                o.ClientName AS [Клиент],
                                o.OrderDate AS [Дата заказа],
                                o.PlannedCompletionDate AS [План],
                                o.ActualCompletionDate AS [Факт],
                                o.TotalPrice AS [Стоимость],
                                o.Status AS [Статус]
                            FROM Orders o
                            LEFT JOIN Products p ON o.ProductId = p.Id
                            WHERE o.OrderDate BETWEEN ? AND ?";
                        var dt = new DataTable();
                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("", from);
                            cmd.Parameters.AddWithValue("", to);
                            using (var adapter = new OleDbDataAdapter(cmd))
                                adapter.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
                    }
                    else if (reportType == "Изделия с максимальным доходом за период")
                    {
                        DateTime from = dateTimeFrom.Value.Date;
                        DateTime to = dateTimeTo.Value.Date.AddDays(1).AddSeconds(-1);

                        string sql = @"
                            SELECT 
                                p.Name AS [Изделие],
                                p.Category AS [Категория],
                                SUM(o.TotalPrice) AS [Общий доход],
                                COUNT(o.Id) AS [Количество заказов]
                            FROM Orders o
                            INNER JOIN Products p ON o.ProductId = p.Id
                            WHERE o.OrderDate BETWEEN ? AND ?
                            GROUP BY p.Name, p.Category
                            ORDER BY [Общий доход] DESC";
                        var dt = new DataTable();
                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("", from);
                            cmd.Parameters.AddWithValue("", to);
                            using (var adapter = new OleDbDataAdapter(cmd))
                                adapter.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчёта:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}