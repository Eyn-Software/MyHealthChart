using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class AppointmentFormEntryModel
    {
        private int uid;
        private int aid;
        private byte[] picbytes;
        private string password;
        private DoctorViewModel chosendoctor;
        private DateTime date;
        private DateTime remindertime;
        private string reason;
        private string diagnosis;
        private string aftercare;

        public AppointmentFormEntryModel()
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
        public DoctorViewModel ChosenDoctor
        {
            get
            {
                return chosendoctor;
            }
            set
            {
                chosendoctor = value;
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
        public byte[] PicBytes
        {
            get
            {
                return picbytes;
            }
            set
            {
                picbytes = value;
            }
        }
    }
}
