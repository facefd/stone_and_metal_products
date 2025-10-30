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
            this.labelDev1Name = new System.Windows.Forms.Label();
            this.labelDev1Position = new System.Windows.Forms.Label();
            this.linkLabelDev1Email = new System.Windows.Forms.LinkLabel();
            this.linkLabelDev1Phone = new System.Windows.Forms.LinkLabel();
            this.labelDev2Name = new System.Windows.Forms.Label();
            this.labelDev2Position = new System.Windows.Forms.Label();
            this.linkLabelDev2Email = new System.Windows.Forms.LinkLabel();
            this.linkLabelDev2Phone = new System.Windows.Forms.LinkLabel();
            this.labelDev3Name = new System.Windows.Forms.Label();
            this.labelDev3Position = new System.Windows.Forms.Label();
            this.linkLabelDev3Email = new System.Windows.Forms.LinkLabel();
            this.linkLabelDev3Phone = new System.Windows.Forms.LinkLabel();
            this.panelDev1 = new System.Windows.Forms.Panel();
            this.panelDev2 = new System.Windows.Forms.Panel();
            this.panelDev3 = new System.Windows.Forms.Panel();
            this.pictureBoxDev1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDev2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDev3 = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev3)).BeginInit();
            this.SuspendLayout();

            // === Общие настройки ===
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panelDev3);
            this.Controls.Add(this.panelDev2);
            this.Controls.Add(this.panelDev1);
            this.Name = "DeveloperInfo";
            this.Text = "О разработчиках";
            this.Load += new System.EventHandler(this.DeveloperInfo_Load);

            // === Контролы ===
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Size = new System.Drawing.Size(300, 23);
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Name = "labelTitle";

            this.labelVersion.Location = new System.Drawing.Point(12, 35);
            this.labelVersion.Size = new System.Drawing.Size(300, 23);
            this.labelVersion.Name = "labelVersion";

            this.labelDescription.Location = new System.Drawing.Point(12, 60);
            this.labelDescription.Size = new System.Drawing.Size(500, 23);
            this.labelDescription.Name = "labelDescription";

            // Dev1
            this.panelDev1.Location = new System.Drawing.Point(12, 90);
            this.panelDev1.Size = new System.Drawing.Size(576, 100);
            this.panelDev1.Controls.Add(this.pictureBoxDev1);
            this.panelDev1.Controls.Add(this.labelDev1Name);
            this.panelDev1.Controls.Add(this.labelDev1Position);
            this.panelDev1.Controls.Add(this.linkLabelDev1Email);
            this.panelDev1.Controls.Add(this.linkLabelDev1Phone);
            this.panelDev1.Name = "panelDev1";

            this.pictureBoxDev1.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxDev1.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxDev1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDev1.Name = "pictureBoxDev1";

            this.labelDev1Name.Location = new System.Drawing.Point(80, 10);
            this.labelDev1Name.Size = new System.Drawing.Size(200, 20);
            this.labelDev1Name.Name = "labelDev1Name";

            this.labelDev1Position.Location = new System.Drawing.Point(80, 30);
            this.labelDev1Position.Size = new System.Drawing.Size(300, 20);
            this.labelDev1Position.Name = "labelDev1Position";

            this.linkLabelDev1Email.Location = new System.Drawing.Point(80, 55);
            this.linkLabelDev1Email.Size = new System.Drawing.Size(200, 20);
            this.linkLabelDev1Email.Name = "linkLabelDev1Email";
            this.linkLabelDev1Email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev1Email_LinkClicked);

            this.linkLabelDev1Phone.Location = new System.Drawing.Point(80, 75);
            this.linkLabelDev1Phone.Size = new System.Drawing.Size(200, 20);
            this.linkLabelDev1Phone.Name = "linkLabelDev1Phone";
            this.linkLabelDev1Phone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev1Phone_LinkClicked);

            // Dev2 (аналогично)
            this.panelDev2.Location = new System.Drawing.Point(12, 195);
            this.panelDev2.Size = new System.Drawing.Size(576, 100);
            this.panelDev2.Controls.Add(this.pictureBoxDev2);
            this.panelDev2.Controls.Add(this.labelDev2Name);
            this.panelDev2.Controls.Add(this.labelDev2Position);
            this.panelDev2.Controls.Add(this.linkLabelDev2Email);
            this.panelDev2.Controls.Add(this.linkLabelDev2Phone);
            this.panelDev2.Name = "panelDev2";

            this.pictureBoxDev2.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxDev2.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxDev2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDev2.Name = "pictureBoxDev2";

            this.labelDev2Name.Location = new System.Drawing.Point(80, 10);
            this.labelDev2Name.Size = new System.Drawing.Size(200, 20);
            this.labelDev2Name.Name = "labelDev2Name";

            this.labelDev2Position.Location = new System.Drawing.Point(80, 30);
            this.labelDev2Position.Size = new System.Drawing.Size(300, 20);
            this.labelDev2Position.Name = "labelDev2Position";

            this.linkLabelDev2Email.Location = new System.Drawing.Point(80, 55);
            this.linkLabelDev2Email.Size = new System.Drawing.Size(200, 20);
            this.linkLabelDev2Email.Name = "linkLabelDev2Email";
            this.linkLabelDev2Email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev2Email_LinkClicked);

            this.linkLabelDev2Phone.Location = new System.Drawing.Point(80, 75);
            this.linkLabelDev2Phone.Size = new System.Drawing.Size(200, 20);
            this.linkLabelDev2Phone.Name = "linkLabelDev2Phone";
            this.linkLabelDev2Phone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev2Phone_LinkClicked);

            // Dev3
            this.panelDev3.Location = new System.Drawing.Point(12, 300);
            this.panelDev3.Size = new System.Drawing.Size(576, 100);
            this.panelDev3.Controls.Add(this.pictureBoxDev3);
            this.panelDev3.Controls.Add(this.labelDev3Name);
            this.panelDev3.Controls.Add(this.labelDev3Position);
            this.panelDev3.Controls.Add(this.linkLabelDev3Email);
            this.panelDev3.Controls.Add(this.linkLabelDev3Phone);
            this.panelDev3.Name = "panelDev3";

            this.pictureBoxDev3.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxDev3.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxDev3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDev3.Name = "pictureBoxDev3";

            this.labelDev3Name.Location = new System.Drawing.Point(80, 10);
            this.labelDev3Name.Size = new System.Drawing.Size(200, 20);
            this.labelDev3Name.Name = "labelDev3Name";

            this.labelDev3Position.Location = new System.Drawing.Point(80, 30);
            this.labelDev3Position.Size = new System.Drawing.Size(300, 20);
            this.labelDev3Position.Name = "labelDev3Position";

            this.linkLabelDev3Email.Location = new System.Drawing.Point(80, 55);
            this.linkLabelDev3Email.Size = new System.Drawing.Size(200, 20);
            this.linkLabelDev3Email.Name = "linkLabelDev3Email";
            this.linkLabelDev3Email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev3Email_LinkClicked);

            this.linkLabelDev3Phone.Location = new System.Drawing.Point(80, 75);
            this.linkLabelDev3Phone.Size = new System.Drawing.Size(200, 20);
            this.linkLabelDev3Phone.Name = "linkLabelDev3Phone";
            this.linkLabelDev3Phone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDev3Phone_LinkClicked);

            // OK Button
            this.buttonOK.Location = new System.Drawing.Point(262, 410);
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            this.buttonOK.Name = "buttonOK";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDev3)).EndInit();
            this.ResumeLayout(false);
        }

        // === Объявления ===
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDev1Name;
        private System.Windows.Forms.Label labelDev1Position;
        private System.Windows.Forms.LinkLabel linkLabelDev1Email;
        private System.Windows.Forms.LinkLabel linkLabelDev1Phone;
        private System.Windows.Forms.Label labelDev2Name;
        private System.Windows.Forms.Label labelDev2Position;
        private System.Windows.Forms.LinkLabel linkLabelDev2Email;
        private System.Windows.Forms.LinkLabel linkLabelDev2Phone;
        private System.Windows.Forms.Label labelDev3Name;
        private System.Windows.Forms.Label labelDev3Position;
        private System.Windows.Forms.LinkLabel linkLabelDev3Email;
        private System.Windows.Forms.LinkLabel linkLabelDev3Phone;
        private System.Windows.Forms.Panel panelDev1;
        private System.Windows.Forms.Panel panelDev2;
        private System.Windows.Forms.Panel panelDev3;
        private System.Windows.Forms.PictureBox pictureBoxDev1;
        private System.Windows.Forms.PictureBox pictureBoxDev2;
        private System.Windows.Forms.PictureBox pictureBoxDev3;
        private System.Windows.Forms.Button buttonOK;
    }
}