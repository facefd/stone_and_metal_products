// FeedbackEditorForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class FeedbackEditorForm : Form
    {
        public int FeedbackId { get; set; }
        public int OrderId { get; set; }
        public DateTime FeedbackDate { get; set; } = DateTime.Now;
        public string Type { get; set; } = "Благодарность";
        public string Comment { get; set; } = "";

        private DataTable _orders;

        public FeedbackEditorForm()
        {
            InitializeComponent();
        }

        public void SetOrders(DataTable orders)
        {
            _orders = orders;
            comboBoxOrder.DisplayMember = "ClientName";
            comboBoxOrder.ValueMember = "Id";
            comboBoxOrder.DataSource = _orders;
        }

        private void FeedbackEditorForm_Load(object sender, EventArgs e)
        {
            if (OrderId > 0 && _orders != null)
            {
                comboBoxOrder.SelectedValue = OrderId;
            }
            dateTimeFeedback.Value = FeedbackDate;
            comboBoxType.SelectedItem = Type;
            textBoxComment.Text = Comment;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxOrder.SelectedValue == null)
            {
                MessageBox.Show("Выберите заказ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OrderId = Convert.ToInt32(comboBoxOrder.SelectedValue);
            FeedbackDate = dateTimeFeedback.Value;
            Type = comboBoxType.SelectedItem?.ToString() ?? "Благодарность";
            Comment = textBoxComment.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}