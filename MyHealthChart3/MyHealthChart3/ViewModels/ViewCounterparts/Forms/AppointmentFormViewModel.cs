using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.Services.Notifications;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AppointmentFormViewModel : BaseViewModel
    {
        private INotificationService NotificationService;
        private IPageService PS;
        private IServerComms NetworkModule;
        private bool ispast, wantsfollowup, rx0exists, rx1exists, vax0exists, vax1exists;
        private int row, result;
        private string rx0name, rx1name, rx2name, vax0name, vax1name, vax2name;
        private DateTime date, followupdate;
        private TimeSpan time, followuptime, remindertime;
        private UserViewModel user;
        private AppointmentFormEntryModel appointmentobject, followupappointmentobject;
        private PrescriptionFormEntryModel prescription0, prescription1, prescription2;
        private VaccineFormEntryModel vaccine0, vaccine1, vaccine2;
        private List<DoctorViewModel> doctors;
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
                if(!Rx0Name.Equals("") || Rx0Name == null)
                {
                    Rx0Exists = true;
                }
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
                if (!Rx1Name.Equals("") || Rx1Name == null)
                {
                    Rx1Exists = true;
                }
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
        public UserViewModel User
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
        public AppointmentFormEntryModel AppointmentObject
        {
            get
            {
                return appointmentobject;
            }
            set
            {
                SetValue(ref appointmentobject, value);
            }
        }
        public AppointmentFormEntryModel FollowupAppointmentObject
        {
            get
            {
                return followupappointmentobject;
            }
            set
            {
                SetValue(ref followupappointmentobject, value);
            }
        }
        public PrescriptionFormEntryModel Prescription0
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
        public PrescriptionFormEntryModel Prescription1
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
        public PrescriptionFormEntryModel Prescription2
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
        public VaccineFormEntryModel Vaccine0
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
        public VaccineFormEntryModel Vaccine1
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
        public VaccineFormEntryModel Vaccine2
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
        public List<DoctorViewModel> Doctors
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
        public ICommand SubmitCmd
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
        public AppointmentFormViewModel(UserViewModel Usr, IPageService Ps, IServerComms networkModule)
        {
            PS = Ps;
            NetworkModule = networkModule;
            User = Usr;
            AppointmentObject = new AppointmentFormEntryModel();
            FollowupAppointmentObject = new AppointmentFormEntryModel();
            Prescription0 = new PrescriptionFormEntryModel();
            Prescription1 = new PrescriptionFormEntryModel();
            Prescription2 = new PrescriptionFormEntryModel();
            Vaccine0 = new VaccineFormEntryModel();
            Vaccine1 = new VaccineFormEntryModel();
            Vaccine2 = new VaccineFormEntryModel();
            NotificationService = new NotificationService();
            Time = DateTime.Now.AddHours(1).TimeOfDay;
            Date = DateTime.Now;
            DoctorNames = new ObservableCollection<string>();
            FollowupDate = Date;
            FollowupTime = Time;
            WantsFollowup = false;

            SetDoctorsCmd = new Command(async () => await SetDoctors());
            SubmitCmd = new Command(async () => await Submit());
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
            DoctorViewModel doc;
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
            foreach(DoctorViewModel d in Doctors)
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
        private async Task Submit()
        {
            PrescriptionListModel P;

            AppointmentObject.Date = Date;
            AppointmentObject.ChosenDoctor = Doctors[row];
            AppointmentObject.UId = User.Id;
            AppointmentObject.Password = User.Password;
            //AppointmentObject.ReminderTime = Date.Date + ReminderTime;
            AppointmentObject.ReminderTime = Date.Date + Time;
            AppointmentObject.AId = await NetworkModule.AddAppointment(AppointmentObject);
            if(WantsFollowup)
            {
                FollowupAppointmentObject.Date = FollowupDate.Date + FollowupTime;
                FollowupAppointmentObject.ChosenDoctor = Doctors[row];
                FollowupAppointmentObject.UId = User.Id;
                FollowupAppointmentObject.Password = User.Password;
                await NetworkModule.AddAppointment(FollowupAppointmentObject);
            }
            if(Rx0Exists)
            {
                Prescription0.AId = AppointmentObject.AId;
                Prescription0.UId = AppointmentObject.UId;
                Prescription0.Name = Rx0Name;
                Prescription0.DId = AppointmentObject.ChosenDoctor.Id;
                Prescription0.Password = AppointmentObject.Password;
                Prescription0.ReminderTime = Prescription0.StartDate.Date + Prescription0.ReminderTime.TimeOfDay;
                //Adds reminders for prescription 0 and stores it on the server
                P = new PrescriptionListModel(Prescription0);
                P.Id = int.Parse(await NetworkModule.AddPrescription(Prescription0));
                await NotificationService.PrescriptionHandler(P);
            }
            if(Rx1Exists)
            {
                Prescription1.AId = AppointmentObject.AId;
                Prescription1.UId = AppointmentObject.UId;
                Prescription1.Name = Rx1Name;
                Prescription1.DId = AppointmentObject.ChosenDoctor.Id;
                Prescription1.Password = AppointmentObject.Password;
                Prescription1.ReminderTime = Prescription1.StartDate.Date + Prescription1.ReminderTime.TimeOfDay;
                //Adds reminders for prescription 1 and stores it on the server
                P = new PrescriptionListModel(Prescription1);
                P.Id = int.Parse(await NetworkModule.AddPrescription(Prescription1));
                await NotificationService.PrescriptionHandler(P);
            }
            if (Rx2Name != null && !Rx2Name.Equals(""))
            {
                Prescription2.AId = AppointmentObject.AId;
                Prescription2.UId = AppointmentObject.UId;
                Prescription2.Name = Rx2Name;
                Prescription2.DId = AppointmentObject.ChosenDoctor.Id;
                Prescription2.Password = AppointmentObject.Password;
                Prescription2.ReminderTime = Prescription2.StartDate.Date + Prescription2.ReminderTime.TimeOfDay;
                //Adds reminders for prescription 2 and stores it on the server
                P = new PrescriptionListModel(Prescription2);
                P.Id = int.Parse(await NetworkModule.AddPrescription(Prescription2));
                await NotificationService.PrescriptionHandler(P);
            }
            if(Vax0Exists)
            {
                Vaccine0.Name = Vax0Name;
                Vaccine0.AId = AppointmentObject.AId;
                Vaccine0.UId = AppointmentObject.UId;
                Vaccine0.DId = AppointmentObject.ChosenDoctor.Id;
                Vaccine0.Password = AppointmentObject.Password;
                await NetworkModule.AddVaccine(Vaccine0);
            }
            if (Vax1Exists)
            {
                Vaccine1.Name = Vax1Name;
                Vaccine1.AId = AppointmentObject.AId;
                Vaccine1.UId = AppointmentObject.UId;
                Vaccine1.DId = AppointmentObject.ChosenDoctor.Id;
                Vaccine1.Password = AppointmentObject.Password;
                await NetworkModule.AddVaccine(Vaccine1);
            }
            if (Vaccine2.Name != null && !Vaccine2.Name.Equals(""))
            {
                Vaccine2.AId = AppointmentObject.AId;
                Vaccine2.UId = AppointmentObject.UId;
                Vaccine2.DId = AppointmentObject.ChosenDoctor.Id;
                Vaccine2.Password = AppointmentObject.Password;
                await NetworkModule.AddVaccine(Vaccine2);
            }
            await PS.PopAsync();
        }
    }
}
