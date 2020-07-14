using MyHealthChart3.Models.ViewDataObjects;
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
        private ObservableCollection<VaccineListModel> vaccines;

        public ObservableCollection<VaccineListModel> Vaccines
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
        }
    }
}
