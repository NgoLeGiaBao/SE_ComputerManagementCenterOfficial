﻿using BUS_ComputerManagementCenter;
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
    public partial class FEditTeacher : Form
    {
        public FEditTeacher()
        {
            InitializeComponent();
        }
        

        public string GetGender()
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


        private void FEditTeacher_Load(object sender, EventArgs e)
        {

            guna2TextBoxID.Text = DTO_Teacher.TeacherChoosen.Id;
            guna2TextBoxIC.Text = DTO_Teacher.TeacherChoosen.IdCard;
            guna2TextBoxFullName.Text = DTO_Teacher.TeacherChoosen.FullName;
            guna2TextBoxPhone.Text = DTO_Teacher.TeacherChoosen.TelephoneNumber;
            
            if (DTO_Teacher.TeacherChoosen.Sex == "Female")
            {
                guna2CustomRadioButtonFemale.Checked = true;
            }
            else
            {
                guna2CustomRadioButtonMale.Checked = true;
            }
            
            guna2DateTimePickerBirth.Value = DTO_Teacher.TeacherChoosen.Date;
            guna2TextBoxAddress.Text = DTO_Teacher.TeacherChoosen.Address;
            guna2TextBoxEmail.Text = DTO_Teacher.TeacherChoosen.EmailAddress;
            guna2TextBoxAcademic.Text = DTO_Teacher.TeacherChoosen.AcademicLevels;
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
            string academicLevel = guna2TextBoxAcademic.Text;

            if (guna2TextBoxFullName.Text == "" || guna2TextBoxEmail.Text == "" || guna2TextBoxAddress.Text == "" || guna2TextBoxPhone.Text == "" || guna2TextBoxAcademic.Text == "")
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

            bool isUpdated = BUS_RelatedToEmployee.Instance.UpdateTeacher(new object[] { identityCard, fullName, gender, birthday, phone, address, email, academicLevel });
            if (isUpdated)
            {
                FEs fEs = Application.OpenForms.OfType<FEs>().FirstOrDefault();
                if (fEs != null)
                {
                    fEs.RefreshPage();
                }
                MessageBox.Show("Update teacher successfully");
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
            this.Close();
        }
    }
}
