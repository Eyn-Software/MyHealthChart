using MyHealthChart3.Models.DBObjects;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class VaccineDetailViewModel : BaseViewModel
    {
        private Vaccine vaccine;

        public Vaccine Vaccine
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
        public VaccineDetailViewModel(Vaccine vax)
        {
            Vaccine = vax;
        }
    }
}
