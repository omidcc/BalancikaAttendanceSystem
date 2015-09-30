﻿using System;
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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadComboBox();
            
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
        }
        List<Stuff>myStuffList=new List<Stuff>();
        StuffManager aStuffManager=new StuffManager();
        private void LoadComboBox()
        {
            myStuffList = aStuffManager.GetAllStuff();
            nameComboBox.Items.Clear();
            foreach (Stuff stuff in myStuffList)
            {
                nameComboBox.Items.Add(stuff.Name);
               
              
            }
            nameComboBox.SelectedIndex = 0;
            
        }

        public void LoadListBox()
        {
            
        }
        List<string>myAttendanceList=new List<string>();
        List<string> selectedDateList = new List<string>();
        private string firstDate;
        private string lastDate;

        private void searchButton_Click(object sender, EventArgs e)
        {
            dateListView.Items.Clear();

            string name = nameComboBox.SelectedItem.ToString();
            
            
        /**    List<string> datList= aStuffManager.GetStuffAttendanceList(name,firstDate,lastDate );
            if (datList.Count <= 0)
            {
                MessageBox.Show(String.Format("In this month , {0} is not attended a single day", name));
            }
         * **/
            
                firstDate = fromDateTimePicker.Text;
                lastDate = toDateTimePicker.Text;
                int id = 0;
                foreach (Stuff stuff in myStuffList)
                {
                    if (stuff.Name == name)
                    {
                        id = stuff.Id;
                        break;
                    }
                }
                List<Details> attendanceList = aStuffManager.GetAttendanceList(id, firstDate, lastDate);
                foreach (Details details in attendanceList)
                {   
                    DateTime time=new DateTime();
                    time=DateTime.Parse(details.Date);
                    string day = String.Format("{0:dddd}", time);
                    string dayFormat = String.Format("{0:ddd}", time.ToShortDateString());
                    ListViewItem item = new ListViewItem(dayFormat);
                    item.SubItems.Add(day);
                    time = DateTime.Parse(details.LoginTime);
                    item.SubItems.Add(time.ToShortTimeString());
                    item.SubItems.Add(details.LoginRemark);
                    time = DateTime.Parse(details.LogoutTime);
                    item.SubItems.Add(time.ToShortTimeString());
                    item.SubItems.Add(details.LogoutRemark);
                    dateListView.Items.Add(item);
                }



           




        }
        
      

        


      public void month(string ss)
        {

          if (ss == "January")
          {
              firstDate = DateTime.Now.Year + "-01-01";
              lastDate = DateTime.Now.Year + "-01-31";
          }
             else if (ss == "February")
             {
                 string yr = null;
                 yr+=(DateTime.Now.Year);
                 int year = int.Parse(yr);

                 if ((year%400) == 0 || ((year%100 != 0) && (year%4 == 0)))
                 {
                     {
                         firstDate = DateTime.Now.Year + "-02-01";
                         lastDate = DateTime.Now.Year + "-02-29";
                     }
                 }
                 else
                 {
                     {
                         firstDate = DateTime.Now.Year + "-02-01";
                         lastDate = DateTime.Now.Year + "-02-28";
                     }
                 }
             }
             else if (ss == "March")
          {
              firstDate = DateTime.Now.Year + "-03-01";
              lastDate = DateTime.Now.Year + "-03-31";
          }
             else if (ss == "April")
          {
              firstDate = DateTime.Now.Year + "-04-01";
              lastDate = DateTime.Now.Year + "-04-30";
          }
             else if (ss == "May")
          {
              firstDate = DateTime.Now.Year + "-05-01";
              lastDate = DateTime.Now.Year + "-05-31";
          }
             else if (ss == "June")
          {
              firstDate = DateTime.Now.Year + "-06-01";
              lastDate = DateTime.Now.Year + "-06-30";
          }
             else if (ss == "July")
          {
              firstDate = DateTime.Now.Year + "-07-01";
              lastDate = DateTime.Now.Year + "-07-31";
          }
             else if (ss == "August")
          {
              firstDate = DateTime.Now.Year + "-08-01";
              lastDate = DateTime.Now.Year + "-08-31";
          }
             else if (ss == "September")
          {
              firstDate = DateTime.Now.Year + "-09-01";
              lastDate = DateTime.Now.Year + "-09-30";
          }
             else if (ss == "October")
          {
              firstDate = DateTime.Now.Year + "-10-01";
              lastDate = DateTime.Now.Year + "-10-31";
          }
             else if (ss == "November")
          {
              firstDate = DateTime.Now.Year + "-11-01";
              lastDate = DateTime.Now.Year + "-11-30";
          }

          else
          {
              firstDate = DateTime.Now.Year + "-12-01";
              lastDate = DateTime.Now.Year + "-12-31";
          }
        }

      private void logOutButton_Click(object sender, EventArgs e)
      {
          Login login = new Login();
          this.Hide();

          login.Closed += (s, args) => this.Close();
          login.Show();
      }

      private void label4_Click(object sender, EventArgs e)
      {
          logOutButton_Click(sender,e);
      }

      private void giveAttendance_Click(object sender, EventArgs e)
      {
          TemporaryAttendance tm=new TemporaryAttendance();
          tm.Show();
      }

      


    }
}
