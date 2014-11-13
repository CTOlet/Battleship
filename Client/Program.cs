using System;
using System.IO;
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
            /*
            using (var fs = new FileStream("Newtonsoft.Json.dll", FileMode.Create, FileAccess.Write))
            {
                fs.Write(Properties.Resources.Newtonsoft_Json, 0, Properties.Resources.Newtonsoft_Json.Length);
            }
             * */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var gameForm = new GameForm();
            Application.Run(gameForm);
        }
    }
}
