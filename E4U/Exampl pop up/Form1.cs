using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Exampl_pop_up
{
    public partial class Form1 : Form
    {



        ////////////////
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet =
        CharSet.Ansi, SetLastError = true)]

        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int
        maximumWorkingSetSize);

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        ////////////////


        //static bool flush = true;
        public static string category;
        private const int SW_SHOWNOACTIVATE = 4; //неактивна
        private const int HWND_TOPMOST = -1; //поверх всех окон, включая топовые
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        Point pt = Screen.PrimaryScreen.WorkingArea.Location;
        private int _secondClose = 0;
        internal int SecondClose
        {
            get { return _secondClose; }
            set { _secondClose = value; }
        }
        public void ShowWindow()
        {
            ShowWindow(Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(Handle.ToInt32(), HWND_TOPMOST, Left, Top, Width, Height, SWP_NOACTIVATE);
        }

        ArrayList lines = new ArrayList();
        static int curRec = 0;
        static int curRecNull = 0;
        private void displayLine(int linenumber)
        {

            if (lines.Count > 0)
            {
                if ((linenumber >= 0) && (linenumber < lines.Count))
                {
                    String line = (String)lines[linenumber];
                    label1.Text = line;
                    curRec++;
                }

                else if (linenumber >= lines.Count)
                {
                    if (curRecNull >= lines.Count)
                    {
                        curRecNull = 0;
                        String line = (String)lines[curRecNull];
                        label1.Text = line;
                        curRecNull++;
                    }
                        

                    else
                    {
                        //label1.Text = "/ Section's end /";
                        String line = (String)lines[curRecNull];
                        label1.Text = line;
                        curRecNull++;
                    }
                    

                }
            }
            else
                label1.Text = "/ Section is empty /";

        }

        //int lang_value;



        /////////////////////////////
        static int curRec_auto = 0;
        private void displayLine_auto(int linenumber)
        {

            if (lines.Count > 0)
            {
                if ((linenumber >= 0) && (linenumber < lines.Count))
                {
                    String line = (String)lines[linenumber];
                    label1.Text = line;
                }

                else if (linenumber == lines.Count)
                {

                    label1.Text = "/ Section's end /";
                    curRec_auto = 0;

                }
            }
            else
                label1.Text = "/ Section is empty /";

        }



        /// <summary>
        /// Constructors reg
        /// </summary>
      
       
        public Form1(int minutesToClose, string text, string name)
        {
            InitializeComponent();
            users_data.category_list.Add(name);
            switch (settings.val)
            {
                case 0:
                    this.BackColor = Color.FromArgb(255, 242, 163);
                    this.ForeColor = Color.Black;
                    break;
                case 1:
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Green;
                    break;
                case 2:
                    this.BackColor = Color.White;
                    this.ForeColor = Color.DarkRed;
                    break;
                case 3:
                    this.ForeColor = settings.font_color;
                    this.BackColor = settings.bg_color;
                    break;
            }
            this.Width = settings.width;
            this.Height = settings.height;
            this.label1.Font = settings.font_family;
            //  lang_value = Form2.lang_val;
            SecondClose = minutesToClose;
            StreamReader reader = new StreamReader("English\\"+name+".txt", Encoding.Default);
            string curLine;
            while ((curLine = reader.ReadLine()) != null)
            {
                lines.Add(curLine);
            }
            reader.Close();

            displayLine(curRec);
            // text = label1.Text;
            this.label1.AutoSize = false;
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Dock = DockStyle.Fill;

            this.StartPosition = FormStartPosition.Manual;
            pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pt.Offset(-this.Width, -this.Height);
            this.Location = pt;
            this.Location = new Point(this.Location.X - 1, this.Location.Y);
            // Showing window code
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.Height; i++)
                {
                   if (this.IsHandleCreated)
                    {
                        this.Invoke((Action)(() =>
                        {
                            this.Location = new Point(this.Location.X, this.Location.Y - 1);
                        }));
                    }
                    if (this.Location == pt) break;
                    Thread.Sleep(-1);
                    
                }

            });

            Task.Factory.StartNew(() =>
            {
                
                Thread.Sleep(_secondClose * 1000);
                /*if (flush)
                {
                    FlushMemory();
                    flush = false;
                }*/
                this.Invoke((Action)(() =>
                {

                    ((IDisposable)this).Dispose();
                    

                }));
                this.Close();


            });
            
        }
            //End of showing window code

        /////////////////////////

        public Form1(int minutesToClose, string text, string name, bool isauto)
        {

            // TopMost = true;

            InitializeComponent();
            //lang_value = Form2.lang_val;
            SecondClose = minutesToClose;
            StreamReader reader = new StreamReader(name, Encoding.Default);
            string curLine;
            while ((curLine = reader.ReadLine()) != null)
            {
                lines.Add(curLine);
            }
            reader.Close();

            int end = lines.Count;
            Random rnd = new Random();
            int val = rnd.Next(1, end);
            curRec_auto = val;

            displayLine_auto(curRec_auto);
            // text = label1.Text;

            this.StartPosition = FormStartPosition.Manual;
            pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pt.Offset(-this.Width, -this.Height);
            this.Location = pt;
            this.Location = new Point(this.Location.X - 1, this.Location.Y - 48 + this.Height);
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.Height; i++)
                {
                    if (this.IsHandleCreated)
                    {
                        this.Invoke((Action)(() =>
                        {
                            this.Location = new Point(this.Location.X, this.Location.Y - 1);
                        }));
                    }
                    if (this.Location == pt) break;
                    Thread.Sleep(-1);
                }

            });

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(_secondClose * 1000);
                this.Invoke((Action)(() =>
                {
                    ((IDisposable)this).Dispose();
                    
                }));
            });
        }


        public Form1(string name)
        {
            InitializeComponent();

            switch (settings.val)
            {
                case 0:
                    this.BackColor = Color.FromArgb(255, 242, 163);
                    break;
                case 1:
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Green;
                    break;
                case 2:
                    this.BackColor = Color.White;
                    this.ForeColor = Color.DarkRed;
                    break;
            }
            //  lang_value = Form2.lang_val;
            StreamReader reader = new StreamReader("English\\" + name + ".txt", Encoding.Default);
            string curLine;
            while ((curLine = reader.ReadLine()) != null)
            {
                lines.Add(curLine);
            }
            reader.Close();

            displayLine(curRec);
            // text = label1.Text;

            this.StartPosition = FormStartPosition.Manual;
            pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pt.Offset(-this.Width, -this.Height);
            this.Location = pt;
            this.Location = new Point(this.Location.X - 1, this.Location.Y - 48 + this.Height);
            // Showing window code
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.Height; i++)
                {
                    if (this.IsHandleCreated)
                    {
                        this.Invoke((Action)(() =>
                        {
                            this.Location = new Point(this.Location.X, this.Location.Y - 1);
                        }));
                    }
                    if (this.Location == pt) break;
                    Thread.Sleep(-1);

                }

            });
        }

        /// <summary>
        /// End of constructors reg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            SpeechSynthesizer reader = new SpeechSynthesizer();
            //reader.SelectVoice("Microsoft Server Speech Text to Speech Voice (fr-FR, Hortense)");

            var builder = new PromptBuilder();
            //if (lang_value == 0)
                builder.StartVoice("Microsoft Zira Desktop");
            /*else if (lang_value == 1)
                builder.StartVoice("Microsoft Hortense Desktop");*/
            builder.AppendText(label1.Text);
            builder.EndVoice();
            reader.SpeakAsync(new Prompt(builder));

            //reader.Speak(label1.Text);
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SpeechSynthesizer reader = new SpeechSynthesizer();
                var builder = new PromptBuilder();
                //if (lang_value == 0)
                builder.StartVoice("Microsoft Zira Desktop");
                /*else if (lang_value == 1)
                    builder.StartVoice("Microsoft Hortense Desktop");*/
                /*string txt = label1.Text;
                int index = txt.IndexOf("-");
                if (index > 0)
                    txt = txt.Substring(0, index);
                    */
                builder.AppendText(label1.Text);
                builder.EndVoice();
                reader.SpeakAsync(new Prompt(builder));
            }
            else
                this.Hide();
        }
    }
    
    
}

