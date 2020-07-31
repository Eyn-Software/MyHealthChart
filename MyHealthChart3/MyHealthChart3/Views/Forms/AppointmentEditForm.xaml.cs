using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentEditForm : ContentPage
    {
        public AppointmentEditForm(Models.Appointment Appointment, IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new AppointmentEditViewModel(Appointment, NetworkModule);
        }
        /*
        Name: SubmitClicked
        Purpose: Calls the submit command and decides whether or not to pop the page
        Author: Samuel McManus
        Uses: Submit
        Used by: N/A
        Date: July 29, 2020
        */
        public async void SubmitClicked(object sender, System.EventArgs e)
        {
            if ((await ViewModel.Submit()).Equals("Success"))
                await Navigation.PopAsync();
        }
        public AppointmentEditViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentEditViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}