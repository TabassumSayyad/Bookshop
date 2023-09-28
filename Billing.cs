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
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            con.Open();
            string str = "select * from Book_Tbl";
            SqlDataAdapter adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
            }
            if (textBox1.Text == "")
            {
                Key = 0;
                stock = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                stock = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
        }
        private void UpdateBook()
        {
            int newQty = stock - Convert.ToInt32(textBox1.Text);
            try
            {
                string str = "Update Book_Tbl set Quantity='" + newQty + "' where Bid ='" + Key + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully");
                con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {

            textBox5.Text = Form1.uid;
        }
        int stock = 0;
        int n = 0;
        int Grdtotal = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text==""||Convert.ToInt32(textBox1.Text)>stock)
            {
                MessageBox.Show("Not enough stock");
            }
            else
            {
                  int total = Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox4.Text);
                  DataGridViewRow newRow = new DataGridViewRow();
                  newRow.CreateCells(dataGridView1);
                  newRow.Cells[0].Value = n + 1;
                  newRow.Cells[1].Value = textBox2.Text;
                  newRow.Cells[2].Value = textBox4.Text;
                  newRow.Cells[3].Value = textBox1.Text;
                  newRow.Cells[4].Value = total;
                  dataGridView1.Rows.Add(newRow);
                  n++;
                  UpdateBook();
                  Grdtotal = Grdtotal + total;
                  label3.Text = "RS"+Grdtotal;
                try
                {
                    string str = "insert into List(Title,Client, Author, Quantity , price ) values('" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                   // MessageBox.Show("Record inserted successfully");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authors au = new Authors();
            au.ShowDialog();
        }
    }
}
