namespace stone_and_metal
{
    partial class Reports
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
            // Reports
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.TextBox textBoxFilterValue;
        private System.Windows.Forms.DataGridView dataGridViewReports;
    }
}