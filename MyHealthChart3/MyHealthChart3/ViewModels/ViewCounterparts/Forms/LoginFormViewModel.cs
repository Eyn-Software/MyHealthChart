using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels
{
    public class LoginFormViewModel : BaseViewModel
    {
        private INotificationService NotificationService;
        private IServerComms NetworkModule;
        private ILoginService LoginService;
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
        public LoginFormViewModel(ILoginService loginService, IServerComms networkModule, INotificationService notificationService)
        {
            NetworkModule = networkModule;
            DataObject = new LoginFormModel();
            NotificationService = notificationService;
            LoginService = loginService;
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
                if((await LoginService.SetUsers(DataObject, NetworkModule, NotificationService)).Equals("Success"))
                    (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));
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
