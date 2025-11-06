// ReportsHelper.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace stone_and_metal
{
    public static class ReportsHelper
    {
        public static void GenerateCsvReport(List<DataItem> data, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Записываем BOM для Excel
                    writer.Write('\uFEFF');

                    // Заголовки
                    writer.WriteLine("Id;Name;Value;Timestamp");

                    // Данные
                    foreach (var item in data)
                    {
                        writer.WriteLine($"{item.Id};{item.Name};{item.Value};{item.Timestamp:yyyy-MM-dd HH:mm:ss}");
                    }
                }

                MessageBox.Show($"Отчёт успешно сохранён в:\n{filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении отчёта:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}