// ProductsForm.cs
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class ProductsForm : Form
    {
        private string _dbPath;
        private DataTable _dataTable;

        public ProductsForm()
        {
            InitializeComponent();
            _dbPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
            _dataTable = new DataTable();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    string sql = "SELECT Id, Name, Description, IsProducedNow, Category FROM Products";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        _dataTable.Clear();
                        adapter.Fill(_dataTable);
                    }
                }
                dataGridView1.DataSource = _dataTable;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изделий:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridView1.Columns["IsProducedNow"] != null)
            {
                dataGridView1.Columns["IsProducedNow"].HeaderText = "Производится сейчас";
                dataGridView1.Columns["IsProducedNow"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridView1.Columns["Name"] != null) dataGridView1.Columns["Name"].HeaderText = "Название";
            if (dataGridView1.Columns["Description"] != null) dataGridView1.Columns["Description"].HeaderText = "Описание";
            if (dataGridView1.Columns["Category"] != null) dataGridView1.Columns["Category"].HeaderText = "Категория";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editor = new ProductEditorForm())
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    SaveProduct(editor.ProductName, editor.Description, editor.IsProducedNow, editor.Category);
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите изделие для редактирования.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = _dataTable.Rows[dataGridView1.CurrentRow.Index];
            using (var editor = new ProductEditorForm())
            {
                editor.ProductName = row["Name"].ToString();
                editor.Description = row["Description"].ToString();
                editor.IsProducedNow = Convert.ToBoolean(row["IsProducedNow"]);
                editor.Category = row["Category"].ToString();
                editor.IsEditMode = true;

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    row["Name"] = editor.ProductName;
                    row["Description"] = editor.Description;
                    row["IsProducedNow"] = editor.IsProducedNow;
                    row["Category"] = editor.Category;
                    SaveChangesToDb();
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите изделие для удаления.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Удалить выбранное изделие?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(_dataTable.Rows[dataGridView1.CurrentRow.Index]["Id"]);
                DeleteProduct(id);
                LoadData();
            }
        }

        private void SaveProduct(string name, string description, bool isProducedNow, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Название изделия не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "INSERT INTO Products (Name, Description, IsProducedNow, Category) VALUES (?, ?, ?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", name);
                        cmd.Parameters.AddWithValue("", description ?? "");
                        cmd.Parameters.AddWithValue("", isProducedNow);
                        cmd.Parameters.AddWithValue("", category ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изделия:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveChangesToDb()
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "SELECT Id, Name, Description, IsProducedNow, Category FROM Products";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        var builder = new OleDbCommandBuilder(adapter);
                        adapter.Update(_dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteProduct(int id)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "DELETE FROM Products WHERE Id = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления изделия:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}