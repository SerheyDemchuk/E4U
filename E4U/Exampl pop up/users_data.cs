using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exampl_pop_up.Properties;

namespace Exampl_pop_up
{
    public partial class users_data : Form
    {
        public Form RefToForm0 { get; set; }
        public static bool isfirst = true;
        public static int count = 0;
        public static string timee;
        DateTime dt;
        public static List<string> category_list = new List<string>();
        

        //  private TimeSpan time = new TimeSpan();

        public users_data()
        {
            InitializeComponent();

        }


        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = dt.AddSeconds(i).ToString("HH");
            label12.Text = dt.AddSeconds(i).ToString("mm");
            i++;
            if (label12.Text.Equals("59"))
            {
                label12.Left = 267;
                label11.Left = 288;
                label8.Left = 236;
                label6.Left = 216;
                label6.Visible = true;
                label8.Visible = true;
            }
            if (label6.Text.Equals("23"))
            {
                label12.Left = 293;
                label11.Left = 314;
                label8.Left = 260;
                label6.Left = 240;
                label4.Left = 211;
                label2.Left = 190;
                label2.Visible = true;
                label4.Visible = true;
                label6.Visible = true;
                label8.Visible = true;
            }

            if (label6.Text.Equals("00") && label12.Text.Equals("00"))
            {
                //label2.Text = Convert.ToString(Form0.Days);
            }

        }

        private void users_data_Load(object sender, EventArgs e)
        {
            //textBox1.BorderStyle = ;
            //string cat = Form1.category;
            //category_list.Add(cat);
            //category_list.Insert(count, Form1.category);
            //  count++;
            //List<string> distinctList = category_list.Distinct().ToList();
            //var distinctList = category_list.Distinct().ToList();
            label2.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            dt = Convert.ToDateTime(Form0.timeIn);
            label6.Text = dt.ToString("HH");
            label12.Text = dt.ToString("mm");
            if (label6.Text != "00" || label12.Text == "59")
            {
                label12.Left = 267;
                label11.Left = 288;
                label8.Left = 236;
                label6.Left = 216;
                label6.Visible = true;
                label8.Visible = true;
            }

            timer1.Enabled = true;
            label1.Text = Settings.Default["Name"].ToString();

            string con_str = @"Data Source=E4U_liteDB.db; Version = 3;";

            using (var m_dbConnection = new SQLiteConnection(con_str))
            {
                m_dbConnection.Open();
                string sql = "SELECT Reg_date FROM profile_data WHERE Login = '" + Settings.Default["Name"].ToString() + "' ";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader.GetString(0));
                    label5.Text = date.ToString("dd/MM/yyyy");
                }
            }

            using (var m_dbConnection1 = new SQLiteConnection(con_str))
            {
                if (category_list.Count == 0)
                {
                    m_dbConnection1.Open();
                    string sql1 = "SELECT Categories FROM profile_data WHERE Login = '" + Settings.Default["Name"].ToString() + "' ";
                    SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection1);
                    SQLiteDataReader reader1 = command1.ExecuteReader();
                    //   if (reader1.ToString() == "")
                    //  {
                    while (reader1.Read())
                    {
                        if (reader1.GetString(0) == "")
                            textBox1.Text = "Пока что категорий нет";
                        else
                        {

                            string str = reader1.GetString(0);
                            category_list = str.Split(',').ToList();
                            var cat_var = category_list.GroupBy(x => x)
                        .Select(g => new { Value = g.Key, Count = g.Count() })
                        .OrderByDescending(x => x.Count);
                            List<string> res_cat_list1 = new List<string>();
                            int count1 = 1;
                            foreach (var x in cat_var)
                            {
                                res_cat_list1.Add(count1 + "." + " " + x.Value);
                                count1++;
                            }

                            textBox1.Text = String.Join(Environment.NewLine, res_cat_list1);
                            //string str_cat = reader1.GetString(0);
                            //textBox1.Text = reader1.GetString(0);
                        }
                    }
                    // }
                    //else
                    //   textBox1.Text = "Пока что категорий нет";

                }

                else
                {
                    var q = category_list.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

                    List<string> res_cat_list = new List<string>();
                    int count = 1;
                    foreach (var x in q)
                    {
                        res_cat_list.Add(count + "." + " " + x.Value);
                        count++;
                    }
                    textBox1.Text = String.Join(Environment.NewLine, res_cat_list);
                }
            }
        }

        private void users_data_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            
           /* m_dbConnection = new SQLiteConnection(con_str);
            m_dbConnection.Open();
            string sql1 = "UPDATE profile_data SET Categories = '" +textBox1.Text+ "' WHERE Login = '" + frm_login.login + "'";
            SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
            command1.ExecuteNonQuery();
            m_dbConnection.Close();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //this.Hide();
            //RefToForm0.Hide();
            //frm_login frm = new frm_login();
            //this.Hide();
            //RefToForm0.Hide();
            //frm.Show();
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\English For You.exe");    // where myapp should be replaced by your executable name
            Application.Exit();





        }
    }
}
