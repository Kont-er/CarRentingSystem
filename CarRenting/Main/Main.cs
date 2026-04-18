// Program.cs
using System;
using System.Windows.Forms;
using CarRentalApp;  // <-- add this if MainForm is here

namespace CarRenting
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
