using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using MyHealthChart3.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConditionList : ContentPage
    {
        UserViewModel user;
        IServerComms networkmodule;
        public ConditionList(UserViewModel User, IServerComms NetworkModule)
        {
            InitializeComponent();
            user = User;
            networkmodule = NetworkModule;
            ViewModel = new ConditionListViewModel(User, NetworkModule);
        }
        /*
        Name: OnAppearing
        Purpose: Calls the command which sets all the user's conditions
        Author: Samuel McManus
        Uses: SetConditionsCmd
        Used by: N/A
        Date: July 7, 2020
        */
        protected override void OnAppearing()
        {
            ViewModel.SetConditionsCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: ConditionSelected
        Purpose: Sends the selected condition to the condition detail page
        Author: Samuel McManus
        Uses: ConditionDetail
        Used by: N/A
        Date: July 7, 2020
        */
        private async void ConditionSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            ConditionViewModel Condition = e.ItemData as ConditionViewModel;
            ConditionFormModel cond = new ConditionFormModel(user);
            cond.Type = Condition.Type;
            await Navigation.PushAsync(new ConditionDetail(cond, networkmodule));
        }
        /*
        Name: NewCondition
        Purpose: Redirects the user to the condition form page
        Author: Samuel McManus
        Uses: ConditionForm
        Used by: MainPage
        Date: July 7, 2020
        */
        private async void NewCondition(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConditionForm(user, networkmodule));
        }
        public ConditionListViewModel ViewModel
        {
            get
            {
                return BindingContext as ConditionListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}