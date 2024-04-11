using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_Person
    {
        protected string id;
        protected string username;
        protected string idCard;
        protected string fullName;
        protected string sex;
        protected DateTime date;
        protected string telephoneNumber;
        protected string address;
        private string emailAddress;

        private static string idSession;

        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Date { get => date; set => date = value; }
        public string TelephoneNumber { get => telephoneNumber; set => telephoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public static string IDSession { get => IdSession; set => IdSession = value; }
        protected string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public static string IdSession { get => idSession; set => idSession = value; }
    }
}
