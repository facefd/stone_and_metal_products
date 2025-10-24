using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            string helpPath = Path.Combine(Application.StartupPath, "help.txt");
            if (File.Exists(helpPath))
            {
                richTextBoxHelp.Text = File.ReadAllText(helpPath, Encoding.UTF8);
                richTextBoxHelp.SelectionStart = 0;
                richTextBoxHelp.ScrollToCaret();
            }
            else
            {
                richTextBoxHelp.Text = "Справка не найдена. Пожалуйста, проверьте наличие файла help.txt.";
            }
        }

        // Добавлено для дизайнерского файла
        private void richTextBoxHelp_TextChanged(object sender, EventArgs e)
        {
            // Необязательно, можно оставить пустым
        }
    }
}