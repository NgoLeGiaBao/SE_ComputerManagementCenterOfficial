using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using Guna.UI2.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Rectangle = iTextSharp.text.Rectangle;
using System.Drawing.Printing;
using GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher;
using GUI_ComputerManagementCenter.GUI_RelatedToLogin;

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
            LoadOverview();
            LoadListTeacher();
            LoadListStudent();
            LoadListCourse();
            LoadDataGridViewCommon();
        }
       

        // Process with datagridview common
        public void LoadDataGridViewCommon ()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Function", typeof(string));
            table.Rows.Add("Change Password");
            table.Rows.Add("Log out");
            guna2DataGridViewCommon.DataSource = table;
        }


         // Get quantity
        public void RefreshQuantity ()
        {
            LoadOverview ();    
            LoadListTeacher();
            LoadListStudent();
            LoadListCourse();
            LoadDataGridViewCommon();

            guna2DataGridViewCommon.Visible = false;
            string page = guna2TabControlEmployee.SelectedTab.Text;
            if (page == "Course")
            {
                guna2ButtonAdd.Text = "+ Add new course";
                labelQuanTity.Text = "All courses (" + BUS_RelatedToEmployee.Instance.GetQuality(page) + ")";
                guna2ButtonAdd.Visible = true;
                labelQuanTity.Visible = true;
                guna2TextBoxSearch.Visible = true;
                guna2TextBoxSearch.Text = "";
                guna2TextBoxSearch.PlaceholderText = "Search course here";
            }
            else if (page == "Student")
            {
                guna2ButtonAdd.Text = "+ Add new student";
                labelQuanTity.Text = "All students (" + BUS_RelatedToEmployee.Instance.GetQuality(page) + ")";
                guna2ButtonAdd.Visible = true;
                labelQuanTity.Visible = true;
                guna2TextBoxSearch.Visible = true;
                guna2TextBoxSearch.PlaceholderText = "Search student here";
                guna2TextBoxSearch.Text = "";

            }
            else if (page == "Teacher")
            {
                guna2ButtonAdd.Text = "+ Add new teacher";
                labelQuanTity.Text = "All teachers (" + BUS_RelatedToEmployee.Instance.GetQuality(page) + ")";
                guna2ButtonAdd.Visible = true;
                labelQuanTity.Visible = true;
                guna2TextBoxSearch.Visible = true;
                guna2TextBoxSearch.PlaceholderText = "Search teacher here";
                guna2TextBoxSearch.Text = "";
            }
            else
            {
                labelQuanTity.Text = "Overview";
                labelQuanTity.Visible = true;
                guna2ButtonAdd.Visible = false;
                guna2TextBoxSearch.Visible = false;
            }
        }


        // Selected index change
        private void guna2TabControlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshQuantity();
        }


        // Click into Button add
        private void guna2ButtonAdd_Click(object sender, EventArgs e)
        {
            string page = guna2TabControlEmployee.SelectedTab.Text;
            if (page == "Course")
            {
                FAddCourse fAddCourse = new FAddCourse();
                FBackGround fBackGround = new FBackGround();
                fBackGround.Show();
                fAddCourse.ShowDialog();
            }
            else if (page == "Student")
            {
                FAddStudent fAddStudent = new FAddStudent();
                FBackGround fBackGround = new FBackGround();
                fBackGround.Show();
                fAddStudent.ShowDialog();
            }
            else if (page == "Teacher")
            {
                FAddTeacher fAddTeacher = new FAddTeacher();
                FBackGround fBackGround = new FBackGround();
                fBackGround.Show();
                fAddTeacher.ShowDialog();
            }
            else
            {
                MessageBox.Show("Home");
            }
        }


        // Load chart
        public void LoadChart ()
        {
            List<string> list = BUS_RelatedToEmployee.Instance.GetDataForChart();
            int i = 0;
            
            chartSystemUser.Series["SeriesUserSystem"].Points.Clear();
            chartStatus.Series["SeriesCourseStatus"].Points.Clear();
            chartFiel.Series["SeriesFiled"].Points.Clear();

            if (list[i] == "0" && list[i + 1] == "0" && list[i+2] == "0" && list[i+3] == "0")
            {
                guna2PictureBoxNoData1.Visible = true;
            } else
            {
                guna2PictureBoxNoData1.Visible = false;
            }
            _ = list[i] != "0" ? chartSystemUser.Series["SeriesUserSystem"].Points.AddXY("Active T", list[i++]) : i++;
            _ = list[i] != "0" ? chartSystemUser.Series["SeriesUserSystem"].Points.AddXY("InActive T", list[i++]) : i++;
            _ = list[i] != "0" ? chartSystemUser.Series["SeriesUserSystem"].Points.AddXY("Active S", list[i++]) : i++;
            _ = list[i] != "0" ? chartSystemUser.Series["SeriesUserSystem"].Points.AddXY("InActive S", list[i++]) : i++;

            if (list[i] == "0" && list[i + 1] == "0" && list[i + 2] == "0")
            {
                guna2PictureBoxData2.Visible = true;
            } else
            {
                guna2PictureBoxData2.Visible = false;
            }
            _ = list[i] != "0" ? chartStatus.Series["SeriesCourseStatus"].Points.AddXY("Ended", list[i++]) : i++;
            _ = list[i] != "0" ? chartStatus.Series["SeriesCourseStatus"].Points.AddXY("On Going", list[i++]) : i++;
            _ = list[i] != "0" ? chartStatus.Series["SeriesCourseStatus"].Points.AddXY("Not yet", list[i++]) : i++;

            if (list[i] == "0" && list[i + 1] == "0" && list[i + 2] == "0")
            {
                guna2PictureBoxData3.Visible = true;
            } else
            {
                guna2PictureBoxData3.Visible = false;
            }
            _ = list[i] != "0" ? chartFiel.Series["SeriesFiled"].Points.AddXY("Word", list[i++]) : i++;
            _ = list[i] != "0" ? chartFiel.Series["SeriesFiled"].Points.AddXY("Powerpoint", list[i++]) : i++;
            _ = list[i] != "0" ? chartFiel.Series["SeriesFiled"].Points.AddXY("Excel", list[i++]) : i++;
        }


        // Process with teacher page
        // Load overview 
        public void LoadOverview ()
        {
            LoadChart();
            int i = 0;
            List<string> list = BUS_RelatedToEmployee.Instance.GetDataForDashBoard();
            labelAllStudent.Text = list[i++];   
            labelActiStudent.Text = list[i++];
            labelAllTeacher.Text = list[i++];
            labelAcTeacher.Text = list[i++];    
            labelAllCourse.Text = list[i++];    
            labelNewCourse.Text = list[i++];

            if (list[i] == "")
            {
                labelRevenues.Text = "0$";
                i++;
            } 
            else
            {
            labelRevenues.Text = list[i++]+"$";
            }

            if (list[i] == "")
            {
                labelAllRevenue.Text = "0$";
                i++;
            }
            else
            {
                labelAllRevenue.Text = list[i++]+"$";
            }
        }


        // Load list teacher
        public void LoadListTeacher ()
        {
            guna2DataGridViewTeacher.Rows.Clear();
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
            if (list.Count > 0)
            {
                if (BUS_RelatedToEmployee.Instance.GetStatusAccount(list[0].Id) == "0")
                {
                    guna2ButtonDeleteTeacher.Text = "Delete";
                }
                else
                {
                    guna2ButtonDeleteTeacher.Text = "Recover";
                }
            }
        }
        

        // Load list student
        public void LoadListStudent()
        {
            guna2DataGridViewStudent.Rows.Clear();
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
            if (list.Count > 0)
            {
                if (BUS_RelatedToEmployee.Instance.GetStatusAccount(list[0].Id) == "0")
                {
                    guna2ButtonDeleteStudent.Text = "Delete";
                }
                else
                {
                    guna2ButtonDeleteStudent.Text = "Recover";
                }
            }
            
        }


        // Load list course
        public void LoadListCourse ()
        {
            flowLayoutPanelCourse.Controls.Clear();
            BUS_RelatedToEmployee.Instance.UpdateCourseStatus();
            int k = 1;
            int i = 0;
            foreach (DTO_Course course in BUS_RelatedToEmployee.Instance.GetListCourse())
            {
                GetGuna2PanelCourse(course, i, k);
                if (k == 3)
                {
                    k = 1;
                }
                else
                {
                    k++;
                }
                i++;
            }
        }



        // Process with teacher page
        // Get ID teacher from row selected from datagridview teacher
        public string GetRowTeacherSelected()
        {
            if(guna2DataGridViewTeacher.Rows.Count > 0)
            {
                int selectedIndex = guna2DataGridViewTeacher.SelectedRows[0].Index;
                string cellValueID = guna2DataGridViewTeacher.Rows[selectedIndex].Cells["ID"].Value.ToString();
                return cellValueID;
            }
            return "";
        }
        

        // Click Edit Teacher
        private void guna2ButtonEditTeacher_Click(object sender, EventArgs e)
        {
            DTO_Teacher.TeacherChoosen = BUS_RelatedToEmployee.Instance.GetTeacherByID(GetRowTeacherSelected());
            FEditTeacher fEditTeacher = new FEditTeacher();
            FBackGround fBackGround = new FBackGround();
            fBackGround.Show();
            fEditTeacher.ShowDialog();
        }


        // Click DeleteTeacher
        private void guna2ButtonDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewTeacher.Rows.Count > 0)
            {
                DTO_Teacher.TeacherChoosen = BUS_RelatedToEmployee.Instance.GetTeacherByID(GetRowTeacherSelected());
                if (guna2ButtonDeleteTeacher.Text == "Delete")
                {
                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete teacher with ID " + DTO_Teacher.TeacherChoosen.Id + "?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        BUS_RelatedToEmployee.Instance.DeleteATeacher(DTO_Teacher.TeacherChoosen.Id);
                        MessageBox.Show("Delete a teacher successfully: " + DTO_Teacher.TeacherChoosen.Id);
                        this.RefreshPage();
                    }
                }
                else
                {
                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to recover teacher with ID " + DTO_Teacher.TeacherChoosen.Id + "?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        BUS_RelatedToEmployee.Instance.UpdateAccount(DTO_Teacher.TeacherChoosen.Id);
                        MessageBox.Show("Recover a teacher successfully: " + DTO_Teacher.TeacherChoosen.Id);
                        this.RefreshPage();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose a teacher in list to delete");
            }
        }



        // Process with student page
        // Get row selected from datagridview teacher
        public string GetRowStudentSelected()
        {
            if (guna2DataGridViewStudent.Rows.Count > 0)
            {
                int selectedIndex = guna2DataGridViewStudent.SelectedRows[0].Index;
                string cellValueID = guna2DataGridViewStudent.Rows[selectedIndex].Cells["StudentID"].Value.ToString();
                return cellValueID;
            }
            return "";
        }



        // Click Edit Student
        private void guna2ButtonEditStudent_Click(object sender, EventArgs e)
        {
            DTO_Student.PersonChoosen = BUS_RelatedToEmployee.Instance.GetStudentByID(GetRowStudentSelected());
            FBackGround fBackGround = new FBackGround();
            fBackGround.Show();
            FEditStudent fEditStudent = new FEditStudent();
            fEditStudent.ShowDialog();     
        }


        // Click Delete Student
        public void GetGuna2PanelCourse (DTO_Course course, int i, int k)
        {
            Guna2Panel guna2PanelCourse = new Guna2Panel();
            Guna2Panel guna2PanelDetailCourse = new Guna2Panel();
            Label labelInforCourse = new Label();
            Label labelIDCourse = new Label();
            Guna2Button guna2ButtonViewCourse = new Guna2Button();
            Guna2Button guna2ButtonDeleteCourse = new Guna2Button();
            Guna2Button guna2ButtonSatus = new Guna2Button();
            Guna2Panel guna2PanelCoverPicture = new Guna2Panel();
            Guna2PictureBox guna2PictureBoxCourse = new Guna2PictureBox();

            guna2PanelCourse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            guna2PanelCourse.BorderRadius = 6;
            guna2PanelCourse.BorderThickness = 1;
            guna2PanelCourse.Controls.Add(guna2ButtonSatus);
            guna2PanelCourse.Controls.Add(guna2PanelDetailCourse);
            guna2PanelCourse.Controls.Add(guna2PanelCoverPicture);
            guna2PanelCourse.FillColor = System.Drawing.Color.White;
            guna2PanelCourse.Location = new System.Drawing.Point(0, 0);
            guna2PanelCourse.Margin = new System.Windows.Forms.Padding(0);
            guna2PanelCourse.Name = "guna2PanelCourse";
            guna2PanelCourse.Size = new System.Drawing.Size(400, 217);
            guna2PanelCourse.TabIndex = 0;

            // guna2PanelDetailCourse
            guna2PanelDetailCourse.Controls.Add(guna2ButtonDeleteCourse);
            guna2PanelDetailCourse.Controls.Add(guna2ButtonViewCourse);
            guna2PanelDetailCourse.Controls.Add(labelInforCourse);
            guna2PanelDetailCourse.Controls.Add(labelIDCourse);
            guna2PanelDetailCourse.Location = new System.Drawing.Point(120, 10);
            guna2PanelDetailCourse.Name = "guna2PanelDetailCourse";
            guna2PanelDetailCourse.Size = new System.Drawing.Size(272, 217);
            guna2PanelDetailCourse.TabIndex = 1;

            // labelInforCourse
            labelInforCourse.Font = new System.Drawing.Font("Poppins", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInforCourse.Location = new System.Drawing.Point(0, 35);
            labelInforCourse.Name = "labelInforCourse";
            labelInforCourse.Size = new System.Drawing.Size(272, 115);
            labelInforCourse.TabIndex = 1;
            labelInforCourse.Text = course.CourseName;
            labelInforCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // labelIDCourse
            labelIDCourse.AutoSize = true;
            labelIDCourse.Location = new System.Drawing.Point(0, 0);
            labelIDCourse.Name = "labelIDCourse";
            labelIDCourse.Size = new System.Drawing.Size(57, 35);
            labelIDCourse.TabIndex = 0;
            labelIDCourse.Text = course.CourseID;
            
            // guna2ButtonViewCourse
            guna2ButtonViewCourse.BorderRadius = 6;
            guna2ButtonViewCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonViewCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonViewCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            guna2ButtonViewCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            guna2ButtonViewCourse.FillColor = System.Drawing.Color.Black;
            guna2ButtonViewCourse.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2ButtonViewCourse.ForeColor = System.Drawing.Color.White;
            guna2ButtonViewCourse.Location = new System.Drawing.Point(0, 156);
            guna2ButtonViewCourse.Name = "guna2ButtonViewCourse";
            guna2ButtonViewCourse.Size = new System.Drawing.Size(171, 41);
            guna2ButtonViewCourse.TabIndex = 2;
            guna2ButtonViewCourse.Text = "View and Edit";
            guna2ButtonViewCourse.Tag = course;
            guna2ButtonViewCourse.Click += new EventHandler(guna2ButtonViewCourse_Click);

            // guna2ButtonDeleteCourse
            guna2ButtonDeleteCourse.BorderRadius = 6;
            guna2ButtonDeleteCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonDeleteCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonDeleteCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            guna2ButtonDeleteCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            guna2ButtonDeleteCourse.FillColor = System.Drawing.Color.Black;
            guna2ButtonDeleteCourse.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2ButtonDeleteCourse.ForeColor = System.Drawing.Color.White;
            guna2ButtonDeleteCourse.Location = new System.Drawing.Point(176, 156);
            guna2ButtonDeleteCourse.Name = "guna2ButtonDeleteCourse";
            guna2ButtonDeleteCourse.Size = new System.Drawing.Size(91, 41);
            guna2ButtonDeleteCourse.TabIndex = 3;
            guna2ButtonDeleteCourse.Text = "Delete";
            guna2ButtonDeleteCourse.Tag = course;
            guna2ButtonDeleteCourse.Click += new EventHandler(guna2ButtonDeleteCourse_Click);
            
            // guna2ButtonSatus 
            guna2ButtonSatus.BorderRadius = 6;
            guna2ButtonSatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonSatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonSatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            guna2ButtonSatus.FillColor = System.Drawing.Color.Lime;
            guna2ButtonSatus.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2ButtonSatus.ForeColor = System.Drawing.Color.White;
            guna2ButtonSatus.Location = new System.Drawing.Point(10, 166);
            guna2ButtonSatus.Name = "guna2ButtonSatus";
            guna2ButtonSatus.Size = new System.Drawing.Size(105, 41);
            guna2ButtonSatus.TabIndex = 4;
            guna2ButtonSatus.Enabled = false;
            guna2ButtonSatus.TextAlign = (HorizontalAlignment)ContentAlignment.MiddleCenter;
            if (course.CourseStatus == 1)
            {
                guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.LightBlue ;
                guna2ButtonSatus.Text = "Not yet";
                
                guna2ButtonSatus.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

            }
            else if (course.CourseStatus == 2)
            {
                guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.LightGreen;
                guna2ButtonSatus.Text = "OnGoing";
                guna2ButtonDeleteCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            } else if (course.CourseStatus == 3)
            {
                guna2ButtonSatus.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
                guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.LightYellow;
                guna2ButtonSatus.Text = "Ended";
            }


            // guna2PanelCoverPicture
            guna2PanelCoverPicture.Controls.Add(guna2PictureBoxCourse);
            guna2PanelCoverPicture.Location = new System.Drawing.Point(10, 10);
            guna2PanelCoverPicture.Margin = new System.Windows.Forms.Padding(10);
            guna2PanelCoverPicture.Name = "guna2PanelCoverPicture";
            guna2PanelCoverPicture.Size = new System.Drawing.Size(105, 150);
            guna2PanelCoverPicture.TabIndex = 0;
      
            // guna2PictureBoxCourse
            guna2PictureBoxCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            guna2PictureBoxCourse.ImageRotate = 0F;
            guna2PictureBoxCourse.Location = new System.Drawing.Point(0, 0);
            guna2PictureBoxCourse.Name = "guna2PictureBoxCourse";
            guna2PictureBoxCourse.Size = new System.Drawing.Size(105, 150);
            guna2PictureBoxCourse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            guna2PictureBoxCourse.TabIndex = 0;
            guna2PictureBoxCourse.TabStop = false;

            if (course.SubjectID.StartsWith("ME"))
            {
                guna2PictureBoxCourse.Image = global::GUI_ComputerManagementCenter.Properties.Resources.B09PMFX3R2;

            }
            else if (course.SubjectID.StartsWith("MP"))
            {
                guna2PictureBoxCourse.Image = global::GUI_ComputerManagementCenter.Properties.Resources._61NYR5UwSyL__AC_UF1000_1000_QL80_;

            } else
            {
                guna2PictureBoxCourse.Image = global::GUI_ComputerManagementCenter.Properties.Resources._61zhCt7RBNL__SY466_;

            }

            if (i == 1)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            }
            else if (k != 2 && i > 2)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            } 
            else if (k == 2 && i > 2)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            }
            flowLayoutPanelCourse.Controls.Add(guna2PanelCourse);
        }


        // Click view course
        private void guna2ButtonViewCourse_Click(object sender, EventArgs e)
        {
            DTO_Course course = ((sender as Guna2Button).Tag as DTO_Course);
            DTO_Course.CourseChoosen = course;
            FEditCourse fEditCourse = new FEditCourse();
            FBackGround fBackGround = new FBackGround();
            fBackGround.Show();
            fEditCourse.ShowDialog();
        }
        

        // Click delete course
        private void guna2ButtonDeleteCourse_Click (object sender, EventArgs e)
        {
            DTO_Course course = ((sender as Guna2Button).Tag as DTO_Course);
            if (course.CourseStatus == 1)
            {
                BUS_RelatedToEmployee.Instance.DeleteACourse(course.CourseID);
                MessageBox.Show("You deleted " + course.CourseName + "course successfully!");
                this.RefreshPage();
            }
            else if (course.CourseStatus == 2)
            {
                MessageBox.Show("You could not delete a course on going");
            }
            else
            {
                MessageBox.Show("You could not delete a course ending up");
            }
        }


        // Click on delete student
        private void guna2ButtonDeleteStudent_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewStudent.Rows.Count > 0)
            {
                DTO_Person.PersonChoosen = BUS_RelatedToEmployee.Instance.GetStudentByID(GetRowStudentSelected());
                if (guna2ButtonDeleteStudent.Text == "Delete")
                {
                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete student with ID " + DTO_Person.PersonChoosen.Id + "?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        BUS_RelatedToEmployee.Instance.DeleteAStudent(DTO_Person.PersonChoosen.Id);
                        MessageBox.Show("Delete a student successfully: " + DTO_Person.PersonChoosen.Id);
                        this.RefreshPage();
                    }
                }
                else
                {
                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to recover student with ID " + DTO_Person.PersonChoosen.Id + "?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        BUS_RelatedToEmployee.Instance.UpdateAccount(DTO_Person.PersonChoosen.Id);
                        MessageBox.Show("Recover a student successfully: " + DTO_Person.PersonChoosen.Id);
                        this.RefreshPage();
                    }
                }  
            }
            else
            {
                MessageBox.Show("Please choose a student in list to delete");
            }
        }


        // Reload page
        public void RefreshPage()
        {
            guna2DataGridViewStudent.Rows.Clear();
            guna2DataGridViewTeacher.Rows.Clear();
            flowLayoutPanelCourse.Controls.Clear();
            LoadOverview();
            LoadListStudent();
            LoadListTeacher();
            LoadListCourse();
            RefreshQuantity();
        }


        // Click button print
        private void guna2ButtonViewAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save Data as PDF";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        Rectangle pageSize = new Rectangle(800, 600);
                        Document document = new Document(pageSize, 20f, 20f, 10f, 10f);
                        PdfWriter.GetInstance(document, fs);
                        document.Open();

                        Paragraph header = new Paragraph("LIST STUDENT IN MANGEMENT COUMPUTER CENTER \n ", FontFactory.GetFont("Times New Roman", 18 + "", Font.Italic));
                        header.Alignment = Element.ALIGN_CENTER;
                        document.Add(header);

                        PdfPTable table = new PdfPTable(8); // Adjust the number of columns based on your data
                        table.WidthPercentage = 100f;

                        float[] columnWidths = new float[] { 110f, 100f, 40f, 60f, 65f, 80f, 80f, 150f }; // Adjust widths as needed
                        table.SetWidths(columnWidths);

                        for (int i = 0; i < guna2DataGridViewStudent.Columns.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(guna2DataGridViewStudent.Columns[i].HeaderText));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.FixedHeight = 20f;
                            table.AddCell(cell);
                        }

                        for (int i = 0; i < guna2DataGridViewStudent.Rows.Count; i++)
                        {
                            if (guna2DataGridViewStudent.Rows[i].IsNewRow) continue;
                            for (int j = 0; j < guna2DataGridViewStudent.Columns.Count; j++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(guna2DataGridViewStudent.Rows[i].Cells[j].Value?.ToString()));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = 20f;
                                table.AddCell(cell);
                            }
                        }
                        document.Add(table);
                        document.Close();
                        MessageBox.Show("Data exported to PDF successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to PDF: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Click circle picture
        private void guna2CirclePictureBoxAvatar_Click(object sender, EventArgs e)
        {
            guna2DataGridViewCommon.Visible = !guna2DataGridViewCommon.Visible;
        }


        // Click person name
        private void labelPersonalName_Click(object sender, EventArgs e)
        {
            guna2DataGridViewCommon.Visible = !guna2DataGridViewCommon.Visible;
        }


        // Click picture box
        private void guna2PictureBoxScroll_Click(object sender, EventArgs e)
        {
            guna2DataGridViewCommon.Visible = !guna2DataGridViewCommon.Visible;
        }


        // Click row in guna2DataGridViewCommon
        private void guna2DataGridViewCommon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = guna2DataGridViewCommon.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string cellValue = cell.Value.ToString();
            if (cellValue == "Change Password")
            {
                FChangePassword fChangePassword = new FChangePassword();
                FBackGround fBackGround = new FBackGround();    
                guna2DataGridViewCommon.Visible = false;
                fBackGround.Show();
                fChangePassword.ShowDialog();
            } 
            else
            {
                FLogin fLogin = new FLogin();
                fLogin.Show();
                this.Close();
            }
        }


        // Xuất danh sách giáo viên
        private void guna2ButtonSavePDFTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save Data as PDF";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        Rectangle pageSize = new Rectangle(800, 600); // Example: 800 points width, 600 points height
                        Document document = new Document(pageSize, 20f, 20f, 10f, 10f);
                        PdfWriter.GetInstance(document, fs);

                        document.Open();

                        Paragraph header = new Paragraph("LIST TEACHER IN MANGEMENT COUMPUTER CENTER \n ", FontFactory.GetFont("Times New Roman", 18 + "", Font.Italic));
                        header.Alignment = Element.ALIGN_CENTER;
                        document.Add(header);

                        PdfPTable table = new PdfPTable(9); // Adjust the number of columns based on your data
                        table.WidthPercentage = 100f;

                        float[] columnWidths = new float[] { 110f, 100f, 50f, 70f, 65f, 80f, 80f, 150f ,70f}; // Adjust widths as needed
                        table.SetWidths(columnWidths);

                        for (int i = 0; i < guna2DataGridViewTeacher.Columns.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(guna2DataGridViewTeacher.Columns[i].HeaderText));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.FixedHeight = 20f;
                            table.AddCell(cell);
                        }

                        for (int i = 0; i < guna2DataGridViewTeacher.Rows.Count; i++)
                        {
                            if (guna2DataGridViewTeacher.Rows[i].IsNewRow) continue;

                            for (int j = 0; j < guna2DataGridViewTeacher.Columns.Count; j++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(guna2DataGridViewTeacher.Rows[i].Cells[j].Value?.ToString()));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = 20f;
                                table.AddCell(cell);
                            }
                        }
                        document.Add(table);
                        document.Close();
                        MessageBox.Show("Data exported to PDF successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to PDF: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        // Mouse leave guan2DataGridViewCommon
        private void guna2DataGridViewCommon_MouseLeave(object sender, EventArgs e)
        {
            guna2DataGridViewCommon.Visible = false;
        }


        // Click icon right text box search
        private void guna2TextBoxSearch_IconRightClick(object sender, EventArgs e)
        {
            string page = guna2TabControlEmployee.SelectedTab.Text;
            string value = guna2TextBoxSearch.Text;
            if (page == "Student")
            {
                guna2DataGridViewStudent.Rows.Clear();
                List<DTO_Student> list = BUS_RelatedToEmployee.Instance.GetStudentBySearch(value);
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
            else if (page == "Teacher")
            {
                guna2DataGridViewTeacher.Rows.Clear();
                List<DTO_Teacher> list = BUS_RelatedToEmployee.Instance.GetTeachertBySearch(value);
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
            else if (page == "Course")
            {
                flowLayoutPanelCourse.Controls.Clear();
                int k = 1;
                int i = 0;
                foreach (DTO_Course course in BUS_RelatedToEmployee.Instance.GetListCourseBySearch(guna2TextBoxSearch.Text)) 
                {
                    GetGuna2PanelCourse(course, i, k);
                    if (k == 3)
                    {
                        k = 1;
                    }
                    else
                    {
                        k++;
                    }
                    i++;
                }
            }
        }


        // Refresh search student
        private void guna2ButtonRefreshSearchStudent_Click(object sender, EventArgs e)
        {
            guna2TextBoxSearch.PlaceholderText = "Search student here";
            guna2TextBoxSearch.Text = "";
            this.RefreshPage();
        }



        // Refresh search teacher
        private void guna2ButtonRefreshSearchTeacher_Click(object sender, EventArgs e)
        {
            guna2TextBoxSearch.PlaceholderText = "Search teacher here";
            guna2TextBoxSearch.Text = "";
            this.RefreshPage();
        }


        // Guan2DataGridViewStudent Click
        private void guna2DataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string studentID = GetRowStudentSelected();
            if (BUS_RelatedToEmployee.Instance.GetStatusAccount(studentID) == "0") {
                guna2ButtonDeleteStudent.Text = "Delete";
            } 
            else
            {
                guna2ButtonDeleteStudent.Text = "Recover";
            }
        }

        // Cick guna2DataGridViewTeacher Click
        private void guna2DataGridViewTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string teacherID = GetRowTeacherSelected();
            if (BUS_RelatedToEmployee.Instance.GetStatusAccount(teacherID) == "0")
            {
                guna2ButtonDeleteTeacher.Text = "Delete";
            }
            else
            {
                guna2ButtonDeleteTeacher.Text = "Recover";
            }
        }
    }
}
