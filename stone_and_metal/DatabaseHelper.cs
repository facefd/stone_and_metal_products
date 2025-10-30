// DatabaseHelper.cs
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

        // Проверка существования БД
        public static bool CheckProfileDatabaseExists()
        {
            if (!File.Exists(ProfileDbPath))
            {
                MessageBox.Show($"Файл {ProfileDbPath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Проверка пользователя
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
                        cmd.Parameters.AddWithValue("@p1", login);
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

        // Регистрация
        public static bool RegisterUser(string login, string password)
        {
            if (!CheckProfileDatabaseExists()) return false;

            if (UserExists(login))
            {
                return false;
            }

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO [Users] ([Login], [Password]) VALUES (?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@p1", login);
                        cmd.Parameters.AddWithValue("@p2", password);
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

        // Вход
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
                        cmd.Parameters.AddWithValue("@p1", login);
                        cmd.Parameters.AddWithValue("@p2", password);
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

        // Сохранение данных — если таблица Data не существует, создаем её
        public static void SaveData(string name, string value)
        {
            if (!CheckProfileDatabaseExists()) return;

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";

            // Проверим, существует ли таблица Data
            bool tableExists = false;
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var tables = conn.GetSchema("Tables");
                    foreach (DataRow row in tables.Rows)
                    {
                        if (row["TABLE_NAME"].ToString() == "Data")
                        {
                            tableExists = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при проверке таблицы Data: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!tableExists)
            {
                CreateDataTable();
            }

            // Теперь сохраняем
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO [Data] ([Name], [Value], [Timestamp]) VALUES (?, ?, ?)";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = name ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@p2", OleDbType.VarChar).Value = value ?? (object)DBNull.Value;
                        cmd.Parameters.Add("@p3", OleDbType.Date).Value = DateTime.Now;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void CreateDataTable()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        CREATE TABLE [Data] (
                            [Id] AUTOINCREMENT PRIMARY KEY,
                            [Name] TEXT(255),
                            [Value] TEXT(255),
                            [Timestamp] DATETIME
                        );";
                    using (var cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Таблица [Data] создана в profile.accdb", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании таблицы [Data]: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Получение данных
        public static List<DataItem> GetData(string sortBy = "Timestamp")
        {
            var list = new List<DataItem>();

            if (!CheckProfileDatabaseExists()) return list;

            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            using (var conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = $"SELECT [Id], [Name], [Value], [Timestamp] FROM [Data] ORDER BY [{sortBy}]";
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