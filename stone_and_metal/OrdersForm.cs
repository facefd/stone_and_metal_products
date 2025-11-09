// OrdersForm.cs
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class OrdersForm : Form
    {
        private string _dbPath;
        private DataTable _ordersTable;
        private DataTable _productsTable;

        public OrdersForm()
        {
            InitializeComponent();
            _dbPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
            _ordersTable = new DataTable();
            _productsTable = new DataTable();
            LoadData();
        }

        private void LoadData()
        {
            LoadProducts();
            LoadOrders();
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    string sql = "SELECT Id, Name FROM Products";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        _productsTable.Clear();
                        adapter.Fill(_productsTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изделий:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    string sql = @"
                        SELECT 
                            o.Id,
                            p.Name AS ProductName,
                            o.ClientName,
                            o.OrderDate,
                            o.PlannedCompletionDate,
                            o.ActualCompletionDate,
                            o.TotalPrice,
                            o.IsPaid,
                            o.Status,
                            o.CancelReason
                        FROM Orders o
                        LEFT JOIN Products p ON o.ProductId = p.Id";
                    using (var adapter = new OleDbDataAdapter(sql, conn))
                    {
                        _ordersTable.Clear();
                        adapter.Fill(_ordersTable);
                    }
                }
                dataGridView1.DataSource = _ordersTable;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            var cols = dataGridView1.Columns;
            if (cols["IsPaid"] != null) cols["IsPaid"].HeaderText = "Оплачен";
            if (cols["ProductName"] != null) cols["ProductName"].HeaderText = "Изделие";
            if (cols["ClientName"] != null) cols["ClientName"].HeaderText = "Клиент";
            if (cols["OrderDate"] != null) cols["OrderDate"].HeaderText = "Дата заказа";
            if (cols["PlannedCompletionDate"] != null) cols["PlannedCompletionDate"].HeaderText = "План";
            if (cols["ActualCompletionDate"] != null) cols["ActualCompletionDate"].HeaderText = "Факт";
            if (cols["TotalPrice"] != null) cols["TotalPrice"].HeaderText = "Стоимость";
            if (cols["Status"] != null) cols["Status"].HeaderText = "Статус";
            if (cols["CancelReason"] != null) cols["CancelReason"].HeaderText = "Причина отмены";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editor = new OrderEditorForm())
            {
                editor.SetProducts(_productsTable);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    SaveOrder(
                        editor.ProductId,
                        editor.ClientName,
                        editor.OrderDate,
                        editor.PlannedCompletionDate,
                        editor.ActualCompletionDate,
                        editor.TotalPrice,
                        editor.IsPaid,
                        editor.Status,
                        editor.CancelReason
                    );
                    LoadOrders();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ для редактирования.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = _ordersTable.Rows[dataGridView1.CurrentRow.Index];
            using (var editor = new OrderEditorForm())
            {
                editor.SetProducts(_productsTable);
                editor.OrderId = Convert.ToInt32(row["Id"]);
                editor.ProductId = Convert.ToInt32(row["ProductName"] is DBNull ? 0 : GetProductIdByName(row["ProductName"].ToString()));
                editor.ClientName = row["ClientName"].ToString();
                editor.OrderDate = row["OrderDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(row["OrderDate"]);
                editor.PlannedCompletionDate = row["PlannedCompletionDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(row["PlannedCompletionDate"]);
                editor.ActualCompletionDate = row["ActualCompletionDate"] is DBNull ? (DateTime?)null : Convert.ToDateTime(row["ActualCompletionDate"]);
                editor.TotalPrice = row["TotalPrice"] is DBNull ? 0 : Convert.ToDecimal(row["TotalPrice"]);
                editor.IsPaid = row["IsPaid"] is DBNull ? false : Convert.ToBoolean(row["IsPaid"]);
                editor.Status = row["Status"].ToString();
                editor.CancelReason = row["CancelReason"].ToString();

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    UpdateOrder(
                        Convert.ToInt32(row["Id"]),
                        editor.ProductId,
                        editor.ClientName,
                        editor.OrderDate,
                        editor.PlannedCompletionDate,
                        editor.ActualCompletionDate,
                        editor.TotalPrice,
                        editor.IsPaid,
                        editor.Status,
                        editor.CancelReason
                    );
                    LoadOrders();
                }
            }
        }

        private int GetProductIdByName(string name)
        {
            foreach (DataRow row in _productsTable.Rows)
            {
                if (row["Name"].ToString() == name)
                    return Convert.ToInt32(row["Id"]);
            }
            return 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ для удаления.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Удалить выбранный заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(_ordersTable.Rows[dataGridView1.CurrentRow.Index]["Id"]);
                DeleteOrder(id);
                LoadOrders();
            }
        }

        private void SaveOrder(int productId, string clientName, DateTime orderDate, DateTime plannedDate, DateTime? actualDate, decimal totalPrice, bool isPaid, string status, string cancelReason)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO Orders 
                        (ProductId, ClientName, OrderDate, PlannedCompletionDate, ActualCompletionDate, TotalPrice, IsPaid, Status, CancelReason) 
                        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", productId);
                        cmd.Parameters.AddWithValue("", clientName ?? "");
                        cmd.Parameters.AddWithValue("", orderDate);
                        cmd.Parameters.AddWithValue("", plannedDate);
                        cmd.Parameters.AddWithValue("", actualDate.HasValue ? (object)actualDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("", totalPrice);
                        cmd.Parameters.AddWithValue("", isPaid);
                        cmd.Parameters.AddWithValue("", status ?? "В работе");
                        cmd.Parameters.AddWithValue("", cancelReason ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения заказа:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrder(int orderId, int productId, string clientName, DateTime orderDate, DateTime plannedDate, DateTime? actualDate, decimal totalPrice, bool isPaid, string status, string cancelReason)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = @"
                        UPDATE Orders SET 
                        ProductId = ?, ClientName = ?, OrderDate = ?, PlannedCompletionDate = ?, 
                        ActualCompletionDate = ?, TotalPrice = ?, IsPaid = ?, Status = ?, CancelReason = ?
                        WHERE Id = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", productId);
                        cmd.Parameters.AddWithValue("", clientName ?? "");
                        cmd.Parameters.AddWithValue("", orderDate);
                        cmd.Parameters.AddWithValue("", plannedDate);
                        cmd.Parameters.AddWithValue("", actualDate.HasValue ? (object)actualDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("", totalPrice);
                        cmd.Parameters.AddWithValue("", isPaid);
                        cmd.Parameters.AddWithValue("", status ?? "В работе");
                        cmd.Parameters.AddWithValue("", cancelReason ?? "");
                        cmd.Parameters.AddWithValue("", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления заказа:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrder(int id)
        {
            try
            {
                using (var conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_dbPath};"))
                {
                    conn.Open();
                    string sql = "DELETE FROM Orders WHERE Id = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления заказа:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}