using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.ObjectModel;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Lists
{
    public class PrescriptionListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel User;
        private ObservableCollection<Models.Prescription> prescriptions;
        private ObservableCollection<Models.Prescription> filteredprescriptions;

        public ObservableCollection<Models.Prescription> Prescriptions
        {
            get
            {
                return prescriptions;
            }
            set
            {
                SetValue(ref prescriptions, value);
            }
        }
        public ObservableCollection<Models.Prescription> FilteredPrescriptions
        {
            get
            {
                return filteredprescriptions;
            }
            set
            {
                SetValue(ref filteredprescriptions, value);
            }
        }
        public System.Windows.Input.ICommand SetPrescriptionsCmd
        {
            get;
            private set;
        }
        public PrescriptionListViewModel(UserViewModel user, IServerComms networkmodule)
        {
            User = user;
            NetworkModule = networkmodule;

            SetPrescriptionsCmd = new Xamarin.Forms.Command(async () => await SetPrescriptions());
        }
        /*
        Name: SetPrescriptions
        Purpose: Gets a list of prescriptions for the user
        Author: Samuel McManus
        Uses: N/A
        Used by: PrescriptionList
        Date: July 14, 2020
        */
        private async System.Threading.Tasks.Task SetPrescriptions()
        {
            Prescriptions = await NetworkModule.GetPrescriptions(User);
            FilteredPrescriptions = Prescriptions;
        }
        /*
        Name: FilterPrescriptions
        Purpose: Filters prescriptions based on content
        Author: Samuel McManus
        Uses: N/A
        Used by: PrescriptionList
        Date: July 27, 2020
        */
        public void FilterPrescriptions(string Filter)
        {
            FilteredPrescriptions = new ObservableCollection<Models.Prescription>();
            foreach (Models.Prescription p in Prescriptions)
            {
                if (p.Name.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.StartDateString.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    p.EndDateString.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 || 
                    p.DoctorName.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    FilteredPrescriptions.Add(p);
            }
        }
    }
}
