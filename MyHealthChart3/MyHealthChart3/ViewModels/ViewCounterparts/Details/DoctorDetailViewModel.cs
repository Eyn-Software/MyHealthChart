using MyHealthChart3.Services;
using MyHealthChart3.Models;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class DoctorDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private Doctor doctor;

        public Doctor Doctor
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
        public DoctorDetailViewModel(Doctor doc, IServerComms networkmodule)
        {
            Doctor = doc;
            NetworkModule = networkmodule;
        }
        private async System.Threading.Tasks.Task EditDoctor()
        {
            
        }
    }
}
