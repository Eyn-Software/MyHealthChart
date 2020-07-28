using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class PrescriptionDetailViewModel : BaseViewModel
    {
        private Services.IServerComms NetworkModule;
        private PrescriptionListModel prescription;
        private UserViewModel user;

        public PrescriptionListModel Prescription
        {
            get
            {
                return prescription;
            }
            set
            {
                SetValue(ref prescription, value);
            }
        }
        public System.Windows.Input.ICommand GetPrescriptionCmd
        {
            get;
            private set;
        }
        public PrescriptionDetailViewModel(PrescriptionListModel Rx, Services.IServerComms networkmodule)
        {
            Prescription = Rx;
            NetworkModule = networkmodule;

            GetPrescriptionCmd = new Xamarin.Forms.Command(async () => await GetPrescription());
        }
        public async System.Threading.Tasks.Task GetPrescription()
        {
            user = Prescription.User;
            Prescription = await NetworkModule.GetPrescription(Prescription);
            Prescription.User = user;
        }
    }
}
