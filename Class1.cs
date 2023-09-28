using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BookManagement
{
    class Class1
    {
        public int login(string uid, string pwd)
        {
            if(uid=="RIT" && pwd=="123")
            {
                return (1);
            }
            else
            {
                return (0);
            }
        }
    }
}
