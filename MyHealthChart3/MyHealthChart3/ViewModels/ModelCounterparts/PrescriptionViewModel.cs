using MyHealthChart3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class PrescriptionViewModel : BaseViewModel
    {
        public PrescriptionViewModel()
        {

        }
        public PrescriptionViewModel(Models.Prescription prescription)
        {
            Id = prescription.Id;
            Name = prescription.Name;
            StartDate = prescription.StartDate;
            EndDate = prescription.EndDate;
            ReminderTime = prescription.ReminderTime;
            PrescriptionNotificationIDs = prescription.PrescriptionNotificationIDs;
            DId = prescription.DId;
            UId = prescription.UId;
            AId = prescription.AId;
        }
        private int id;
        private string name;
        private DateTime startdate;
        private DateTime enddate;
        private DateTime remindertime;
        private List<PrescriptionNotificationID> prescriptionnotificationids;
        private int did;
        private int uid;
        private int aid;

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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetValue(ref name, value);
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
                SetValue(ref startdate, value);
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
                SetValue(ref enddate, value);
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
                SetValue(ref remindertime, value);
            }
        }
        public List<PrescriptionNotificationID> PrescriptionNotificationIDs
        {
            get
            {
                return prescriptionnotificationids;
            }
            set
            {
                SetValue(ref prescriptionnotificationids, value);
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
                SetValue(ref did, value);
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
                SetValue(ref uid, value);
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
                SetValue(ref aid, value);
            }
        }
    }
}

