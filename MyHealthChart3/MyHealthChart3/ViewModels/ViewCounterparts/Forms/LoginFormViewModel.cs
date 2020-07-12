using MyHealthChart3.Models;
using MyHealthChart3.Services;
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
            SubmitCmd = new Command(async () => Submit());
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
                List<UserViewModel> Users =  await NetworkModule.Login(DataObject);
                foreach(UserViewModel User in Users)
                {
                    MessagingCenter.Send(this, Events.UserAdded, User);
                }
                (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));
            }
        }
    }
}
