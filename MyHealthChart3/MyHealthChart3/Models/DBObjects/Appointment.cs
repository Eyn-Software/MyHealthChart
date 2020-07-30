using System;

namespace MyHealthChart3.Models
{
    public class Appointment
    {
        public Appointment()
        {

        }
        public int Id { get; set; }
        public Doctor ChosenDoctor { get; set; }
        public string Doctor { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Aftercare { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public byte[] PicBytes { get; set; }
        public int DId { get; set; }
        public int UId { get; set; }
        public string Password { get; set; }
        public string Prescriptions { get; set; }
        public string Vaccines { get; set; }
        public string Address { get; set; }
    }
}
