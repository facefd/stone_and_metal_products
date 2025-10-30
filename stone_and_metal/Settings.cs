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
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
        }

        private void LoadSettings()
        {
            // Заглушка — загрузка настроек
        }

        public void ApplySettings(Form form, DataGridView dataGridView, Button button, MenuStrip menuStrip)
        {
            // Заглушка — применение настроек
        }

        private void Settings_Load(object sender, EventArgs e)
        {
        }
    }
}