using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel.Design.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ETS_converter
{
    public partial class Form1 : Form
    {

        Koneksi konn = new Koneksi();

        private SqlCommand cmd;
        private SqlDataReader rd;
        private SqlDataAdapter da;
        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        void MunculMataUang()
        {
            comboBox1.Items.Add("IDR");
            comboBox1.Items.Add("BAHT");
            comboBox1.Items.Add("USD");

            comboBox2.Items.Add("IDR");
            comboBox2.Items.Add("BAHT");
            comboBox2.Items.Add("USD");
        }

        void kondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "IDR";
            comboBox2.Text = "BAHT";
            MunculMataUang();
            MunculData();
        }

        void MunculData()
        {
            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from TBL_KURENSI", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_KURENSI");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_KURENSI";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
             if (textBox1.Text.Trim() == "")
             {
                 MessageBox.Show("MASUKAN NILAI");
             }
             else
             {
                //MessageBox.Show("MASUK NIH");
                 SqlConnection conn = konn.GetConn();
                conn.Open();
                cmd = new SqlCommand("select nilai from TBL_KURENSI where asal='" + comboBox1.Text + "'and tujuan='" + comboBox2.Text + "'", conn);
                textBox2.Text = (Double.Parse(textBox1.Text) * 2).ToString();
                /*
                 int result = (int)cmd.ExecuteScalar();

                 if (result != 0)
                 {
                    textBox2.Text = (result * Double.Parse(textBox1.Text)).ToString();
                    }
                 else
                 {
                     MessageBox.Show("DATA TIDAK ADA!");
                 }
                */
            }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

    }
}