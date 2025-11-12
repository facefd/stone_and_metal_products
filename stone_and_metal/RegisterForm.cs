using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public string NewLogin => textBoxNewLogin.Text;
        public string NewPassword => textBoxNewPassword.Text;
        public string ConfirmPassword => textBoxConfirmPassword.Text;

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewLogin) || string.IsNullOrWhiteSpace(NewPassword) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NewPassword != ConfirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.RegisterUser(NewLogin, NewPassword))
            {
                int userId = DatabaseHelper.GetUserIdByLogin(NewLogin);
                DatabaseHelper.LogAction(userId, "Registration", GetLocalIpAddress(), $"Новый пользователь: {NewLogin}");

                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}