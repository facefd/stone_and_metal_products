using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class LoginForm : Form
    {
        public string UserRole { get; private set; } = "user";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DatabaseHelper.InitializeDatabase();
        }

        public string Login => textBoxLogin?.Text ?? string.Empty;
        public string Password => textBoxPassword?.Text ?? string.Empty;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (success, role) = DatabaseHelper.ValidateLogin(Login, Password);
            if (success)
            {
                int userId = DatabaseHelper.GetUserIdByLogin(Login);
                DatabaseHelper.LogAction(userId, "Login", GetLocalIpAddress(), $"Роль: {role}");

                UserRole = role;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DatabaseHelper.LogAction(-1, "Failed Login", GetLocalIpAddress(), $"Логин: {Login}");
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();

            if (registerForm.DialogResult == DialogResult.OK)
            {
                this.Activate();
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            buttonRegister_Click(sender, e);
        }

        private string GetLocalIpAddress()
        {
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch { }
            return "Unknown";
        }
    }
}