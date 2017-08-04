using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Exampl_pop_up
{
   
    public partial class frm_login : Form
    {
        public static string login;
        public static string password;
        
        


        /* SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Локальный диск Е\Exampl pop up\Exampl pop up\E4U.mdf;Integrated Security=True");
         SqlDataAdapter cmd = new SqlDataAdapter();
         SqlDataReader reader;*/

        public frm_login()
        {
            InitializeComponent();
       
        }


        private void btn_Submit_Click(object sender, EventArgs e)
        {
            /* if (txt_UserName.Text != "" && txt_Password.Text != "")
             {
                 SQLiteConnection m_dbConnection;
                 string con_str = @"Data Source=E4U_liteDB.db; Version = 3;";
                 m_dbConnection = new SQLiteConnection(con_str);
                 m_dbConnection.Open();
                 login = txt_UserName.Text;
                 password = txt_Password.Text;
                 string sql = "SELECT Login, Password FROM [TABLE] WHERE Login = '" + login + "' AND Password = '" + password + "'";
                 SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                 SQLiteDataReader reader = command.ExecuteReader();
                 if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         this.Hide();
                         var frm = new Form0(login + ", welcome to English 4 You! ");
                         frm.Show();
                     }

                 }
                 else
                 {
                     MessageBox.Show("Неверный логин/пароль");
                 }

                 reader.Close();
                 m_dbConnection.Close();
                 //cn.Open();

                   //cmd.InsertCommand = new SqlCommand("INSERT INTO [TABLE](Login,Password) VALUES ('" + txt_UserName.Text + "','" + txt_Password.Text + "')");
                 //  cmd.InsertCommand = new SqlCommand("SELECT Login, Password FROM [TABLE] WHERE Login = '"+login+ "' AND Password = '" + password + "'");
                   //  cmd.InsertCommand.ExecuteNonQuery();
                   /*cmd.InsertCommand.Connection = cn;

                   reader = cmd.InsertCommand.ExecuteReader();
                   if (reader.HasRows)
                   {
                       while (reader.Read())
                       {
                               this.Hide();
                               var frm = new Form0(login + ", welcome to English 4 You! ");
                               frm.Show();    

                           //Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                           //  reader.GetString(1));
                       }
                   }
                   else
                   {
                       MessageBox.Show("Неверный логин/пароль");
                   }

                   reader.Close();
                   cn.Close();



                   //cmd.InsertCommand.Connection = cn;
                   //cmd.InsertCommand.ExecuteNonQuery();
                   //cmd.Clone();
                   // MessageBox.Show(reader.ToString());


             }
             */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_reg form = new frm_reg();
            form.Show();
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form0 form0 = new Form0(frm_reg.name);
            form0.Show();
            this.Hide();
        }
    }
}

//Connection String
// string cs = @"Data Source=DESKTOP-KJM6DTV;AttachDbFilename=|DataDirectory|\@E4U_DB.mdf;Integrated Security=True;";
//btn_Submit Click event

/*using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Exampl_pop_up.Properties.Settings.E4U_DBConnectionString"].ConnectionString))
            {
                var cmd = new SqlCommand("insert into Tables (Id,Some) values (@Id,@Some)", conn);
                //cmd.Parameters.AddWithValue("@Id", 1);
                //cmd.Parameters.AddWithValue("@UserName", "Serh");
                cmd.Parameters.AddWithValue("@Some", "2e32ewe");
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Exampl_pop_up.Properties.Settings.E4U_DBConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into qwer (Id,field) VALUES (@Id,@field)";
                    command.Parameters.AddWithValue("@Id", 1);
                    command.Parameters.AddWithValue("@field", 3234);

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }



            /* try
             {
                 //Create SqlConnection
                 SqlConnection con = new SqlConnection(cs);
                 SqlCommand cmd = new SqlCommand("Select * from tblLogin where UserName=@username and Password=@password", con);
                 cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                 cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                 con.Open();
                 SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 adapt.Fill(ds);
                 con.Close();
                 int count = ds.Tables[0].Rows.Count;
                 //If count is equal to 1, than show frmMain form
                 if (count == 1)
                 {
                     MessageBox.Show("Login Successful!");
                     this.Hide();
                     Form0 fm = new Form0();
                     fm.Show();
                 }
                 else
                 {
                     MessageBox.Show("Login Failed!");
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             */
