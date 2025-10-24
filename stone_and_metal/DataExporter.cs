using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class DataExporter : Form
    {
        public DataExporter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DataExporter
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "DataExporter";
            this.Load += new System.EventHandler(this.DataExporter_Load);
            this.ResumeLayout(false);

        }

        private void DataExporter_Load(object sender, EventArgs e)
        {

        }
    }
}
