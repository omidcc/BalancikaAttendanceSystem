using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
            string Query = @"select * from tbl_attendance where userId='" + id + "' AND date>='"+firstDate+"' AND date<='"+lastDate+"' ";

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
            string Query = @"insert into tbl_attendance(userId,date) values('" + i + "','" + date + "')";

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
    }
}
