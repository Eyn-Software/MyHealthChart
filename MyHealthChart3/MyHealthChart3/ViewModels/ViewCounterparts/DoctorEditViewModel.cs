using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorEditViewModel : BaseViewModel
    {
        private bool haserror;
        private string error;
        private DoctorEditModel dataobject;
        private UserViewModel user;
        private DoctorViewModel doctor;
        private IPageService PS;
        private IServerComms NetworkModule;

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
        public DoctorEditModel DataObject
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
        public DoctorViewModel Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                SetValue(ref doctor, value);
            }
        }
        public ICommand SubmitCmd
        {
            get;
            private set;
        }
        public DoctorEditViewModel(DoctorViewModel D, UserViewModel U, IPageService ps, IServerComms networkModule)
        {
            User = U;
            Doctor = D;
            PS = ps;
            NetworkModule = networkModule;
            DataObject = new DoctorEditModel(Doctor);

            SubmitCmd = new Command(async () => await Submit());
        }
        private async Task Submit()
        {
            HasError = false;
            Error = await NetworkModule.EditDoctor(DataObject, User);
            if(Error.Equals("Success"))
            {
                await PS.PopAsync();
            }
            else
            {
                HasError = true;
            }
            
        }
    }
}
