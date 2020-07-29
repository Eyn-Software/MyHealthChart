using MyHealthChart3.Models;
using MyHealthChart3.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class DoctorEditViewModel : BaseViewModel
    {
        private bool haserror;
        private string error;
        private Doctor dataobject;
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
        public Doctor DataObject
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
        public DoctorEditViewModel(Models.Doctor D, IPageService ps, IServerComms networkModule)
        {
            DataObject = D;
            PS = ps;
            NetworkModule = networkModule;

            SubmitCmd = new Command(async () => await Submit());
        }
        private async Task Submit()
        {
            HasError = false;
            Error = await NetworkModule.EditDoctor(DataObject);
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
