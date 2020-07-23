using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class UserFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private bool namehaserror;
        private bool birthdayhaserror;
        private string nameerror;
        private string birthdayerror;
        private UserViewModel user;

        public bool HasErrors;
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
        public UserFormViewModel(UserViewModel otheruser, IServerComms networkmodule)
        {
            User = new UserViewModel();
            User.Birthday = DateTime.Now;
            User.Id = otheruser.Id;
            User.Password = otheruser.Password;
            NetworkModule = networkmodule;
        }
        public async System.Threading.Tasks.Task Submit()
        {
            HasErrors = true;
            if (User.Name.Equals(""))
                NameError = "Required*";
            int result = DateTime.Compare(User.Birthday, DateTime.Now);
            if(result > 0)
                BirthdayError = "You cannot use a birthday in the future";
            if(!NameHasError && !BirthdayHasError)
            {
                HasErrors = false;
                User = await NetworkModule.AddUser(User);
                Xamarin.Forms.MessagingCenter.Send(this, Events.UserAdded, User);
            }
        }
    }
}
