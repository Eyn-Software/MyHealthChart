using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class RegistrationFormViewModel : BaseViewModel
    {
        private ILoginService LoginService;
        private IServerComms NetworkModule;
        private INotificationService NotificationService;
        private RegistrationFormModel dataobject;
        private bool namehaserror;
        private bool birthdayhaserror;
        private bool emailhaserror;
        private bool passwordhaserror;
        private bool confirmpasswordhaserror;
        private string nameerror;
        private string birthdayerror;
        private string emailerror;
        private string passworderror;
        private string confirmpassworderror;

        public bool NameHasError
        {
            get
            {
                return namehaserror;
            }
            set
            {
                SetValue(ref namehaserror, value);
            }
        }
        public bool BirthdayHasError
        {
            get
            {
                return birthdayhaserror;
            }
            set
            {
                SetValue(ref birthdayhaserror, value);
            }
        }
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
        public bool ConfirmPasswordHasError
        {
            get
            {
                return confirmpasswordhaserror;
            }
            set
            {
                SetValue(ref confirmpasswordhaserror, value);
            }
        }
        public string NameError
        {
            get
            {
                return nameerror;
            }
            set
            {
                SetValue(ref nameerror, value);
                if (NameError.Equals(""))
                    NameHasError = false;
                else
                    NameHasError = true;
            }
        }
        public string BirthdayError
        {
            get
            {
                return birthdayerror;
            }
            set
            {
                SetValue(ref birthdayerror, value);
                if (BirthdayError.Equals(""))
                    BirthdayHasError = false;
                else
                    BirthdayHasError = true;
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
        public string ConfirmPasswordError
        {
            get
            {
                return confirmpassworderror;
            }
            set
            {
                SetValue(ref confirmpassworderror, value);
                if (ConfirmPasswordError.Equals(""))
                    ConfirmPasswordHasError = false;
                else
                    ConfirmPasswordHasError = true;
            }
        }
        public RegistrationFormModel DataObject
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
        public RegistrationFormViewModel(ILoginService loginservice, IServerComms networkModule, INotificationService notificationService)
        {
            LoginService = loginservice;
            NetworkModule = networkModule;
            NotificationService = notificationService;
            DataObject = new RegistrationFormModel();

            SubmitCmd = new Command(async () => await Submit());
        }
        private async Task Submit()
        {
            //Resets all errors
            NameError = "";
            BirthdayError = "";
            EmailError = "";
            PasswordError = "";
            ConfirmPasswordError = "";

            //Catches name errors
            if (DataObject.Name.Equals(""))
                NameError = "Required*";
            //Catches birthday errors
            int result = DateTime.Compare(DataObject.Birthday, DateTime.Now);
            if (result > 0)
                BirthdayError = "You cannot use a birthday in the future";
            //Catches email errors
            if (DataObject.Email.Equals(""))
                EmailError = "Required*";
            else if (!DataObject.Email.Contains("@") || !DataObject.Email.Contains("."))
                EmailError = "Invalid email";
            //Catches password errors
            if (DataObject.Password.Equals(""))
                PasswordError = "Required*";
            else if (DataObject.Password.Length < 6 || DataObject.Password.Length > 254)
                PasswordError = "Your password must be between 6 and 254 characters";
            //Catches password confirmation errors
            if (!DataObject.ConfirmPassword.Equals(DataObject.Password))
                ConfirmPasswordError = "Your passwords must match";

            //Sends in the relevant data if 
            if(!NameHasError && !BirthdayHasError && !EmailHasError && !PasswordHasError && !ConfirmPasswordHasError)
            {
                Models.LoginFormModel Login = new Models.LoginFormModel();
                Login.Email = DataObject.Email;
                Login.Password = DataObject.Password;
                await LoginService.SetCredentials(Login);
                List<User> Users = await NetworkModule.Register(DataObject);
                foreach (User User in Users)
                {
                    MessagingCenter.Send(this, Events.UserAdded, User);
                }
                (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));
            }
        }
    }
}
