using System;
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
            loginForm.Show();
            Application.Run();
            //if (loginForm.DialogResult == DialogResult.OK)
            //{
            //    var mainForm = new Main_Form();
            //    mainForm.clientSocket = loginForm.clientSocket;
            //    mainForm.user = loginForm.user;

            //    mainForm.ShowDialog();
            //}
        }
    }
}
