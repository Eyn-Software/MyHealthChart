using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ViewCounterparts.Lists;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionList : ContentPage
    {
        private User User;
        private Services.IServerComms NetworkModule;
        public PrescriptionList(User Usr, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            User = Usr;
            NetworkModule = networkmodule;
            ViewModel = new PrescriptionListViewModel(User, networkmodule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetPrescriptionsCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: PrescriptionSelected
        Purpose: Redirects the user to prescription detail page when they select a prescription
        Author: Samuel McManus
        Uses: PrescriptionDetail
        Used by: N/A
        Date: July 14, 2020
        */
        private async void PrescriptionSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.Prescription Prescription = e.ItemData as Models.Prescription;
            Prescription.UId = User.Id;
            Prescription.Password = User.Password;
            await Navigation.PushAsync(new Details.PrescriptionDetail(Prescription, NetworkModule));
        }
        /*
        Name: OnFilterTextChanged
        Purpose: Calls filter prescriptions when the search text is changed
        Author: Samuel McManus
        Uses: FilterPrescriptions
        Used by: N/A
        Date: July 27, 2020
        */
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchbar = sender as SearchBar;
            ViewModel.FilterPrescriptions(searchbar.Text);
        }
        public PrescriptionListViewModel ViewModel
        {
            get
            {
                return BindingContext as PrescriptionListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}