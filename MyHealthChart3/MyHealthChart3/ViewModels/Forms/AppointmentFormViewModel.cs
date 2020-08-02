using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentFormViewModel : BaseViewModel
    {
        private INotificationService NotificationService;
        private IServerComms NetworkModule;
        private bool ispast, wantsfollowup, rx0exists, rx1exists, vax0exists, vax1exists, rx0haserror, rx1haserror, rx2haserror;
        private int row, result;
        private string rx0name, rx1name, rx2name, vax0name, vax1name, vax2name, rx0error, rx1error, rx2error;
        private DateTime date, followupdate;
        private TimeSpan time, followuptime, remindertime;
        private User user;
        private Appointment appointment, followupappointment;
        private Prescription prescription0, prescription1, prescription2;
        private Vaccine vaccine0, vaccine1, vaccine2;
        private List<Doctor> doctors;
        private ObservableCollection<string> doctornames;

        public bool IsPast
        {
            get
            {
                return ispast;
            }
            set
            {
                SetValue(ref ispast, value);
                if(!IsPast)
                {
                    Rx0Exists = false;
                    Vax0Exists = false;
                }
            }
        }
        public bool WantsFollowup
        {
            get
            {
                return wantsfollowup;
            }
            set
            {
                SetValue(ref wantsfollowup, value);
            }
        }
        public bool Rx0Exists
        {
            get
            {
                return rx0exists;
            }
            set
            {
                SetValue(ref rx0exists, value);
                if(!Rx0Exists)
                {
                    Rx1Exists = false;
                }
            }
        }
        public string Rx0Name
        {
            get
            {
                return rx0name;
            }
            set
            {
                SetValue(ref rx0name, value);
                if (!Rx0Name.Equals("") && Rx0Name != null)
                {
                    Rx0Exists = true;
                }
                else
                    Rx0Exists = false;
            }
        }
        public bool Rx0HasError
        {
            get
            {
                return rx0haserror;
            }
            set
            {
                SetValue(ref rx0haserror, value);
            }
        }
        public string Rx0Error
        {
            get
            {
                return rx0error;
            }
            set
            {
                SetValue(ref rx0error, value);
                if (Rx0Error.Equals(""))
                    Rx0HasError = false;
                else
                    Rx0HasError = true;
            }
        }
        public bool Rx1Exists
        {
            get
            {
                return rx1exists;
            }
            set
            {
                SetValue(ref rx1exists, value);
            }
        }
        public string Rx1Name
        {
            get
            {
                return rx1name;
            }
            set
            {
                SetValue(ref rx1name, value);
                if (!Rx1Name.Equals("") && Rx1Name != null)
                {
                    Rx1Exists = true;
                }
                else
                    Rx1Exists = false;
            }
        }
        public bool Rx1HasError
        {
            get
            {
                return rx1haserror;
            }
            set
            {
                SetValue(ref rx1haserror, value);
            }
        }
        public string Rx1Error
        {
            get
            {
                return rx1error;
            }
            set
            {
                SetValue(ref rx1error, value);
                if (Rx1Error.Equals(""))
                    Rx1HasError = false;
                else
                    Rx1HasError = true;
            }
        }
        public string Rx2Name
        {
            get
            {
                return rx2name;
            }
            set
            {
                SetValue(ref rx2name, value);
            }
        }
        public bool Rx2HasError
        {
            get
            {
                return rx2haserror;
            }
            set
            {
                SetValue(ref rx2haserror, value);
            }
        }
        public string Rx2Error
        {
            get
            {
                return rx2error;
            }
            set
            {
                SetValue(ref rx2error, value);
                if (Rx2Error.Equals(""))
                    Rx2HasError = false;
                else
                    Rx2HasError = true;
            }
        }
        public bool Vax0Exists
        {
            get
            {
                return vax0exists;
            }
            set
            {
                SetValue(ref vax0exists, value);
                if(!Vax0Exists)
                {
                    Vax1Exists = false;
                }
            }
        }
        public string Vax0Name
        {
            get
            {
                return vax0name;
            }
            set
            {
                SetValue(ref vax0name, value);
                if(!Vax0Name.Equals(""))
                {
                    Vax0Exists = true;
                }
            }
        }
        public bool Vax1Exists
        {
            get
            {
                return vax1exists;
            }
            set
            {
                SetValue(ref vax1exists, value);
            }
        }
        public string Vax1Name
        {
            get
            {
                return vax1name;
            }
            set
            {
                SetValue(ref vax1name, value);
                if(!Vax1Name.Equals(""))
                {
                    Vax1Exists = true;
                }
            }
        }
        public string Vax2Name
        {
            get
            {
                return vax2name;
            }
            set
            {
                SetValue(ref vax2name, value);
            }
        }
        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                SetValue(ref row, value);
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                SetValue(ref date, value);
                if(Date.TimeOfDay != time)
                {
                    Date = Date.Date.Add(time);
                }
                result = DateTime.Compare(Date, DateTime.Now);
                if(result > 0)
                {
                    IsPast = false;
                }
                else
                {
                    IsPast = true;
                }
            }
        }
        public TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                SetValue(ref time, value);
                Date = Date.Date + Time;
            }
        }
        public TimeSpan ReminderTime
        {
            get
            {
                return time;
            }
            set
            {
                SetValue(ref remindertime, value);
            }
        }
        public DateTime FollowupDate
        {
            get
            {
                return followupdate;
            }
            set
            {
                SetValue(ref followupdate, value);
            }
        }
        public TimeSpan FollowupTime
        {
            get
            {
                return followuptime;
            }
            set
            {
                SetValue(ref followuptime, value);
            }
        }
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                SetValue(ref user, value);
            }
        }
        public Appointment Appointment
        {
            get
            {
                return appointment;
            }
            set
            {
                SetValue(ref appointment, value);
            }
        }
        public Appointment FollowupAppointment
        {
            get
            {
                return followupappointment;
            }
            set
            {
                SetValue(ref followupappointment, value);
            }
        }
        public Prescription Prescription0
        {
            get
            {
                return prescription0;
            }
            set
            {
                SetValue(ref prescription0, value);
            }
        }
        public Prescription Prescription1
        {
            get
            {
                return prescription1;
            }
            set
            {
                SetValue(ref prescription1, value);
            }
        }
        public Prescription Prescription2
        {
            get
            {
                return prescription2;
            }
            set
            {
                SetValue(ref prescription2, value);
            }
        }
        public Vaccine Vaccine0
        {
            get
            {
                return vaccine0;
            }
            set
            {
                SetValue(ref vaccine0, value);
            }
        }
        public Vaccine Vaccine1
        {
            get
            {
                return vaccine1;
            }
            set
            {
                SetValue(ref vaccine1, value);
            }
        }
        public Vaccine Vaccine2
        {
            get
            {
                return vaccine2;
            }
            set
            {
                SetValue(ref vaccine2, value);
            }
        }
        public List<Doctor> Doctors
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
        public ObservableCollection<string> DoctorNames
        {
            get
            {
                return doctornames;
            }
            set
            {
                SetValue(ref doctornames, value);
            }
        }
        public ICommand SetDoctorsCmd
        {
            get;
            private set;
        }
        /*
        Name: AppointmentFormViewModel 
        Purpose: Initializes the Appointment Form ViewModel
        Author: Samuel McManus
        Uses: SetDoctors, Submit
        Used by: AppointmentForm
        Date: July 3, 2020
        */
        public AppointmentFormViewModel(User Usr, IServerComms networkModule)
        {
            NetworkModule = networkModule;
            User = Usr;
            Appointment = new Appointment();
            FollowupAppointment = new Appointment();
            Prescription0 = new Prescription();
            Prescription1 = new Prescription();
            Prescription2 = new Prescription();
            Vaccine0 = new Vaccine();
            Vaccine1 = new Vaccine();
            Vaccine2 = new Vaccine();
            NotificationService = new NotificationService();
            Time = DateTime.Now.AddHours(1).TimeOfDay;
            Date = DateTime.Now;
            DoctorNames = new ObservableCollection<string>();
            FollowupDate = Date;
            FollowupTime = Time;
            WantsFollowup = false;

            SetDoctorsCmd = new Command(async () => await SetDoctors());
        }
        /*
        Name: SetDoctors
        Purpose: Sets all of the available doctors on the appointment form
        Author: Samuel McManus
        Uses: GetDoctors
        Used by: AppointmentForm
        Date: July 3 2020
        */
        private async Task SetDoctors()
        {
            Doctors = await NetworkModule.GetDoctors(User);
            int result;
            Doctor doc;
            if (Doctors.Count != 0)
            {
                for (int i = 0; i < Doctors.Count - 1; i++)
                {
                    for (int j = 0; j < Doctors.Count - i - 1; j++)
                    {
                        result = String.Compare(Doctors[j].Name, Doctors[j + 1].Name);
                        if (result > 0)
                        {
                            doc = Doctors[j];
                            Doctors[j] = Doctors[j + 1];
                            Doctors[j + 1] = doc;
                        }
                    }
                }
            }
            foreach(Doctor d in Doctors)
            {
                DoctorNames.Add(d.Name);
            }
        }
        /*
        Name: Submit
        Purpose: Submits all the relevant appointments, prescriptions, and vaccines
        Author: Samuel McManus
        Uses: AddAppointment, AddPrescription, AddVaccine
        Used by: MainPage
        Date: July 3, 2020
        */
        public async Task<string> Submit()
        {
            Rx0HasError = false;
            Rx1HasError = false;
            Rx2HasError = false;
            //Error checking
            int result;
            if (Rx0Exists)
            {
                result = DateTime.Compare(Prescription0.EndDate, Prescription0.StartDate);
                if (result < 0)
                    Rx0Error = "The start date cannot come before the end date";
            }
            if(Rx1Exists)
            {
                result = DateTime.Compare(Prescription1.EndDate, Prescription1.StartDate);
                if(result < 0)
                    Rx1Error = "The start date cannot come before the end date";
            }
            if(Rx2Name != null && !Rx2Name.Equals(""))
            {
                result = DateTime.Compare(Prescription2.EndDate, Prescription2.StartDate);
                if(result < 0)
                    Rx2Error = "The start date cannot come before the end date";
            }
            if (Rx0HasError || Rx1HasError || Rx2HasError)
                return "";
            Appointment.Date = Date;
            Appointment.ChosenDoctor = Doctors[row];
            Appointment.UId = User.Id;
            Appointment.Password = User.Password;
            Appointment.ReminderTime = Date.Date + Time;
            Appointment.Id = await NetworkModule.AddAppointment(Appointment);
            if(WantsFollowup)
            {
                FollowupAppointment.Date = FollowupDate.Date + FollowupTime;
                FollowupAppointment.ChosenDoctor = Doctors[row];
                FollowupAppointment.UId = User.Id;
                FollowupAppointment.Password = User.Password;
                await NetworkModule.AddAppointment(FollowupAppointment);
            }
            if(Rx0Exists)
            {
                Prescription0.AId = Appointment.Id;
                Prescription0.UId = Appointment.UId;
                Prescription0.Name = Rx0Name;
                Prescription0.DId = Appointment.ChosenDoctor.Id;
                Prescription0.Password = Appointment.Password;
                Prescription0.ReminderTime = Prescription0.StartDate.Date + Prescription0.ReminderTime.TimeOfDay;
                //Adds reminders for prescription 0 and stores it on the server
                Prescription0.Id = int.Parse(await NetworkModule.AddPrescription(Prescription0));
                await NotificationService.PrescriptionHandler(Prescription0);
            }
            if(Rx1Exists)
            {
                Prescription1.AId = Appointment.Id;
                Prescription1.UId = Appointment.UId;
                Prescription1.Name = Rx1Name;
                Prescription1.DId = Appointment.ChosenDoctor.Id;
                Prescription1.Password = Appointment.Password;
                Prescription1.ReminderTime = Prescription1.StartDate.Date + Prescription1.ReminderTime.TimeOfDay;
                //Adds reminders for prescription 1 and stores it on the server
                Prescription1.Id = int.Parse(await NetworkModule.AddPrescription(Prescription1));
                await NotificationService.PrescriptionHandler(Prescription1);
            }
            if (Rx2Name != null && !Rx2Name.Equals(""))
            {
                Prescription2.AId = Appointment.Id;
                Prescription2.UId = Appointment.UId;
                Prescription2.Name = Rx2Name;
                Prescription2.DId = Appointment.ChosenDoctor.Id;
                Prescription2.Password = Appointment.Password;
                Prescription2.ReminderTime = Prescription2.StartDate.Date + Prescription2.ReminderTime.TimeOfDay;
                //Adds reminders for prescription 2 and stores it on the server
                Prescription2.Id = int.Parse(await NetworkModule.AddPrescription(Prescription2));
                await NotificationService.PrescriptionHandler(Prescription2);
            }
            if(Vax0Exists)
            {
                Vaccine0.Name = Vax0Name;
                Vaccine0.AId = Appointment.Id;
                Vaccine0.UId = Appointment.UId;
                Vaccine0.DId = Appointment.ChosenDoctor.Id;
                Vaccine0.Password = Appointment.Password;
                await NetworkModule.AddVaccine(Vaccine0);
            }
            if (Vax1Exists)
            {
                Vaccine1.Name = Vax1Name;
                Vaccine1.AId = Appointment.Id;
                Vaccine1.UId = Appointment.UId;
                Vaccine1.DId = Appointment.ChosenDoctor.Id;
                Vaccine1.Password = Appointment.Password;
                await NetworkModule.AddVaccine(Vaccine1);
            }
            if (Vaccine2.Name != null && !Vaccine2.Name.Equals(""))
            {
                Vaccine2.AId = Appointment.Id;
                Vaccine2.UId = Appointment.UId;
                Vaccine2.DId = Appointment.ChosenDoctor.Id;
                Vaccine2.Password = Appointment.Password;
                await NetworkModule.AddVaccine(Vaccine2);
            }
            return "Success";
        }
    }
}
