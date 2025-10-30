using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class Reports : Form
    {
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