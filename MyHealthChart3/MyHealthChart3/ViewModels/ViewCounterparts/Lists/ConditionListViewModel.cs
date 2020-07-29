using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class ConditionListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel user;
        private ObservableCollection<Models.Condition> conditions;
        private ObservableCollection<Models.Condition> filteredconditions;

        public UserViewModel User
        {
            get
            {
                return user;
            }
            set
            {
                SetValue(ref user, value);
            }
        }
        public ObservableCollection<Models.Condition> Conditions
        {
            get
            {
                return conditions;
            }
            private set
            {
                SetValue(ref conditions, value);
            }
        }
        public ObservableCollection<Models.Condition> FilteredConditions
        {
            get
            {
                return filteredconditions;
            }
            set
            {
                SetValue(ref filteredconditions, value);
            }
        }

        public ICommand SetConditionsCmd
        {
            get;
            private set;
        }
        public ConditionListViewModel(UserViewModel Usr, IServerComms networkModule)
        {
            User = Usr; 
            NetworkModule = networkModule;
            Conditions = new ObservableCollection<Models.Condition>();

            SetConditionsCmd = new Command(async () => await SetConditions());
        }
        /*
        Name: SetConditions
        Purpose: Sets the relevant conditions
        Author: Samuel McManus
        Uses: GetConditions, FilterConditions
        Used by: ConditionList
        Date: July 7, 2020
        */
        public async Task SetConditions()
        {
            Conditions = await NetworkModule.GetConditions(User);
            FilterConditions("");
        }
        /*
        Name: FilterConditions
        Purpose: Sets the relevant conditions
        Author: Samuel McManus
        Uses: N/A
        Used by: ConditionList
        Date: July 28, 2020
        */
        public void FilterConditions(string Filter)
        {
            FilteredConditions = new ObservableCollection<Models.Condition>();
            foreach (Models.Condition c in Conditions)
            {
                if (c.Type.IndexOf(Filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    FilteredConditions.Add(c);
            }
        }
    }
}
