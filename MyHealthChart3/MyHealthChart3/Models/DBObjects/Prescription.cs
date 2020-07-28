using System;

namespace MyHealthChart3.Models
{
    public class Prescription
    {
        public Prescription()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateString { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateString { get; set; }
        public bool NeedsReminder { get; set; }
        public DateTime ReminderTime { get; set; }
        public string ReminderTimeString { get; set; }
        public string DoctorName { get; set; }
        public int DId { get; set; }
        public int UId { get; set; }
        public int AId { get; set; }
        public string Password { get; set; }
    }
}