using SqlConLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CreateLogin_and_Login
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }
        SqlCon Con = new SqlCon();
        SqlQuery SqlQuery = new SqlQuery();
        Login NextAgain = new Login();
        

        private void button2_Click(object sender, EventArgs e)
        {
            NextAgain.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlQuery.name = textBox1.Text;
            SqlQuery.email = textBox2.Text;
            SqlQuery.password = textBox3.Text;
            SqlQuery.Create();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            Con.ConOpen();
        }
    }
}
