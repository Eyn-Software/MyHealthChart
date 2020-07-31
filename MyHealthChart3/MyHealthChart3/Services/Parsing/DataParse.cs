using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyHealthChart3.Services.Parsing
{
    class DataParse : IDataParse
    {
        public DataParse()
        {

        }
        /*
        Name: DownloadUsers
        Purpose: Parses the string sent from the server when users are downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: Login, Register
        Date: June 28, 2020
        */
        public List<UserViewModel> DownloadUsers(string ReceivedData)
        {
            List<UserViewModel> Users = new List<UserViewModel>();
            UserViewModel User;
            int Id;
            string Name;
            DateTime Birthday;
            int AId;
            int index;

            while (!ReceivedData.Equals(""))
            {
                index = ReceivedData.IndexOf("///");
                Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);
                index = ReceivedData.IndexOf("///");
                Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);
                index = ReceivedData.IndexOf("///");
                Birthday = DateTime.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);
                index = ReceivedData.IndexOf("///");
                AId = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);
                User = new UserViewModel();
                User.Id = Id;
                User.Name = Name;
                User.Birthday = Birthday;
                User.AId = AId;
                Users.Add(User);
            }
            return Users;
        }
        /*
        Name: DownloadDoctor
        Purpose: Parses the string sent from the server when doctors are downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: GetDoctors
        Date: June 30, 2020
        */
        public List<Doctor> DownloadDoctors(string ReceivedData)
        {
            List<Doctor> Doctors = new List<Doctor>();
            Doctor Doctor;
            int index;

            while (!ReceivedData.Equals(""))
            {
                Doctor = new Doctor();

                index = ReceivedData.IndexOf("///");
                Doctor.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor.Practice = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor.Type = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor.Address = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor.Email = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor.Phone = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Doctors.Add(Doctor);
            }
            return Doctors;
        }
        /*
        Name: DownloadUsers
        Purpose: Parses the string sent from the server when appointments are downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: Login, Register
        Date: July 2, 2020
        */
        public List<Appointment> DownloadAppointments(string ReceivedData)
        {
            int index;
            List<Appointment> Appointments = new List<Appointment>();
            Appointment Appointment;

            while (!ReceivedData.Equals(""))
            {
                Appointment = new Appointment(); 

                index = ReceivedData.IndexOf("///");
                Appointment.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.Doctor = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.Date = DateTime.Parse(ReceivedData.Substring(0, index));
                Appointment.DateString = Appointment.Date.ToShortDateString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.Address = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.Reason = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.Diagnosis = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.Aftercare = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Appointments.Add(Appointment);
            }
            return Appointments;
        }
        /*
        Name: DownloadFutureAppointment
        Purpose: Parses the list of future appoitnments
        Author: Samuel McManus
        Uses: N/A
        Used by: GetFutureAppointments
        Date: July 16, 2020
        */
        public List<AppointmentReminderModel> DownloadFutureAppointments(string ReceivedData)
        {
            int index;
            List<AppointmentReminderModel> Appointments = new List<AppointmentReminderModel>();
            AppointmentReminderModel Appointment;
            while (!ReceivedData.Equals(""))
            {
                Appointment = new AppointmentReminderModel();

                index = ReceivedData.IndexOf("///");
                Appointment.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.UserName = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.DoctorName = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Appointment.ReminderTime = DateTime.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                Appointments.Add(Appointment);
            }
            return Appointments;
        }
        /*
        Name: DownloadConditions
        Purpose: Parses the string sent from the server when conditions are downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: ConditionList
        Date: July 6, 2020
        */
        public ObservableCollection<Models.Condition> DownloadConditions(string ReceivedData)
        {
            ObservableCollection<Models.Condition> Conditions = new ObservableCollection<Models.Condition>();
            while (!ReceivedData.Equals(""))
            {
                Models.Condition Condition = new Models.Condition();
                int index = ReceivedData.IndexOf("///");
                Condition.Type = ReceivedData.Substring(0, index);
                Conditions.Add(Condition);
                ReceivedData = ReceivedData.Substring(index + 3);
            }
            return Conditions;
        }
        /*
        Name: DownloadAllergies
        Purpose: Parses a list of allergies
        Author: Samuel McManus
        Uses: N/A
        Used by: GetAllergies
        Date: July 8, 2020
        */
        public ObservableCollection<Allergy> DownloadAllergies(string ReceivedData)
        {
            ObservableCollection<Allergy> Allergies = new ObservableCollection<Allergy>();
            while(!ReceivedData.Equals(""))
            {
                Allergy Allergy = new Allergy();
                int index = ReceivedData.IndexOf("///");
                Allergy.Type = ReceivedData.Substring(0, index);
                Allergies.Add(Allergy);
                ReceivedData = ReceivedData.Substring(index + 3);
            }
            return Allergies;
        }
        /*
        Name: DownloadCalendar
        Purpose: Parses a list of all appointments associated with the account
        Author: Samuel McManus
        Uses: N/A
        Used by: GetCalendar
        Date: July 11, 2020
        */
        public CalendarEventCollection DownloadCalendar(string ReceivedData)
        {
            CalendarEventCollection Events = new CalendarEventCollection();
            CalendarInlineEvent Event;
            int index;
            string UName;
            string DName;

            while (!ReceivedData.Equals(""))
            {
                Event = new CalendarInlineEvent();
                index = ReceivedData.IndexOf("///");
                Event.StartTime = DateTime.Parse(ReceivedData.Substring(0, index));
                Event.EndTime = Event.StartTime;
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                UName = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                DName = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Event.Subject = UName + " has an appointment with " + DName + " at " + Event.StartTime.ToShortTimeString();
                Events.Add(Event);
            }
            return Events;
        }
        /*
        Name: DownloadVaccines
        Purpose: Parses a list of vaccines
        Author: Samuel McManus
        Uses: N/A
        Used by: GetVaccines
        Date: July 13, 2020
        */
        public ObservableCollection<Vaccine> DownloadVaccines(string ReceivedData)
        {
            ObservableCollection<Vaccine> Vaccines = new ObservableCollection<Vaccine>();
            Vaccine Vaccine;
            int index;
            while(!ReceivedData.Equals(""))
            {
                Vaccine = new Vaccine();

                index = ReceivedData.IndexOf("///");
                Vaccine.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Vaccine.Date = DateTime.Parse(ReceivedData.Substring(0, index));
                Vaccine.StringDate = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortDateString();
                ReceivedData = ReceivedData.Substring(index + 3);

                Vaccines.Add(Vaccine);
            }
            return Vaccines;
        }
        /*
        Name: DownloadPrescriptions
        Purpose: Parses a list of prescriptions
        Author: Samuel McManus
        Uses: N/A
        Used by: GetPrescriptions
        Date: July 14, 2020
        */
        public ObservableCollection<Prescription> DownloadPrescriptions(string ReceivedData)
        {
            ObservableCollection<Prescription> Prescriptions = new ObservableCollection<Prescription>();
            Prescription Prescription;
            int index;

            while (!ReceivedData.Equals(""))
            {
                Prescription = new Prescription();

                index = ReceivedData.IndexOf("///");
                Prescription.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.StartDate = DateTime.Parse(ReceivedData.Substring(0, index));
                Prescription.StartDateString = Prescription.StartDate.ToShortDateString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.EndDate = DateTime.Parse(ReceivedData.Substring(0, index));
                Prescription.EndDateString = Prescription.EndDate.ToShortDateString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.ReminderTime = DateTime.Parse(ReceivedData.Substring(0, index));
                Prescription.ReminderTimeString = Prescription.ReminderTime.ToShortTimeString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.DoctorName = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Prescriptions.Add(Prescription);
            }
            return Prescriptions;
        }
        /*
        Name: DownloadFolders
        Purpose: Parses a list of folders
        Author: Samuel McManus
        Uses: N/A
        Used by: GetChildFolders
        Date: July 19, 2020
        */
        public ObservableCollection<Folder> DownloadFolders(string ReceivedData)
        {
            ObservableCollection<Folder> Folders = new ObservableCollection<Folder>();
            Folder Folder;
            int index;
            while(!ReceivedData.Equals(""))
            {
                Folder = new Folder();

                index = ReceivedData.IndexOf("///");
                Folder.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Folder.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                //Remove after adding creation date to every non-root item
                try
                {
                    Folder.CreationDate = ReceivedData.Substring(0, index);
                }
                catch(Exception e)
                {

                }
                ReceivedData = ReceivedData.Substring(index + 3);

                Folders.Add(Folder);
            }
            return Folders;
        }
        /*
        Name: DownloadNotes
        Purpose: Parses a list of notes
        Author: Samuel McManus
        Uses: N/A
        Used by: GetChildNotes
        Date: July 19, 2020
        */
        public ObservableCollection<Note> DownloadNotes(string ReceivedData)
        {
            ObservableCollection<Note> Notes = new ObservableCollection<Note>();
            Note Note;
            int index;
            while(!ReceivedData.Equals(""))
            {
                Note = new Note();

                index = ReceivedData.IndexOf("///");
                Note.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Note.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                try
                {
                    Note.CreationDate = ReceivedData.Substring(0, index);
                }
                catch(Exception e)
                {

                }
                ReceivedData = ReceivedData.Substring(index + 3);
                Notes.Add(Note);
            }
            return Notes;
        }
        public UserViewModel DownloadUser(string ReceivedData)
        {
            UserViewModel User = new UserViewModel();
            int index;

            index = ReceivedData.IndexOf("///");
            User.Id = int.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            User.Name = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            User.Birthday = DateTime.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            User.AId = int.Parse(ReceivedData.Substring(0, index));

            return User;
        }
        /*
        Name: DownloadAppointment
        Purpose: Parses the string sent from the server when a single appointment is downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentDetail
        Date: July 6, 2020
        */
        public Appointment DownloadAppointment(string ReceivedData, Appointment Appointment)
        {
            int index;

            index = ReceivedData.IndexOf("///");
            Appointment.Id = int.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Doctor = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Date = DateTime.Parse(ReceivedData.Substring(0, index));
            Appointment.DateString = Appointment.Date.ToShortDateString();
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Address = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Reason = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Diagnosis = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Aftercare = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Prescriptions = ReceivedData.Substring(0, index - 2);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Vaccines = ReceivedData.Substring(0, index - 2);

            if (Appointment.Vaccines.Equals("abcdefa"))
                Appointment.Vaccines = "";
            if (Appointment.Prescriptions.Equals("abcdefa"))
                Appointment.Prescriptions = "";
            return Appointment;
        }
        /*
        Name: DownloadNote
        Purpose: Parses the string sent from the server when a note is downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: ServerComms
        Date: July 30, 2020
        */
        public Note DownloadNote(string ReceivedData, Note N)
        {
            Note Note = N;
            int index;

            index = ReceivedData.IndexOf("///");
            Note.Name = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Note.Description = ReceivedData.Substring(0, index);

            return Note;
        }
        /*
        Name: DownloadAddress
        Purpose: Parses an address for a doctor
        Author: Samuel McManus
        Uses: N/A
        Used by: DoctorDetail
        Date: July 30, 2020
        */
        public Address DownloadAddress(string ReceivedData)
        {
            Address Address = new Address();
            int index;

            index = ReceivedData.IndexOf(",");
            Address.Street = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 2);

            index = ReceivedData.IndexOf(",");
            Address.City = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 2);

            index = ReceivedData.IndexOf(",");
            Address.State = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 2);

            Address.ZipCode = ReceivedData;

            return Address;
        }
    }
}
