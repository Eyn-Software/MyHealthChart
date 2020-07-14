using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class VaccineDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private VaccineListModel vaccine;

        public VaccineListModel Vaccine
        {
            get
            {
                return vaccine;
            }
            set
            {
                SetValue(ref vaccine, value);
            }
        }
        public VaccineDetailViewModel(VaccineListModel vax, IServerComms networkModule)
        {
            Vaccine = vax;
            NetworkModule = networkModule;
        }
    }
}
