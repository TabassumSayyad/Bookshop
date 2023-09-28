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
    public partial class Authors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
        public Authors()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string str = "select Author,Title,Category from Book_Tbl where Author='"+textBox1.Text+"'";
            SqlDataAdapter adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing bl = new Billing();
            bl.ShowDialog();
        }
    }
}
