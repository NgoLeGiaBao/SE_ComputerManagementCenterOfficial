using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using iTextSharp.text.pdf.qrcode;
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
    public partial class FPasswordRecovery : Form
    {
        public FPasswordRecovery()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FLogin fLogin = new FLogin();
            fLogin.Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string text = guna2TextBoxUserName.Text;
            if (BUS_RelatedToLogin.Instance.CheckUserNameExist(guna2TextBoxUserName.Text))
            {
                DTO_Person.IDSession = guna2TextBoxUserName.Text;
                BUS_RelatedToLogin.Instance.SendEmailToUser(text);
                FVerifyAccount  fVerify = new FVerifyAccount();
                fVerify.Show();
                this.Hide();
            }
            else
            {
                labelMessAuthencation.Text = "Username doesn't exist";
            }
        }

        private void guna2TextBoxUserName_Click(object sender, EventArgs e)
        {
            labelMessAuthencation.Text = "";
        }
    }
}
