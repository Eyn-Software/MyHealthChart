using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class AppointmentDetailModel
    {
        private int aid;
        private string doctorname;
        private string address;
        private DateTime date;
        private TimeSpan time;
        private DateTime remindertime;
        private string reason;
        private string diagnosis;
        private string aftercare;
        private string prescriptions;
        private string vaccines;
        private int uid;
        private string password;

        public AppointmentDetailModel()
        {

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
        public string DoctorName
        {
            get
            {
                return doctorname;
            }
            set
            {
                doctorname = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
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
        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                reason = value;
            }
        }
        public string Diagnosis
        {
            get
            {
                return diagnosis;
            }
            set
            {
                diagnosis = value;
            }
        }
        public string Aftercare
        {
            get
            {
                return aftercare;
            }
            set
            {
                aftercare = value;
            }
        }
        public string Prescriptions
        {
            get
            {
                return prescriptions;
            }
            set
            {
                prescriptions = value;
            }
        }
        public string Vaccines
        {
            get
            {
                return vaccines;
            }
            set
            {
                vaccines = value;
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
