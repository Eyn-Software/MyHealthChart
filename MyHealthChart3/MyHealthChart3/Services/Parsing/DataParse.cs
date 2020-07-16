using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<UserViewModel>> DownloadUsers(string ReceivedData)
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
        public async Task<List<DoctorViewModel>> DownloadDoctors(string ReceivedData)
        {
            List<DoctorViewModel> Doctors = new List<DoctorViewModel>();
            DoctorViewModel Doctor;
            int Id;
            string Name;
            string Practice;
            string Type;
            string Address;
            string Email;
            string Phone;
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
                Practice = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Type = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Address = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Email = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Phone = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Doctor = new DoctorViewModel();
                Doctor.Id = Id;
                Doctor.Name = Name;
                Doctor.Practice = Practice;
                Doctor.Type = Type;
                Doctor.Address = Address;
                Doctor.Email = Email;
                Doctor.Phone = Phone;
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
        public async Task<List<AppointmentListModel>> DownloadAppointments(string ReceivedData)
        {
            int Id;
            string Doctor;
            string Date;
            int index;
            List<AppointmentListModel> Appointments = new List<AppointmentListModel>();
            AppointmentListModel Appointment;

            while (!ReceivedData.Equals(""))
            {
                index = ReceivedData.IndexOf("///");
                Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Doctor = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Date = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Appointment = new AppointmentListModel();
                Appointment.Id = Id;
                Appointment.Doctor = Doctor;
                Appointment.Date = Date;
                Appointment.DateAsDateTime = DateTime.Parse(Date);
                Appointment.Date = Appointment.DateAsDateTime.ToShortDateString();
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
        public async Task<List<AppointmentReminderModel>> DownloadFutureAppointments(string ReceivedData)
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
        public async Task<ObservableCollection<ConditionViewModel>> DownloadConditions(string ReceivedData)
        {
            ObservableCollection<ConditionViewModel> Conditions = new ObservableCollection<ConditionViewModel>();
            while (!ReceivedData.Equals(""))
            {
                ConditionViewModel Condition = new ConditionViewModel();
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
        public async Task<ObservableCollection<AllergyViewModel>> DownloadAllergies(string ReceivedData)
        {
            ObservableCollection<AllergyViewModel> Allergies = new ObservableCollection<AllergyViewModel>();
            while(!ReceivedData.Equals(""))
            {
                AllergyViewModel Allergy = new AllergyViewModel();
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
        public async Task<CalendarEventCollection> DownloadCalendar(string ReceivedData)
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
        public async Task<ObservableCollection<VaccineListModel>> DownloadVaccines(string ReceivedData)
        {
            ObservableCollection<VaccineListModel> Vaccines = new ObservableCollection<VaccineListModel>();
            VaccineListModel Vaccine;
            string Name;
            string Date;
            int index;
            while(!ReceivedData.Equals(""))
            {
                Vaccine = new VaccineListModel();

                index = ReceivedData.IndexOf("///");
                Vaccine.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Vaccine.Date = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortDateString();
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
        public async Task<ObservableCollection<PrescriptionListModel>> DownloadPrescriptions(string ReceivedData)
        {
            ObservableCollection<PrescriptionListModel> Prescriptions = new ObservableCollection<PrescriptionListModel>();
            PrescriptionListModel Prescription;
            int index;

            while (!ReceivedData.Equals(""))
            {
                Prescription = new PrescriptionListModel();

                index = ReceivedData.IndexOf("///");
                Prescription.Id = int.Parse(ReceivedData.Substring(0, index));
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.Name = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.StartDate = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortDateString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.EndDate = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortDateString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.ReminderTime = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortTimeString();
                ReceivedData = ReceivedData.Substring(index + 3);

                index = ReceivedData.IndexOf("///");
                Prescription.DoctorName = ReceivedData.Substring(0, index);
                ReceivedData = ReceivedData.Substring(index + 3);

                Prescriptions.Add(Prescription);
            }
            return Prescriptions;
        }
        /*
        Name: DownloadDoctor
        Purpose: Parses the string sent from the server when a doctor is downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: GetDoctor
        Date: July 1, 2020
        */
        public async Task<DoctorViewModel> DownloadDoctor(string ReceivedData)
        {
            int Id;
            string Name;
            string Practice;
            string Type;
            string Address;
            string Email;
            string Phone;
            int index;

            index = ReceivedData.IndexOf("///");
            Id = int.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Name = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Practice = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Type = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Address = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Email = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            Phone = ReceivedData;

            DoctorViewModel Doctor = new DoctorViewModel();
            Doctor.Id = (int)Id;
            Doctor.Name = Name;
            Doctor.Practice = Practice;
            Doctor.Type = Type;
            Doctor.Address = Address;
            Doctor.Email = Email;
            Doctor.Phone = Phone;
            return Doctor;
        }
        /*
        Name: DownloadAppointment
        Purpose: Parses the string sent from the server when a single appointment is downloaded
        Author: Samuel McManus
        Uses: N/A
        Used by: AppointmentDetail
        Date: July 6, 2020
        */
        public async Task<AppointmentDetailModel> DownloadAppointment(string ReceivedData)
        {
            AppointmentDetailModel Appointment = new AppointmentDetailModel();
            int index;

            index = ReceivedData.IndexOf("///");
            Appointment.AId = int.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Date = DateTime.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            if(index > 0)
                Appointment.ReminderTime = DateTime.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            if (index > 0)
                Appointment.Aftercare = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            if (index > 0)
                Appointment.Reason = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            if (index > 0)
                Appointment.Diagnosis = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Prescriptions = ReceivedData.Substring(0, index - 2);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Vaccines = ReceivedData.Substring(0, index - 2);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.DoctorName = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Appointment.Address = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);
            return Appointment;
        }
        public async Task<PrescriptionListModel> DownloadPrescription(string ReceivedData)
        {
            int index;
            PrescriptionListModel Prescription = new PrescriptionListModel();

            index = ReceivedData.IndexOf("///");
            Prescription.Id = int.Parse(ReceivedData.Substring(0, index));
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Prescription.Name = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Prescription.StartDate = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortDateString();
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Prescription.EndDate = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortDateString();
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Prescription.ReminderTime = DateTime.Parse(ReceivedData.Substring(0, index)).ToShortTimeString();
            ReceivedData = ReceivedData.Substring(index + 3);

            index = ReceivedData.IndexOf("///");
            Prescription.DoctorName = ReceivedData.Substring(0, index);
            ReceivedData = ReceivedData.Substring(index + 3);

            return Prescription;
        }
    }
}
