using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exampl_pop_up.Properties;

namespace Exampl_pop_up
{
    
    static class Program
    {
        static string name = Settings.Default["Name"].ToString();
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
         
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (name == "")
            {
                Application.Run(new frm_reg());
                Settings.Default["Name"] = frm_reg.name;
                Settings.Default.Save();
            }
            
            else
            {

                Application.Run(new Form0(Settings.Default["Name"].ToString()));
                
            }

        }

    }
}
