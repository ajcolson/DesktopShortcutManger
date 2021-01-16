using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopShortcutManger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (Environment.UserName != "SYSTEM")
            {
               DialogResult continueWithoutSystemUserAccount = MessageBox.Show("This program may not work correctly as it was not started by the SYSTEM account for this computer. Some shortcuts may not delete correctly right now.\n\nPlease contact your system administrator about this for more assistance.\n\nWould you like to continue running this program?", "Desktop Shortcut Manager may not be working correctly...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               if (continueWithoutSystemUserAccount == DialogResult.No)
               {
                   return;
               }
            }
            Application.Run(new MainForm());
        }
    }
}
