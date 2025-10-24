namespace stone_and_metal
{
    partial class HelpForm
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
            this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxHelp
            // 
            this.richTextBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxHelp.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxHelp.Name = "richTextBoxHelp";
            this.richTextBoxHelp.Size = new System.Drawing.Size(600, 400);
            this.richTextBoxHelp.TabIndex = 0;
            this.richTextBoxHelp.Text = "";
            this.richTextBoxHelp.TextChanged += new System.EventHandler(this.richTextBoxHelp_TextChanged);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.richTextBoxHelp);
            this.Name = "HelpForm";
            this.Text = "Справка";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.RichTextBox richTextBoxHelp;
    }
}