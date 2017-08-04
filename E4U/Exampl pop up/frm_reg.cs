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
using System.Data.SqlClient;


namespace Exampl_pop_up
{
    public partial class frm_reg : Form
    {
        public static string name;

        public frm_reg()
        {
            InitializeComponent();
        }

        private void frm_reg_Load(object sender, EventArgs e)
        {
            //txt_UserName.Focused = false;
           // this.ActiveControl = btn_reg;
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            string con_str = @"Data Source=E4U_liteDB.db; Version = 3;";
            //SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Локальный диск Е\Exampl pop up\Exampl pop up\E4U.mdf;Integrated Security=True");
            //SqlDataAdapter cmd = new SqlDataAdapter();


            if (txt_UserName.Text != "")
            {
                
                    m_dbConnection = new SQLiteConnection(con_str);
                    m_dbConnection.Open();
                    //cn.Open();
                    string login = txt_UserName.Text;
                    name = txt_UserName.Text;
                    string date = Convert.ToString(DateTime.Today);
                    //string sql = "INSERT INTO [TABLE](Id, Login, Password) VALUES (NULL,'" + txt_UserName.Text + "','" + txt_Password.Text + "')";
                    string sql1 = "INSERT INTO profile_data(Login,Reg_date, Categories, TimeIn) VALUES ('" + txt_UserName.Text + "','" + date +"', '', '00:00:00')";
                    //SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    //command.ExecuteNonQuery();
                    SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
                    command1.ExecuteNonQuery();
                    m_dbConnection.Close();
                //SQLiteDataReader reader = command.ExecuteReader();
                //cmd.InsertCommand = new SqlCommand("INSERT INTO [TABLE] VALUES ('" + txt_UserName.Text + "','" + txt_Password.Text + "')");
                //cmd.InsertCommand.Connection = cn;
                //cmd.InsertCommand.ExecuteNonQuery();
                //cn.Close();

                Form0 frm0 = new Form0(frm_reg.name);
                frm0.Show();
                this.Hide();




            }
                
            }

    }
}
