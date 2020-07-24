using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class AppointmentViewModel : BaseViewModel
    {
        public AppointmentViewModel()
        {

        }
        public AppointmentViewModel(Models.Appointment appointment)
        {
            Id = appointment.Id;
            Date = appointment.Date;
            ReminderTime = appointment.ReminderTime;
            FollowUpAdvice = appointment.FollowUpAdvice;
            ReasonForVisit = appointment.ReasonForVisit;
            Diagnosis = appointment.Diagnosis;
            Picture = appointment.Picture;
            DId = appointment.DId;
            UId = appointment.UId;
            Prescriptions = appointment.Prescriptions;
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                SetValue(ref id, value);
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                SetValue(ref date, value);
            }
        }

        //Need to save the time that the user wants to be reminded of their appointment
        //This will be used to resubmit the notifications after device restart, because they are not saved otherwise.
        private DateTime remindertime;
        public DateTime ReminderTime
        {
            get
            {
                return remindertime;
            }
            set
            {
                SetValue(ref remindertime, value);
            }
        }
        private string followupadvice;
        public string FollowUpAdvice
        {
            get
            {
                return followupadvice;
            }
            set
            {
                SetValue(ref followupadvice, value);
            }
        }
        private string reasonforvisit;
        public string ReasonForVisit
        {
            get
            {
                return reasonforvisit;
            }
            set
            {
                SetValue(ref reasonforvisit, value);
            }
        }
        private string diagnosis;
        public string Diagnosis
        {
            get
            {
                return diagnosis;
            }
            set
            {
                SetValue(ref diagnosis, value);
            }
        }
        private byte[] picture;
        public byte[] Picture
        {
            get
            {
                return picture;
            }
            set
            {
                SetValue(ref picture, value);
            }
        }

        private int did;
        public int DId
        {
            get
            {
                return did;
            }
            set
            {
                SetValue(ref did, value);
            }
        }
        private int uid;
        public int UId
        {
            get
            {
                return uid;
            }
            set
            {
                SetValue(ref uid, value);
            }
        }
        private List<Models.Prescription> prescriptions;
        public List<Models.Prescription> Prescriptions
        {
            get
            {
                return prescriptions;
            }
            set
            {
                SetValue(ref prescriptions, value);
            }
        }
    }
}