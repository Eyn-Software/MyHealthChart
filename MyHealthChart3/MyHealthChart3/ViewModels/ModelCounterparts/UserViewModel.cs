using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class UserViewModel : BaseViewModel
    {
        public int Id
        {
            get;
            set;
        }
        public UserViewModel()
        {

        }

        public UserViewModel(Models.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Birthday = user.Birthday;
            AId = user.AId;
            Password = user.Password;
            Doctors = user.Doctors;
            Appointments = user.Appointments;
            Prescriptions = user.Prescriptions;
            Vaccines = user.Vaccines;
            Allergies = user.Allergies;
            Conditions = user.Conditions;
            Notes = user.Notes;
            Folders = user.Folders;
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

        private DateTime birthday;
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                SetValue(ref birthday, value);
            }
        }

        private int aid;
        public int AId
        {
            get
            {
                return aid;
            }
            set
            {
                SetValue(ref aid, value);
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetValue(ref password, value);
            }
        }
        private List<Models.Doctor> doctors;
        public List<Models.Doctor> Doctors
        {
            get
            {
                return doctors;
            }
            set
            {
                SetValue(ref doctors, value);
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

        private List<Models.Vaccine> vaccines;
        public List<Models.Vaccine> Vaccines
        {
            get
            {
                return vaccines;
            }
            set
            {
                SetValue(ref vaccines, value);
            }
        }

        private List<Models.Allergy> allergies;
        public List<Models.Allergy> Allergies
        {
            get
            {
                return allergies;
            }
            set
            {
                SetValue(ref allergies, value);
            }
        }

        private List<Models.Condition> conditions;
        public List<Models.Condition> Conditions
        {
            get
            {
                return conditions;
            }
            set
            {
                SetValue(ref conditions, value);
            }
        }
        private List<Models.Note> notes;
        public List<Models.Note> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                SetValue(ref notes, value);
            }
        }
        private List<Models.Folder> folders;
        public List<Models.Folder> Folders
        {
            get
            {
                return folders;
            }
            set
            {
                SetValue(ref folders, value);
            }
        }
    }
}
