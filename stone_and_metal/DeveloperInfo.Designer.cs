namespace stone_and_metal
{
    partial class DeveloperInfo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelDev1 = new System.Windows.Forms.Panel();
            this.linkLabelDev1Email = new System.Windows.Forms.LinkLabel();
            this.linkLabelDev1Phone = new System.Windows.Forms.LinkLabel();
            this.labelDev1Position = new System.Windows.Forms.Label();
            this.labelDev1Name = new System.Windows.Forms.Label();
            this.panelDev2 = new System.Windows.Forms.Panel();
            this.linkLabelDev2Email = new System.Windows.Forms.LinkLabel();
            this.linkLabelDev2Phone = new System.Windows.Forms.LinkLabel();
            this.labelDev2Position = new System.Windows.Forms.Label();
            this.labelDev2Name = new System.Windows.Forms.Label();
            this.panelDev3 = new System.Windows.Forms.Panel();
            this.linkLabelDev3Email = new System.Windows.Forms.LinkLabel();
            this.linkLabelDev3Phone = new System.Windows.Forms.LinkLabel();
            this.labelDev3Position = new System.Windows.Forms.Label();
            this.labelDev3Name = new System.Windows.Forms.Label();
            this.pictureBoxDev1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDev2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDev3 = new System.Windows.Forms.PictureBox();
            this.panelDev1.SuspendLayout();
            this.panelDev2.SuspendLayout();
            this.panelDev3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(12, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(300, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Stone & Metal";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(12, 50);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(300, 23);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Версия 1.0";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(12, 80);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(300, 23);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Программа для учёта изделий из камня и металла.";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(137, 500);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelDev1
            // 
            this.panelDev1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelDev1.Controls.Add(this.pictureBoxDev1);
            this.panelDev1.Controls.Add(this.linkLabelDev1Email);
            this.panelDev1.Controls.Add(this.linkLabelDev1Phone);
            this.panelDev1.Controls.Add(this.labelDev1Position);
            this.panelDev1.Controls.Add(this.labelDev1Name);
            this.panelDev1.Location = new System.Drawing.Point(12, 110);
            this.panelDev1.Name = "panelDev1";
            this.panelDev1.Size = new System.Drawing.Size(300, 120);
            this.panelDev1.TabIndex = 4;
            // 
            // pictureBoxDev1
            // 
            this.pictureBoxDev1.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxDev1.Name = "pictureBoxDev1";
            this.pictureBoxDev1.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxDev1.TabIndex = 4;
            this.pictureBoxDev1.TabStop = false;
            // 
            // linkLabelDev1Email
            // 
            this.linkLabelDev1Email.Location = new System.Drawing.Point(10, 75);
            this.linkLabelDev1Email.Name = "linkLabelDev1Email";
            this.linkLabelDev1Email.Size = new System.Drawing.Size(280, 20);
            this.linkLabelDev1Email.TabIndex = 3;
            this.linkLabelDev1Email.TabStop = true;
            this.linkLabelDev1Email.Text = "Email: aface_shot@mail.ru";
            this.linkLabelDev1Email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev1Email_LinkClicked);
            // 
            // linkLabelDev1Phone
            // 
            this.linkLabelDev1Phone.Location = new System.Drawing.Point(10, 95);
            this.linkLabelDev1Phone.Name = "linkLabelDev1Phone";
            this.linkLabelDev1Phone.Size = new System.Drawing.Size(280, 20);
            this.linkLabelDev1Phone.TabIndex = 2;
            this.linkLabelDev1Phone.TabStop = true;
            this.linkLabelDev1Phone.Text = "Телефон: +7 (910) 720-71-54";
            this.linkLabelDev1Phone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev1Phone_LinkClicked);
            // 
            // labelDev1Position
            // 
            this.labelDev1Position.AutoSize = false;
            this.labelDev1Position.Location = new System.Drawing.Point(55, 25);
            this.labelDev1Position.Name = "labelDev1Position";
            this.labelDev1Position.Size = new System.Drawing.Size(235, 40);
            this.labelDev1Position.TabIndex = 1;
            this.labelDev1Position.Text = "Должность: Middle App Developer, Product manager, Scrum master";
            // 
            // labelDev1Name
            // 
            this.labelDev1Name.Location = new System.Drawing.Point(55, 5);
            this.labelDev1Name.Name = "labelDev1Name";
            this.labelDev1Name.Size = new System.Drawing.Size(235, 20);
            this.labelDev1Name.TabIndex = 0;
            this.labelDev1Name.Text = "Имя: Гайдин А.Н";
            // 
            // panelDev2
            // 
            this.panelDev2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelDev2.Controls.Add(this.pictureBoxDev2);
            this.panelDev2.Controls.Add(this.linkLabelDev2Email);
            this.panelDev2.Controls.Add(this.linkLabelDev2Phone);
            this.panelDev2.Controls.Add(this.labelDev2Position);
            this.panelDev2.Controls.Add(this.labelDev2Name);
            this.panelDev2.Location = new System.Drawing.Point(12, 240);
            this.panelDev2.Name = "panelDev2";
            this.panelDev2.Size = new System.Drawing.Size(300, 120);
            this.panelDev2.TabIndex = 5;
            // 
            // pictureBoxDev2
            // 
            this.pictureBoxDev2.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxDev2.Name = "pictureBoxDev2";
            this.pictureBoxDev2.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxDev2.TabIndex = 4;
            this.pictureBoxDev2.TabStop = false;
            // 
            // linkLabelDev2Email
            // 
            this.linkLabelDev2Email.Location = new System.Drawing.Point(10, 75);
            this.linkLabelDev2Email.Name = "linkLabelDev2Email";
            this.linkLabelDev2Email.Size = new System.Drawing.Size(280, 20);
            this.linkLabelDev2Email.TabIndex = 3;
            this.linkLabelDev2Email.TabStop = true;
            this.linkLabelDev2Email.Text = "Email: iDK@example.com";
            this.linkLabelDev2Email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev2Email_LinkClicked);
            // 
            // linkLabelDev2Phone
            // 
            this.linkLabelDev2Phone.Location = new System.Drawing.Point(10, 95);
            this.linkLabelDev2Phone.Name = "linkLabelDev2Phone";
            this.linkLabelDev2Phone.Size = new System.Drawing.Size(280, 20);
            this.linkLabelDev2Phone.TabIndex = 2;
            this.linkLabelDev2Phone.TabStop = true;
            this.linkLabelDev2Phone.Text = "Телефон: +8 (800) 555-35-35";
            this.linkLabelDev2Phone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev2Phone_LinkClicked);
            // 
            // labelDev2Position
            // 
            this.labelDev2Position.AutoSize = false;
            this.labelDev2Position.Location = new System.Drawing.Point(55, 25);
            this.labelDev2Position.Name = "labelDev2Position";
            this.labelDev2Position.Size = new System.Drawing.Size(235, 40);
            this.labelDev2Position.TabIndex = 1;
            this.labelDev2Position.Text = "Должность: Senior Frontend Developer, React engineer, Team lead, SEO";
            // 
            // labelDev2Name
            // 
            this.labelDev2Name.Location = new System.Drawing.Point(55, 5);
            this.labelDev2Name.Name = "labelDev2Name";
            this.labelDev2Name.Size = new System.Drawing.Size(235, 20);
            this.labelDev2Name.TabIndex = 0;
            this.labelDev2Name.Text = "Имя: Гриценко Д.А";
            // 
            // panelDev3
            // 
            this.panelDev3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelDev3.Controls.Add(this.pictureBoxDev3);
            this.panelDev3.Controls.Add(this.linkLabelDev3Email);
            this.panelDev3.Controls.Add(this.linkLabelDev3Phone);
            this.panelDev3.Controls.Add(this.labelDev3Position);
            this.panelDev3.Controls.Add(this.labelDev3Name);
            this.panelDev3.Location = new System.Drawing.Point(12, 370);
            this.panelDev3.Name = "panelDev3";
            this.panelDev3.Size = new System.Drawing.Size(300, 120);
            this.panelDev3.TabIndex = 6;
            // 
            // pictureBoxDev3
            // 
            this.pictureBoxDev3.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxDev3.Name = "pictureBoxDev3";
            this.pictureBoxDev3.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxDev3.TabIndex = 4;
            this.pictureBoxDev3.TabStop = false;
            // 
            // linkLabelDev3Email
            // 
            this.linkLabelDev3Email.Location = new System.Drawing.Point(10, 75);
            this.linkLabelDev3Email.Name = "linkLabelDev3Email";
            this.linkLabelDev3Email.Size = new System.Drawing.Size(280, 20);
            this.linkLabelDev3Email.TabIndex = 3;
            this.linkLabelDev3Email.TabStop = true;
            this.linkLabelDev3Email.Text = "Email: sidorov@example.com";
            this.linkLabelDev3Email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev3Email_LinkClicked);
            // 
            // linkLabelDev3Phone
            // 
            this.linkLabelDev3Phone.Location = new System.Drawing.Point(10, 95);
            this.linkLabelDev3Phone.Name = "linkLabelDev3Phone";
            this.linkLabelDev3Phone.Size = new System.Drawing.Size(280, 20);
            this.linkLabelDev3Phone.TabIndex = 2;
            this.linkLabelDev3Phone.TabStop = true;
            this.linkLabelDev3Phone.Text = "Телефон: +7 (123) 456-78-92";
            this.linkLabelDev3Phone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev3Phone_LinkClicked);
            // 
            // labelDev3Position
            // 
            this.labelDev3Position.AutoSize = false;
            this.labelDev3Position.Location = new System.Drawing.Point(55, 25);
            this.labelDev3Position.Name = "labelDev3Position";
            this.labelDev3Position.Size = new System.Drawing.Size(235, 40);
            this.labelDev3Position.TabIndex = 1;
            this.labelDev3Position.Text = "Должность: Фондовый акционер, Тестировщик";
            // 
            // labelDev3Name
            // 
            this.labelDev3Name.Location = new System.Drawing.Point(55, 5);
            this.labelDev3Name.Name = "labelDev3Name";
            this.labelDev3Name.Size = new System.Drawing.Size(235, 20);
            this.labelDev3Name.TabIndex = 0;
            this.labelDev3Name.Text = "Имя: Сидоров С.С.";
            // 
            // DeveloperInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 530);
            this.Controls.Add(this.panelDev3);
            this.Controls.Add(this.panelDev2);
            this.Controls.Add(this.panelDev1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeveloperInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О разработчиках";
            this.Load += new System.EventHandler(this.DeveloperInfo_Load);
            this.panelDev1.ResumeLayout(false);
            this.panelDev2.ResumeLayout(false);
            this.panelDev3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev3)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panelDev1;
        private System.Windows.Forms.Label labelDev1Name;
        private System.Windows.Forms.Label labelDev1Position;
        private System.Windows.Forms.LinkLabel linkLabelDev1Email;
        private System.Windows.Forms.LinkLabel linkLabelDev1Phone;
        private System.Windows.Forms.Panel panelDev2;
        private System.Windows.Forms.Label labelDev2Name;
        private System.Windows.Forms.Label labelDev2Position;
        private System.Windows.Forms.LinkLabel linkLabelDev2Email;
        private System.Windows.Forms.LinkLabel linkLabelDev2Phone;
        private System.Windows.Forms.Panel panelDev3;
        private System.Windows.Forms.Label labelDev3Name;
        private System.Windows.Forms.Label labelDev3Position;
        private System.Windows.Forms.LinkLabel linkLabelDev3Email;
        private System.Windows.Forms.LinkLabel linkLabelDev3Phone;
        private System.Windows.Forms.PictureBox pictureBoxDev1;
        private System.Windows.Forms.PictureBox pictureBoxDev2;
        private System.Windows.Forms.PictureBox pictureBoxDev3;
    }
}
