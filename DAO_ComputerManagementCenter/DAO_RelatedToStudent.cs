using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_RelatedToStudent
    {
        private static DAO_RelatedToStudent instance;
        public static DAO_RelatedToStudent Instance
        {
            get { if (instance == null) instance = new DAO_RelatedToStudent(); return instance; }
            private set { instance = value; }
        }
    }
}
