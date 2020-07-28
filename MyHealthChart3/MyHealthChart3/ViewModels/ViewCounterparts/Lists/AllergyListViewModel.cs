using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AllergyListViewModel : BaseViewModel
    {
        private Services.IServerComms NetworkModule;
        private UserViewModel User;
        private ObservableCollection<Allergy> allergies;
        private ObservableCollection<Allergy> filteredallergies;
        
        public ObservableCollection<Allergy> Allergies
        {
            get
            {
                return allergies;
            }
            set
            {
                SetValue(ref allergies, value);
            }
        }
        public ObservableCollection<Allergy> FilteredAllergies
        {
            get
            {
                return filteredallergies;
            }
            set
            {
                SetValue(ref filteredallergies, value);
            }
        }
        public ICommand SetAllergiesCmd
        {
            get;
            private set;
        }
        public AllergyListViewModel(UserViewModel Usr, Services.IServerComms networkModule)
        {
            User = Usr;
            NetworkModule = networkModule;
            Allergies = new ObservableCollection<Allergy>();

            SetAllergiesCmd = new Command(async () => await SetAllergies());
        }
        /*
        Name: SetAllergies
        Purpose: Sets a list of the user's allergies
        Author: Samuel McManus
        Uses: N/A
        Used by: AllergyList
        Date: July 8, 2020
        */
        private async Task SetAllergies()
        {
            Allergies = await NetworkModule.GetAllergies(User);
            FilterAllergies("");
        }
        public void FilterAllergies(string Filter)
        {
            FilteredAllergies = new ObservableCollection<Allergy>();
            foreach (Allergy a in Allergies)
            {
                if (a.Type.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    FilteredAllergies.Add(a);
            }
        }

    }
}
