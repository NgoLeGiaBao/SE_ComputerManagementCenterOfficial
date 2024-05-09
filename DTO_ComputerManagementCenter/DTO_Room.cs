using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_Room
    {
        
        private string roomID;
        private string roomName;
        private static DTO_Room roomChoosen;

        public DTO_Room (string roomID, string roomName)
        {
            this.RoomID = roomID;
            this.RoomName = roomName;
        }
        public DTO_Room (DataRow data)
        {
            this.RoomID = data["MaPhongHoc"].ToString();
            this.RoomName = data["TenPhongHoc"].ToString();
        }
        public string RoomID { get => roomID; set => roomID = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public static DTO_Room RoomChoosen { get => roomChoosen; set => roomChoosen = value; }
    }
}
