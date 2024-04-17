﻿using BUS_ComputerManagementCenter;
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
            string id = guna2TextBoxIC.Text;
            if (id.Length != 12)
            {
                MessageBox.Show("Indetity Card have only 12 characters");
                guna2TextBoxIC.Focus();
            }
            else
            {
                if (BUS_RelatedToEmployee.Instance.CheckExistTeacherID("GV" + id))
                {
                    MessageBox.Show("ID existed");
                    guna2TextBoxIC.Focus();
                }
                else
                {
                    guna2TextBoxID.Text = "HV" + id;
                    guna2TextBoxFullName.Focus();
                    //MessageBox.Show("");
                }
            }
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
            }
            else
            {
                MessageBox.Show("Data is not valid");
            }
        }
    }
}
