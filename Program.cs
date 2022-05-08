using System;
using System.Windows.Forms;
using EmployeeApp.Model;

namespace EmployeeApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Filter.isFirstStartAppWithNoData = true;
            Filter.isFirstStartAppWithNoDataPositions = true;
            Application.Run(new Form1());
        }
    }
}
