using System;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class AppointmentFormEntryModel
    {
        public AppointmentFormEntryModel()
        {

        }
        public int UId { get; set; }
        public string Password { get; set; }
        public int AId { get; set; }
        public byte[] PicBytes { get; set; }
        public Doctor ChosenDoctor { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public string Aftercare { get; set; }
    }
}
