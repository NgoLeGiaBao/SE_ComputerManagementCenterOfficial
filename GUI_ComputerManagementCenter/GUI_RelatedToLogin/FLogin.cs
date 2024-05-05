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
            if (username == "" || password == "")
            {
                labelMessError.Text = "Please fill all field information";
            } else
            {
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
                else
                {
                    labelMessError.Text = "Username or password is invalid";
                }
            }
        }

        private void labelForgetPw_Click(object sender, EventArgs e)
        {
            FPasswordRecovery fPasswordRecovery = new FPasswordRecovery();
            fPasswordRecovery.Show();
            this.Hide();
        }

        private void guna2TextBoxPassword_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBoxPassword.UseSystemPasswordChar)
            {
                guna2TextBoxPassword.UseSystemPasswordChar = false;
                guna2TextBoxPassword.PasswordChar = '\0';
                guna2TextBoxPassword.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.hide__1_;
            } else
            {
                guna2TextBoxPassword.UseSystemPasswordChar = true;
                guna2TextBoxPassword.PasswordChar = '.';
                guna2TextBoxPassword.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.visible__1_;
            }

        }

        private void guna2TextBoxUserName_Click(object sender, EventArgs e)
        {
            labelMessError.Text = "";
        }

        private void guna2TextBoxPassword_Click(object sender, EventArgs e)
        {
            labelMessError.Text = ""; 
        }
    }
}
