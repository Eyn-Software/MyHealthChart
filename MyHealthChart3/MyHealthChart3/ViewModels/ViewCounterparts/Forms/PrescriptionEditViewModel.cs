using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class PrescriptionEditViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private DateTime enddate;
        private TimeSpan remindertime;
        private PrescriptionListModel prescription;

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
        public PrescriptionListModel Prescription
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
        public PrescriptionEditViewModel(PrescriptionListModel p, IServerComms networkmodule)
        {
            Prescription = p;
            NetworkModule = networkmodule;
            EndDate = DateTime.Parse(Prescription.EndDate);
            ReminderTime = DateTime.ParseExact(Prescription.ReminderTime, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

        }
        public async System.Threading.Tasks.Task Submit()
        {
            Prescription.EndDate = EndDate.ToString();
            Prescription.ReminderTime = (DateTime.Now.Date + ReminderTime).ToString();
            result = await NetworkModule.EditPrescription(Prescription);
        }
    }
}
