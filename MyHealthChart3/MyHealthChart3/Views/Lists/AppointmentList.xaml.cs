using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using MyHealthChart3.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentList : ContentPage
    {
        UserViewModel User;
        IServerComms NetworkModule;
        public AppointmentList(UserViewModel Usr, IServerComms networkModule)
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
            ViewModel.SetAppointmentsCmd.Execute(null);
            base.OnAppearing();
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