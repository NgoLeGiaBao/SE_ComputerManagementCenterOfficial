using DAO_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DataRow dataRow = DAO_RelatedToEmployee.Instance.GetStudentByID(id).Rows[0];
            return new DTO_Student(dataRow);
        }

        // Get teacher by ID
        public DTO_Teacher GetTeacherByID (string id)
        {
            DataRow dataRow = DAO_RelatedToEmployee.Instance.GetTeacherByID(id).Rows[0];
            return new DTO_Teacher(dataRow);
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
    }    
}
