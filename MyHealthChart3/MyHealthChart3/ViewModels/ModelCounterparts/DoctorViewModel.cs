using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class DoctorViewModel : BaseViewModel
    {
        public DoctorViewModel()
        {

        }
        public DoctorViewModel(Models.Doctor doctor)
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

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                SetValue(ref id, value);
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetValue(ref name, value);
            }
        }
        private string practice;
        public string Practice
        {
            get
            {
                return practice;
            }
            set
            {
                SetValue(ref practice, value);
            }
        }
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                SetValue(ref type, value);
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                SetValue(ref address, value);
            }
        }
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                SetValue(ref phone, value);
            }
        }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                SetValue(ref email, value);
            }
        }
        private List<Models.User> users;
        public List<Models.User> Users
        {
            get
            {
                return users;
            }
            set
            {
                SetValue(ref users, value);
            }
        }
        private List<Models.Appointment> appointments;
        public List<Models.Appointment> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                SetValue(ref appointments, value);
            }
        }
        private List<Models.Prescription> prescriptions;
        public List<Models.Prescription> Prescriptions
        {
            get
            {
                return prescriptions;
            }
            set
            {
                SetValue(ref prescriptions, value);
            }
        }
    }
}

