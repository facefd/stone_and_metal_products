// DataForm.cs — ЗАГЛУШКА, чтобы проект собирался
using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            // Заглушка — просто показываем сообщение
            MessageBox.Show("Эта форма больше не используется.\nВсе данные теперь управляются через:\n- Изделия\n- Заказы\n- Отзывы", 
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Автоматически закрываем
        }
    }
}