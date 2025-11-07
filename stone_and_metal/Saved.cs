using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace stone_and_metal
{
    public class Saved
    {
        private readonly string _databasePath;

        public Saved(string databasePath)
        {
            _databasePath = databasePath ?? throw new ArgumentNullException(nameof(databasePath));
        }

        public void ExportToExcel(DataTable dataTable, string filePath)
        {
            if (dataTable == null)
                throw new ArgumentNullException(nameof(dataTable));
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь не может быть пустым.", nameof(filePath));

            try
            {
                // ❗ КЛАССИЧЕСКИЙ using-блок — НЕ using var!
                ExcelPackage package = null;
                try
                {
                    package = new ExcelPackage();
                    var worksheet = package.Workbook.Worksheets.Add("Таблица1");

                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }

                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                        }
                    }

                    worksheet.Cells.AutoFitColumns();

                    package.SaveAs(new FileInfo(filePath));
                    MessageBox.Show("✅ Экспорт в Excel завершён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    package?.Dispose(); // Вручную, если не используем using-блок
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка экспорта в Excel:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToCSV(DataTable dataTable)
        {
            if (dataTable == null)
                throw new ArgumentNullException(nameof(dataTable));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить как CSV";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = null;
                    try
                    {
                        writer = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8);

                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            writer.Write(i == 0 ? "" : ";");
                            writer.Write("\"" + dataTable.Columns[i].ColumnName.Replace("\"", "\"\"") + "\"");
                        }
                        writer.WriteLine();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                writer.Write(i == 0 ? "" : ";");
                                writer.Write("\"" + (row[i]?.ToString() ?? "").Replace("\"", "\"\"") + "\"");
                            }
                            writer.WriteLine();
                        }
                    }
                    finally
                    {
                        writer?.Dispose();
                    }

                    MessageBox.Show("✅ Экспорт в CSV завершён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Ошибка при экспорте CSV:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveAsAccess()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы Access (*.accdb)|*.accdb|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить копию базы данных";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(_databasePath, saveFileDialog.FileName, overwrite: true);
                    MessageBox.Show("✅ Копия базы сохранена:\n" + saveFileDialog.FileName, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Ошибка при сохранении копии:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}