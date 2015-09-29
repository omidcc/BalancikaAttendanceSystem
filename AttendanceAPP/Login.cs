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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            getAllUser();
            IntialCondition();

        }

        private DateTime timeStart = DateTime.Parse("6:00");
        private DateTime timeEnd = DateTime.Parse("12:00");
        private string role="Employee";
        
        private void IntialCondition()
        {
            userComboBox.Items.Add("Employee");
            userComboBox.Items.Add("Admin");
            userComboBox.SelectedIndex = 0;
            TimeChecker();


        }

        private void TimeChecker()
        {
            DateTime currentTime = DateTime.Now;
            if ((currentTime >= timeStart) && (currentTime <= timeEnd))
            {
                logOutButton.Enabled = false;
                logOnButton.Enabled = true;
            }
            else
            {
                logOnButton.Enabled = false;
                logOutButton.Enabled = true;
            }
        }

        public void AdminRole()
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            string message = "";
            if (username == "admin" && password == "admin")
            {

                Admin admin = new Admin();
                this.Hide();

                admin.Closed += (s, args) => this.Close();
                admin.Show();
            }
            else
            {
                MessageBox.Show("Admin username and password is incorrect", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


 
        }
        StuffManager aStuffManager=new StuffManager();
        List<Stuff>aStuffList=new List<Stuff>(); 
        void getAllUser()
        {
            aStuffList = aStuffManager.GetAllStuff();

        }

        private void logOutButton_MouseEnter(object sender, EventArgs e)
        {
            logOutButton.BackColor = Color.LightGray;
        }

        private void logOutButton_MouseLeave(object sender, EventArgs e)
        {
            logOutButton.BackColor = Color.WhiteSmoke;
        }

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userComboBox.SelectedIndex == 0)
            {

                logOutButton.Text = "Log Out";
                remarkLabel.Show();
                remarksTextBox.Show();
                logOnButton.Show();
          TimeChecker();
                




            }
            else
            {
                remarkLabel.Hide();
                remarksTextBox.Hide();
                logOutButton.Text = "Submit";
                logOnButton.Hide();
                if (logOutButton.Enabled == false)
                {
                    logOutButton.Enabled = true;
                }
              
            }
        }

        private Attendance myAttendance;
        private Stuff myStuff;
        private void logOnButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hide Work");
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
                MessageBox.Show(message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           

            
        }

        private void ClearAll()
        {
            userNameTextBox.Text = passwordTextBox.Text = remarksTextBox.Text = null;
        }


        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logOutButton.PerformClick();
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            string remarks = remarksTextBox.Text;
            DateTime date = DateTime.Now;
            string message = "";
            if (userComboBox.SelectedIndex == 0)
            {
                string mes;
                int flag = 1;
                foreach (Stuff stuff in aStuffList)
                {
                    if ((stuff.Username == username) && (stuff.Password == password))
                    {
                        if (aStuffManager.LogOutSubmit(date, stuff.Id, out message, remarks))
                        {
                            MessageBox.Show(message, "Success");
                        }
                        else
                        {
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        userNameTextBox.Text = passwordTextBox.Text = "";
                        flag = 0;
                        break;
                    }
                    ClearAll();




                }
            
            if (flag == 1)
                    MessageBox.Show("Invalid username or password","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
            else
            {
                AdminRole();
                ClearAll();
            }
        }

        private void logOutButton_MouseHover(object sender, EventArgs e)
        {
            logOutButton.BackColor = Color.LightGray;
        }

        
    }
}
