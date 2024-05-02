﻿using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher;
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
using System.Windows.Markup;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorStudent
{
    public partial class FStudent : Form
    {
        public FStudent()
        {
            InitializeComponent();
            LoadListCourse();
            //LoadAttendance();
        }

        //private void LoadAttendance ()
        //{
        //    guna2DataGridView1.ColumnCount = 12; // Số lượng cột
        //
        //    // Đặt tên cho các cột
        //    for (int i = 0; i < 6; i++)
        //    {
        //        guna2DataGridView1.Columns[i].HeaderText = "Column" + (i + 1);
        //    }
        //
        //    // Tạo dữ liệu mẫu
        //    List<string> data = new List<string>();
        //    for (int i = 0; i < 10; i++) // Số lượng dòng
        //    {
        //        string rowData = ""; // Khởi tạo dữ liệu cho dòng
        //        for (int j = 0; j < 6; j++) // Số lượng cột
        //        {
        //            rowData += $"Data_{i + 1}_{j + 1} "; // Dữ liệu mẫu
        //        }
        //        data.Add(rowData.Trim()); // Thêm dữ liệu dòng vào danh sách
        //    }
        //
        //    // Thêm dữ liệu vào Guna2DataGridView
        //    foreach (string row in data)
        //    {
        //        string[] values = row.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //        int rowIndex = guna2DataGridView1.Rows.Add(values);
        //
        //        // Nếu số lượng cột trên mỗi dòng lớn hơn 6, thêm một dòng mới
        //        while (guna2DataGridView1.Rows[rowIndex].Cells.Count < 6)
        //        {
        //            guna2DataGridView1.Rows[rowIndex].Cells.Add(new DataGridViewTextBoxCell());
        //        }
        //    }
        //}
        public void GetGuna2PanelCourse(DTO_Course course, int i, int k)
        {

            // guna2PanelCourse
            Guna2Panel guna2PanelCourse = new Guna2Panel();
            Guna2Panel guna2PanelDetailCourse = new Guna2Panel();
            Label labelInforCourse = new Label();
            Label labelIDCourse = new Label();
            Guna2Button guna2ButtonViewCourse = new Guna2Button();
            //Guna2Button guna2ButtonDeleteCourse = new Guna2Button();
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
            //guna2PanelDetailCourse.Controls.Add(guna2ButtonDeleteCourse);
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
            guna2ButtonViewCourse.Size = new System.Drawing.Size(272, 41);
            guna2ButtonViewCourse.TabIndex = 2;
            guna2ButtonViewCourse.Text = "View Detail Course";

            guna2ButtonViewCourse.Tag = course;
            guna2ButtonViewCourse.Click += new EventHandler(guna2ButtonViewCourse_Click);

            // 
            // guna2ButtonDeleteCourse
            // 
            //guna2ButtonDeleteCourse.BorderRadius = 6;
            //guna2ButtonDeleteCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            //guna2ButtonDeleteCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            //guna2ButtonDeleteCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            //guna2ButtonDeleteCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            //guna2ButtonDeleteCourse.FillColor = System.Drawing.Color.Black;
            //guna2ButtonDeleteCourse.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //guna2ButtonDeleteCourse.ForeColor = System.Drawing.Color.White;
            //guna2ButtonDeleteCourse.Location = new System.Drawing.Point(141, 156);
            //guna2ButtonDeleteCourse.Name = "guna2ButtonDeleteCourse";
            //guna2ButtonDeleteCourse.Size = new System.Drawing.Size(131, 41);
            //guna2ButtonDeleteCourse.TabIndex = 3;
            //guna2ButtonDeleteCourse.Text = "Delete";
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
            }
            else if (course.CourseStatus == 2)
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
            }
            else if (k == 2 && i > 2)
            {
                guna2PanelCourse.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            }

            flowLayoutPanelCourse.Controls.Add(guna2PanelCourse);
        }
        private void guna2ButtonViewCourse_Click(object sender, EventArgs e)
        {
            DTO_Course course = ((sender as Guna2Button).Tag as DTO_Course);
            
            
            //FCourseDetail detail = new FCourseDetail();

            //FBackGround fBackGround = new FBackGround();
            DTO_Course.CourseChoosen = course;

            //fBackGround.Show();
            //detail.ShowDialog();

            FCourseInformation fCourseInf = new FCourseInformation();
            fCourseInf.Show();
        }

        public void LoadListCourse()
        {
            int k = 1;
            int i = 0;
            foreach (DTO_Course course in BUS_RelatedToStudent.Instance.GetCourseByStudentID(DTO_Person.IDSession))
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
}
