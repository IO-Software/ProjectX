﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectY
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            loadCodes();
            loadPointConverter();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());
        }

        public static void loadCodes() {
            Codes loadedCodes = new Codes();
        }

        public static void loadPointConverter()
        {
            PointConverter pointConverter = new PointConverter();
        }
    }
}
