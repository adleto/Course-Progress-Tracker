using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI
{
    static class Program
    {
        public static List<string> Roles = new List<string>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            var fLogin = new frmLogin();
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                if (Roles.Contains("AdministrativnoOsoblje"))
                {
                    Application.Run(new frmIndexAdmin());
                }
                else if (Roles.Contains("Predavač"))
                {
                    Application.Run(new frmIndexAdmin());
                }
                else
                {
                    MessageBox.Show("Please use client application.");
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
