﻿using BUS_ComputerManagementCenter;
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
            LoadListStudent();
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
                FAddCourse fAddCourse = new FAddCourse();
                fAddCourse.Show();
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
        public void LoadListStudent()
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

        public void GetGuna2PanelCourse (DTO_Course course, int i, int k)
        {

            // guna2PanelCourse
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
            // 
            guna2PanelDetailCourse.Controls.Add(guna2ButtonDeleteCourse);
            guna2PanelDetailCourse.Controls.Add(guna2ButtonViewCourse);
            guna2PanelDetailCourse.Controls.Add(labelInforCourse);
            guna2PanelDetailCourse.Controls.Add(labelIDCourse);
            guna2PanelDetailCourse.Location = new System.Drawing.Point(120, 10);
            guna2PanelDetailCourse.Name = "guna2PanelDetailCourse";
            guna2PanelDetailCourse.Size = new System.Drawing.Size(272, 217);
            guna2PanelDetailCourse.TabIndex = 1;
            //

            // labelInforCourse
            // 
            labelInforCourse.Font = new System.Drawing.Font("Poppins", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInforCourse.Location = new System.Drawing.Point(0, 35);
            labelInforCourse.Name = "labelInforCourse";
            labelInforCourse.Size = new System.Drawing.Size(272, 115);
            labelInforCourse.TabIndex = 1;
            labelInforCourse.Text = course.CourseName;
            labelInforCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelIDCourse
            // 
            labelIDCourse.AutoSize = true;
            labelIDCourse.Location = new System.Drawing.Point(0, 0);
            labelIDCourse.Name = "labelIDCourse";
            labelIDCourse.Size = new System.Drawing.Size(57, 35);
            labelIDCourse.TabIndex = 0;
            labelIDCourse.Text = course.CourseID;
            

            // guna2ButtonViewCourse
            // 
            guna2ButtonViewCourse.BorderRadius = 6;
            guna2ButtonViewCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonViewCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonViewCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            guna2ButtonViewCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            guna2ButtonViewCourse.FillColor = System.Drawing.Color.Black;
            guna2ButtonViewCourse.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2ButtonViewCourse.ForeColor = System.Drawing.Color.White;
            guna2ButtonViewCourse.Location = new System.Drawing.Point(0, 156);
            guna2ButtonViewCourse.Name = "guna2ButtonViewCourse";
            guna2ButtonViewCourse.Size = new System.Drawing.Size(131, 41);
            guna2ButtonViewCourse.TabIndex = 2;
            guna2ButtonViewCourse.Text = "View and Edit";

            guna2ButtonViewCourse.Tag = course;
            guna2ButtonViewCourse.Click += new EventHandler(guna2ButtonViewCourse_Click);

            // 
            // guna2ButtonDeleteCourse
            // 
            guna2ButtonDeleteCourse.BorderRadius = 6;
            guna2ButtonDeleteCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonDeleteCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonDeleteCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            guna2ButtonDeleteCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            guna2ButtonDeleteCourse.FillColor = System.Drawing.Color.Black;
            guna2ButtonDeleteCourse.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2ButtonDeleteCourse.ForeColor = System.Drawing.Color.White;
            guna2ButtonDeleteCourse.Location = new System.Drawing.Point(141, 156);
            guna2ButtonDeleteCourse.Name = "guna2ButtonDeleteCourse";
            guna2ButtonDeleteCourse.Size = new System.Drawing.Size(131, 41);
            guna2ButtonDeleteCourse.TabIndex = 3;
            guna2ButtonDeleteCourse.Text = "Delete";
            // 
            // guna2ButtonSatus
            // 
            guna2ButtonSatus.BorderRadius = 6;
            guna2ButtonSatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            guna2ButtonSatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            //guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            guna2ButtonSatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            guna2ButtonSatus.FillColor = System.Drawing.Color.Lime;
            guna2ButtonSatus.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            guna2ButtonSatus.ForeColor = System.Drawing.Color.White;
            guna2ButtonSatus.Location = new System.Drawing.Point(10, 166);
            guna2ButtonSatus.Name = "guna2ButtonSatus";
            guna2ButtonSatus.Size = new System.Drawing.Size(105, 41);
            guna2ButtonSatus.TabIndex = 4;
            guna2ButtonSatus.Enabled = false;

            guna2ButtonSatus.TextAlign = (HorizontalAlignment)ContentAlignment.MiddleCenter;
            if (course.CourseStatus == 0)
            {
                guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.LightGray;
                guna2ButtonSatus.Text = "Not yet started";
                
                guna2ButtonSatus.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

            }
            else if (course.CourseStatus == 1)
            {
                guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.LightGreen;
                guna2ButtonSatus.Text = "OnGoing";
            } else if (course.CourseStatus == 2)
            {
                guna2ButtonSatus.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
                guna2ButtonSatus.DisabledState.FillColor = System.Drawing.Color.LightSkyBlue;
                guna2ButtonSatus.Text = "Ended";
            }


            // 
            // guna2PanelCoverPicture
            // 


            guna2PanelCoverPicture.Controls.Add(guna2PictureBoxCourse);
            guna2PanelCoverPicture.Location = new System.Drawing.Point(10, 10);
            guna2PanelCoverPicture.Margin = new System.Windows.Forms.Padding(10);
            guna2PanelCoverPicture.Name = "guna2PanelCoverPicture";
            guna2PanelCoverPicture.Size = new System.Drawing.Size(105, 150);
            guna2PanelCoverPicture.TabIndex = 0;
            // 


            // guna2PictureBoxCourse
            // 
            guna2PictureBoxCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            guna2PictureBoxCourse.Image = global::GUI_ComputerManagementCenter.Properties.Resources.course_1;
            guna2PictureBoxCourse.ImageRotate = 0F;
            guna2PictureBoxCourse.Location = new System.Drawing.Point(0, 0);
            guna2PictureBoxCourse.Name = "guna2PictureBoxCourse";
            guna2PictureBoxCourse.Size = new System.Drawing.Size(105, 150);
            guna2PictureBoxCourse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            guna2PictureBoxCourse.TabIndex = 0;
            guna2PictureBoxCourse.TabStop = false;
            // 
            if (i == 1)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            }
            else if (k != 2 && i > 2)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            } else if (k == 2 && i > 2)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            }

            flowLayoutPanelCourse.Controls.Add(guna2PanelCourse);

        }

        private void guna2ButtonViewCourse_Click(object sender, EventArgs e)
        {
            DTO_Course course = ((sender as Guna2Button).Tag as DTO_Course);
            MessageBox.Show(course.CourseID.ToString());
        }


        public void RefreshPage()
        {
            guna2DataGridViewStudent.Rows.Clear();
            guna2DataGridViewTeacher.Rows.Clear();
            flowLayoutPanelCourse.Controls.Clear();
            LoadListStudent();
            LoadListTeacher();
            LoadListCourse();
        }

        private void guna2ButtonViewAndPrint_Click(object sender, EventArgs e)
        {

            try
            {
                // Create a SaveFileDialog instance
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save Data as PDF";

                // Show the dialog and check for user confirmation
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Create and use the file stream within a using block for proper resource management
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // Create a new PDF document with desired margins and orientation
                        Rectangle pageSize = new Rectangle(800, 600); // Example: 800 points width, 600 points height
                        Document document = new Document(pageSize, 20f, 20f, 10f, 10f);
                        PdfWriter.GetInstance(document, fs);

                        document.Open();

                        // Add a header with bold font, centered alignment, custom font family, and larger font size
                        Paragraph header = new Paragraph("DANH SÁCH HỌC VIÊN", FontFactory.GetFont("Times New Roman", 18 + "", Font.Italic));
                        header.Alignment = Element.ALIGN_CENTER;
                        document.Add(header);

                        // Add a table with alternating row colors, centered content, and different column widths
                        PdfPTable table = new PdfPTable(8); // Adjust the number of columns based on your data
                        table.WidthPercentage = 100f;

                        // Set column widths
                        float[] columnWidths = new float[] { 110f, 100f, 40f, 60f, 65f, 80f, 80f, 150f }; // Adjust widths as needed
                        table.SetWidths(columnWidths);

                        // Add table header row with background color, bold font, and centered alignment
                        for (int i = 0; i < guna2DataGridViewStudent.Columns.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(guna2DataGridViewStudent.Columns[i].HeaderText));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            //cell.Font = FontFactory.GetFont("Times New Roman", 12, Font.BOLD);
                            cell.FixedHeight = 50f;
                            table.AddCell(cell);
                        }

                        // Add table data rows with alternating colors and centered content
                        bool alternateColor = false;
                        for (int i = 0; i < guna2DataGridViewStudent.Rows.Count; i++)
                        {
                            if (guna2DataGridViewStudent.Rows[i].IsNewRow) continue;

                            for (int j = 0; j < guna2DataGridViewStudent.Columns.Count; j++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(guna2DataGridViewStudent.Rows[i].Cells[j].Value?.ToString()));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = 50f;

                                //cell.Font = FontFactory.GetFont("Times New Roman", 10, Font.NORMAL);
                                if (alternateColor)
                                {
                                    cell.BackgroundColor = BaseColor.BLUE;
                                }
                                else
                                {
                                    cell.BackgroundColor = BaseColor.WHITE;
                                }
                                alternateColor = !alternateColor;
                                table.AddCell(cell);
                            }
                        }

                        // Add the table to the document
                        document.Add(table);

                        document.Close();

                        // Show success message with custom icon
                        MessageBox.Show("Data exported to PDF successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions during PDF creation
                MessageBox.Show("Error exporting data to PDF: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
