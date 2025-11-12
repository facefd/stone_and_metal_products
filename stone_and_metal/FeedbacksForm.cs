// FeedbacksForm.cs
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class FeedbacksForm : Form
    {
        private string _dbPath;
        private DataTable _feedbacksTable;
        private DataTable _ordersTable;

        public FeedbacksForm()
        {
            InitializeComponent();
            _dbPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
            _feedbacksTable = new DataTable();
            _ordersTable = new DataTable();
            LoadData();
        }

        private void LoadData()
        {
            LoadOrders();
            LoadFeedbacks();
        }

        private void LoadOrders()
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    string sql = "SELECT Id, ClientName FROM Orders";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        _ordersTable.Clear();
                        adapter.Fill(_ordersTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFeedbacks()
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    string sql = @"
                        SELECT 
                            f.Id,
                            o.ClientName AS OrderClient,
                            f.FeedbackDate,
                            f.Type,
                            f.Comment
                        FROM Feedbacks f
                        LEFT JOIN Orders o ON f.OrderId = o.Id";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        _feedbacksTable.Clear();
                        adapter.Fill(_feedbacksTable);
                    }
                }
                dataGridView1.DataSource = _feedbacksTable;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отзывов:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dataGridView1.Columns["OrderClient"] != null) dataGridView1.Columns["OrderClient"].HeaderText = "Клиент";
            if (dataGridView1.Columns["FeedbackDate"] != null) dataGridView1.Columns["FeedbackDate"].HeaderText = "Дата";
            if (dataGridView1.Columns["Type"] != null) dataGridView1.Columns["Type"].HeaderText = "Тип";
            if (dataGridView1.Columns["Comment"] != null) dataGridView1.Columns["Comment"].HeaderText = "Комментарий";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editor = new FeedbackEditorForm())
            {
                editor.SetOrders(_ordersTable);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    SaveFeedback(
                        editor.OrderId,
                        editor.FeedbackDate,
                        editor.Type,
                        editor.Comment
                    );
                    LoadFeedbacks();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите отзыв для редактирования.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = _feedbacksTable.Rows[dataGridView1.CurrentRow.Index];
            using (var editor = new FeedbackEditorForm())
            {
                editor.SetOrders(_ordersTable);
                editor.FeedbackId = Convert.ToInt32(row["Id"]);
                editor.OrderId = GetOrderIdByClient(row["OrderClient"].ToString());
                editor.FeedbackDate = row["FeedbackDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(row["FeedbackDate"]);
                editor.Type = row["Type"].ToString();
                editor.Comment = row["Comment"].ToString();

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    UpdateFeedback(
                        Convert.ToInt32(row["Id"]),
                        editor.OrderId,
                        editor.FeedbackDate,
                        editor.Type,
                        editor.Comment
                    );
                    LoadFeedbacks();
                }
            }
        }

        private int GetOrderIdByClient(string clientName)
        {
            foreach (DataRow row in _ordersTable.Rows)
            {
                if (row["ClientName"].ToString() == clientName)
                    return Convert.ToInt32(row["Id"]);
            }
            return 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите отзыв для удаления.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Удалить выбранный отзыв?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(_feedbacksTable.Rows[dataGridView1.CurrentRow.Index]["Id"]);
                DeleteFeedback(id);
                LoadFeedbacks();
            }
        }

        private void SaveFeedback(int orderId, DateTime feedbackDate, string type, string comment)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "INSERT INTO Feedbacks (OrderId, FeedbackDate, Type, Comment) VALUES (?, ?, ?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", orderId);
                        cmd.Parameters.AddWithValue("", feedbackDate);
                        cmd.Parameters.AddWithValue("", type ?? "Благодарность");
                        cmd.Parameters.AddWithValue("", comment ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения отзыва:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFeedback(int id, int orderId, DateTime feedbackDate, string type, string comment)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "UPDATE Feedbacks SET OrderId = ?, FeedbackDate = ?, Type = ?, Comment = ? WHERE Id = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", orderId);
                        cmd.Parameters.AddWithValue("", feedbackDate);
                        cmd.Parameters.AddWithValue("", type ?? "Благодарность");
                        cmd.Parameters.AddWithValue("", comment ?? "");
                        cmd.Parameters.AddWithValue("", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления отзыва:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteFeedback(int id)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "DELETE FROM Feedbacks WHERE Id = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления отзыва:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FeedbacksForm_Load(object sender, EventArgs e)
        {

        }
    }
}