using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class DoctorDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private DoctorViewModel doctor;

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
        public DoctorDetailViewModel(DoctorViewModel doc, IServerComms networkmodule)
        {
            Doctor = doc;
            NetworkModule = networkmodule;
        }
        private async System.Threading.Tasks.Task EditDoctor()
        {
            
        }
    }
}
