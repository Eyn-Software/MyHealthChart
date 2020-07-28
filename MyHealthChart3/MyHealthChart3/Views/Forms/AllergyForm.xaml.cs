using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllergyForm : ContentPage
    {
        public AllergyForm(UserViewModel User, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new AllergyFormViewModel(User, NetworkModule);
        }
        /*
        Name: Submit
        Purpose: Adds the user to the user_allergy table and returns to the list
        Author: Samuel McManus
        Uses: Submit
        Used by: N/A
        Date: July 8, 2020
        */
        public async void Submit(object sender, EventArgs e)
        {
            if(await ViewModel.Submit())
            {
                await Navigation.PopAsync();
            }  
        }
        public AllergyFormViewModel ViewModel
        {
            get
            {
                return BindingContext as AllergyFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}