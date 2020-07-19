using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AllergyListViewModel : BaseViewModel
    {
        private Services.IServerComms NetworkModule;
        private UserViewModel User;
        private ObservableCollection<AllergyViewModel> allergies;
        
        public ObservableCollection<AllergyViewModel> Allergies
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
        public ICommand SetAllergiesCmd
        {
            get;
            private set;
        }
        public AllergyListViewModel(UserViewModel Usr, Services.IServerComms networkModule)
        {
            User = Usr;
            NetworkModule = networkModule;
            Allergies = new ObservableCollection<AllergyViewModel>();

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
        }

    }
}
