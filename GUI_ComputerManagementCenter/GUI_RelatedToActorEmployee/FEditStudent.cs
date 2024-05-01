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

        // Get gender
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

            bool isUpdated = BUS_RelatedToEmployee.Instance.UpdateStudent(new object[] {identityCard, fullName, gender, birthday, phone, address, email});
            if (isUpdated)
            {
                // Tạo một tham chiếu đến form FEs nếu cần thiết
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
            this.Close();   
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form fBackground = Application.OpenForms["FBackGround"];
            fBackground.Hide();
         
        }
    }
}
