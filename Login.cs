using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Form1 : Form
    {
        public static string uid = "";
        public static string pwd = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = System.DateTime.Now.ToString("dddd,dd/MM/yyyy");
        }

       private void button1_Click(object sender, EventArgs e)
        {
            uid = textBox1.Text;
            pwd = textBox2.Text;
            Class2 cs= new Class2();
            DataSet ds = new DataSet();
            ds = cs.login(uid, pwd);
            if(ds.Tables[0].Rows.Count>=1)
            {
                uid = textBox1.Text;
                MessageBox.Show("Login Successful");
                this.Hide();
                Billing bl = new Billing();
                bl.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login unsucccessful");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration re = new Registration();
            re.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

