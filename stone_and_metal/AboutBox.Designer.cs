namespace stone_and_metal
{
    partial class AboutBox
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
            this.labelAuthor = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(90, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 23);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Stone & Metal";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(90, 45);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(200, 23);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Версия 1.0";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(20, 70);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(270, 23);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Программа для учёта изделий из камня и металла.";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(20, 95);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(270, 23);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "© 2025, Разработчики";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(137, 130);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 165);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Button buttonOK;
    }
}