using System;
using System.Windows.Forms;

namespace PresentacionCompilador
{

    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new FrmCompilador());        
        }
    }
}
