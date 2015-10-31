using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AttendanceAPP.DAL;
using AttendanceAPP.Model;

namespace AttendanceAPP.BLL
{
    class StuffManager
    {
        StuffGateway aStuffGateway=new StuffGateway();
        internal List<Model.Stuff> GetAllStuff()
        {
            return aStuffGateway.GetAllStuff();
        }

        public void AttendanceSubmit(DateTime aDateTime, int id, out string message)
        {
            if (aStuffGateway.CheckAttendance(aDateTime,id)==true)
            {
                message = "You cannot submit attendance more than one times a day";
            }
            else
            {
                aStuffGateway.GetAttendance(aDateTime, id);
                message = "Attendance Submitted";
            }
        }


       

        public List<string> GetStuffAttendanceList(string name, string firstDate,string lastDate)
        {
            List<Stuff> stuffList = aStuffGateway.GetAllStuff();
            int id = 0;
            foreach (Stuff stuff in stuffList)
            {
                if (stuff.Name == name)
                {
                    id = stuff.Id;
                    break;
                }
            }
            List<string> dateList = aStuffGateway.GetAttendanceList(id, firstDate, lastDate);
            return dateList;


        }


       

        internal void submitAttendance(int p, string date)
        {
            aStuffGateway.SubmitAttendance(p,date);
        }

        public int getCurrentDateId(int id, string date)
        {
            return aStuffGateway.GetCurrentId(id,date);
        }

        public void SubmitLogin(int id, DateTime time, string remark)
        {
            aStuffGateway.SubmitLogin(id,time,remark);
        }

        public bool CheckAttendance(int id, string date)
        {
            
            return aStuffGateway.CheckAttendance(DateTime.Parse(date),id);
            
        }

        public bool LogOutSubmit(DateTime aDateTime, int id, out string message,string remarks)
        {
                int dateId = getCurrentDateId(id, aDateTime.ToString());
            if (dateId != 0)
            {
                if (aStuffGateway.CheckLogout(dateId))
                {
                    message = "You have already Logged out";

                    return false;
                }
                else
                {
                    aStuffGateway.LogoutSubmit(aDateTime, dateId, remarks);
                    message = "Logged out successfully";
                    return true;
                }
            }
            else
            {
                message = "Submit the login First";
                return false;
            }
        }

        public List<Details> GetAttendanceList(int stuffId, string firstDate, string lastDate)
        {
            List<Details> AttendanceList = aStuffGateway.GetAttendanceID(stuffId, firstDate, lastDate);
            foreach (Details details in AttendanceList)
            {
                int id = details.dateId;
                Details loginDetails = aStuffGateway.LoginGet(id);
                Details logoutDetails = aStuffGateway.LogoutGet(id);
                details.LoginTime = loginDetails.LoginTime;
                details.LoginRemark = loginDetails.LoginRemark;
                details.LogoutRemark = logoutDetails.LogoutRemark;
                details.LogoutTime = logoutDetails.LogoutTime;

            }
            return AttendanceList;
        }


        public string SubmitHoliday(string date,string remark)
        {
            int count = aStuffGateway.SubmitHoliday(date,remark);

            if (count > 0)
                return "Holiday Submitted";
            else
            {
                return "Error Occured during holiday submission";
            }
        }

        public int CheckAttendanceByDate(string date)
        {
            int isExist = aStuffGateway.CheckAttendanceByDate(DateTime.Parse(date));

            return isExist;
        }

        public void UpdateHoliday(string date)
        {
            aStuffGateway.UpdateHoliday(date);
        }


    }
}
