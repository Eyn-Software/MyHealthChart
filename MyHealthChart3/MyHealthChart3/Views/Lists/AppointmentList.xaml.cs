using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using MyHealthChart3.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentList : ContentPage
    {
        User User;
        IServerComms NetworkModule;
        public AppointmentList(User Usr, IServerComms networkModule)
        {
            InitializeComponent();
            User = Usr;
            NetworkModule = networkModule;
            ViewModel = new AppointmentListViewModel(User, networkModule);
        }
        /*
        Name: OnAppearing
        Purpose: Calls the set appointments command
        Author: Samuel McManus
        Uses: AppointmentForm
        Used by: N/A
        Date: June 28, 2020
        */
        protected override void OnAppearing()
        {
            SetAppointments();
            base.OnAppearing();
        }
        /*
        Name: SetAppointments
        Purpose: Sets the appointments and decides whether topush the doctor form
        Author: Samuel McManus
        Uses: SetAppointments, AppointmentForm
        Used by: OnAppearing
        Date: July 31, 2020
        */
        public async void SetAppointments()
        {
            if (!await ViewModel.SetAppointments())
                await Navigation.PushAsync(new AppointmentForm(User, NetworkModule));
        }
        /*
        Name: AppointmentSelected
        Purpose: Takes the user to the appointment detail page
        Author: Samuel McManus
        Uses: AppointmentDetail
        Used by: N/A
        Date: June 28, 2020
        */
        public async void AppointmentSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Appointment Appointment = e.ItemData as Appointment;
            Appointment.UId = User.Id;
            Appointment.Password = User.Password;
            await Navigation.PushAsync(new AppointmentDetail(Appointment, NetworkModule));
        }
        /*
        Name: NewAppointment
        Purpose: Creates a new appointment for a user
        Author: Samuel McManus
        Uses: AppointmentForm
        Used by: N/A
        Date: June 28, 2020
        */
        private void NewAppointment(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AppointmentForm(User, NetworkModule));
        }
        /*
        Name: OnFilterTextChanged
        Purpose: Calls filter appointments when the search text is changed
        Author: Samuel McManus
        Uses: FilterAppointments
        Used by: N/A
        Date: July 31, 2020
        */
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchbar = sender as SearchBar;
            ViewModel.FilterAppointments(searchbar.Text);
        }
        public AppointmentListViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}