using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Transitions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using Exampl_pop_up.Properties;

namespace Exampl_pop_up
{

    public partial class Form0 : Form
    {
        public static Form1 notific = new Form1("test");
        public static string timeIn;
        public static string hours;
        public static string min;
        private const int GROUP_BOX_BOTTOM = 12;
        DateTime dt;
        
        public Form0(string _label)
        {
            InitializeComponent();
            lbl_log.Text = _label + ", добро пожаловать в English For You!";
            //font_changer();
            
            //  label1.Font = new Font("Broadway", label1.Font.Size);
            // label1.Text = "Привет";
        }

        private void font_changer()
        {

            List<string> fonts = new List<string>();

            foreach (FontFamily font in FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            string[] font_arr = fonts.ToArray();

            Random rnd = new Random();
            int val = rnd.Next(0, fonts.Count());

            this.lbl_log.Font = new Font(font_arr[val], 20);


        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            FormCollection fc = Application.OpenForms;

            if(fc.Count == 1)
            { 
            Form2 form = new Form2();
            form.Show();
                this.Hide();
            }*/
        }

        private void Form0_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer1.Enabled = false;
            ////////////////////
            string con_str = @"Data Source=E4U_liteDB.db; Version = 3;";
            using (var m_dbConnection = new SQLiteConnection(con_str))
            {
                m_dbConnection.Open();
                //cn.Open();
                string sql1 = "UPDATE profile_data SET TimeIn = '" + timeIn + "' WHERE Login = '" + frm_login.login + "'";
                SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
                command1.ExecuteNonQuery();
            }
            using (var m_dbConnection1 = new SQLiteConnection(con_str))
            {
                m_dbConnection1.Open();
                string todb = string.Join(",", users_data.category_list.ToArray());
                string sql2 = "UPDATE profile_data SET Categories = '" + todb + "' WHERE Login = '" + frm_login.login + "'";
                SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection1);
                command2.ExecuteNonQuery();
                
            }
            Application.Exit();
            ////////////////////
            //if (e.CloseReason == CloseReason.UserClosing)
            // {
            //    e.Cancel = true;
            //   Hide();
            // }
        }


        /// <summary>
        /// Menu animation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            ////profile_image//////
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination = this.Height - 96;
            Transition.run(pictureBox1, "Top", iDestination, new TransitionType_UserDefined(elements, 450));
            ////profile_image//////

            ////settings_image//////
            IList<TransitionElement> elementss = new List<TransitionElement>();
            elementss.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination_s = this.Height - 96;
            Transition.run(pictureBox3, "Top", iDestination_s, new TransitionType_UserDefined(elementss, 450));
            ////settings_image//////

        }

        private void panel2_MouseLeave_1(object sender, EventArgs e)
        {
            ////profile_image//////
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination = this.Height;
            Transition.run(pictureBox1, "Top", iDestination, new TransitionType_UserDefined(elements, 550));
            ////profile_image//////

            ////settings_image//////
            IList<TransitionElement> elementss = new List<TransitionElement>();
            elementss.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination_s = this.Height;
            Transition.run(pictureBox3, "Top", iDestination_s, new TransitionType_UserDefined(elementss, 550));
            ////settings_image//////
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            ////profile_image//////
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination = this.Height - 96;
            Transition.run(pictureBox1, "Top", iDestination, new TransitionType_UserDefined(elements, 450));
            ////profile_image//////

            ////settings_image//////
            IList<TransitionElement> elementss = new List<TransitionElement>();
            elementss.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination_s = this.Height - 96;
            Transition.run(pictureBox3, "Top", iDestination_s, new TransitionType_UserDefined(elementss, 450));
            ////settings_image//////

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            ////profile_image//////
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination = this.Height;
            Transition.run(pictureBox1, "Top", iDestination, new TransitionType_UserDefined(elements, 550));
            ////profile_image//////

            ////settings_image//////
            IList<TransitionElement> elementss = new List<TransitionElement>();
            elementss.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination_s = this.Height;
            Transition.run(pictureBox3, "Top", iDestination_s, new TransitionType_UserDefined(elementss, 550));
            ////settings_image//////


        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ////profile_image//////
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination = this.Height - 96;
            Transition.run(pictureBox1, "Top", iDestination, new TransitionType_UserDefined(elements, 550));
            ////profile_image//////

            ////settings_image//////
            IList<TransitionElement> elementss = new List<TransitionElement>();
            elementss.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination_s = this.Height - 96;
            Transition.run(pictureBox3, "Top", iDestination_s, new TransitionType_UserDefined(elementss, 550));
            ////settings_image//////
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            ////profile_image//////
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination = this.Height - 96;
            Transition.run(pictureBox1, "Top", iDestination, new TransitionType_UserDefined(elements, 550));
            ////profile_image//////

            ////settings_image//////
            IList<TransitionElement> elementss = new List<TransitionElement>();
            elementss.Add(new TransitionElement(100, 100, InterpolationMethod.Accleration));
            int iDestination_s = this.Height - 96;
            Transition.run(pictureBox3, "Top", iDestination_s, new TransitionType_UserDefined(elementss, 550));
            ////settings_image//////
        }


        /// <summary>
        /// Menu animation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            users_data udf = new users_data();
            udf.ShowDialog();
            udf.RefToForm0 = this;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //users_data.category_list.ToString();
            FormCollection fc = Application.OpenForms;
            
            if ( Settings.Default["Name"].ToString() == "" && fc.Count == 2 )
            {
                Form2 form = new Form2();
                form.Show();
                this.Hide();
                form.RefToForm0 = this;
            }   
            else if (Settings.Default["Name"].ToString() != "" && fc.Count == 1)
            {
                Form2 form = new Form2();
                form.Show();
                this.Hide();
                form.RefToForm0 = this;

            }
            
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            
            SQLiteConnection m_dbConnection;
            string con_str = @"Data Source=E4U_liteDB.db; Version = 3;";
            m_dbConnection = new SQLiteConnection(con_str);
            m_dbConnection.Open();
            string sql = "SELECT TimeIn FROM profile_data WHERE Login = '"+frm_login.login+"' ";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                timeIn = reader.GetString(0);
                timer1.Enabled = true;
                dt = Convert.ToDateTime(timeIn);
            }
            m_dbConnection.Close();



            button1.Visible = false;

        }


        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeIn = dt.AddSeconds(i).ToString("HH:mm:ss");
            hours = dt.ToString("HH");
            min = dt.ToString("mm");
            i++;
            if (min == "60")
            {
               Convert.ToInt32(hours); 
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox2, "Перейти к настройке окна");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, "Профиль");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox3, "Настройки");
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
           
            //if(!Form2.timer1.Enabled)
            notific.ShowWindow();
            settings set = new settings();
            set.ShowDialog();
        }
    }
}
