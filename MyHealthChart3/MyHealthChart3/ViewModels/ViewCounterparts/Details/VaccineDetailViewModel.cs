namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class VaccineDetailViewModel : BaseViewModel
    {
        private Models.DBObjects.Vaccine vaccine;

        public Models.DBObjects.Vaccine Vaccine
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
        public VaccineDetailViewModel(Models.DBObjects.Vaccine vax)
        {
            Vaccine = vax;
        }
    }
}
