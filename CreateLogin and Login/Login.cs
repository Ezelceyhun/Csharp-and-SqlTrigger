using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using SqlConLib;
using System.Runtime.InteropServices;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Fabric;
using static CreateLogin_and_Login.Login;
using System.Drawing;
using System.Net;
using System.Text;
namespace CreateLogin_and_Login
{
    public partial class Login : Form
    {
        /// <txtDosyalarý>
        /// kullanýcý mail ve þifreyi kaydedilen txt dosyalarý import
        string path = Application.StartupPath.ToString() + "\\userLoad.txt";
        string passPath = Application.StartupPath.ToString() + "\\userLoadPass.txt";
        string userChecked = Application.StartupPath.ToString() + "\\userChecked.txt";
        /// </txtDosyalarý>
        
        //public deðiþkenler:
        public Credential credential;
        public string sqlPass;
        public string sqlMail;
        SqlCon Con = new();
        SqlQuery SqlQuery = new SqlQuery();
        public string credentialUserName;
        public string credentialPassword;

        ///<txtDosya>   
        ///txt dosylarýna bilgilerin yazýldýðý metot
        void DosyaYaz()
        {       

            //userLoad.txt
            File.WriteAllText(path, string.Empty);                       
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(textBox1.Text);
            sw.Flush();
            sw.Close();
            fs.Close();

            //userLoadPass.txt
            File.WriteAllText(passPath, string.Empty);
            FileStream fsPass = new FileStream(passPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter swPass = new StreamWriter(fsPass);
            swPass.WriteLine(textBox2.Text);
            swPass.Flush();
            swPass.Close();
            fsPass.Close();
        }
        ///</txtDosya>
      
        ///<txtOku>
        ///txt içindeki kullanýcý mailini textbox'a yaz
        void DosyaOku()
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while(yazi != null)
            {
                textBox1.Text = yazi;
            }
            sw.Close();
            fs.Close();
        }
        ///</txtOku>

        /// <txtSil>
        /// txt içeriðini sil
        void DosyaSil()
        {
            File.WriteAllText(path, string.Empty);
        }
        /// </txtSil>


        ///<Credential>
        ///Credential için gerekli kodlar
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool CredWrite(ref Credential userCredential, uint flags);
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool CredRead(string target, CredentialType type, int reservedFlag, out IntPtr CredentialPtr);
        [DllImport("advapi32.dll")]
        public static extern bool CredFree(IntPtr buffer);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

        public struct Credential
        {
            public UInt32 Flags;
            public CredentialType Type;
            public string TargetName;
            public string Comment;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
            public UInt32 CredentialBlobSize;
            public string CredentialBlob;
            public UInt32 Persist;
            public UInt32 AttributeCount;
            public IntPtr Attributes;
            public string TargetAlias;
            public string UserName;
        }

        public enum CredentialType : uint
        {
            Generic = 1,
            DomainPassword,
            DomainCertificate,
            DomainVisiblePassword,
            GenericCertificate,
            DomainExtended,
            Maximum,
            MaximumEx = Maximum + 1000,
        }
        ///</Credential> 
    
        ///Credential kaydý ve sql kontrolü
        public void LoginCheck()
        {
            SqlQuery.email = textBox1.Text;
            SqlQuery.password = textBox2.Text;
            SqlQuery.Login();
            if (SqlQuery.dr.Read())
            {
                if (RememberMe && !string.IsNullOrEmpty(SqlQuery.email) && !string.IsNullOrEmpty(SqlQuery.password))
                {
                    credential = new Credential
                    {
                        TargetName = "CreateLogin",
                        Type = CredentialType.Generic,
                        UserName = SqlQuery.email,
                        CredentialBlob = SqlQuery.password,
                        Persist = 1
                    };

                    if (!CredWrite(ref credential, 0))
                    {
                        MessageBox.Show("kaydedilemedi");
                    }
                }

                File.WriteAllText(userChecked, string.Empty);
                FileStream fs = new FileStream(userChecked, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("1");
                sw.Flush();
                sw.Close();
                fs.Close();

                UserPanel userPanel = new UserPanel();
                userPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanýcý Adý veya Þifre Hatalý!");
            }
        }

        //otomatik giriþ metotu
        void LoadControl()
        {
            FileStream fsPass = new FileStream(passPath, FileMode.Open, FileAccess.Read);
            StreamReader swPass = new StreamReader(fsPass);

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);

            var userName = sw.ReadLine();
            var userPass = swPass.ReadLine();

            string con = "Data Source=CEYHUN\\SQLEXPRESS;Initial Catalog=UserLogin;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string query = "select user_password, user_email from UserTable where user_email='" + userName + "'";

            using (SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            sqlPass = reader.GetString(0);
                            sqlMail = reader.GetString(1);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }





            

            








            if (userPass == sqlPass) //txt ve sqlde ki þifreleri karþýlaþtýrma
            {
                if (userName == sqlMail) //txt ve sqlde ki e-mailleri karþýlaþtýrma
                {
                    if (userName == credentialUserName) //kimlik ve txt kullanýcý adý karþýlaþtýrma
                    {
                        if(credentialPassword == userPass) //credential þifre ve txt þifre karþýlaþtýrma
                        {
                            //LoadCredentials();
                            UserPanel userPanel = new UserPanel();
                            userPanel.Show();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("PC ve txt Karþýlaþtýrma Hatasý! (Credential/TXT E-Mail)");
                    }
                }
                else
                {
                    MessageBox.Show("PC ve Sql Karþýlaþtýrma Hatasý! (SQL/TXT E-Mail)");
                }
            }
            else
            {
                MessageBox.Show("PC ve Sql Karþýlaþtýrma Hatasý! (SQL/TXT PASSWORD)");
            }
            fs.Close();
            sw.Close();
            fsPass.Close();
            swPass.Close();
        }
        void formGecis()
        {
            CreateUser next = new CreateUser();
            this.Hide();
            next.Show();
        }

        public Login()
        {
            InitializeComponent();
    
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(userChecked, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);

            string checkedUser = sw.ReadLine();

            fs.Close();
            sw.Close();

            if(checkedUser == "1")
            {
                Con.ConOpen();
                LoadCredentials();
                LoadControl();
               
            }
          

            //beni hatýrla özelliði checked ise otomatik doldur ve giriþ yap
        }       

        void LoadCredentials()
        {

            IntPtr credPointer;
            if(CredRead("CreateLogin", CredentialType.Generic, 0, out credPointer))
            {
                Credential credential = (Credential)Marshal.PtrToStructure(credPointer, typeof(Credential));
                credentialUserName = credential.UserName;
                textBox1.Text = credentialUserName;
                //textBox2.Text = credential.CredentialBlob;

                credentialPassword = credential.CredentialBlob;

                checkBox1.Checked = true;
                CredFree(credPointer);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formGecis();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DosyaYaz();
            LoginCheck();
        }
        private bool RememberMe
        {
            get { return checkBox1.Checked; }
        }
    }
}
