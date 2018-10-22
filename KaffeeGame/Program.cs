using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaffeeGame
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
            Application.Run(new StartForm());
            //TODO: Virus einbauen
            //Thread.Sleep(5000);
            //MessageBox.Show("Diese Website hat einen Virus auf ihrem System installiert!");
        }
    }
}
