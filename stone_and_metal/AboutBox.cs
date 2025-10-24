using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            this.Text = "О программе";
            labelTitle.Text = "Stone & Metal";
            labelVersion.Text = "Версия 1.0";
            labelDescription.Text = "Программа для учёта изделий из камня и металла.";
            labelAuthor.Text = "© 2025, Разработчики";

            LoadLogo();
        }

        private void LoadLogo()
        {
            string logoPath = Path.Combine(Application.StartupPath, "LogoStoneAndMetal.png");
            if (File.Exists(logoPath))
            {
                pictureBoxLogo.Image = Image.FromFile(logoPath);
            }
            else
            {
                pictureBoxLogo.Image = null;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}