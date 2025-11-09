// Form1.cs
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
        private string connectionString;
        private string _userRole;

        public Form1(string userRole = "user")
        {
            InitializeComponent();
            _userRole = userRole;

            string debugPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
            string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\stone_and_metal.accdb"));
            if (File.Exists(debugPath))
                accessDatabasePath = debugPath;
            else if (File.Exists(projectPath))
                accessDatabasePath = projectPath;
            else
                throw new FileNotFoundException("Файл базы данных stone_and_metal.accdb не найден...");

            connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accessDatabasePath};";
            dataTable = new DataTable("Таблица1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            ThemeManager.ApplyCurrentTheme(this, dataGridView1, btnSave, menuStrip1);

            if (_userRole != "admin")
            {
                foreach (ToolStripItem item in databaseToolStripMenuItem.DropDownItems)
                {
                    if (item.Text.Contains("Сохранить копию"))
                    {
                        item.Visible = false;
                        break;
                    }
                }
            }
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

        // === Меню ===
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ProductsForm();
            f.ShowDialog();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new OrdersForm();
            f.ShowDialog();
        }

        private void feedbacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FeedbacksForm();
            f.ShowDialog();
        }

        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AccountingObjects();
            f.ShowDialog();
        }

        private void ReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ReferenceBooks();
            f.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Reports();
            f.ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saved = new Saved(accessDatabasePath);
            saved.ExportToCSV(dataTable);
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
            var helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void DeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cert = new Certificate();
            cert.ShowDeveloperInfo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // === Вид ===
        private void ViewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new Settings(accessDatabasePath);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                settings.ApplySettings(this, dataGridView1, btnSave, menuStrip1);
            }
        }

        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme(this, dataGridView1, btnSave, menuStrip1);
        }

        private void increaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = this.Font;
            this.Font = new Font(f.FontFamily, f.Size + 1, f.Style);
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size + 1);
        }

        private void decreaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = this.Font;
            if (f.Size > 6)
            {
                this.Font = new Font(f.FontFamily, f.Size - 1, f.Style);
                dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size - 1);
            }
            else
            {
                MessageBox.Show("Шрифт уже минимального размера!", "Вид", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // === Прочее ===
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog
            {
                Filter = "Файлы Access (*.accdb;*.mdb)|*.accdb;*.mdb|Все файлы (*.*)|*.*",
                Title = "Выберите файл базы данных"
            };
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string newDb = d.FileName;
                    if (!File.Exists(newDb))
                    {
                        MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string table = GetFirstTableName(newDb);
                    if (string.IsNullOrEmpty(table))
                    {
                        MessageBox.Show("В базе нет таблиц.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    accessDatabasePath = newDb;
                    connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accessDatabasePath};";
                    LoadData();
                    MessageBox.Show($"База подключена:\n{accessDatabasePath}\nТаблица: {table}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void connectBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"База подключена.\nПуть: {accessDatabasePath}", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private string GetFirstTableName(string dbPath)
        {
            string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
            using (var conn = new OleDbConnection(connStr))
            {
                conn.Open();
                var tables = conn.GetSchema("Tables");
                foreach (DataRow row in tables.Rows)
                {
                    string name = row["TABLE_NAME"].ToString();
                    if (!name.StartsWith("MSys")) return name;
                }
            }
            return null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
    }
}