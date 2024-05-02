using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS_ComputerManagementCenter;
using System.Windows.Forms;
using DTO_ComputerManagementCenter;
using GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher;
using GUI_ComputerManagementCenter.GUI_RelatedToActorStudent;
using GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee;

namespace GUI_ComputerManagementCenter.GUI_RelatedToLogin
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void guna2ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = guna2TextBoxUserName.Text;
            string password = guna2TextBoxPassword.Text;


            if (BUS_RelatedToLogin.Instance.CheckLogin(username, password))
            {
                DTO_Person.IDSession = username;
                if (username.StartsWith("HV"))
                {
                    FStudent fStudent = new FStudent();
                    fStudent.Show();
                    this.Hide();
                }
                else if (username.StartsWith("GV"))
                {
                    
                    FTeacher fTeacher = new FTeacher();
                    fTeacher.Show();
                    this.Hide();
                    
                }
                else if (username.StartsWith("NV"))
                {
                    FEs fEs = new FEs();
                    fEs.Show();
                    this.Hide();
                }
            }
        }

        private void labelForgetPw_Click(object sender, EventArgs e)
        {
            FForgetPassword fForgetPassword = new FForgetPassword();
            fForgetPassword.Show();
            this.Hide();
        }
    }
}
