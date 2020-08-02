using MyHealthChart3.Models;
using MyHealthChart3.Models.DBObjects;
using MyHealthChart3.Services;
using System.Collections.ObjectModel;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Lists
{
    public class VaccineListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private User User;
        private ObservableCollection<Vaccine> vaccines;
        private ObservableCollection<Vaccine> filteredvaccines;

        public ObservableCollection<Vaccine> Vaccines
        {
            get
            {
                return vaccines;
            }
            set
            {
                SetValue(ref vaccines, value);
            }
        }
        public ObservableCollection<Vaccine> FilteredVaccines
        {
            get
            {
                return filteredvaccines;
            }
            set
            {
                SetValue(ref filteredvaccines, value);
            }
        }
        public System.Windows.Input.ICommand SetVaccinesCmd
        {
            get;
            private set;
        }
        public VaccineListViewModel(User user, IServerComms networkModule)
        {
            User = user;
            NetworkModule = networkModule;

            SetVaccinesCmd = new Xamarin.Forms.Command(async () => await SetVaccines());
        }
        /*
        Name: SetVaccines
        Purpose: Sets the list of the user's vaccines
        Author: Samuel McManus
        Uses: N/A
        Used by: VaccineListViewModel
        Date: July 13, 2020
        */
        public async System.Threading.Tasks.Task SetVaccines()
        {
            Vaccines = await NetworkModule.GetVaccines(User);
            FilteredVaccines = Vaccines;
        }
        /*
        Name: FilterVaccines
        Purpose: Takes text from the search bar and filters 
        Author: Samuel McManus
        Uses: N/A
        Used by: VaccineList
        Date: July 24, 2020
        */
        public void FilterVaccines(string Filter)
        {
            FilteredVaccines = new ObservableCollection<Vaccine>();
            foreach(Vaccine v in Vaccines)
            {
                if (v.Name.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0 || 
                    v.StringDate.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    FilteredVaccines.Add(v);
            }
        }
    }
}
