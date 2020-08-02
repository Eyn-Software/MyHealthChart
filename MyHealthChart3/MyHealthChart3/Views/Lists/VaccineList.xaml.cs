using MyHealthChart3.ViewModels.ViewCounterparts.Lists;
using MyHealthChart3.Models.DBObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHealthChart3.Models;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VaccineList : ContentPage
    {
        private User User;
        public VaccineList(User user, Services.IServerComms networkModule)
        {
            InitializeComponent();
            User = user;
            ViewModel = new VaccineListViewModel(User, networkModule);
        }
        /*
        Name: OnAppearing
        Purpose: Gets vaccines from the server whenever this page appears
        Author: Samuel McManus
        Uses: SetVaccines
        Used by: N/A
        Date: July 13, 2020
        */
        protected override void OnAppearing()
        {
            ViewModel.SetVaccinesCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: VaccineSelected
        Purpose: Takes the selected vaccine and pushes it to the detail page
        Author: Samuel McManus
        Uses: VaccineDetail
        Used by: N/A
        Date: July 13, 2020
        */
        private async void VaccineSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Vaccine Vaccine = e.ItemData as Vaccine;
            Vaccine.UId = User.Id;
            Vaccine.Password = User.Password;
            await Navigation.PushAsync(new Details.VaccineDetail(Vaccine));
        }
        /*
        Name: OnFilterTextChanged
        Purpose: Takes search bar text and sends to filter method
        Author: Samuel McManus
        Uses: FilterVaccines
        Used by: N/A
        Date: July 24, 2020
        */
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchbar = sender as SearchBar;
            ViewModel.FilterVaccines(searchbar.Text);
        }
        public VaccineListViewModel ViewModel
        {
            get
            {
                return BindingContext as VaccineListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}