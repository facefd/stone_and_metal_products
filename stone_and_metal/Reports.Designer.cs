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
            this.comboBoxReportType = new System.Windows.Forms.ComboBox();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.textBoxFilterName = new System.Windows.Forms.TextBox();
            this.textBoxFilterValue = new System.Windows.Forms.TextBox();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();

            // comboBoxReportType
            this.comboBoxReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReportType.Items.AddRange(new object[] {
                "Все записи",
                "Сумма по значению (если числовые данные)",
                "Количество по имени",
                "Фильтр по имени",
                "Фильтр по значению"
            });
            this.comboBoxReportType.Location = new System.Drawing.Point(12, 12);
            this.comboBoxReportType.Name = "comboBoxReportType";
            this.comboBoxReportType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxReportType.TabIndex = 0;
            this.comboBoxReportType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReportType_SelectedIndexChanged);

            // buttonGenerateReport
            this.buttonGenerateReport.Location = new System.Drawing.Point(220, 12);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(100, 23);
            this.buttonGenerateReport.TabIndex = 1;
            this.buttonGenerateReport.Text = "Сформировать";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.ButtonGenerateReport_Click);

            // textBoxFilterName
            this.textBoxFilterName.Location = new System.Drawing.Point(330, 12);
            this.textBoxFilterName.Name = "textBoxFilterName";
            this.textBoxFilterName.Size = new System.Drawing.Size(150, 20);
            this.textBoxFilterName.TabIndex = 2;
            this.textBoxFilterName.Text = "Имя...";
            this.textBoxFilterName.Visible = false;
            this.textBoxFilterName.Enter += new System.EventHandler(this.textBoxFilterName_Enter);
            this.textBoxFilterName.Leave += new System.EventHandler(this.textBoxFilterName_Leave);

            // textBoxFilterValue
            this.textBoxFilterValue.Location = new System.Drawing.Point(490, 12);
            this.textBoxFilterValue.Name = "textBoxFilterValue";
            this.textBoxFilterValue.Size = new System.Drawing.Size(150, 20);
            this.textBoxFilterValue.TabIndex = 3;
            this.textBoxFilterValue.Text = "Значение...";
            this.textBoxFilterValue.Visible = false;
            this.textBoxFilterValue.Enter += new System.EventHandler(this.textBoxFilterValue_Enter);
            this.textBoxFilterValue.Leave += new System.EventHandler(this.textBoxFilterValue_Leave);

            // dataGridViewReports
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.AllowUserToDeleteRows = false;
            this.dataGridViewReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReports.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.Size = new System.Drawing.Size(860, 500);
            this.dataGridViewReports.TabIndex = 4;

            // Reports
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.comboBoxReportType);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.textBoxFilterName);
            this.Controls.Add(this.textBoxFilterValue);
            this.Controls.Add(this.dataGridViewReports);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчёты";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.TextBox textBoxFilterValue;
        private System.Windows.Forms.DataGridView dataGridViewReports;
    }
}