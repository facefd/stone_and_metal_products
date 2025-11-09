// DatabaseHelper.cs
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace stone_and_metal
{
    public static class DatabaseHelper
    {
        private static readonly string StoneAndMetalDbPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
        private static readonly string ProfileDbPath = Path.Combine(Application.StartupPath, "profile.accdb");

        public static void InitializeDatabase()
        {
            if (!File.Exists(StoneAndMetalDbPath))
                MessageBox.Show($"Файл {StoneAndMetalDbPath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!File.Exists(ProfileDbPath))
                MessageBox.Show($"Файл {ProfileDbPath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CreateRequiredTablesInStoneAndMetal();
            EnsureUserRoleInProfile();
        }

        private static void CreateRequiredTablesInStoneAndMetal()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={StoneAndMetalDbPath};";
            var tablesToCreate = new Dictionary<string, string>
            {
                ["Products"] = @"
                    CREATE TABLE [Products] (
                        [Id] COUNTER PRIMARY KEY,
                        [Name] TEXT(255),
                        [Description] MEMO,
                        [IsProducedNow] YESNO,
                        [Category] TEXT(100)
                    )",
                ["Orders"] = @"
                    CREATE TABLE [Orders] (
                        [Id] COUNTER PRIMARY KEY,
                        [ProductId] LONG,
                        [ClientName] TEXT(255),
                        [OrderDate] DATETIME,
                        [PlannedCompletionDate] DATETIME,
                        [ActualCompletionDate] DATETIME,
                        [TotalPrice] CURRENCY,
                        [IsPaid] YESNO,
                        [Status] TEXT(50),
                        [CancelReason] MEMO
                    )",
                ["Feedbacks"] = @"
                    CREATE TABLE [Feedbacks] (
                        [Id] COUNTER PRIMARY KEY,
                        [OrderId] LONG,
                        [FeedbackDate] DATETIME,
                        [Type] TEXT(50),
                        [Comment] MEMO
                    )"
            };

            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var existingTables = new HashSet<string>();
                    foreach (DataRow row in conn.GetSchema("Tables").Rows)
                    {
                        string name = row["TABLE_NAME"].ToString();
                        if (!name.StartsWith("MSys")) existingTables.Add(name);
                    }

                    foreach (var kvp in tablesToCreate)
                    {
                        string name = kvp.Key;
                        string sql = kvp.Value;
                        if (!existingTables.Contains(name))
                        {
                            using (var cmd = new OleDbCommand(sql, conn))
                                cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании таблиц: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void EnsureUserRoleInProfile()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    bool hasRoleColumn = false;
                    var schema = conn.GetSchema("Columns", new[] { null, null, "Users", null });
                    foreach (DataRow row in schema.Rows)
                    {
                        if (row["COLUMN_NAME"].ToString() == "Role")
                        {
                            hasRoleColumn = true;
                            break;
                        }
                    }

                    if (!hasRoleColumn)
                    {
                        using (var cmd = new OleDbCommand("ALTER TABLE [Users] ADD COLUMN [Role] TEXT(20)", conn))
                            cmd.ExecuteNonQuery();

                        using (var cmd = new OleDbCommand("UPDATE [Users] SET [Role] = 'admin' WHERE [Id] = (SELECT MIN([Id]) FROM [Users])", conn))
                        {
                            try { cmd.ExecuteNonQuery(); }
                            catch { /* Игнор */ }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении Users: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool CheckDatabaseExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                MessageBox.Show($"Файл {dbPath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool CheckStoneAndMetalDatabaseExists() => CheckDatabaseExists(StoneAndMetalDbPath);
        public static bool CheckProfileDatabaseExists() => CheckDatabaseExists(ProfileDbPath);

        public static bool UserExists(string login)
        {
            if (!CheckProfileDatabaseExists()) return false;
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM [Users] WHERE [Login] = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", login ?? string.Empty);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static bool RegisterUser(string login, string password)
        {
            if (!CheckProfileDatabaseExists()) return false;
            if (UserExists(login)) return false;
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO [Users] ([Login], [Password], [Role]) VALUES (?, ?, 'user')";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", login ?? string.Empty);
                        cmd.Parameters.AddWithValue("", password ?? string.Empty);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static (bool success, string role) ValidateLogin(string login, string password)
        {
            if (!CheckProfileDatabaseExists()) return (false, "");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT [Role] FROM [Users] WHERE [Login] = ? AND [Password] = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("", login ?? string.Empty);
                        cmd.Parameters.AddWithValue("", password ?? string.Empty);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return (true, result.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (false, "");
        }
    }
}