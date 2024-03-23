using Microsoft.Data.SqlClient;
using SqlConLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateLogin_and_Login
{
    public class ShowUsers : SqlQuery
    {
        public BindingSource bs = new BindingSource();
        public void ShowUser()
        {
            con.ConOpen();
            con.con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From UserTable", con.con);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);           
            bs.DataSource = dt1;
            con.con.Close();
        }
    }
}
