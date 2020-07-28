using MyHealthChart3.Models;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class PrescriptionDetailViewModel : BaseViewModel
    {
        private Services.IServerComms NetworkModule;
        private Prescription prescription;

        public Prescription Prescription
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
        public PrescriptionDetailViewModel(Prescription Rx, Services.IServerComms networkmodule)
        {
            Prescription = Rx;
            NetworkModule = networkmodule;
        }
    }
}
