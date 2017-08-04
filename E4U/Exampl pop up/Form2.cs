using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
namespace Exampl_pop_up
{
    public partial class Form2 : Form
    {
        public Form RefToForm0 { get; set; }
        FlowLayoutPanel panel = new FlowLayoutPanel();
        public static List<string> paths = new List<string>();
        //public static int myInt = 50;
        public static int lang_val = 0;
        public string str;
        public bool isopen = false;
        public bool isopen_man = false;
        public Form2()
        {

            InitializeComponent();

        }

        /// <summary>
        /// Timer's
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            { 
                int time;
                int differ;
                time = Convert.ToInt32(textBox2.Text);
                differ = Convert.ToInt32(textBox1.Text);
                    if (time != 0 && differ != 0)
                    { 
                        if (time == differ)
                        {
                            time = time * 1000;
                            time += time;
                        }
                        else if(differ > time)
                    {
                        differ *= 1000;
                        time *=  1000;
                        time += differ; 
                    }

                        else
                            time = time * 1000;

                        timer1.Interval = time;
                    Form1 notific = new Form1(Convert.ToInt32(textBox1.Text), "", choose_path());
                        notific.ShowWindow();
                    }
                    else
                    {
                        try { }
                        catch { }
                    }
                }

            else
            {
                try { }
                catch { }

            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                int time;
                int differ;
                time = Convert.ToInt32(textBox2.Text);
                differ = Convert.ToInt32(textBox1.Text);
                if (time != 0 && differ != 0)
                {
                    if (time == differ)
                    {
                        time = time * 1000;
                        time += time;
                    }

                    else if (differ > time)
                    {
                        differ *= 1000;
                        time *= 1000;
                        time += differ;
                    }

                    else

                        time = time * 1000;


                    timer2.Interval = time;

                    Form1 notific = new Form1(Convert.ToInt32(textBox1.Text), "", rand_path(), true);
                    notific.ShowWindow();
                }
                else
                {
                    try { }
                    catch { }
                }
            }

            else
            {
                try { }
                catch { }
            }
        }


        /// <summary>
        /// Timer's
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        public string rand_path()
        {
            string[] files = System.IO.Directory.GetFiles("English");
            int count = files.Length;
            Random rnd = new Random();
            int val = rnd.Next(0, count);
            return files[val];
        }


        public string choose_path()
        {
            int count = paths.Count;
            Random rnd = new Random();
            int val = rnd.Next(0, count);
            return paths[val];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex==-1)
                try { }
                catch { }
            else
            { 

                  str = comboBox1.SelectedItem.ToString();
                   this.Hide();
                label3.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
       
                timer1.Enabled = true;
                timer2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    
                }
            }
        }
        

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            button1.Visible = true;
            //this.TopMost = true;
            //pictureBox3.Visible = false;
            //pictureBox5.Visible = true;
       
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            if (RefToForm0.Visible == false)
                Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"E:\Локальный диск Е\Exampl pop up\Exampl pop up\bin\Debug\click.wav");
            simpleSound.Play();

            if (timer1.Enabled == false)
            { 
                try { }
                catch { }
            }
            else
            timer1.Enabled = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            label3.Text = "Возобновить появление окна ";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"E:\Локальный диск Е\Exampl pop up\Exampl pop up\bin\Debug\click.wav");
            simpleSound.Play();
            timer1.Enabled = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
            label3.Text = "Остановить появление окна";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            panel.SuspendLayout(); // don't calculate the layout before all picture boxes are added
            panel.Size = new Size(300, 326);
            panel.Location = new Point(0, 200);
            panel.Padding = new Padding(0);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoScroll = true; // automatically add scrollbars if needed
            panel.WrapContents = true; // all picture boxes in a single row
            this.Controls.Add(panel);

/*            for (int z = 0; z < 10; ++z)
            {
                var pictureBox = new PictureBox();
                // the location is calculated by the FlowLayoutPanel
                pictureBox.Size = new Size(75, 75);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.ImageLocation = "imgPath";
                panel.Controls.Add(pictureBox);
            }

            panel.ResumeLayout();
            */

            ////////////////////


            button1.Visible = false;
            // checkBox1.Checked = true;
            //checkBox2.Checked = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            label3.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox5.Visible = false;

            int i = 0;
            int x = 0;
            int y = 206;
            string[] files = Directory.GetFiles("English");
            i = files.Length;
            string[] file_names = new string[i];
            i = 0;
            foreach (string file in files)
            {
                file_names[i] = Path.GetFileNameWithoutExtension(file);
                i++;

                Label namebutton = new Label();
                namebutton.Location = new Point(x, y);
                namebutton.Text = file_names[i-1];
                namebutton.AutoSize = false;
                namebutton.Width = 275;
                namebutton.Height = 30;
                namebutton.TextAlign = ContentAlignment.TopCenter;
                namebutton.BorderStyle = BorderStyle.None;
                namebutton.Cursor = Cursors.Hand;
                
                namebutton.Font = new Font(namebutton.Font.FontFamily, 10);
                
                namebutton.MouseDown += (object sender1, MouseEventArgs e1) =>
                {
                    if (e1.Button == MouseButtons.Left)
                    {
                        if (namebutton.BackColor == Color.WhiteSmoke)
                        {
                            namebutton.BackColor = Color.Transparent;
                            paths.Remove(namebutton.Text);
                            if (paths.Count == 0)
                            {
                                timer1.Enabled = false;
                                pictureBox5.Visible = false;
                                pictureBox3.Visible = true;
                            }
                        }
                        else
                        {
                            namebutton.BackColor = Color.WhiteSmoke;
                            paths.Add(namebutton.Text);

                        }
                    }
                    else
                    {
                        if(namebutton.BackColor != Color.WhiteSmoke)
                        { 
                        namebutton.BackColor = Color.WhiteSmoke;
                        paths.Add(namebutton.Text);
                        }
                        ContextMenuStrip cm = new ContextMenuStrip();
                        cm.Items.Add("Редактировать");
                        namebutton.ContextMenuStrip = cm;
                        cm.Click += (sender2, EventArgs) =>
                        {
                          Process.Start("English\\" + namebutton.Text + ".txt");   
                         
                        };
                        }
                };

                namebutton.MouseHover += (sender1, eventArgs) =>
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(namebutton, namebutton.Text);

                };


                //namebutton.UseVisualStyleBackColor = true;
                //this.Controls.Add(namebutton);
                x += 10;
                y += 20;
                panel.Controls.Add(namebutton);
            }        
            this.comboBox1.Items.AddRange(file_names);

            panel.ResumeLayout();


            /*  if (checkBox1.Checked == true)
              { 
              string[] files = System.IO.Directory.GetFiles("English");

              this.comboBox1.Items.AddRange(files);
          }
              else {
                  string[] files = System.IO.Directory.GetFiles("French");

                  this.comboBox1.Items.AddRange(files);
              }
              */
        }

        



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            notifyIcon1.Visible = false;
            timer1.Enabled = false;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = -1;
            comboBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles("English");

            this.comboBox1.Items.AddRange(files);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles("French");
            this.comboBox1.Items.AddRange(files);
            lang_val = 1;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            button1.Visible = true;
            //pictureBox3.Visible = false;
            //pictureBox5.Visible = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && paths.Count != 0)
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
                //this.Height = 134;
                this.Hide();
                pictureBox3.Visible = false;
                pictureBox5.Visible = true;
                isopen_man = false;


            }

            else
                try
                {
                    MessageBox.Show("Выберите категорию слов");
                }
                catch { }
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox5.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            if (!isopen && !isopen_man && timer1.Enabled == true)
            {
                
                timer1.Enabled = false;
                this.Height = 236;
                isopen = true;
                Form2.ActiveForm.Text = "Авто режим";
                pictureBox7.Visible = true;
               // label5.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;
            }
            if (!isopen && !isopen_man && timer2.Enabled == true)
            {
                this.Height = 236;
                isopen = true;
                Form2.ActiveForm.Text = "Авто режим";
               // label5.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;
            }
            
            else if (!isopen && isopen_man && timer1.Enabled == true)
            {
                timer1.Enabled = false;
                this.Height = 236;
                isopen = true;
                Form2.ActiveForm.Text = "Авто режим";
                pictureBox7.Visible = true;
                isopen_man = false;
               // label5.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;

            }
            

            else if(!isopen && !isopen_man && timer1.Enabled == false && timer1.Enabled == false)
            {

                this.Height = 236;
                isopen = true;
                Form2.ActiveForm.Text = "Авто режим";
                pictureBox7.Visible = true;
               // label5.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;

            }

            else if (!isopen && isopen_man && timer1.Enabled == false && timer1.Enabled == false)
            {

                this.Height = 236;
                isopen = true;
                isopen_man = false;
                Form2.ActiveForm.Text = "Авто режим";
                pictureBox7.Visible = true;
              //  label5.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;

            }


            else
            {

                this.Height = 134;
                isopen = false;

            }


        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox6, "Перейти к режиму ручной настройки");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox4, "Настройки авто режима");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox3, "Старт");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox5, "Пауза");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            if (!isopen_man && !isopen && timer2.Enabled == true)
            {
                timer2.Enabled = false;
                this.Height = 553;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox3.Visible = true;
                Form2.ActiveForm.Text = "Ручной режим";
                isopen_man = true;
               // label5.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;
            }
            else if(!isopen_man && !isopen && timer2.Enabled == false && timer1.Enabled == false)
            {
                this.Height = 553;
                
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox3.Visible = true;
                Form2.ActiveForm.Text = "Ручной режим";
                isopen_man = true;
              //  label5.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;
            }

            else if (!isopen_man && !isopen && timer2.Enabled == false && timer1.Enabled == true)
            {
                this.Height = 553;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox5.Visible = true;
                Form2.ActiveForm.Text = "Ручной режим";
                isopen_man = true;
               // label5.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;
            }

            else if (!isopen_man && isopen)
            {
                timer2.Enabled = false;
                this.Height = 553;
                isopen = false;
                Form2.ActiveForm.Text = "Ручной режим";
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox3.Visible = true;
                isopen_man = true;
               // label5.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;
            }

            else if (isopen && !isopen_man && timer1.Enabled == false && timer1.Enabled == false)
            {

                this.Height = 553;
                isopen = false;
                isopen_man = true;
                Form2.ActiveForm.Text = "Авто режим";
                pictureBox3.Visible = true;
              //  label5.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;

            }


            else
            {
                timer1.Enabled = false;
                pictureBox7.Visible = true;
                Form2.ActiveForm.Text = "Авто режим";
                this.Height = 134;
                isopen_man = false;

            }

            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = false;
            this.Height = 134;
            this.Hide();
            pictureBox3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = true;

            //pictureBox5.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            pictureBox5.Visible = false;
            pictureBox3.Visible = false;
            pictureBox7.Visible = true;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox7, "Старт");
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox8, "Пауза");
        }

        private void открытьГлавноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            this.RefToForm0.Show();
            this.RefToForm0.BringToFront();
            this.BringToFront();

            //Form0 form = new Form0(frm_login.login + ", welcome to English 4 You! ");
            //form.Show();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.RefToForm0.Show();
            this.RefToForm0.BringToFront();
            this.BringToFront();
            //this.SendToBack();

        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox9, "Домой");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                try { }
                catch { }
            else
                Process.Start("English\\" + comboBox1.SelectedItem.ToString());
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }






        /* private void checkBox1_CheckedChanged(object sender, EventArgs e)
         {
             checkBox2.Checked = false;
             timer2.Enabled = true;
             this.Height = 122;
             this.Hide();
         }

         private void checkBox2_CheckedChanged(object sender, EventArgs e)
         {
             checkBox1.Checked = false;
             this.Height = 415;
         }

         */


        /*private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            
            checkBox1.Checked = false;
            comboBox1.Items.Clear();
            string[] files = System.IO.Directory.GetFiles("French");

            this.comboBox1.Items.AddRange(files);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            
            checkBox2.Checked = false;
            comboBox1.Items.Clear();
            string[] filess = System.IO.Directory.GetFiles("English");

            this.comboBox1.Items.AddRange(filess);
        }

        */
    }
    

}
