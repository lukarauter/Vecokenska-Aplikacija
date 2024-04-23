using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vecokenska_aplikacija
{
    public partial class Form3 : Form
    {
        public DataGridView DataGridViewReference { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Access Form1 to get data
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault(); // Find Form1 instance
            if (form1 != null)
            {
                DataGridView dataGridView1 = form1.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;
                if (dataGridView1 != null)
                {
                    double sum = 0;
                    int count = 0;

                    // Iterate over rows and calculate sum
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[3].Value != null && double.TryParse(row.Cells[3].Value.ToString(), out double value))
                        {
                            sum += value;
                            count++;
                        }
                    }

                    // Calculate average sum
                    double average = count > 0 ? sum / count : 0;

                    // Display the average sum in TextBox in Form3
                    textBox1.Text = average.ToString();
                }
                else
                {
                    MessageBox.Show("DataGridView1 not found in Form1.");
                }
            }
            else
            {
                MessageBox.Show("Form1 not found.");
            }
        }

    }
}
