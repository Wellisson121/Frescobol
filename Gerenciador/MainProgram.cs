using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador
{
    static class MainProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen splash = new SplashScreen();
            splash.StartPosition = FormStartPosition.CenterScreen;
            splash.Show();

            Application.DoEvents();

            MainForm mainForm = new MainForm();
            mainForm.StartPosition = FormStartPosition.CenterScreen;

            for (int i = 0; i <= 12; i++)
                splash.UpdateProgress(10);

            //mainForm.ImagensAtletas = splash.LoadImagensAtletas();

            splash.Dispose();
            splash = null;

            Application.Run(mainForm);
        }
    }
}
