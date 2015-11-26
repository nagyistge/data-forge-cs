using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//
// Install MS Charts for these examples to compile:
// 
// http://www.microsoft.com/en-us/download/confirmation.aspx?id=14422
//

namespace _1.plot
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
            Application.Run(new Form1());
        }
    }
}
