// ProductEditorForm.cs
using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class ProductEditorForm : Form
    {
        public string ProductName { get; set; } = "";
        public string Description { get; set; } = "";
        public bool IsProducedNow { get; set; } = true;
        public string Category { get; set; } = "";
        public bool IsEditMode { get; set; } = false;

        public ProductEditorForm()
        {
            InitializeComponent();
        }

        private void ProductEditorForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = ProductName;
            textBoxDesc.Text = Description;
            checkBoxProducedNow.Checked = IsProducedNow;
            textBoxCategory.Text = Category;
            Text = IsEditMode ? "Редактирование изделия" : "Добавление изделия";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Название изделия обязательно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductName = textBoxName.Text;
            Description = textBoxDesc.Text;
            IsProducedNow = checkBoxProducedNow.Checked;
            Category = textBoxCategory.Text;
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