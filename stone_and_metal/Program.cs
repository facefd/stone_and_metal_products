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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new LoginForm())
            {
                //Application.Run(new Form1(loginForm.UserRole));
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(loginForm.UserRole));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}