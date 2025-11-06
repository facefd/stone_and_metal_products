// Reports.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace stone_and_metal
{
    // Только partial — поля и InitializeComponent уже в Reports.Designer.cs
    public partial class Reports : Form
    {
        private DataGridView dataGridViewReports;
        private ComboBox comboBoxReportType;
        private Button buttonGenerateReport;

        public Reports()
        {
            InitializeComponent();
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

        private void Reports_Load(object sender, EventArgs e)
        {

        }
    }
}