using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Doctor
    {
        public Doctor()
        {

        }
        public Doctor(DoctorViewModel doctor)
        {
            Id = doctor.Id;
            Name = doctor.Name;
            Practice = doctor.Practice;
            Type = doctor.Type;
            Address = doctor.Address;
            Email = doctor.Email;
            Phone = doctor.Phone;
            Users = doctor.Users;
            Appointments = doctor.Appointments;
            Prescriptions = doctor.Prescriptions;

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

        public string Practice
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public List<User> Users
        {
            get;
            set;
        }
        public List<Appointment> Appointments
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
