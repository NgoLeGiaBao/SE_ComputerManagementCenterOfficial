using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FEs : Form
    {
        public FEs()
        {
            InitializeComponent();
        }

        private void FEs_Load(object sender, EventArgs e)
        {
            // Load list teacher
            LoadListTeacher();
        }

        // Load list student
        public void LoadListTeacher ()
        {
            List<DTO_Teacher> list = BUS_RelatedToEmployee.Instance.GetListTeacher();
            foreach (DTO_Teacher item in list)
            {
                object[] rowValues = new object[]
                {
                    item.Id,
                    item.FullName,
                    item.Sex,
                    item.Date.ToString("dd/MM/yyyy"),
                    item.TelephoneNumber,
                    item.IdCard,
                    item.Address,
                    item.EmailAddress,
                    item.AcademicLevels,
                };
                guna2DataGridViewTeacher.Rows.Add(rowValues);
            }    
        }


        // Selected index change
        private void guna2TabControlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string page = guna2TabControlEmployee.SelectedTab.Text;
            if (page == "Course")
            {
                guna2ButtonAdd.Text = "+ Add new course";
                guna2ButtonAdd.Visible = true;
            }
            else if (page == "Student")
            {
                guna2ButtonAdd.Text = "+ Add new student";
                guna2ButtonAdd.Visible = true;
            }
            else if (page == "Teacher")
            {
                guna2ButtonAdd.Text = "+ Add new teacher";
                guna2ButtonAdd.Visible = true;
            }
            else
            {
                guna2ButtonAdd.Visible = false;
            }
        }

        // Click into Button add
        private void guna2ButtonAdd_Click(object sender, EventArgs e)
        {
            string page = guna2TabControlEmployee.SelectedTab.Text;
            if (page == "Course")
            {
                MessageBox.Show("Course");
            }
            else if (page == "Student")
            {
                MessageBox.Show("Student");
            }
            else if (page == "Teacher")
            {
                MessageBox.Show("Teacher");
            }
            else
            {
                MessageBox.Show("Home");
            }
        }

        private void guna2TextBoxSearch_Click(object sender, EventArgs e)
        {
            guna2TextBoxSearch.Text = "";
        }
    }
}
