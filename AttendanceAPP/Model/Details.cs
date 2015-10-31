using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceAPP.Model
{
    class Details
    {
        public int  dateId { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public string LoginTime { get; set; }
        public string LoginRemark { get; set; }
        public string LogoutTime { get; set; }
        public string LogoutRemark { get; set; }
        public int Holiday { get; set; }
        public string HolidayRemark { get; set; }
    }
}
