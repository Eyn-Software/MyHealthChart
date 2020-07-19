using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Lists
{
    public class PrescriptionListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private UserViewModel User;
        private ObservableCollection<PrescriptionListModel> prescriptions;

        public ObservableCollection<PrescriptionListModel> Prescriptions
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
        }

    }
}
