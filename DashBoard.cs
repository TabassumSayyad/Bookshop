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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users us = new Users();
            us.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
        SqlConnection con = new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
        private void DashBoard_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(Quantity) from Book_Tbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label10.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Price) from Book_Tbl", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            label11.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(ID) from Users", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            label12.Text = dt2.Rows[0][0].ToString();

            con.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Sell ts = new Total_Sell();
            ts.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
