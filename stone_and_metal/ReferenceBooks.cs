using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class ReferenceBooks : Form
    {
        public ReferenceBooks()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ReferenceBooks
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ReferenceBooks";
            this.Load += new System.EventHandler(this.ReferenceBooks_Load);
            this.ResumeLayout(false);

        }

        private void ReferenceBooks_Load(object sender, EventArgs e)
        {

        }
    }
}