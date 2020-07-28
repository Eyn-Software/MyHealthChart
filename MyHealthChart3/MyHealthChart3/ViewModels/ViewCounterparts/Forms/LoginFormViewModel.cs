using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.Services.Notifications;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels
{
    public class LoginFormViewModel : BaseViewModel
    {
        private INotificationService NotificationService;
        private IServerComms NetworkModule;
        private bool emailhaserror;
        private bool passwordhaserror;
        private string emailerror;
        private string passworderror;
        private LoginFormModel dataobject;

        public bool EmailHasError
        {
            get
            {
                return emailhaserror;
            }
            set
            {
                SetValue(ref emailhaserror, value);
            }
        }
        public bool PasswordHasError
        {
            get
            {
                return passwordhaserror;
            }
            set
            {
                SetValue(ref passwordhaserror, value);
            }
        }
        public string EmailError
        {
            get
            {
                return emailerror;
            }
            set
            {
                SetValue(ref emailerror, value);
                if (EmailError.Equals(""))
                    EmailHasError = false;
                else
                    EmailHasError = true;
            }
        }
        public string PasswordError
        {
            get
            {
                return passworderror;
            }
            set
            {
                SetValue(ref passworderror, value);
                if (PasswordError.Equals(""))
                    PasswordHasError = false;
                else
                    PasswordHasError = true;
            }
        }
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
            EmailError = "";
            PasswordError = "";
            //Catches email errors
            if (DataObject.Email.Equals(""))
                EmailError = "Required*";
            else if (!DataObject.Email.Contains("@") || !DataObject.Email.Contains("."))
                EmailError = "Invalid email";
            //Catches password errors
            if(DataObject.Password.Equals(""))
                PasswordError = "Required*";
            //Catches email password combo errors
            if (!EmailHasError && !PasswordHasError)
            {
                List<UserViewModel> Users = await NetworkModule.Login(DataObject);
                if (Users.Count != 0)
                {
                    List<PrescriptionListModel> Prescriptions = new List<PrescriptionListModel>();
                    List<AppointmentReminderModel> Appointments = new List<AppointmentReminderModel>();
                    List<PrescriptionListModel> TempRx;
                    List<AppointmentReminderModel> TempAppt;

                    //Gets a list of all prescriptions and appointments for the user
                    //This section is used to create prescription and appointment reminders.
                    foreach (UserViewModel User in Users)
                    {
                        MessagingCenter.Send(this, Events.UserAdded, User);
                        //Get a list of all prescriptions for the user and add it to the list "Prescription"
                        TempRx = new List<PrescriptionListModel>(await NetworkModule.GetPrescriptions(User));
                        if (TempRx.Count != 0)
                        {
                            foreach (PrescriptionListModel p in TempRx)
                                Prescriptions.Add(p);
                        }
                        //Get a list of all future appointments for the user and add it to the list "Appointment"
                        TempAppt = new List<AppointmentReminderModel>(await NetworkModule.GetFutureAppointments(User));
                        if (TempAppt.Count != 0)
                        {
                            foreach (AppointmentReminderModel a in TempAppt)
                                Appointments.Add(a);
                        }
                    }
                    //Sets up daily notifications for each prescription
                    if (Prescriptions.Count != 0)
                    {
                        foreach (PrescriptionListModel p in Prescriptions)
                        {
                            await NotificationService.PrescriptionHandler(p);
                        }
                    }
                    //Sets up daily notifications for each appointment
                    if (Appointments.Count != 0)
                    {
                        foreach (AppointmentReminderModel a in Appointments)
                            await NotificationService.AppointmentHandler(a);
                    }
                (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));
                }
                //If the email and password don't work, set the password error.
                else
                {
                    PasswordHasError = true;
                    PasswordError = "Invalid email or password";
                }
            }
        }
    }
}
