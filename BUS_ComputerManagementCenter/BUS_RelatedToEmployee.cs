﻿using DAO_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BUS_ComputerManagementCenter
{
    public class BUS_RelatedToEmployee
    {
        private static BUS_RelatedToEmployee instance;
        public static BUS_RelatedToEmployee Instance
        {
            get { if (instance == null) instance = new BUS_RelatedToEmployee(); return instance; }
            private set { instance = value; }
        }

        //---Get----
        // Get student list
        public List<DTO_Student> GetListStudet()
        {
            List<DTO_Student> listStudent = new List<DTO_Student>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetListStudet();
            foreach (DataRow data in dataTable.Rows)
            {
                listStudent.Add(new DTO_Student(data));
            }
            return listStudent;
        }
        

        // Get course list
        public List<DTO_Course> GetListCourse()
        {
            List<DTO_Course> listCourse = new List<DTO_Course>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetListCourse();
            foreach (DataRow data in dataTable.Rows)
            {
                listCourse.Add(new DTO_Course(data));
            }
            return listCourse;
        }


        // Get course by search
        public List<DTO_Course> GetListCourseBySearch(string search)
        {
            List<DTO_Course> listCourse = new List<DTO_Course>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetCourseBySearch(search); 
            foreach (DataRow data in dataTable.Rows)
            {
                listCourse.Add(new DTO_Course(data));
            }
            return listCourse;
        }


        // Get student list
        public List<DTO_Teacher> GetListTeacher()
        {
            List<DTO_Teacher> listTeacher = new List<DTO_Teacher>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetListTeacher();
            foreach (DataRow data in dataTable.Rows)
            {
                listTeacher.Add(new DTO_Teacher(data));
            }
            return listTeacher;
        }
        

        // Get subject list
        public List<DTO_Subject> GetListSubject()
        {
            List<DTO_Subject> listSubject = new List<DTO_Subject>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetListSubject();
            foreach (DataRow data in dataTable.Rows)
            {
                listSubject.Add(new DTO_Subject(data));
            }
            return listSubject;
        }

        
        // Get subject id base on name subject
        public string GetSubjectIDBaseOnSubjectName(string subjectName)
        {
            return DAO_RelatedToEmployee.Instance.GetSubjecIDtBaseOnSubjectName(subjectName).ToString();
        }

        
        // Get shift 
        public DataTable GetListShift()
        {
            return DAO_RelatedToEmployee.Instance.GetListShift();
        }
        

        // Get lasted course id
        public string GetLastedCourseID()
        {
            return DAO_RelatedToEmployee.Instance.GetLastedCourseID().ToString();
        }

        
        // Get course by ID
        public DTO_Course GetCourseByID (string id)
        {
            DataRow dataRow = DAO_RelatedToEmployee.Instance.GetCourseByID(id).Rows[0];
            return new DTO_Course(dataRow);
        }


        // Get student by ID
        public DTO_Student GetStudentByID (string id)
        {
            if (DAO_RelatedToEmployee.Instance.GetStudentByID(id).Rows.Count > 0)
            {
                DataRow dataRow = DAO_RelatedToEmployee.Instance.GetStudentByID(id).Rows[0];
                return new DTO_Student(dataRow);
            }
            return null;
        }


        // Get student by course ID
        public List<DTO_Student> GetStudentByCourseID (string courseID)
        {
            List<DTO_Student> listStudent = new List<DTO_Student>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetListStudentByCourseID(courseID);
            foreach (DataRow data in dataTable.Rows)
            {
                listStudent.Add(new DTO_Student(data));
            }
            return listStudent;
        }


        // Get teacher by ID
        public DTO_Teacher GetTeacherByID (string id)
        {
            DataRow dataRow = DAO_RelatedToEmployee.Instance.GetTeacherByID(id).Rows[0];
            return new DTO_Teacher(dataRow);
        }


        // Get student by search and no exist
        public List<DTO_Student> GetStudentBySearchAndNoExist(string search, string exist)
        {
            List<DTO_Student> listStudent = new List<DTO_Student>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetStudentBySearchAndNoExist(search, exist);
            foreach (DataRow data in dataTable.Rows)
            {
                listStudent.Add(new DTO_Student(data));
            }
            return listStudent;
        }


        // Get student by search
        public List<DTO_Student> GetStudentBySearch(string search)
        {
            List<DTO_Student> listStudent = new List<DTO_Student>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetStudentBySearch(search);
            foreach (DataRow data in dataTable.Rows)
            {
                listStudent.Add(new DTO_Student(data));
            }
            return listStudent;
        }


        // Get teacher by search
        public List<DTO_Teacher> GetTeachertBySearch(string search)
        {
            List<DTO_Teacher> listTeacher = new List<DTO_Teacher>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetTeachertBySearch(search);
            foreach (DataRow data in dataTable.Rows)
            {
                listTeacher.Add(new DTO_Teacher(data));
            }
            return listTeacher;
        }


        // Get teacher by course id
        public DTO_Teacher GetTeacherByCourseID (string courseID)
        {
            DTO_Teacher teacher = null;
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetTeacherByCourseID(courseID);
            foreach (DataRow data in dataTable.Rows)
            {
                teacher = new DTO_Teacher(data);
            }
            return teacher;
        }


        // Get quantity 
        public string GetQuality (string type)
        {
            string result = DAO_RelatedToEmployee.Instance.GetQuantity(type).ToString();
            return result == "" ? "0": result;
        }


        // Get room
        public List<DTO_Room> GetRoom()
        {
            List<DTO_Room> listRoom = new List<DTO_Room>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetRoom();
            foreach (DataRow data in dataTable.Rows)
            {
                listRoom.Add(new DTO_Room(data));
            }
            return listRoom;
        }


        // Get room by course id
        public DTO_Room GetRoomByCourseID (string courseID)
        {
            DTO_Room room = null;
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetRoomByCourseID(courseID);
            foreach (DataRow data in dataTable.Rows)
            {
                room = new DTO_Room(data);
            }
            return room;
        }


        // Get data to give dashboard
        public List<string> GetDataForDashBoard()
        {
            List<string> data = new List<string>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetDataForDashBoard();
            foreach (DataRow dataRow  in dataTable.Rows) 
            {
                data.Add(dataRow["SoLuong"].ToString());    
            }
            return data;
        }


        // Get data to give chart
        public List<string> GetDataForChart()
        {
            List<string> data = new List<string>();
            DataTable dataTable = DAO_RelatedToEmployee.Instance.GetDataForChart();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                data.Add(dataRow["SoLuong"].ToString());
            }
            return data;
        }


        // Get status account 
        public string GetStatusAccount (string accountID)
        {
            return DAO_RelatedToEmployee.Instance.GetStatusAccount(accountID) == null ? "": DAO_RelatedToEmployee.Instance.GetStatusAccount(accountID).ToString();
        }

        //--Check--//
        // Check student exist
        public bool CheckExistStudentID (string id)
        {
            return DAO_RelatedToEmployee.Instance.GetStudentByID(id).Rows.Count > 0 ? true : false;
        }
        // Check teacher exist
        public bool CheckExistTeacherID(string id)
        {
            return DAO_RelatedToEmployee.Instance.GetTeacherByID(id).Rows.Count > 0 ? true : false;
        }
      
         //---Add----
         // Add a new student
        public bool AddNewStudent(object[] parameters, string obj)
        {
            return DAO_RelatedToEmployee.Instance.AddNewStudent(parameters, obj);
        }
        // Add a new course
        public bool AddNewCourse(object[] parameters)
        {
            return DAO_RelatedToEmployee.Instance.AddNewCourse(parameters);
        }
        // Add new teacher
        public bool AddNewTeacher(object[] parameters)
        {
            return DAO_RelatedToEmployee.Instance.AddNewTeacher(parameters);
        }
        // Add Course Teacher Detail
        public bool AddNewCourseTeacherDetail(object[] parameters)
        {
            return DAO_RelatedToEmployee.Instance.AddNewCourseTeacherDetail(parameters);
        }
        // Add Course Student Detail
        public bool AddNewCourseStudentDetail(object[] parameters)
        {
            return DAO_RelatedToEmployee.Instance.AddNewCourseStudentDetail(parameters);
        }

        //--Update--
        // Update student
        public bool UpdateStudent(object[] parameters)
        {
            return DAO_RelatedToEmployee.Instance.UpdateStudent(parameters);
        }
        // Update teacher
        public bool UpdateTeacher(object[] parameters)
        {
            return DAO_RelatedToEmployee.Instance.UpdateTeacher(parameters);
        }
        // Update course status
        public void UpdateCourseStatus()
        {
            DAO_RelatedToEmployee.Instance.UpdateCourseStatus();
        }
        // Update course
        public void UpdateCourse(object[] parameters)
        {
            DAO_RelatedToEmployee.Instance.UpdateCourse(parameters);
        }
        // Update account
        public void UpdateAccount (string accoutID)
        {
            DAO_RelatedToEmployee.Instance.UpdateAccount(accoutID);
        }
        //--Delete --
        public void DeleteACourse(string courseID)
        {
            DAO_RelatedToEmployee.Instance.DeleteACourse(courseID);
        }
        // Delete a student
        public void DeleteAStudent(string studentID)
        {
            DAO_RelatedToEmployee.Instance.DeleteAStudent(studentID);
        }
        // Delete a teacher
        public void DeleteATeacher(string teacherID)
        {
            DAO_RelatedToEmployee.Instance.DeleteATeacher(teacherID);
        }
    }    
}
