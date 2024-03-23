using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
namespace SqlConLib
{
    public class SqlCon
    {
        public SqlConnection con;
        public void ConOpen()
        {
            con = new SqlConnection("Data Source=CEYHUN\\SQLEXPRESS;Initial Catalog=UserLogin;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");          
        }
    }
}
