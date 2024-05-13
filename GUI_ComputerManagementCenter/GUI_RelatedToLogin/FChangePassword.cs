using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_ComputerManagementCenter.GUI_RelatedToLogin
{
    public partial class FChangePassword : Form
    {
        public FChangePassword()
        {
            InitializeComponent();
        }

        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {
            if (label2.Text == "" && label3.Text == "" && label4.Text == "")
            {
                if (BUS_RelatedToLogin.Instance.ChangeNewPassword(DTO_Person.IDSession, guna2TextBoxNew.Text))
                {
                    MessageBox.Show("Change Password Successfully");
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is FBackGround)
                        {
                            form.Hide();
                        }
                    }
                    this.Close();
                }
            } 
            else
            {
                MessageBox.Show("Please check information field again");
            }

        }

        private void guna2TextBoxCurr_Leave(object sender, EventArgs e)
        {
            if (!BUS_RelatedToLogin.Instance.CheckLogin(DTO_Person.IDSession, guna2TextBoxCurr.Text)) {
                label2.Text = "Current password is wrong";
            } else
            {
                label2.Text = "";
            }
        }
        private void guna2TextBoxNew_Leave(object sender, EventArgs e)
        {
            if (guna2TextBoxNew.Text.Length < 6)
            {
                label3.Text = "Password must be at least 6 character";
            } else
            {
                label3.Text = "";
            }
        }

        private void guna2TextBoxReNew_Leave(object sender, EventArgs e)
        {
            if (guna2TextBoxNew.Text != guna2TextBoxReNew.Text)
            {
                label4.Text = "Re-new password is invalid";
            } else
            {
                label4.Text = "";
            }
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FBackGround)
                {
                    form.Hide();
                }
            }
        }

        private void guna2ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Form form in Application.OpenForms)
            {
                if (form is FBackGround)
                {
                    form.Hide();
                }
            }
        }

        private void guna2TextBoxCurr_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBoxCurr.UseSystemPasswordChar)
            {
                guna2TextBoxCurr.UseSystemPasswordChar = false;
                guna2TextBoxCurr.PasswordChar = '\0';
                guna2TextBoxCurr.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.hide__1_;
            }
            else
            {
                guna2TextBoxCurr.UseSystemPasswordChar = true;
                guna2TextBoxCurr.PasswordChar = '.';
                guna2TextBoxCurr.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.visible__1_;
            }
        }

        private void guna2TextBoxNew_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBoxNew.UseSystemPasswordChar)
            {
                guna2TextBoxNew.UseSystemPasswordChar = false;
                guna2TextBoxNew.PasswordChar = '\0';
                guna2TextBoxNew.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.hide__1_;
            }
            else
            {
                guna2TextBoxNew.UseSystemPasswordChar = true;
                guna2TextBoxNew.PasswordChar = '.';
                guna2TextBoxNew.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.visible__1_;
            }
        }

        private void guna2TextBoxReNew_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBoxReNew.UseSystemPasswordChar)
            {
                guna2TextBoxReNew.UseSystemPasswordChar = false;
                guna2TextBoxReNew.PasswordChar = '\0';
                guna2TextBoxReNew.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.hide__1_;
            }
            else
            {
                guna2TextBoxReNew.UseSystemPasswordChar = true;
                guna2TextBoxReNew.PasswordChar = '.';
                guna2TextBoxReNew.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.visible__1_;
            }
        }

        private void guna2TextBoxCurr_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            label3.Text = string.Empty;
            label4.Text = string.Empty;
        }

        private void guna2TextBoxNew_Click(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            label4.Text = string.Empty;
        }
    }
}
