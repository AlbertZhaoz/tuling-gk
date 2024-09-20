using System;
using System.Windows.Forms;
using TulingHslCore;

namespace TulingHsl
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(!HslHelper.HslAuthorization()){
                MessageBox.Show("Fail Active");
            }

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(mainForm);
        }
    }
}
