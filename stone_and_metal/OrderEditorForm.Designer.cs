// OrderEditorForm.Designer.cs
namespace stone_and_metal
{
    partial class OrderEditorForm
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
            this.labelProduct = new System.Windows.Forms.Label();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.dateTimeOrderDate = new System.Windows.Forms.DateTimePicker();
            this.labelPlanned = new System.Windows.Forms.Label();
            this.dateTimePlanned = new System.Windows.Forms.DateTimePicker();
            this.labelActual = new System.Windows.Forms.Label();
            this.checkBoxHasActualDate = new System.Windows.Forms.CheckBox();
            this.dateTimeActual = new System.Windows.Forms.DateTimePicker();
            this.labelPrice = new System.Windows.Forms.Label();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIsPaid = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelCancelReason = new System.Windows.Forms.Label();
            this.textBoxCancelReason = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 15);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(51, 13);
            this.labelProduct.TabIndex = 0;
            this.labelProduct.Text = "Изделие:";
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(15, 31);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(300, 21);
            this.comboBoxProduct.TabIndex = 1;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(12, 60);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(46, 13);
            this.labelClient.TabIndex = 2;
            this.labelClient.Text = "Клиент:";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(15, 76);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(300, 20);
            this.textBoxClientName.TabIndex = 3;
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new System.Drawing.Point(12, 105);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(75, 13);
            this.labelOrderDate.TabIndex = 4;
            this.labelOrderDate.Text = "Дата заказа:";
            // 
            // dateTimeOrderDate
            // 
            this.dateTimeOrderDate.Location = new System.Drawing.Point(15, 121);
            this.dateTimeOrderDate.Name = "dateTimeOrderDate";
            this.dateTimeOrderDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimeOrderDate.TabIndex = 5;
            // 
            // labelPlanned
            // 
            this.labelPlanned.AutoSize = true;
            this.labelPlanned.Location = new System.Drawing.Point(12, 150);
            this.labelPlanned.Name = "labelPlanned";
            this.labelPlanned.Size = new System.Drawing.Size(141, 13);
            this.labelPlanned.TabIndex = 6;
            this.labelPlanned.Text = "Плановая дата выполнения:";
            // 
            // dateTimePlanned
            // 
            this.dateTimePlanned.Location = new System.Drawing.Point(15, 166);
            this.dateTimePlanned.Name = "dateTimePlanned";
            this.dateTimePlanned.Size = new System.Drawing.Size(200, 20);
            this.dateTimePlanned.TabIndex = 7;
            // 
            // labelActual
            // 
            this.labelActual.AutoSize = true;
            this.labelActual.Location = new System.Drawing.Point(12, 195);
            this.labelActual.Name = "labelActual";
            this.labelActual.Size = new System.Drawing.Size(147, 13);
            this.labelActual.TabIndex = 8;
            this.labelActual.Text = "Фактическая дата выполнения:";
            // 
            // checkBoxHasActualDate
            // 
            this.checkBoxHasActualDate.AutoSize = true;
            this.checkBoxHasActualDate.Location = new System.Drawing.Point(15, 211);
            this.checkBoxHasActualDate.Name = "checkBoxHasActualDate";
            this.checkBoxHasActualDate.Size = new System.Drawing.Size(143, 17);
            this.checkBoxHasActualDate.TabIndex = 9;
            this.checkBoxHasActualDate.Text = "Выполнен";
            this.checkBoxHasActualDate.UseVisualStyleBackColor = true;
            this.checkBoxHasActualDate.CheckedChanged += new System.EventHandler(this.checkBoxHasActualDate_CheckedChanged);
            // 
            // dateTimeActual
            // 
            this.dateTimeActual.Enabled = false;
            this.dateTimeActual.Location = new System.Drawing.Point(160, 210);
            this.dateTimeActual.Name = "dateTimeActual";
            this.dateTimeActual.Size = new System.Drawing.Size(155, 20);
            this.dateTimeActual.TabIndex = 10;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(12, 240);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(62, 13);
            this.labelPrice.TabIndex = 11;
            this.labelPrice.Text = "Стоимость:";
            // 
            // numericPrice
            // 
            this.numericPrice.DecimalPlaces = 2;
            this.numericPrice.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            this.numericPrice.Location = new System.Drawing.Point(15, 256);
            this.numericPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(120, 20);
            this.numericPrice.TabIndex = 12;
            this.numericPrice.ThousandsSeparator = true;
            // 
            // checkBoxIsPaid
            // 
            this.checkBoxIsPaid.AutoSize = true;
            this.checkBoxIsPaid.Location = new System.Drawing.Point(150, 258);
            this.checkBoxIsPaid.Name = "checkBoxIsPaid";
            this.checkBoxIsPaid.Size = new System.Drawing.Size(67, 17);
            this.checkBoxIsPaid.TabIndex = 13;
            this.checkBoxIsPaid.Text = "Оплачен";
            this.checkBoxIsPaid.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 285);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(44, 13);
            this.labelStatus.TabIndex = 14;
            this.labelStatus.Text = "Статус:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "В работе",
            "Выполнен",
            "Отменён"});
            this.comboBoxStatus.Location = new System.Drawing.Point(15, 301);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(120, 21);
            this.comboBoxStatus.TabIndex = 15;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // labelCancelReason
            // 
            this.labelCancelReason.AutoSize = true;
            this.labelCancelReason.Location = new System.Drawing.Point(145, 285);
            this.labelCancelReason.Name = "labelCancelReason";
            this.labelCancelReason.Size = new System.Drawing.Size(93, 13);
            this.labelCancelReason.TabIndex = 16;
            this.labelCancelReason.Text = "Причина отмены:";
            this.labelCancelReason.Visible = false;
            // 
            // textBoxCancelReason
            // 
            this.textBoxCancelReason.Location = new System.Drawing.Point(148, 301);
            this.textBoxCancelReason.Name = "textBoxCancelReason";
            this.textBoxCancelReason.Size = new System.Drawing.Size(167, 20);
            this.textBoxCancelReason.TabIndex = 17;
            this.textBoxCancelReason.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 340);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrderEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 381);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxCancelReason);
            this.Controls.Add(this.labelCancelReason);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxIsPaid);
            this.Controls.Add(this.numericPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.dateTimeActual);
            this.Controls.Add(this.checkBoxHasActualDate);
            this.Controls.Add(this.labelActual);
            this.Controls.Add(this.dateTimePlanned);
            this.Controls.Add(this.labelPlanned);
            this.Controls.Add(this.dateTimeOrderDate);
            this.Controls.Add(this.labelOrderDate);
            this.Controls.Add(this.textBoxClientName);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.labelProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.OrderEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.DateTimePicker dateTimeOrderDate;
        private System.Windows.Forms.Label labelPlanned;
        private System.Windows.Forms.DateTimePicker dateTimePlanned;
        private System.Windows.Forms.Label labelActual;
        private System.Windows.Forms.CheckBox checkBoxHasActualDate;
        private System.Windows.Forms.DateTimePicker dateTimeActual;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.CheckBox checkBoxIsPaid;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelCancelReason;
        private System.Windows.Forms.TextBox textBoxCancelReason;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}