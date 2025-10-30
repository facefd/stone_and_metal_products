// DataForm.cs
using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxValue.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper.SaveData(textBoxName.Text, textBoxValue.Text);
            RefreshDataGrid();

            textBoxName.Clear();
            textBoxValue.Clear();
        }

        private void RefreshDataGrid()
        {
            var data = DatabaseHelper.GetData();
            dataGridView1.DataSource = data;
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            var data = DatabaseHelper.GetData(comboBoxSort.SelectedItem?.ToString() ?? "Timestamp");
            dataGridView1.DataSource = data;
        }
    }
}