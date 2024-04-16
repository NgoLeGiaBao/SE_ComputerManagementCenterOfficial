using BUS_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FAddStudent : Form
    {
        public FAddStudent()
        {
            InitializeComponent();
        }

        // Get Gender
        public string GetGender ()
        {
            string gender = "";
            if (guna2CustomRadioButtonFemale.Checked)
            {
                gender = "Female";
            } else if (guna2CustomRadioButtonMale.Checked)
            {
                gender = "Male";
            }
            return gender;
        }

        // Check indentity card number
        private void guna2TextBoxIC_Leave(object sender, EventArgs e)
        {
            string id = guna2TextBoxIC.Text;
            if (id.Length != 12)
            {
                MessageBox.Show("Indetity Card have only 12 characters");
                guna2TextBoxIC.Focus();
            } else
            {
                guna2TextBoxID.Text = "HV"+id;
                guna2TextBoxFullName.Focus();
            }
        }

        // Click on Save Button
        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {   
            string gender = GetGender();
            string identityCard = guna2TextBoxIC.Text;
            string fullName = guna2TextBoxFullName.Text;
            string phone = guna2TextBoxPhone.Text;
            string birthday = guna2DateTimePickerBirth.Value.ToString("yyyy/MM/dd");
            string address = guna2TextBoxAddress.Text;
            string email = guna2TextBoxEmail.Text;
            string username = "HV" + identityCard;
            string password = BUS_RelatedToSendEmail.CreateStringRadom(8);
            string emailSubject = "Your Account Login Information";
            string emailBody = $@"
            Dear {fullName},

            We hope this email finds you well.

            As requested, we are sending you the login credentials for your account. Please find your details below:

            Username: {username}
            Password: {password}

            Please ensure to keep this information secure and do not share it with anyone. If you have any questions or concerns, feel free to reach out to our customer support team.

            Best regards,
            [Gia Bảo]
            ";


            bool isAdded = BUS_RelatedToEmployee.Instance.AddNewStudent(new Object [] { identityCard, fullName, gender , birthday, phone, address, email, password }, "HV");
            if (isAdded) {
                BUS_RelatedToSendEmail.SendEmailToUser(email, emailSubject, emailBody);
                MessageBox.Show("Successfully");
            } else
            {
                MessageBox.Show("Data is not valid");
            }
        }
    }
}
