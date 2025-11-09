// FeedbackEditorForm.Designer.cs
namespace stone_and_metal
{
    partial class FeedbackEditorForm
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
            this.labelOrder = new System.Windows.Forms.Label();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimeFeedback = new System.Windows.Forms.DateTimePicker();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Location = new System.Drawing.Point(12, 15);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(46, 13);
            this.labelOrder.TabIndex = 0;
            this.labelOrder.Text = "Заказ:";
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Location = new System.Drawing.Point(15, 31);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(300, 21);
            this.comboBoxOrder.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(12, 60);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(95, 13);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Дата обращения:";
            // 
            // dateTimeFeedback
            // 
            this.dateTimeFeedback.Location = new System.Drawing.Point(15, 76);
            this.dateTimeFeedback.Name = "dateTimeFeedback";
            this.dateTimeFeedback.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFeedback.TabIndex = 3;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(12, 105);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(71, 13);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "Тип отзыва:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Благодарность",
            "Жалоба"});
            this.comboBoxType.Location = new System.Drawing.Point(15, 121);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxType.TabIndex = 5;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(12, 150);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(77, 13);
            this.labelComment.TabIndex = 6;
            this.labelComment.Text = "Комментарий:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(15, 166);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(300, 60);
            this.textBoxComment.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FeedbackEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 281);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.dateTimeFeedback);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.comboBoxOrder);
            this.Controls.Add(this.labelOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeedbackEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отзыв клиента";
            this.Load += new System.EventHandler(this.FeedbackEditorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.ComboBox comboBoxOrder;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimeFeedback;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}