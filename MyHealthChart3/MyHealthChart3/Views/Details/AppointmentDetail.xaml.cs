using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentDetail : ContentPage
    {
        public AppointmentDetail(Models.Appointment Appointment, IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new AppointmentDetailViewModel(Appointment, NetworkModule);
        }
        /*
        Name: EditAppointment
        Purpose: Takes the user to the appointment edit page
        Author: Samuel McManus
        Uses: EditAppointmentForm
        Used by: N/A
        Date: July 30, 2020
        */
        private void EditAppointment(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AppointmentEditForm(ViewModel.Appointment, ViewModel.NetworkModule));
        }
        public AppointmentDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}