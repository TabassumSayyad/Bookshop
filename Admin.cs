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
    public partial class Admin : Form
    {
        public static string uid = "";
        public static string pwd = "";
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uid = textBox1.Text;
            pwd = textBox2.Text;
            Class1 cs = new Class1();
            int no = cs.login(uid, pwd);
            Books bs = new Books();
            if(no==1)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                bs.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }
        }
    }
}
