using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EricZhao;
namespace MainWindow
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Boolean lbRet = MiniDump.IsAlreadyInstanceStart();

            // MessageBox.Show(lbRet + "");
            if (lbRet)
            {
                MiniDump.ExitProcess(3);
            }
            MiniDump.RegistUnhandledExceptionHandler();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new MainWindow());
        }
    }
}
