using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class User
    {
        public User(UserViewModel user)
        {
            Id = user.Id;
            Name = user.Name;
            Birthday = user.Birthday;
            AId = user.AId;
            Password = user.Password;
            Doctors = user.Doctors;
            Appointments = user.Appointments;
            Prescriptions = user.Prescriptions;
            Allergies = user.Allergies;
            Conditions = user.Conditions;
            Notes = user.Notes;
            Folders = user.Folders;
        }
        public User()
        {

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

        public DateTime Birthday
        {
            get;
            set;
        }
        public int AId
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }

        public List<Doctor> Doctors
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
        public List<Note> Notes
        {
            get;
            set;
        }
        public List<Folder> Folders
        {
            get;
            set;
        }

        public List<Allergy> Allergies
        {
            get;
            set;
        }
        public List<Condition> Conditions
        {
            get;
            set;
        }
    }
}
