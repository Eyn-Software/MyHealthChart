using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Lists
{
    public class VaccineListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel User;
        private ObservableCollection<VaccineViewModel> vaccines;

        public ObservableCollection<VaccineViewModel> Vaccines
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
        public System.Windows.Input.ICommand SetVaccinesCmd
        {
            get;
            private set;
        }
        public VaccineListViewModel(UserViewModel user, IServerComms networkModule)
        {
            User = user;
            NetworkModule = networkModule;

            SetVaccinesCmd = new Xamarin.Forms.Command(async () => await SetVaccines());
        }
        public async System.Threading.Tasks.Task SetVaccines()
        {
            Vaccines = await NetworkModule.GetVaccines(User);
        }
    }
}
