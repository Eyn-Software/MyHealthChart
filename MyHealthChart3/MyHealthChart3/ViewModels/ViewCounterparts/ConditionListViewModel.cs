using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class ConditionListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private IPageService PS;
        private UserViewModel user;
        private ObservableCollection<ConditionViewModel> conditions;

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
        public ObservableCollection<ConditionViewModel> Conditions
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

        public ICommand SetConditionsCmd
        {
            get;
            private set;
        }
        public ConditionListViewModel(UserViewModel Usr, IServerComms networkModule, IPageService ps)
        {
            User = Usr; 
            NetworkModule = networkModule;
            PS = ps;
            Conditions = new ObservableCollection<ConditionViewModel>();

            SetConditionsCmd = new Command(async () => await SetConditions());
        }
        public async Task SetConditions()
        {
            Conditions = await NetworkModule.GetConditions(User);
        }
    }
}
