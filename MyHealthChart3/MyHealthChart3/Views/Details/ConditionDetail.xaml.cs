using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConditionDetail : ContentPage
    {
        public ConditionDetail(Models.Condition Condition, IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new ConditionDetailViewModel(Condition, NetworkModule);
        }
        /*
        Name: Delete Condition
        Purpose: Deletes the chosen condition
        Author: Samuel McManus
        Uses: DeleteConditionCmd
        Used by: MainPage
        Date: July 7, 2020
        */
        public async void DeleteCondition(object sender, EventArgs e)
        {
            await ViewModel.DeleteCondition();
            await Navigation.PopAsync();
        }
        public ConditionDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as ConditionDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}