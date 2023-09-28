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
namespace BookManagement
{
    public partial class Total_Sell : Form
    {
        public Total_Sell()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
        private void Total_Sell_Load(object sender, EventArgs e)
        {
            Class2 cs = new Class2();
            DataSet ds = new DataSet();
            ds = cs.all_data2();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Books bs = new Books();
            bs.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users us = new Users();
            us.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard db = new DashBoard();
            db.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            con.Open();
            string str = "select * from List where IssueDate ='" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+ "'";
            SqlDataAdapter adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
