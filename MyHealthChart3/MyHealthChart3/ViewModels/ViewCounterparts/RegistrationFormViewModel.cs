using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class RegistrationFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private RegistrationFormModel dataobject;
        private bool haserror;
        private string error;

        public ICommand SubmitCmd
        {
            get;
            private set;
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
        public bool HasError
        {
            get
            {
                return haserror;
            }
            private set
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
            private set
            {
                SetValue(ref error, value);
            }
        }
        public RegistrationFormViewModel(IServerComms networkModule)
        {
            NetworkModule = networkModule;
            DataObject = new RegistrationFormModel();

            SubmitCmd = new Command(async () => await Submit());
        }
        private async Task Submit()
        {
            int result = DateTime.Compare(DataObject.Birthday, DateTime.Now);
            if(DataObject.Password.Equals(DataObject.ConfirmPassword) && DataObject.Email.Contains("@") && !DataObject.Name.Equals("")
                && result < 0)
            {
                HasError = false;
                List<UserViewModel> Users = await NetworkModule.Register(DataObject);
                foreach (UserViewModel User in Users)
                {
                    MessagingCenter.Send(this, Events.UserAdded, User);
                }
                (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(WelcomePage)));
            }
            else
            {
                HasError = true;
            }
            if(!DataObject.Password.Equals(DataObject.ConfirmPassword))
            {
                Error = "Passwords don't match";
            }
            else if(!DataObject.Email.Contains("@"))
            {
                Error = "Invalid email address";
            }
            else if(DataObject.Name.Equals(""))
            {
                Error = "Invalid name";
            }
        }
    }
}
