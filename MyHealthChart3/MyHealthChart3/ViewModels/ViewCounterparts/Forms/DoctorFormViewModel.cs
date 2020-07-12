using MyHealthChart3.Models;
using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorFormViewModel : BaseViewModel
    {
        private IPageService PS;
        private IServerComms NetworkModule;
        private UserViewModel user;
        private bool haserror;
        private string error;
        private DoctorFormModel dataobject;

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
        public UserViewModel User
        {
            get
            {
                return user;
            }
            private set
            {
                SetValue(ref user, value);
            }
        }
        public DoctorFormModel DataObject
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
        public DoctorFormViewModel(UserViewModel u, IPageService ps, IServerComms networkModule)
        {
            User = u;
            PS = ps;
            NetworkModule = networkModule;
            DataObject = new DoctorFormModel();
            HasError = false;

            SubmitCmd = new Command(async () => await Submit());
        }
        public async Task Submit()
        {

            if(DataObject.Name != "" && DataObject.Practice != "" && DataObject.Type != "")
            {
                HasError = false;
                string result = await NetworkModule.SubmitDoctor(DataObject, User);
                if (!result.Equals("Success"))
                {
                    HasError = true;
                    Error = result;
                }
                else
                {
                    await PS.PopAsync();
                }
            }
        }
    }
}
