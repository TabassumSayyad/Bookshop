using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace BookManagement
{
    class Class2
    {
         SqlConnection con=new SqlConnection("Data Source=TABASSUMSAYYAD\\TABASSUM;Initial Catalog=ConnectionDB;Integrated Security=True");
         SqlDataAdapter adpt;
        /*public int add_data(string name,string uname, string addr,string mob,string pwd)
        {
            string str= "insert into Users values('" +name + "','" + uname + "','" + addr + "','" + mob + "','" + pwd + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            int no = cmd.ExecuteNonQuery();
            return (no);
        }*/
        public DataSet login(string uid, string pwd)
        {
            string str = "select * from Users where uname ='" + uid + "' and pwd='" + pwd + "'";
            adpt = new SqlDataAdapter(str, con);
            //con.Open();
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
        }

        public DataSet all_data()
        {
            string str = "select * from Users";
            adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
        }
        public DataSet all_data1()
        {
            string str = "select * from Book_Tbl";
            adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
        }
        /* public DataSet Filter( string combo)
         {
             string str = "select * from Book_Tbl where Category ='"+combo+"'";
             adpt = new SqlDataAdapter(str, con);
             SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
             DataSet ds = new DataSet();
             adpt.Fill(ds);
             return (ds);
         }*/
        public DataSet all_data2()
        {
            string str = "select * from List";
            adpt = new SqlDataAdapter(str, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adpt);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
        }
    }
}
