using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class AccountingObjects : Form
    {
        public AccountingObjects()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AccountingObjects
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AccountingObjects";
            this.Load += new System.EventHandler(this.AccountingObjects_Load);
            this.ResumeLayout(false);

        }

        private void AccountingObjects_Load(object sender, EventArgs e)
        {

        }
    }
}