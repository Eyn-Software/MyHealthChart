using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class PrescriptionFormEntryModel
    {
        private string name;
        private DateTime startdate;
        private DateTime enddate;
        private bool needsreminder;
        private DateTime remindertime;
        private int aid;
        private int did;
        private int uid;
        private string password;

        public PrescriptionFormEntryModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            ReminderTime = DateTime.Now;
        }
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return startdate;
            }
            set
            {
                startdate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
            }
        }
        public bool NeedsReminder
        {
            get
            {
                return needsreminder;
            }
            set
            {
                needsreminder = value;
            }
        }
        public DateTime ReminderTime
        {
            get
            {
                return remindertime;
            }
            set
            {
                remindertime = value;
            }
        }
        public int AId
        {
            get
            {
                return aid;
            }
            set
            {
                aid = value;
            }
        }
        public int DId
        {
            get
            {
                return did;
            }
            set
            {
                did = value;
            }
        }
        public int UId
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
