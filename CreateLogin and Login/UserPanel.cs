using Microsoft.Data.SqlClient;
using SqlConLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateLogin_and_Login
{
    public partial class UserPanel : Form
    {
        string userChecked = Application.StartupPath.ToString() + "\\userChecked.txt";        
        public UserPanel()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
           
        }

        [DllImport("advapi32.dll", SetLastError = true, EntryPoint = "CredDeleteW", CharSet = CharSet.Unicode)]
        public static extern bool CredDelete(string target, int type, int flags);


        private void button2_Click(object sender, EventArgs e)
        {
            //checked txt içeriğini 0 yaparak otomatik girişi engelliyoruz
            File.WriteAllText(userChecked, string.Empty);
            FileStream fs = new FileStream(userChecked, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("0");
            sw.Flush();
            sw.Close();
            fs.Close();

            // Silinecek kimlik bilgisi adı
            string credentialName = "CreateLogin"; 

            bool result = CredDelete(credentialName, 1, 0); 

            if (result)
            {
                Login loginPanel = new Login();
                loginPanel.Show();
                this.Hide();
                MessageBox.Show("Kimlik bilgisi başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                int errorCode = Marshal.GetLastWin32Error(); // Hata kodunu al
                MessageBox.Show($"Kimlik bilgisi silinirken bir hata oluştu. Hata Kodu: {errorCode}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
