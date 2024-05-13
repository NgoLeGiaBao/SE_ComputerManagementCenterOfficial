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

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FEditStudent : Form
    {
        public FEditStudent()
        {
            InitializeComponent();
        }


        private void FEditStudent_Load(object sender, EventArgs e)
        {
            guna2TextBoxID.Text = DTO_Person.PersonChoosen.Id;
            guna2TextBoxIC.Text = DTO_Person.PersonChoosen.IdCard;
            guna2TextBoxFullName.Text = DTO_Person.PersonChoosen.FullName;
            guna2TextBoxPhone.Text = DTO_Person.PersonChoosen.TelephoneNumber;
            if (DTO_Person.PersonChoosen.Sex == "Female")
            {
                guna2CustomRadioButtonFemale.Checked = true;
            } else
            {
                guna2CustomRadioButtonMale.Checked = true;
            }
            guna2DateTimePickerBirth.Value = DTO_Person.PersonChoosen.Date;
            guna2TextBoxAddress.Text = DTO_Person.PersonChoosen.Address;
            guna2TextBoxEmail.Text = DTO_Person.PersonChoosen.EmailAddress;
        }


        public string GetGender ()
        {
            if (guna2CustomRadioButtonFemale.Checked)
            {
                return "Female";
            }
            if (guna2CustomRadioButtonFemale.Checked)
            {
                return "Male";
            }
            return "";
        }

        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {
            string gender = GetGender();
            string identityCard = guna2TextBoxIC.Text;
            string fullName = guna2TextBoxFullName.Text;
            string phone = guna2TextBoxPhone.Text;
            string birthday = guna2DateTimePickerBirth.Value.ToString("yyyy/MM/dd");
            string address = guna2TextBoxAddress.Text;
            string email = guna2TextBoxEmail.Text;

            if (guna2TextBoxFullName.Text == "" || guna2TextBoxEmail.Text == "" || guna2TextBoxAddress.Text == "" || guna2TextBoxPhone.Text == "")
            {
                MessageBox.Show("Please fill all filed data");
                return;
            }

            if (phone.Length != 10)
            {
                MessageBox.Show("Telephone number only contains 10 characters");
                return;
            }

            if (!email.ToLower().EndsWith("@gmail.com"))
            {
                MessageBox.Show("Please enter format @gmail.com");
                return;
            }

            bool isUpdated = BUS_RelatedToEmployee.Instance.UpdateStudent(new object[] {identityCard, fullName, gender, birthday, phone, address, email});
            if (isUpdated)
            {
                FEs fEs = Application.OpenForms.OfType<FEs>().FirstOrDefault();
                if (fEs != null)
                {
                    fEs.RefreshPage();
                }
                MessageBox.Show("Update student successfully");
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
    }
}
