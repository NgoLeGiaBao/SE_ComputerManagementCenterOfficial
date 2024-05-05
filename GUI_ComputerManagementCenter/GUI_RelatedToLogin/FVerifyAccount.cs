using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using Guna.UI2.WinForms;
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
    public partial class FVerifyAccount : Form
    {
        public FVerifyAccount()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (BUS_RelatedToLogin.Instance.CheckVerifyCode(guna2TextBoxUserName.Text, DTO_Person.IDSession))
            {
                FNewPassword fNewPassword = new FNewPassword();
                fNewPassword.Show();    
                this.Hide();
            }
            else
            {
                labelMessAuthencation.Text = "Authencation is invalid";
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FPasswordRecovery fPasswordRecovery = new FPasswordRecovery();
            fPasswordRecovery.Show();
            this.Hide();
        }
    }
}
