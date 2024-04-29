using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vecokenska_aplikacija
{
    public partial class Form2 : Form
    {
        private DataGridView dataGridView1;
        public DataGridView DataGridViewReference
        {
            get { return dataGridView1; }
            set
            {
                dataGridView1 = value; // Assign the provided DataGridView to dataGridView1
                if (dataGridView1 != null)
                {
                    dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
                }
            }
        }

        public Form2()
        {

            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {

                DataGridViewReference.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            }

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Update the text boxes with data from the selected row
            if (DataGridViewReference.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DataGridViewReference.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["Column1"].Value?.ToString();
                textBox2.Text = selectedRow.Cells["Column2"].Value?.ToString();
                textBox3.Text = selectedRow.Cells["Column3"].Value?.ToString();
                textBox4.Text = selectedRow.Cells["Column4"].Value?.ToString();
            }
        }

        private bool ValidateTextBoxes()
        {
            bool isValid = true;

            if (ContainsDigits(textBox1.Text))
            {
                MessageBox.Show("Vnesli ste številko v stolpec Znamka.", "NAPAKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            if (ContainsDigits(textBox2.Text))
            {
                MessageBox.Show("Vnesli ste številko v stolpec Model.", "NAPAKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            if (!IsValidNumber(textBox3.Text, maxDigits: 4))
            {
                MessageBox.Show("Vnesli ste črke ali pa premajhno/previsoko letnico v stolpec Letnik.", "NAPAKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            if (!IsValidNumber(textBox4.Text, maxDigits: 7))
            {
                MessageBox.Show("Dovoljeno je največ do 7 številčnega števila oz. vnesli ste črke v stolpec Cena.", "NAPAKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Prosim vnesi vse podatke v polja.", "NAPAKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return isValid;
        }
        private bool ContainsDigits(string input)
        {

            string pattern = @"\d";


            return Regex.IsMatch(input, pattern);
        }
        private bool IsValidNumber(string input, int maxDigits)
        {

            if (!int.TryParse(input, out int number))
            {
                return false;
            }


            return input.Length <= maxDigits;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                if (DataGridViewReference.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DataGridViewReference.SelectedRows[0];

                    selectedRow.Cells[0].Value = textBox1.Text;
                    selectedRow.Cells[1].Value = textBox2.Text;
                    selectedRow.Cells[2].Value = textBox3.Text;
                    selectedRow.Cells[3].Value = textBox4.Text;

                    MessageBox.Show("Spremembe so bile uspešno shranjene.", "Obvestilo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Prosimo izberite vrstico, ki jo želite urediti.", "NAPAKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}


