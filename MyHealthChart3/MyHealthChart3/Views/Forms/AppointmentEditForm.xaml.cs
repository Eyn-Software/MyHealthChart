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
            IPageService PS = new PageService();
            ViewModel = new AppointmentEditViewModel(Appointment, PS, NetworkModule);
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