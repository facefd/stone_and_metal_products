using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace stone_and_metal
{
    public class DataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public static class DatabaseHelper
    {
        private static readonly string StoneAndMetalDbPath = Path.Combine(Application.StartupPath, "stone_and_metal.accdb");
        private static readonly string ProfileDbPath = Path.Combine(Application.StartupPath, "profile.accdb");

        public static void InitializeDatabase()
        {
            if (!File.Exists(StoneAndMetalDbPath))
            {
                MessageBox.Show($"Файл {StoneAndMetalDbPath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!File.Exists(ProfileDbPath))
            {
                MessageBox.Show($"Файл {ProfileDbPath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CreateDataTableIfNotExists();
        }

        private static void CreateDataTableIfNotExists()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={StoneAndMetalDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var tables = conn.GetSchema("Tables");
                    bool tableExists = false;
                    foreach (DataRow row in tables.Rows)
                    {
                        if (row["TABLE_NAME"].ToString() == "Data")
                        {
                            tableExists = true;
                            break;
                        }
                    }

                    if (!tableExists)
                    {
                        string createSql = @"
                            CREATE TABLE [Data] (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                Value TEXT NOT NULL,
                                Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
                            )";
                        using (var cmd = new OleDbCommand(createSql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Таблица [Data] создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static bool CheckStoneAndMetalDatabaseExists()
        {
            return CheckDatabaseExists(StoneAndMetalDbPath);
        }

        public static bool CheckProfileDatabaseExists()
        {
            return CheckDatabaseExists(ProfileDbPath);
        }

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
                        cmd.Parameters.AddWithValue("@login", login ?? string.Empty);
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
                    string sql = "INSERT INTO [Users] ([Login], [Password]) VALUES (?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login ?? string.Empty);
                        cmd.Parameters.AddWithValue("@password", password ?? string.Empty);
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

        public static bool ValidateLogin(string login, string password)
        {
            if (!CheckProfileDatabaseExists()) return false;

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM [Users] WHERE [Login] = ? AND [Password] = ?";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login ?? string.Empty);
                        cmd.Parameters.AddWithValue("@password", password ?? string.Empty);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при проверке логина: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static void SaveData(string name, string value)
        {
            if (!CheckStoneAndMetalDatabaseExists()) return;

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={StoneAndMetalDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO [Data] ([Name], [Value]) VALUES (?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name ?? string.Empty);
                        cmd.Parameters.AddWithValue("@value", value ?? string.Empty);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static List<DataItem> GetData(string sortBy = "Timestamp")
        {
            var list = new List<DataItem>();
            if (!CheckStoneAndMetalDatabaseExists()) return list;

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={StoneAndMetalDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = $"SELECT * FROM [Data] ORDER BY [{sortBy}]";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new DataItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Value = reader["Value"].ToString(),
                                    Timestamp = Convert.ToDateTime(reader["Timestamp"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return list;
        }
    }
}