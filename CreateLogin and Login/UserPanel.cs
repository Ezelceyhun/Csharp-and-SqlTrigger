using Microsoft.Data.SqlClient;
using SqlConLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateLogin_and_Login
{
    public partial class UserPanel : Form
    {
        public UserPanel()
        {
            InitializeComponent();
            LoadData();
        }
        SqlCon con = new SqlCon();
        SqlQuery SqlQuery = new SqlQuery();
        ShowUsers showusers = new ShowUsers();
        DataTable dataTable;
        SqlDataAdapter dataAdapter;
        public string conn = "Data Source=CEYHUN\\SQLEXPRESS;Initial Catalog=UserLogin;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string query = "SELECT * FROM UserTable"; 
                dataAdapter = new SqlDataAdapter(query, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        public void UpdateData()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataTable);
        }
        private void button1_Click(object sender, EventArgs e)
        { 

        }
    }
}
