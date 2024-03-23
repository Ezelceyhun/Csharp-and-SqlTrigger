using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using SqlConLib;
namespace CreateLogin_and_Login
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        SqlCon Con = new();
        SqlQuery SqlQuery = new SqlQuery();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Con.ConOpen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUser next = new CreateUser();
            this.Hide();
            next.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlQuery.email = textBox1.Text;
            SqlQuery.password = textBox2.Text;
            SqlQuery.Login();
            if(SqlQuery.dr.Read())
            {
                UserPanel userPanel = new UserPanel();
                userPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanýcý Adý veya Þifre Hatalý!");
            }
        }
    }
}
