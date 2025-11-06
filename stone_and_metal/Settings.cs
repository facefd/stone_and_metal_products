// Settings.cs
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class Settings : Form
    {
        private string databasePath;
        private bool isDarkMode;
        private float fontSize;

        public Settings(string dbPath)
        {
            InitializeComponent();
            databasePath = dbPath;
            LoadSettings();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Settings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
        }

        private void LoadSettings()
        {
            // Заглушка — загрузка настроек из файла/реестра
            // isDarkMode = GetThemeFromConfig();
            // fontSize = GetFontSizeFromConfig();
            isDarkMode = ThemeManager.IsDarkMode;
            fontSize = 8.25f; // по умолчанию
        }

        public void ApplySettings(Form form, DataGridView dataGridView, Button button, MenuStrip menuStrip)
        {
            // Применяем тему
            if (isDarkMode && !ThemeManager.IsDarkMode)
            {
                ThemeManager.ToggleTheme(form, dataGridView, button, menuStrip);
            }
            else if (!isDarkMode && ThemeManager.IsDarkMode)
            {
                ThemeManager.ToggleTheme(form, dataGridView, button, menuStrip);
            }

            // Применяем размер шрифта
            var newFont = new Font(form.Font.FontFamily, fontSize, form.Font.Style);
            form.Font = newFont;
            dataGridView.Font = new Font(dataGridView.Font.FontFamily, fontSize);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
        }
    }
}