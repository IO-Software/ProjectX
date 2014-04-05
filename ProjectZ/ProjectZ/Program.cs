using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectZ
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Codes codes = new Codes();
            PointConverter pointConverter = new PointConverter();
            EdgeKeeper edgeKeeper = new EdgeKeeper();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult debug = MessageBox.Show("Do you want to start debug mode?", "Debugmode?", MessageBoxButtons.YesNoCancel);
            if (debug == DialogResult.Yes)
            {
                Application.Run(new Window());
            }
            else if (debug == DialogResult.No)
            {
                Application.Run(new GameWindow());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
