using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllergyList : ContentPage
    {
        UserViewModel User;
        Services.IServerComms NetworkModule;
        public AllergyList(UserViewModel user, Services.IServerComms networkModule)
        {
            InitializeComponent();
            User = user;
            NetworkModule = networkModule;
            ViewModel = new AllergyListViewModel(User, NetworkModule);
        }
        /*
        Name: OnAppearing
        Purpose: Sets the list of allergies before appearing each time
        Author: Samuel McManus
        Uses: SetAllergies
        Used by: N/A
        Date: July 8, 2020
        */
        protected override void OnAppearing()
        {
            ViewModel.SetAllergiesCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: AllergySelected
        Purpose: Displays the details of an allergy when clicked
        Author: Samuel McManus
        Uses: AllergyDetail
        Used by: N/A
        Date: July 8, 2020
        */
        private async void AllergySelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Allergy Allergy = e.ItemData as Allergy;
            Allergy al = new Allergy(User);
            al.Type = Allergy.Type;
            await Navigation.PushAsync(new Details.AllergyDetail(al, NetworkModule));
        }
        /*
        Name: NewAllergy
        Purpose: Creates a new allergy 
        Author: Samuel McManus
        Uses: AllergyForm
        Used by: N/A
        Date: July 8, 2020
        */
        private async void NewAllergy(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forms.AllergyForm(User, NetworkModule));
        }
        /*
        Name: OnFilterTextChanged
        Purpose: Takes search bar text and searches for allergies with that text
        Author: Samuel McManus
        Uses: AllergyListViewModel
        Used by: N/A
        Date: July 28, 2020
        */
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchbar = sender as SearchBar;
            ViewModel.FilterAllergies(searchbar.Text);
        }
        public AllergyListViewModel ViewModel
        {
            get
            {
                return BindingContext as AllergyListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}