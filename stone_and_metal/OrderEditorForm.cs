// OrderEditorForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class OrderEditorForm : Form
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ClientName { get; set; } = "";
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime PlannedCompletionDate { get; set; } = DateTime.Now.AddDays(7);
        public DateTime? ActualCompletionDate { get; set; } = null;
        public decimal TotalPrice { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
        public string Status { get; set; } = "В работе";
        public string CancelReason { get; set; } = "";

        private DataTable _products;

        public OrderEditorForm()
        {
            InitializeComponent();
        }

        public void SetProducts(DataTable products)
        {
            _products = products;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";
            comboBoxProduct.DataSource = _products;
        }

        private void OrderEditorForm_Load(object sender, EventArgs e)
        {
            if (ProductId > 0 && _products != null)
            {
                comboBoxProduct.SelectedValue = ProductId;
            }
            textBoxClientName.Text = ClientName;
            dateTimeOrderDate.Value = OrderDate;
            dateTimePlanned.Value = PlannedCompletionDate;
            checkBoxIsPaid.Checked = IsPaid;
            comboBoxStatus.SelectedItem = Status;
            textBoxCancelReason.Text = CancelReason;
            if (ActualCompletionDate.HasValue)
            {
                checkBoxHasActualDate.Checked = true;
                dateTimeActual.Value = ActualCompletionDate.Value;
            }

            UpdateCancelReasonVisibility();
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCancelReasonVisibility();
        }

        private void UpdateCancelReasonVisibility()
        {
            bool show = (comboBoxStatus.SelectedItem?.ToString() == "Отменён");
            labelCancelReason.Visible = show;
            textBoxCancelReason.Visible = show;
        }

        private void checkBoxHasActualDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeActual.Enabled = checkBoxHasActualDate.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            ClientName = textBoxClientName.Text;
            OrderDate = dateTimeOrderDate.Value;
            PlannedCompletionDate = dateTimePlanned.Value;
            ActualCompletionDate = checkBoxHasActualDate.Checked ? dateTimeActual.Value : (DateTime?)null;
            TotalPrice = numericPrice.Value;
            IsPaid = checkBoxIsPaid.Checked;
            Status = comboBoxStatus.SelectedItem?.ToString() ?? "В работе";
            CancelReason = textBoxCancelReason.Text;

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