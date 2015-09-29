using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceAPP.BLL;
using AttendanceAPP.Model;

namespace AttendanceAPP
{
    public partial class TemporaryAttendance : Form
    {
        public TemporaryAttendance()
        {
            InitializeComponent();
            GetStuffList();
        }
        StuffManager aStuffManager=new StuffManager();


        List<Stuff>  aStuffList = new List<Stuff>();

        public void GetStuffList()
        {
            aStuffList = aStuffManager.GetAllStuff();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            string remark = remarksTextBox.Text;
            string message = "Username & Password is incorrect!";
            string date = DateTime.Now.ToString();

            bool getAttendance = false;

            foreach (Stuff stuff in aStuffList)
            {
                if (username == stuff.Username && password == stuff.Password)
                {
                    if (aStuffManager.CheckAttendance(stuff.Id, date))
                    {
                        getAttendance = false;
                        message = "This employee Already gets his attendance for today";
                        break;

                    }
                    else
                    {

                        aStuffManager.submitAttendance(stuff.Id, date);

                        int id = aStuffManager.getCurrentDateId(stuff.Id, date);

                        DateTime time = DateTime.Now.ToLocalTime();
                        aStuffManager.SubmitLogin(id, time, remark);
                        getAttendance = true;
                        MessageBox.Show("Attendance Submitted Successfully", "Success");
                        ClearAll();
                        break;
                    }
                }

            }
            if (!getAttendance)
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearAll()
        {
            userNameTextBox.Text = passwordTextBox.Text = remarksTextBox.Text = "";

        }

       
    }
}
