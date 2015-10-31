using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows.Forms;
using AttendanceAPP.Model;

namespace AttendanceAPP.DAL
{
    internal class StuffGateway
    {
        private string connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionLink"].ConnectionString;

        public List<Stuff> GetAllStuff()
        {
            string Query = @"select * from tbl_stuff";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Stuff> myStuffs = new List<Stuff>();
            while (reader.Read())
            {
                Stuff aStuff = new Stuff();
                aStuff.Username = reader["username"].ToString();
                aStuff.Password = reader["password"].ToString();
                aStuff.Name = reader["fullname"].ToString();
                aStuff.Id = int.Parse(reader["Id"].ToString());

                myStuffs.Add(aStuff);
            }
            reader.Close();
            connection.Close();

            return myStuffs;
        }

        public void GetAttendance(DateTime aDateTime, int id)
        {

            string Query = @"insert into tbl_attendance(userId,date) values('" + id + "','" + aDateTime + "')";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool CheckAttendance(DateTime time, int id)
        {
            string Query = @"select * from tbl_attendance where userId='" + id + "' and date='" + time + "'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            reader.Close();
            connection.Close();

            return count > 0;
        }

      

        public List<string> GetAttendanceList(int id, string firstDate, string lastDate)
        {
            string Query = @"select * from tbl_attendance where userId='" + id + "' AND date>='"+firstDate+"' AND date<='"+lastDate+"' ASC ";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<string> myDateList = new List<string>();
            while (reader.Read())
            {
                string date = reader["date"].ToString();
                myDateList.Add(date);
            }
            reader.Close();
            connection.Close();

            return myDateList;
        }

        public void SubmitAttendance(int i, string date)
        {
            string Query = @"insert into tbl_attendance(userId,date,holiday) values('" + i + "','" +date + "','"+0+"')";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        List<string>attendanceList=new List<string>(); 
        public int GetCurrentId(int id, string date)
        {
            string Query = @"select * from tbl_attendance where userId='"+id+"' and date='"+date+"'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();
            int mydateId = 0;
           

            while (reader.Read())
            {
                mydateId=Int32.Parse(reader["Id"].ToString());
          
            }
            reader.Close();
            connection.Close();

            return mydateId;
        }

        public void SubmitLogin(int id, DateTime time, string remark)
        {
            string Query = @"insert into tbl_login values('"+time.ToString()+"','"+remark+"','"+id+"')";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool CheckLogout(int date)
        {
            string Query = @"select * from tbl_logout where  dateId='" + date + "'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();
            bool result = false;
            while (reader.Read())
            {
                result = true;
            }
            reader.Close();
            connection.Close();
            return result;
        }

        public void LogoutSubmit(DateTime aDateTime, int id,string remarks)
        {
            string Query = @"insert into tbl_logout(logout_time,remarks,dateId) values('" + aDateTime.ToString() + "','" + remarks + "','" + id + "')";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            
        }

        public List<Details> GetAttendanceID(int stuffId, string firstDate, string lastDate)
        {

         string Query = @"select * from tbl_attendance where userId='" + stuffId + "' and date between '"+DateTime.Parse(firstDate)+"' and '"+DateTime.Parse(lastDate)+"' order by date asc";
            //string Query = @"select * from tbl_attendance where userId='" + stuffId + "' ";
           
            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();
            int mydateId = 0;

            List<Details> detailsList=new List<Details>();
         
            while (reader.Read())
            {
                Details aDetails=new Details();
                aDetails.dateId = Int32.Parse(reader["Id"].ToString());
                aDetails.Date = reader["date"].ToString();
                aDetails.Holiday =int.Parse( reader["holiday"].ToString());
                aDetails.HolidayRemark = reader["holidayRemark"].ToString();
                detailsList.Add(aDetails);

            }
            reader.Close();
            connection.Close();

            return detailsList;
        }

        public Details LoginGet(int id)
        {
            string Query = @"select * from tbl_login where dateId='" + id + "'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();
            int mydateId = 0;

            Details LoginDetails=new Details();
            while (reader.Read())
            {
                LoginDetails.LoginRemark = reader["remarks"].ToString();
                LoginDetails.LoginTime = reader["login_time"].ToString();

            }
            reader.Close();
            connection.Close();

            return LoginDetails;
        }

        public Details LogoutGet(int id)
        {
            string Query = @"select * from tbl_logout where dateId='" + id + "'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();
            int mydateId = 0;
            Details LogoutDetails =new Details();
            Details LoginDetails=new Details();
            while (reader.Read())
            {
                LogoutDetails.LogoutRemark = reader["remarks"].ToString();
                LogoutDetails.LogoutTime = reader["logout_time"].ToString();

            }
            reader.Close();
            connection.Close();

            return LogoutDetails;
        }

        public int SubmitHoliday(string holiday,string remark)
        {
            SubmitAttendanceHoliday(holiday,remark);

            if (ping > 0)
                return 1;
            else
                return 0;
        }

       
        private int ping; 
        private void SubmitAttendanceHoliday(string holiday,string remark)
        {
            List<Stuff> stuffList = GetAllStuff();
            List<int>stuffId=new List<int>();
            ping = 0;

            foreach (Stuff stuff in stuffList)
            {
                SubmitWithRemark(stuff.Id, holiday, remark);
                ping++;
            }
       
        }

        private void SubmitWithRemark(int stuffId,string holiday,string remark)
        {
            string Query = @"insert into tbl_attendance(userId,date,holiday,remark) values('" + stuffId + "','" + holiday + "','" + 0 + "','"+remark+"')";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        internal int CheckAttendanceByDate(DateTime dateTime)
        {
            string Query = @"select * from tbl_attendance where date='" + dateTime + "'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            SqlDataReader reader = command.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                count++;

            }
            reader.Close();
            connection.Close();

            return count;
        }

        public void UpdateHoliday(string date)
        {
            string Query = @"UPDATE tbl_attendance SET holiday='"+1+"' where date='"+date+"'";

            SqlConnection connection = new SqlConnection(connectionStrings);

            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);

            command.ExecuteNonQuery();
            connection.Close();

        }

       
    }
}
