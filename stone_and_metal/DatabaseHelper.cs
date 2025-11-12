using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace stone_and_metal
{
    public static class DatabaseHelper
    {
        // ПУТЬ К БАЗЕ — ВСЕГДА ТАМ, ГДЕ НАХОДИТСЯ .EXE ФАЙЛ!
        private static readonly string BasePath = @"E:\git\stone_and_metal_products\stone_and_metal"; // Используем указанный путь
        private static readonly string StoneAndMetalDbPath = Path.Combine(BasePath, "stone_and_metal.accdb");
        private static readonly string ProfileDbPath = Path.Combine(BasePath, "profile.accdb");

        private static readonly object _lockObject = new object();

        public static void InitializeDatabase()
        {
            lock (_lockObject)
            {
                EnsureDatabaseExists();
                CreateRequiredTablesInStoneAndMetal();
                EnsureUserRoleInProfile();
                EnsureLogsTableInProfile();
            }
        }

        private static void EnsureDatabaseExists()
        {
            if (!File.Exists(StoneAndMetalDbPath))
                throw new FileNotFoundException($"Файл БД не найден: {StoneAndMetalDbPath}");
            if (!File.Exists(ProfileDbPath))
                throw new FileNotFoundException($"Файл БД не найден: {ProfileDbPath}");
        }

        private static void CreateRequiredTablesInStoneAndMetal()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={StoneAndMetalDbPath};";
            var tablesToCreate = new System.Collections.Generic.Dictionary<string, string>
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

            try
            {
                using (var conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    var existingTables = new System.Collections.Generic.HashSet<string>();
                    foreach (DataRow row in conn.GetSchema("Tables").Rows)
                    {
                        string name = row["TABLE_NAME"].ToString();
                        if (!name.StartsWith("MSys")) existingTables.Add(name);
                    }

                    foreach (var kvp in tablesToCreate)
                    {
                        if (!existingTables.Contains(kvp.Key))
                        {
                            using (var cmd = new OleDbCommand(kvp.Value, conn))
                                cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при создании таблиц в базе {StoneAndMetalDbPath}: {ex.Message}", ex);
            }
        }

        private static void EnsureUserRoleInProfile()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            try
            {
                using (var conn = new OleDbConnection(connectionString))
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при добавлении колонки Role в базу {ProfileDbPath}: {ex.Message}", ex);
            }
        }

        private static void EnsureLogsTableInProfile()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
            try
            {
                using (var conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    bool tableExists = false;
                    foreach (DataRow row in conn.GetSchema("Tables").Rows)
                    {
                        if (row["TABLE_NAME"].ToString() == "Logs")
                        {
                            tableExists = true;
                            break;
                        }
                    }

                    if (!tableExists)
                    {
                        string createSql = @"
                            CREATE TABLE [Logs] (
                                [Id] COUNTER PRIMARY KEY,
                                [UserId] LONG,
                                [Action] TEXT(255),
                                [Timestamp] DATETIME,
                                [IpAddress] TEXT(45),
                                [Details] MEMO
                            )";
                        using (var cmd = new OleDbCommand(createSql, conn))
                            cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при создании таблицы Logs в базе {ProfileDbPath}: {ex.Message}", ex);
            }
        }

        // Метод для хэширования пароля
        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool UserExists(string login)
        {
            lock (_lockObject)
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
                try
                {
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "SELECT COUNT(*) FROM [Users] WHERE [Login] = ?";
                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", login ?? string.Empty);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            return count > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Ошибка при проверке существования пользователя: {ex.Message}", ex);
                }
            }
        }

        public static bool RegisterUser(string login, string password)
        {
            lock (_lockObject)
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                    return false;

                if (UserExists(login)) return false;

                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
                try
                {
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "INSERT INTO [Users] ([Login], [Password], [Role]) VALUES (?, ?, 'user')";
                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", login);
                            cmd.Parameters.AddWithValue("@p2", HashPassword(password)); // Сохраняем хэш пароля
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Ошибка при регистрации пользователя: {ex.Message}", ex);
                }
            }
        }

        public static (bool success, string role) ValidateLogin(string login, string password)
        {
            lock (_lockObject)
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                    return (false, "");

                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
                try
                {
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "SELECT [Role] FROM [Users] WHERE [Login] = ? AND [Password] = ?";
                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", login);
                            cmd.Parameters.AddWithValue("@p2", HashPassword(password)); // Сравниваем с хэшем
                            var result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                return (true, result.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Ошибка при проверке логина: {ex.Message}", ex);
                }
            }
            return (false, "");
        }

        public static int GetUserIdByLogin(string login)
        {
            lock (_lockObject)
            {
                if (string.IsNullOrEmpty(login))
                    return -1;

                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
                try
                {
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "SELECT [Id] FROM [Users] WHERE [Login] = ?";
                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", login);
                            var result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                return Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Ошибка при получении ID пользователя: {ex.Message}", ex);
                }
            }
            return -1;
        }

        public static void LogAction(int userId, string action, string ipAddress = "", string details = "")
        {
            lock (_lockObject)
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ProfileDbPath};";
                try
                {
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"
                            INSERT INTO [Logs] ([UserId], [Action], [Timestamp], [IpAddress], [Details])
                            VALUES (?, ?, ?, ?, ?)";

                        using (var cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@p1", userId);
                            cmd.Parameters.AddWithValue("@p2", action ?? string.Empty);
                            cmd.Parameters.AddWithValue("@p3", DateTime.Now);
                            cmd.Parameters.AddWithValue("@p4", ipAddress ?? string.Empty);
                            cmd.Parameters.AddWithValue("@p5", details ?? string.Empty);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Ошибка при логировании действия: {ex.Message}", ex);
                }
            }
        }
    }
}