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
            InitializePrimaryComponents();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult debug = MessageBox.Show("Press YES for PlayMode and press NO for DebugMode", "Mode?", MessageBoxButtons.YesNoCancel);
            if (debug == DialogResult.Yes)
            {
                Application.Run(new GameWindow());               
            }
            else if (debug == DialogResult.No)
            {
                Application.Run(new Window());
            }
            else
            {
                Application.Exit();
            }
        }

        private static void InitializePrimaryComponents()
        {
            Codes codes = new Codes();
            PointConverter pointConverter = new PointConverter();
            EdgeKeeper edgeKeeper = new EdgeKeeper();
            Textures texture = new Textures();
        }
    }
}
