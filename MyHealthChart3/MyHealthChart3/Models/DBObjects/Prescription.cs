using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Prescription
    {
        public Prescription()
        {

        }
        public Prescription(PrescriptionViewModel prescription)
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
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public DateTime ReminderTime
        {
            get;
            set;
        }
        public List<Notification> PrescriptionNotificationIDs
        {
            get;
            set;
        }
        public int DId
        {
            get;
            set;
        }
        public int UId
        {
            get;
            set;
        }

        public int AId
        {
            get;
            set;
        }
    }
}