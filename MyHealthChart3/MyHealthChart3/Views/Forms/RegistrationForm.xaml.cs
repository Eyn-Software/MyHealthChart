using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationForm : ContentPage
    {
        public RegistrationForm(ILoginService LoginService, IServerComms NetworkModule, INotificationService NotificationService)
        {
            InitializeComponent();
            ViewModel = new RegistrationFormViewModel(LoginService, NetworkModule, NotificationService);
        }
        public RegistrationFormViewModel ViewModel
        {
            get
            {
                return BindingContext as RegistrationFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}