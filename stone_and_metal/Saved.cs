using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace stone_and_metal
{
    public class Saved
    {
        private readonly string accessDatabasePath;

        public Saved(string databasePath)
        {
            this.accessDatabasePath = databasePath;
        }

        public void SaveAsAccess()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы Access (*.accdb)|*.accdb|Все файлы (*.*)|*.*",
                Title = "Сохранить базу данных как",
                FileName = $"{Path.GetFileNameWithoutExtension(accessDatabasePath)}_копия_{DateTime.Now:yyyyMMdd_HHmmss}.accdb"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (IsFileLocked(accessDatabasePath))
                    {
                        MessageBox.Show("База данных занята. Закройте её и попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    File.Copy(accessDatabasePath, saveFileDialog.FileName, overwrite: true);
                    MessageBox.Show($"База данных успешно сохранена как:\n{saveFileDialog.FileName}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении базы:\n{ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ExportToCSV(DataTable dt)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Сохранить как CSV файл"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Записываем BOM для Excel
                        sw.Write('\uFEFF');

                        // Заголовки
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sw.Write(QuoteCsv(dt.Columns[i].ToString()));
                            if (i < dt.Columns.Count - 1) sw.Write(";");
                        }
                        sw.WriteLine();

                        // Данные
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                sw.Write(QuoteCsv(row[i]?.ToString() ?? ""));
                                if (i < dt.Columns.Count - 1) sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show($"Данные успешно экспортированы в:\n{saveFileDialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка экспорта:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsFileLocked(string path)
        {
            try
            {
                using (var fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }

        private string QuoteCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(';') || value.Contains('"') || value.Contains('\n'))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}