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
            IPageService PS = new PageService();
            ViewModel = new ConditionListViewModel(User, NetworkModule, PS);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetConditionsCmd.Execute(null);
            base.OnAppearing();
        }
        private async void ConditionSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            ConditionViewModel Condition = e.ItemData as ConditionViewModel;
            ConditionFormModel cond = new ConditionFormModel(user);
            cond.Type = Condition.Type;
            await Navigation.PushAsync(new ConditionDetail(cond, networkmodule));
        }
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