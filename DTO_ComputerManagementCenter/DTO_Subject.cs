using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_Subject
    {
        private string subjectID;
        private string subjectName;
        private string subjectDescription;

        public DTO_Subject(string subjectID, string subjectName, string subjectDescription)
        {
            this.SubjectID = subjectID;
            this.SubjectName = subjectName;
            this.SubjectDescription = subjectDescription;
        }
        public DTO_Subject(DataRow dataRow)
        {
            this.subjectID = dataRow["MaMonHoc"].ToString();
            this.subjectName = dataRow["TenMonHoc"].ToString();
            this.subjectDescription = dataRow["MoTaMonHoc"].ToString();
        }
        public string SubjectID { get => subjectID; set => subjectID = value; }
        public string SubjectName { get => subjectName; set => subjectName = value; }
        public string SubjectDescription { get => subjectDescription; set => subjectDescription = value; }
    }
}
