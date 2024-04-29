using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace vecokenska_aplikacija
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.DataGridViewReference = dataGridView1;
            form2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.DataGridViewReference = dataGridView1;
            form2.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.CurrentCell.RowIndex;


            if (dataGridView1.Rows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Želite izbrisati ta vnos?", "Izbris", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.DataGridViewReference = dataGridView1;
            form3.Show();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataToXml("data.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromXml("data.xml");
        }

        [Serializable]
        public class RowData
        {
            public string Lastnost1 { get; set; }
            public string Lastnost2 { get; set; }
            public string Lastnost3 { get; set; }
            public string Lastnost4 { get; set; }
        }


        private void SaveDataToXml(string fileName)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                List<RowData> dataList = new List<RowData>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    RowData data = new RowData
                    {
                        Lastnost1 = row.Cells["Column1"].Value?.ToString(),
                        Lastnost2 = row.Cells["Column2"].Value?.ToString(),
                        Lastnost3 = row.Cells["Column3"].Value?.ToString(),
                        Lastnost4 = row.Cells["Column4"].Value?.ToString()
                    };
                    dataList.Add(data);
                }


                XmlSerializer serializer = new XmlSerializer(typeof(List<RowData>));
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, dataList);
                }
                MessageBox.Show("Podatki so se uspešno shranili.");
            }
            else
            {
                MessageBox.Show("Podatki se niso uspešno shranili.");
            }
        }

        private void LoadDataFromXml(string fileName)
        {
            if (File.Exists(fileName))
            {

                {

                    XmlSerializer serializer = new XmlSerializer(typeof(List<RowData>));
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        List<RowData> dataList = (List<RowData>)serializer.Deserialize(reader);


                        dataGridView1.Rows.Clear();


                        foreach (RowData data in dataList)
                        {
                            dataGridView1.Rows.Add(data.Lastnost1, data.Lastnost2, data.Lastnost3, data.Lastnost4);
                        }
                    }
                }
            }


        }
    }

}




