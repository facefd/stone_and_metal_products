using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class Form1 : Form
    {
        private string accessDatabasePath;
        private DataTable dataTable;
        private string connectionString; // Убран readonly

        public Form1()
        {
            InitializeComponent();

            string debugPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
            string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\stone_and_metal.accdb"));

            if (File.Exists(debugPath))
                accessDatabasePath = debugPath;
            else if (File.Exists(projectPath))
                accessDatabasePath = projectPath;
            else
                throw new FileNotFoundException("Файл базы данных stone_and_metal.accdb не найден ни в bin\\Debug, ни в корне проекта.");

            connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accessDatabasePath};";
            dataTable = new DataTable("Таблица1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            // Применить текущую тему при загрузке (по умолчанию светлая)
            ThemeManager.ApplyCurrentTheme(this, dataGridView1, btnSave, menuStrip1);
        }

        private void LoadData()
        {
            try
            {
                using (var conn = new OleDbConnection(connectionString))
                {
                    string sql = "SELECT * FROM Таблица1";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        dataTable.Clear();
                        adapter.Fill(dataTable);
                    }
                }

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка загрузки данных:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Таблица1";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        var commandBuilder = new OleDbCommandBuilder(adapter);
                        adapter.Update(dataTable);
                    }
                }
                MessageBox.Show("✅ Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка при сохранении:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы Access (*.accdb;*.mdb)|*.accdb;*.mdb|Все файлы (*.*)|*.*",
                Title = "Выберите файл базы данных"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string newDatabasePath = openFileDialog.FileName;

                    if (!File.Exists(newDatabasePath))
                    {
                        MessageBox.Show("Файл базы данных не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string tableName = GetFirstTableName(newDatabasePath);
                    if (string.IsNullOrEmpty(tableName))
                    {
                        MessageBox.Show("В базе данных нет таблиц.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    accessDatabasePath = newDatabasePath;
                    connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accessDatabasePath};";

                    LoadData();

                    MessageBox.Show($"База данных успешно подключена:\n{accessDatabasePath}\nТаблица: {tableName}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения к базе:\n{ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void connectBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"✅ База данных подключена.\nПуть: {accessDatabasePath}",
                "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void SavedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saved = new Saved(accessDatabasePath);
            saved.SaveAsAccess();
        }

        private void About_the_ProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cert = new Certificate();
            cert.ShowAbout();
        }

        private void ContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cert = new Certificate();
            cert.ShowHelp();
        }

        private void DeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cert = new Certificate();
            cert.ShowDeveloperInfo();
        }

        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел 'Объекты учёта' будет реализован позже.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел 'Отчёты' будет реализован позже.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saved = new Saved(accessDatabasePath);
            saved.ExportToCSV(dataTable);
        }

        private string GetFirstTableName(string databasePath)
        {
            string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};";
            using (var conn = new OleDbConnection(connStr))
            {
                conn.Open();
                var tables = conn.GetSchema("Tables");
                foreach (DataRow row in tables.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    if (!tableName.StartsWith("MSys"))
                    {
                        return tableName;
                    }
                }
            }
            return null;
        }

        // =============== НОВОЕ: Вид ===============

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Это родительский элемент, кликать по нему не нужно
        }

        // Подменю: Тема
        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme(this, dataGridView1, btnSave, menuStrip1);
            MessageBox.Show($"Тема {(ThemeManager.IsDarkMode ? "тёмная" : "светлая")} включена!", "Вид", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Подменю: Увеличить шрифт
        private void increaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentFont = this.Font;
            this.Font = new Font(currentFont.FontFamily, currentFont.Size + 1, currentFont.Style);
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size + 1);
            MessageBox.Show($"Шрифт увеличен до {this.Font.Size}!", "Вид", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Подменю: Уменьшить шрифт
        private void decreaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentFont = this.Font;
            if (currentFont.Size > 6) // Минимальный размер
            {
                this.Font = new Font(currentFont.FontFamily, currentFont.Size - 1, currentFont.Style);
                dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size - 1);
                MessageBox.Show($"Шрифт уменьшен до {this.Font.Size}!", "Вид", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Шрифт уже минимального размера!", "Вид", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Заглушки
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void menuToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void Site_reportsToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void dataToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void database1DataSetBindingSource_CurrentChanged(object sender, EventArgs e) { }
        private void DataBaseToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) { btnSave_Click(sender, e); }
    }
}