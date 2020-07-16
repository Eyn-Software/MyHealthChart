using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.Services.Notifications;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels
{
    public class LoginFormViewModel : BaseViewModel
    {
        private INotificationService NotificationService;
        private IServerComms NetworkModule;
        private LoginFormModel dataobject;
        private bool haserror;
        private string error;
        public LoginFormModel DataObject
        {
            get
            {
                return dataobject;
            }
            set
            {
                SetValue(ref dataobject, value);
            }
        }
        public bool HasError
        {
            get
            {
                return haserror;
            }
            set
            {
                SetValue(ref haserror, value);
            }
        }
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                SetValue(ref error, value);
            }
        }
        public ICommand SubmitCmd
        {
            get;
            private set;
        }
        /*
        Name: LoginFormViewModel
        Purpose: Initializes the login form viewmodel
        Author: Samuel McManus
        Uses: N/A
        Used by: Submit
        Date: June 26 2020
        */
        public LoginFormViewModel(IServerComms networkModule)
        {
            NetworkModule = networkModule;
            DataObject = new LoginFormModel();
            NotificationService = new NotificationService();
            SubmitCmd = new Command(async () => await Submit());
        }
        /*
        Name: Submit
        Purpose: Submits the user and sends it to the server,
                 then updates the authorized list on the 
                 main page
        Author: Samuel McManus
        Uses: NetworkModule.Login
        Used by: LoginFormViewModel
        Date: June 26 2020
        */
        private async Task Submit()
        {
            if(DataObject.Password.Length < 6)
            {
                Error = "Your password must be at least 6 characters";
                HasError = true;
            }
            else if (!DataObject.Email.Contains("@") || !DataObject.Email.Contains(".com"))
            {
                Error = "Your email is incorrectly formatted";
                HasError = true;
            }
            else
            {
                List<UserViewModel> Users = await NetworkModule.Login(DataObject);
                List<PrescriptionListModel> Prescriptions = new List<PrescriptionListModel>();
                List<AppointmentReminderModel> Appointments = new List<AppointmentReminderModel>();
                List<PrescriptionListModel> TempRx;
                List<AppointmentReminderModel> TempAppt;
                //Sets all reminders for appointments and prescriptions
                foreach (UserViewModel User in Users)
                {
                    MessagingCenter.Send(this, Events.UserAdded, User);
                    //Get a list of all prescriptions for the user and add it to the list "Prescription"
                    TempRx = new List<PrescriptionListModel>(await NetworkModule.GetPrescriptions(User));
                    if(TempRx.Count != 0)
                    {
                        foreach (PrescriptionListModel p in TempRx)
                            Prescriptions.Add(p);
                    }
                    //Get a list of all future appointments for the user and add it to the list "Appointment"
                    TempAppt = new List<AppointmentReminderModel>(await NetworkModule.GetFutureAppointments(User));
                    if(TempAppt.Count != 0)
                    {
                        foreach (AppointmentReminderModel a in TempAppt)
                            Appointments.Add(a);
                    }
                }
                if(Prescriptions.Count != 0)
                {
                    foreach (PrescriptionListModel p in Prescriptions)
                    {
                        await NotificationService.PrescriptionHandler(p);
                    }
                }
                if(Appointments.Count != 0)
                {
                    foreach (AppointmentReminderModel a in Appointments)
                        await NotificationService.AppointmentHandler(a);
                }
                (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));
            }
        }
    }
}
