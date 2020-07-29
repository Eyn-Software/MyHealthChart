using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConditionForm : ContentPage
    {
        public ConditionForm(UserViewModel User, IServerComms networkModule)
        {
            InitializeComponent();
            ViewModel = new ConditionFormViewModel(User, networkModule);
        }
        /*
        Name: Submit
        Purpose: Submits the condition being entered
        Author: Samuel McManus
        Uses: Submit
        Used by: N/A
        Date: July 7, 2020
        */
        public async void Submit(object sender, EventArgs e)
        {
            if(await ViewModel.Submit())
            {
                await Navigation.PopAsync();
            }
        }
        public ConditionFormViewModel ViewModel
        {
            get
            {
                return BindingContext as ConditionFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}