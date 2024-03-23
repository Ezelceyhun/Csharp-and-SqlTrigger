using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqlConLib
{
    public class SqlQuery : SqlCon, InterfaceSql
    {
        public SqlCon con = new SqlCon();
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataTable dt;
        public SqlDependency sd;

        public int id {  get; set; }
        public string name {  get; set; }
        public string email {  get; set; }
        public string password {  get; set; }
        public void Create()
        {          
            con.ConOpen();
            con.con.Open();
            cmd = new SqlCommand("Insert Into UserTable (user_name,user_email,user_password) Values (@user_name,@user_email,@user_password)",con.con);
            cmd.Parameters.AddWithValue("@user_name", name);
            cmd.Parameters.AddWithValue("@user_email", email);
            cmd.Parameters.AddWithValue("@user_password", password);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
        public void Login()
        {
            con.ConOpen();
            con.con.Open();
            cmd = new SqlCommand("Select * From UserTable Where user_email=@user_email AND user_password=@user_password", con.con);
            cmd.Parameters.AddWithValue("@user_email", email);
            cmd.Parameters.AddWithValue("@user_password", password);
            dr = cmd.ExecuteReader();
        }
        public void Update()
        {
            
        }
        
    }
}
