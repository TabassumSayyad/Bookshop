using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace BookManagement
{
    public partial class Registration : Form
    {
       
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
        }
       // public string conString = "Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True";
      
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Missing info");
            }
            else
            {
                    string str = "insert into Users values('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(str,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully");
                    con.Close();
            }
            /*Class2 cs = new Class2();
            int no = cs.add_data(textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text);
            if(no>=1)
            {
                MessageBox.Show("Record added Successfully\nYou can Login now");
            }
            else
            {
                MessageBox.Show("Error Occured");
            }*/
          /*  DataSet ds = new DataSet();
            ds = cs.all_data();
            dataGridView1.DataSource = ds.Tables[0];*/
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String str = textBox3.Text;
            if(str.Length>=1)
            {
                Regex reg = new Regex(@"^[A-Za-z]+$");
                bool bl;
                bl = reg.IsMatch(textBox3.Text);
                if(bl==false)
                {
                    MessageBox.Show("Only Character");
                    textBox3.Text = str.Substring(0, (str.Length - 1));
                }
            }
        }
    }
}
