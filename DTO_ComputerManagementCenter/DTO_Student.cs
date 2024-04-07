using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_Student : DTO_Person
    {
        // Constructor Student with full paramenter
        public DTO_Student(string id, string username, string idCard, string fullName, string sex, DateTime date, string telephoneNumber, string address, string emailAddress)
        {
            this.Id = id;
            this.Username = username;
            this.IdCard = idCard;
            this.FullName = fullName;
            this.Sex = sex;
            this.Date = date;
            this.TelephoneNumber = telephoneNumber;
            this.Address = address;
            this.EmailAddress = emailAddress;
        }
        // Constructor Student with datarow
        public DTO_Student(DataRow dataRow)
        {
            this.Id = dataRow["MaHocVien"].ToString();
            this.Username = dataRow["TenDangNhap"].ToString();
            this.IdCard = dataRow["SoCCCD"].ToString();
            this.FullName = dataRow["HoTen"].ToString();
            this.Sex = dataRow["GioiTinh"].ToString();
            this.Date = DateTime.Parse(dataRow["NgaySinh"].ToString());
            this.TelephoneNumber = dataRow["SoDienThoai"].ToString();
            this.Address = dataRow["DiaChi"].ToString();
            this.EmailAddress = dataRow["DiaChiEmail"].ToString();
        }

    }
}
