﻿using Microsoft.Data.SqlClient;
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
            //LoadData();
        }
        SqlCon con = new SqlCon();
        SqlQuery SqlQuery = new SqlQuery();
        ShowUsers showusers = new ShowUsers();
        DataTable dataTable;
        SqlDataAdapter dataAdapter;
        public string conn = "Data Source=CEYHUN\\SQLEXPRESS;Initial Catalog=UserLogin;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        

        //public void LoadData()
        //{
        //    using (SqlConnection connection = new SqlConnection(conn))
        //    {
        //        connection.Open();
        //        string query = "SELECT * FROM UserTable";
        //        dataAdapter = new SqlDataAdapter(query, connection);
        //        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

        //        dataTable = new DataTable();
        //        dataAdapter.Fill(dataTable);

        //        dataGridView1.DataSource = dataTable;
        //    }
        //}

        public void UpdateData()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataTable);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn2 = new SqlConnection(conn);
            if (conn2.State == ConnectionState.Closed)
            {
                conn2.Open();
                string sorgu = "select * from UserTable where user_name= '"+comboBox1.Text+"'";
                SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource= ds;
                int no = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                string add="insert into UserTable (user_name) values ("+textBox1.Text+")'";
                SqlCommand cmd1 = new(add,conn2);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("ekleme yapıldı");
            }
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            SqlConnection conn2 = new SqlConnection(conn);
            if(conn2.State == ConnectionState.Closed)
            {
                conn2.Open();
                string query2 = "Select user_name from UserTable";
                SqlDataAdapter da1 = new(query2,conn2);
                DataSet ds = new();
                da1.Fill(ds);
                for(int i = 0; i <= ds.Tables[0].Rows.Count-1;i++)
                {
                    comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
        }
    }
}
