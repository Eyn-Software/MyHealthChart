using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class PrescriptionListModel
    {
        public PrescriptionListModel()
        {

        }
        public PrescriptionListModel(PrescriptionFormEntryModel P)
        {
            Name = P.Name;
            StartDate = P.StartDate.ToShortDateString();
            EndDate = P.EndDate.ToShortDateString();
            ReminderTime = P.ReminderTime.ToString();
            User.Id = P.UId;
            User.Password = P.Password;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReminderTime { get; set; }
        public string DoctorName { get; set; }
        public ViewModels.ModelCounterparts.UserViewModel User { get; set; }
    }
}
