using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorList : ContentPage
    {
        /*
        Name: DoctorList
        Purpose: The initialization of the doctor
                    list view
        Author: Samuel McManus
        Uses: DoctorListViewModel
        Used by: OptionList
        Date: May 29 2020
        */
        User User;
        IServerComms NetworkModule;
        public DoctorList(User u, IServerComms networkModule)
        {
            InitializeComponent();
            NetworkModule = networkModule;
            User = u;
            ViewModel = new DoctorListViewModel(networkModule, u);
        }
        /*
        Name: OnAppearing
        Purpose: Sets the doctors before the
                    doctors list page displays
        Author: Samuel McManus
        Uses: SetDoctorsCmd
        Used by: N/A
        Date: May 29 2020
        */
        protected override void OnAppearing()
        {
            SetDoctors();
            base.OnAppearing();
        }
        /*
        Name: SetDoctors
        Purpose: Sets the doctors and decides whether topush the doctor form
        Author: Samuel McManus
        Uses: DoctorForm
        Used by: OnAppearing
        Date: July 31, 2020
        */
        public async void SetDoctors()
        {
            if (!await ViewModel.SetDoctors())
                await Navigation.PushAsync(new DoctorForm(User, NetworkModule));
        }
        /*
        Name: DoctorSelected
        Purpose: Navigates the user to the doctor detail page
        Author: Samuel McManus
        Uses: DoctorDetail
        Used by: N/A
        Date: July 16 2020
        */
        private void DoctorSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Doctor Doctor = e.ItemData as Doctor;
            Doctor.UId = User.Id;
            Doctor.Password = User.Password;
            Navigation.PushAsync(new Details.DoctorDetail(Doctor, NetworkModule));
        }
        /*
        Name: NewDoctor
        Purpose: Takes the user to the doctor form
        Author: Samuel McManus
        Uses: N/A
        Used by: DoctorListViewModel
        Date: May 30 2020
        */
        private async void NewDoctor(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoctorForm(User, NetworkModule));
        }
        /*
        Name: OnFilterTextChanged
        Purpose: Calls filter doctors when the search text is changed
        Author: Samuel McManus
        Uses: FilterDoctors
        Used by: N/A
        Date: July 30, 2020
        */
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchbar = sender as SearchBar;
            ViewModel.FilterDoctors(searchbar.Text);
        }
        public DoctorListViewModel ViewModel
        {
            get
            {
                return BindingContext as DoctorListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}