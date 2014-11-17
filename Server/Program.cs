using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
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
            using (var fs = new FileStream("Classes.dll", FileMode.Create, FileAccess.Write))
            {
                fs.Write(Properties.Resources.Classes, 0, Properties.Resources.Classes.Length);
            }
            using (var fs = new FileStream("Newtonsoft.Json.dll", FileMode.Create, FileAccess.Write))
            {
                fs.Write(Properties.Resources.Newtonsoft_Json, 0, Properties.Resources.Newtonsoft_Json.Length);
            }
            using (var fs = new FileStream("MySql.Data.dll", FileMode.Create, FileAccess.Write))
            {
                fs.Write(Properties.Resources.MySql_Data, 0, Properties.Resources.MySql_Data.Length);
            }
            /**/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Server());
        }
    }
}
