using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class AppointmentReminderModel
    {
        public AppointmentReminderModel()
        {

        }
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string UserName { get; set; }
        public DateTime ReminderTime { get; set; }
    }
}
