using MyHealthChart3.Models;
using MyHealthChart3.Services;
using System;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class PrescriptionEditViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private DateTime enddate;
        private TimeSpan remindertime;
        private Prescription prescription;

        public string result;
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
        public TimeSpan ReminderTime
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
        public Prescription Prescription
        {
            get
            {
                return prescription;
            }
            set
            {
                SetValue(ref prescription, value);
            }
        }
        public PrescriptionEditViewModel(Prescription p, IServerComms networkmodule)
        {
            Prescription = p;
            NetworkModule = networkmodule;
            EndDate = Prescription.EndDate;
            ReminderTime = Prescription.ReminderTime.TimeOfDay;

        }
        public async System.Threading.Tasks.Task Submit()
        {
            Prescription.EndDate = EndDate;
            Prescription.ReminderTime = DateTime.Now.Date + ReminderTime; 
            result = await NetworkModule.EditPrescription(Prescription);
        }
    }
}
