using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
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
            MessageBox.Show(DTO_Person.IDSession);
            if (labelMessCurr.Text == "" && labelMessNewPass.Text == "" && labelMessReNewPass.Text == "")
            {
                if (BUS_RelatedToLogin.Instance.ChangeNewPassword(DTO_Person.IDSession, guna2TextBoxNew.Text))
                {
                    MessageBox.Show("Change Password Successfully");
                }
            } else
            {
                MessageBox.Show("Please check information field again");
            }

        }

        private void guna2TextBoxCurr_Leave(object sender, EventArgs e)
        {
            if (!BUS_RelatedToLogin.Instance.CheckLogin(DTO_Person.IDSession, guna2TextBoxCurr.Text)) {
                labelMessCurr.Text = "Current password is wrong";
            } else
            {
                labelMessCurr.Text = "";
            }
        }
        private void guna2TextBoxNew_Leave(object sender, EventArgs e)
        {
            if (guna2TextBoxNew.Text.Length < 6)
            {
                labelMessNewPass.Text = "Password must be at least 6 character";
            } else
            {
                labelMessNewPass.Text = "";
            }
        }

        private void guna2TextBoxReNew_Leave(object sender, EventArgs e)
        {
            if (guna2TextBoxNew.Text != guna2TextBoxReNew.Text)
            {
                labelMessReNewPass.Text = "Re-new password is invalid";
            } else
            {
                labelMessReNewPass.Text = "";
            }
        }
    }
}
