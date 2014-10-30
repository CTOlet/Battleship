using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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
            var loginForm = new Login_Form();
            Application.Run(loginForm);
            if (loginForm.DialogResult == DialogResult.OK)
            {
                var mainForm = new Main_Form();
                mainForm.clientSocket = loginForm.clientSocket;
                //mainForm.user_id = loginForm.user_id;

                mainForm.ShowDialog();
            }
        }
    }
}
