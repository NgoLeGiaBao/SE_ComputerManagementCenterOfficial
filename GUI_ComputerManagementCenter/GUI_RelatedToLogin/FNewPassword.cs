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
    public partial class FNewPassword : Form
    {
        public FNewPassword()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (BUS_RelatedToLogin.Instance.ChangeNewPassword(DTO_Person.IDSession, guna2TextBoxUserName.Text))
            {
                MessageBox.Show("A new password was created successfully");
                FLogin fLogin = new FLogin();
                fLogin.Show();
                this.Hide();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBoxUserName_Leave(object sender, EventArgs e)
        {
            if (guna2TextBoxUserName.Text.Length < 6) {
                labelMessAuthencation.Text = "Password must be at least 6 characters";
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (guna2TextBoxUserName.Text != guna2TextBox1.Text)
            {
                label2.Text = "Confirmation password is invalid";
            }
        }

        private void guna2TextBoxUserName_Click(object sender, EventArgs e)
        {
            labelMessAuthencation.Text = "";
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void guna2TextBoxUserName_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBoxUserName.UseSystemPasswordChar)
            {
                guna2TextBoxUserName.UseSystemPasswordChar = false;
                guna2TextBoxUserName.PasswordChar = '\0';
                guna2TextBoxUserName.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.hide__1_;
            }
            else
            {
                guna2TextBoxUserName.UseSystemPasswordChar = true;
                guna2TextBoxUserName.PasswordChar = '.';
                guna2TextBoxUserName.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.visible__1_;
            }
        }

        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBox1.UseSystemPasswordChar)
            {
                guna2TextBox1.UseSystemPasswordChar = false;
                guna2TextBox1.PasswordChar = '\0';
                guna2TextBox1.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.hide__1_;
            }
            else
            {
                guna2TextBox1.UseSystemPasswordChar = true;
                guna2TextBox1.PasswordChar = '.';
                guna2TextBox1.IconRight = global::GUI_ComputerManagementCenter.Properties.Resources.visible__1_;
            }
        }
    }
}
