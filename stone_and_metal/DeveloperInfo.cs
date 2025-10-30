// DeveloperInfo.cs
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class DeveloperInfo : Form
    {
        public DeveloperInfo()
        {
            InitializeComponent();
        }

        private void DeveloperInfo_Load(object sender, EventArgs e)
        {
            this.Text = "О разработчиках";
            labelTitle.Text = "Stone & Metal";
            labelVersion.Text = "Версия 1.0";
            labelDescription.Text = "Программа для учёта изделий из камня и металла.";

            labelDev1Name.Text = "Имя: Гайдин А.Н";
            labelDev1Position.Text = "Должность: Middle App Developer, Product manager, Scrum master";
            linkLabelDev1Email.Text = "Email: aface_shot@mail.ru";
            linkLabelDev1Phone.Text = "Телефон: +7 (910) 720-71-54";

            labelDev2Name.Text = "Имя: Гриценко Д.А";
            labelDev2Position.Text = "Должность: Senior Frontend Developer, React engineer, Team lead, SEO";
            linkLabelDev2Email.Text = "Email: iDK@example.com";
            linkLabelDev2Phone.Text = "Телефон: +8 (800) 555-35-35";

            labelDev3Name.Text = "Имя: Сидоров С.С.";
            labelDev3Position.Text = "Должность: Фондовый акционер, Тестировщик";
            linkLabelDev3Email.Text = "Email: sidorov@example.com";
            linkLabelDev3Phone.Text = "Телефон: +7 (123) 456-78-92";

            panelDev1.BackColor = Color.FromArgb(240, 240, 240);
            panelDev2.BackColor = Color.FromArgb(245, 245, 245);
            panelDev3.BackColor = Color.FromArgb(250, 250, 250);

            LoadLogo(pictureBoxDev1);
            LoadLogo(pictureBoxDev2);
            LoadLogo(pictureBoxDev3);
        }

        private void LoadLogo(PictureBox pb)
        {
            string logoPath = Path.Combine(Application.StartupPath, "LogoStoneAndMetal.png");
            if (File.Exists(logoPath))
            {
                pb.Image = Image.FromFile(logoPath);
            }
        }

        private void linkLabelDev1Email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenEmail("aface_shot@mail.ru");
        private void linkLabelDev1Phone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenPhone("+79107207154");
        private void linkLabelDev2Email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenEmail("iDK@example.com");
        private void linkLabelDev2Phone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenPhone("+88005553535");
        private void linkLabelDev3Email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenEmail("sidorov@example.com");
        private void linkLabelDev3Phone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenPhone("+71234567892");

        private void OpenEmail(string email)
        {
            try { Process.Start(new ProcessStartInfo("mailto:" + email) { UseShellExecute = true }); }
            catch { MessageBox.Show("Не удалось открыть почту.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void OpenPhone(string phone)
        {
            try { Process.Start(new ProcessStartInfo("tel:" + phone) { UseShellExecute = true }); }
            catch { MessageBox.Show("Не удалось открыть телефон.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void buttonOK_Click(object sender, EventArgs e) => this.Close();
    }
}