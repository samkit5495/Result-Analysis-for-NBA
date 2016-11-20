using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Result_Analysis_for_NBA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Server server=new Server();
            server.start();
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmFirst_Page());
            
        }

       /* static void OnProcessExit(object sender, EventArgs e)
        {
            Server server = new Server();
            server.stop();
        }*/
    }
}
