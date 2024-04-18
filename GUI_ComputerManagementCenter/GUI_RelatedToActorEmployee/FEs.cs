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


        // Process with all pages
        private void FEs_Load(object sender, EventArgs e)
        {
            LoadListTeacher();
            LoaListStudent();
            LoadListCourse();
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
                FAddStudent fAddStudent = new FAddStudent();
                fAddStudent.Show();
            }
            else if (page == "Teacher")
            {
               FAddTeacher fAddTeacher = new FAddTeacher();
                fAddTeacher.Show();
            }
            else
            {
                MessageBox.Show("Home");
            }
        }

        // When click on TextBox Search
        private void guna2TextBoxSearch_Click(object sender, EventArgs e)
        {
            guna2TextBoxSearch.Text = "";
        }

        // When leave on TextBox Search
        private void guna2TextBoxSearch_Leave(object sender, EventArgs e)
        {
            guna2TextBoxSearch.Text = "Search here";
        }


        // Process with teacher page
        // Load list teacher
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
        
        // Load list student
        public void LoaListStudent()
        {
            List<DTO_Student> list = BUS_RelatedToEmployee.Instance.GetListStudet();
            foreach (DTO_Student item in list)
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
                };
                guna2DataGridViewStudent.Rows.Add(rowValues);
            }
        }
        // Load list course
        public void LoadListCourse ()
        {
            for (int i = 0; i < 10; i++)
            {
                //flowLayoutPanel1.AutoScroll = true;

                //// Tạo một Guna2Panel mới và thiết lập một số thuộc tính
                //Guna2Panel guna2Panel1 = new Guna2Panel();
                //guna2Panel1.BackColor = Color.Blue;
                //guna2Panel1.FillColor = Color.Red;
                //guna2Panel1.Size = new Size(200, 500);
                //guna2Panel1.Margin = new Padding(10);
                //
                //// Thêm Guna2Panel vào FlowLayoutPanel
                //flowLayoutPanel1.Controls.Add(guna2Panel1);
            }
        }



        // Process with teacher page

        // Get ID teacher from row selected from datagridview teacher
        public string GetRowTeacherSelected()
        {
            int selectedIndex = guna2DataGridViewTeacher.SelectedRows[0].Index;
            string cellValueID = guna2DataGridViewTeacher.Rows[selectedIndex].Cells["ID"].Value.ToString();
            return cellValueID;
        }
        
        // Click Edit Teacher
        private void guna2ButtonEditTeacher_Click(object sender, EventArgs e)
        {
            DTO_Teacher.TeacherChoosen = BUS_RelatedToEmployee.Instance.GetTeacherByID(GetRowTeacherSelected());
            FEditTeacher fEditTeacher = new FEditTeacher();
            fEditTeacher.Show();
        }

        // Click DeleteTeacher
        private void guna2ButtonDeleteTeacher_Click(object sender, EventArgs e)
        {

        }

        // Process with student page
        // Get row selected from datagridview teacher
        public string GetRowStudentSelected()
        {
            int selectedIndex = guna2DataGridViewStudent.SelectedRows[0].Index;
            string cellValueID = guna2DataGridViewStudent.Rows[selectedIndex].Cells["StudentID"].Value.ToString();
            return cellValueID;
        }

        // Click Edit Student
        private void guna2ButtonEditStudent_Click(object sender, EventArgs e)
        {
           DTO_Student.PersonChoosen = BUS_RelatedToEmployee.Instance.GetStudentByID(GetRowStudentSelected());
            MessageBox.Show(DTO_Student.PersonChoosen.FullName);
            FEditStudent fEditStudent = new FEditStudent();
           fEditStudent.Show();
            
        }

        // Click Delete Student
        private void guna2ButtonDeleteStudent_Click(object sender, EventArgs e)
        {

        }
    }
}
