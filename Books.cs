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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
        int Key = 0;
        private void populate()
        {
            con.Open();
            string str = "select * from Book_Tbl";
            SqlDataAdapter adpt = new SqlDataAdapter(str,con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Books_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""|| comboBox1.Text=="" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    string str = "insert into Book_Tbl values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully");
                    con.Close();
                    populate();
                    Reset();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            Class2 cs = new Class2();
            DataSet ds = new DataSet();
            ds = cs.all_data1();
            dataGridView2.DataSource = ds.Tables[0];
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            con.Open();
            string str = "select * from Book_Tbl where Category ='" + comboBox2.SelectedItem.ToString()+ "'";
            SqlDataAdapter adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
      
        }
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex=-1;
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" )
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    con.Open();
                    string str = "delete from Book_Tbl where Bid='" + Key + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted successfully");
                    con.Close();
                    populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                try
                {
                    string str = "Update Book_Tbl set Title='" + textBox1.Text + "',Author='" + textBox2.Text + "',Category='" + comboBox1.SelectedItem.ToString() + "',Quantity='" + textBox3.Text + "',Price='" + textBox4.Text + "' where Bid ='"+Key+"'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfully");
                    con.Close();
                    populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
      
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                comboBox1.SelectedItem = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
            }
            if (textBox1.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total_Sell ts = new Total_Sell();
            ts.ShowDialog();
        }
    }
}
