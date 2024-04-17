using GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee;
using GUI_ComputerManagementCenter.GUI_RelatedToLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_ComputerManagementCenter
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FLogin());
            //Application.Run(new Form2());
            //Application.Run(new FEmployee());
            //Application.Run(new FEmployees());  
            //Application.Run(new FE());
            //Application.Run(new Fes());
            Application.Run(new FEs());
            //Application.Run(new FAddTeacher());
            //Application.Run(new FAddStudent());
        }
    }
}
