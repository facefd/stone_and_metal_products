// DataForm.Designer.cs — минимальная версия
namespace stone_and_metal
{
    partial class DataForm
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
            this.SuspendLayout();
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "DataForm";
            this.Text = "Данные";
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.ResumeLayout(false);
        }
    }
}