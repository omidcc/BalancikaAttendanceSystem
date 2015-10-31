using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceAPP.Model
{
    class Attendance
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string LoginRemarks { get; set; }
        public string LogoutRemarks { get; set; }

        public int DateId { get; set; }
        public int HolyDayCheker { get; set; }
        public string Holiday { get; set; }
        public string HolidayRemark { get; set; }
    }
}
