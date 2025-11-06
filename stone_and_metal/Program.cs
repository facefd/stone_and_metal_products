// Program.cs
using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
            //try
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);

            //    var loginForm = new LoginForm();
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new Form1());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Критическая ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}