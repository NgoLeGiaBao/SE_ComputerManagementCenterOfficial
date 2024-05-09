using BUS_ComputerManagementCenter;
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

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FAddTeacher : Form
    {
        public FAddTeacher()
        {
            InitializeComponent();
        }
        public string GetGender()
        {
            string gender = "";
            if (guna2CustomRadioButtonFemale.Checked)
            {
                gender = "Female";
            }
            else if (guna2CustomRadioButtonMale.Checked)
            {
                gender = "Male";
            }
            return gender;
        }

        private void guna2TextBoxIC_Leave(object sender, EventArgs e)
        {
            guna2TextBoxID.Text = "GV" + guna2TextBoxIC.Text;
        }

        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {
            string id = guna2TextBoxIC.Text;
            if (id.Length == 0)
            {
                MessageBox.Show("Please enter indetity card");
                return;
            }
            else if (id.Length != 12)
            {
                MessageBox.Show("Indetity card have only 12 characters");
                return;

            }
            string gender = GetGender();
            string identityCard = guna2TextBoxIC.Text;
            string fullName = guna2TextBoxFullName.Text;
            string phone = guna2TextBoxPhone.Text;
            string birthday = guna2DateTimePickerBirth.Value.ToString("yyyy/MM/dd");
            string address = guna2TextBoxAddress.Text;
            string email = guna2TextBoxEmail.Text;
            string username = "GV" + identityCard;
            string academicLevel = guna2TextBoxAcademic.Text;
            string password = BUS_RelatedToSendEmail.CreateStringRadom(8);
            string emailSubject = "Your Account Login Information";
            string emailBody = BUS_RelatedToSendEmail.GetBodyEmailWithAccountInformation(username, password, fullName);


            bool isAdded = BUS_RelatedToEmployee.Instance.AddNewTeacher(new Object[] { identityCard, fullName, gender, birthday, phone, address, email, password, academicLevel });
            if (isAdded)
            {
                BUS_RelatedToSendEmail.SendEmailToUser(email, emailSubject, emailBody);
                MessageBox.Show("Successfully");
                // Tạo một tham chiếu đến form FEs nếu cần thiết
                FEs fEs = Application.OpenForms.OfType<FEs>().FirstOrDefault();
                if (fEs != null)
                {
                    fEs.RefreshPage();
                }
            }
            else
            {
                MessageBox.Show("Data is not valid");
            }
        }

        private void guna2ButtonCacel_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FBackGround)
                {
                    form.Hide();
                }
            }
            this.Close();   
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FBackGround)
                {
                    form.Hide();
                }
            }
        }

        private void FAddTeacher_Load(object sender, EventArgs e)
        {
            guna2CustomRadioButtonMale.Checked = true;
        }
    }
}
