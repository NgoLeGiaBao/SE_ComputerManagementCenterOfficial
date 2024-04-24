using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_ComputerManagementCenter
{
    public class BUS_RelatedToStudent
    {
        // Singleton design pattern
        private static BUS_RelatedToStudent instance;
        public static BUS_RelatedToStudent Instance
        {
            get { if (instance == null) { instance = new BUS_RelatedToStudent(); } return instance; }
            private set { instance = value; }
        }
    }
}
