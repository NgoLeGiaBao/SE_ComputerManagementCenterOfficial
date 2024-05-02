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
    public partial class FForgetPassword : Form
    {
        private string code = "";
        public FForgetPassword()
        {
            InitializeComponent();
        }

        private void FForgetPassword_Load(object sender, EventArgs e)
        {
            guna2PanelUserName.Location = new System.Drawing.Point(30, 268);
            guna2PanelAuthencation.Visible = false;
            guna2PanelNew.Visible = false;
            guna2PanelRe.Visible = false;
            guna2PanelBTN.Visible = false;
        }

        private void guna2ButtonSendMail_Click(object sender, EventArgs e)
        {
            if (BUS_RelatedToLogin.Instance.CheckUserNameExist(guna2TextBoxUserName.Text))
            {
                guna2PanelUserName.Visible = false;
                guna2PanelAuthencation.Visible=true;
                guna2PanelAuthencation.Location = new System.Drawing.Point(30, 268);
                DTO_Person.IDSession = guna2TextBoxUserName.Text;
                code = BUS_RelatedToLogin.Instance.SendEmailToUser(guna2TextBoxUserName.Text);
            } else
            {
                labelMessUsername.Text = "Username doesn't exist";
            }
        }

        private void guna2ButtonConfAuth_Click(object sender, EventArgs e)
        {
            if (BUS_RelatedToLogin.Instance.CheckVerifyCode(code, DTO_Person.IDSession))
            {
                guna2PanelAuthencation.Visible = false;
                guna2PanelNew.Visible = true;
                guna2PanelRe.Visible = true;
                guna2PanelBTN.Visible = true;
            }
            else
            {
                labelMessAuthencation.Text = "Authencation is invalid";
            }
        }

        private void guna2ButtonCancelAuth_Click(object sender, EventArgs e)
        {
            guna2PanelAuthencation.Visible = false;
            guna2PanelUserName.Visible = true;

        }

        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {
            if (BUS_RelatedToLogin.Instance.ChangeNewPassword(DTO_Person.IDSession, guna2TextBoxNew.Text)) 
            {
                MessageBox.Show("OK");
            }
        }
    }
}
