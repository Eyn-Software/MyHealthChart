using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Appointment
    {
        public Appointment()
        {

        }
        public Appointment(AppointmentViewModel appointment)
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
            Vaccines = appointment.Vaccines;
            Prescriptions = appointment.Prescriptions;
        }
        public int Id
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }

        //Need to save the time that the user wants to be reminded of their appointment
        //This will be used to resubmit the notifications after device restart, because they are not saved otherwise.
        public DateTime ReminderTime
        {
            get;
            set;
        }
        public string FollowUpAdvice
        {
            get;
            set;
        }
        public string ReasonForVisit
        {
            get;
            set;
        }
        public string Diagnosis
        {
            get;
            set;
        }

        public byte[] Picture
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
        public List<Vaccine> Vaccines
        {
            get;
            set;
        }
        public List<Prescription> Prescriptions
        {
            get;
            set;
        }
    }
}
