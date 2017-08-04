using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exampl_pop_up
{
    public partial class settings : Form
    {
        public static int val = 0;
        public static string font = "Microsoft Sans Serif; 18pt; style=Bold";
        public static Font font_family = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold);
        public static int width = 215;
        public static int height = 47;
        public static Color bg_color = Color.FromArgb(255, 242, 163);
        public static Color font_color = Color.Black;
        Point pt = Screen.PrimaryScreen.WorkingArea.Location;

        public settings()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BorderStyle == BorderStyle.FixedSingle || pictureBox3.BorderStyle == BorderStyle.FixedSingle || pictureBox4.BorderStyle == BorderStyle.FixedSingle)
            {
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                val = 0;
            }
            Form0.notific.BackColor = Color.FromArgb(255, 242, 163);
            Form0.notific.ForeColor = Color.Black;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BorderStyle == BorderStyle.FixedSingle || pictureBox3.BorderStyle == BorderStyle.FixedSingle || pictureBox4.BorderStyle == BorderStyle.FixedSingle)
            {
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                val = 1;
            }
            Form0.notific.BackColor = Color.White;
            Form0.notific.ForeColor = Color.Green;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BorderStyle == BorderStyle.FixedSingle || pictureBox2.BorderStyle == BorderStyle.FixedSingle || pictureBox4.BorderStyle == BorderStyle.FixedSingle)
            {
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
                val = 2;
            }
            Form0.notific.BackColor = Color.White;
            Form0.notific.ForeColor = Color.DarkRed;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            if (pictureBox1.BorderStyle == BorderStyle.FixedSingle || pictureBox2.BorderStyle == BorderStyle.FixedSingle || pictureBox3.BorderStyle == BorderStyle.FixedSingle)
            {
                pictureBox4.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                val = 3;
            }

            
                /*    ContextMenuStrip cm = new ContextMenuStrip();
                    cm.Items.Add("Редактировать");
                    pictureBox4.ContextMenuStrip = cm;
                */
            
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                Form0.notific.BackColor = colorDialog1.Color;
                bg_color = colorDialog1.Color;

            }


            DialogResult result1 = colorDialog2.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                // Set form background to the selected color.
                Form0.notific.ForeColor = colorDialog2.Color;
                font_color = colorDialog2.Color;
            }

    

        }

        private void settings_Load(object sender, EventArgs e)
        {
            if (val == 0)
            {
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
            }
            else if (val == 1)
            {
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
            }
            else if(val == 2)
            {
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox4.BorderStyle = BorderStyle.None;
            }
            else
            {
                pictureBox4.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
            }

            lbl_font.Text = font;

            Form0.notific.label1.AutoSize = false;
            Form0.notific.label1.TextAlign = ContentAlignment.MiddleCenter;
            Form0.notific.label1.Dock = DockStyle.Fill;
            trackBar1.Value = width;
            trackBar2.Value = height;
        }

        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form0.notific.Hide();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

            Form0.notific.Width = trackBar1.Value;
            Form0.notific.label1.AutoSize = false;
            Form0.notific.label1.TextAlign = ContentAlignment.MiddleCenter;
            Form0.notific.label1.Dock = DockStyle.Fill;

            Form0.notific.StartPosition = FormStartPosition.Manual;
            pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pt.Offset(-Form0.notific.Width, -Form0.notific.Height);
            Form0.notific.Location = pt;
            pt.X = 0;
            pt.Y = 0;
            width = trackBar1.Value; 
            //Form0.notific.Location = new Point(Form0.notific.Location.X - 1, Form0.notific.Location.Y - 48 + Form0.notific.Height);

            //Form0.notific.label1.Dock = DockStyle.Right;

            //Form0.notific.label1.Anchor = AnchorStyles.Right;
            //   MessageBox.Show(trackBar1.Value.ToString());

        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            Form0.notific.Height = trackBar2.Value;
            Form0.notific.label1.AutoSize = false;
            Form0.notific.label1.TextAlign = ContentAlignment.MiddleCenter;
            Form0.notific.label1.Dock = DockStyle.Fill;

            Form0.notific.StartPosition = FormStartPosition.Manual;
            pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pt.Offset(-Form0.notific.Width, -Form0.notific.Height);
            Form0.notific.Location = pt;
            pt.X = 0;
            pt.Y = 0;
            height = trackBar2.Value;
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.OK == fontDialog1.ShowDialog(this))
            {
                Form0.notific.label1.Font = fontDialog1.Font;
                lbl_font.Text = fontDialog1.Font.Name + "; " + fontDialog1.Font.Size + "pt; " + "style=" + fontDialog1.Font.Style;

                font = lbl_font.Text;
                lbl_font.Left = settings.ActiveForm.Width / 2 - lbl_font.Width / 2 - 15;
                font_family = fontDialog1.Font;
                Form0.notific.label1.AutoSize = false;
                Form0.notific.label1.TextAlign = ContentAlignment.MiddleCenter;
                Form0.notific.label1.Dock = DockStyle.Fill;
                
                Form0.notific.StartPosition = FormStartPosition.Manual;
                pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                pt.Offset(-Form0.notific.Width, -Form0.notific.Height);
                Form0.notific.Location = pt;
                pt.X = 0;
                pt.Y = 0;
                
            }
        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
    }
}
