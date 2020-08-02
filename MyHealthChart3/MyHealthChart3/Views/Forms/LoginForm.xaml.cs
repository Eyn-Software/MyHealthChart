using MyHealthChart3.Services;
using MyHealthChart3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginForm : ContentPage
    {
        /*
        Name: LoginForm
        Purpose: Initializes the login form
        Author: Samuel McManus
        Uses: LoginForm
        Used by: MainPage
        Date: June 26 2020
        */
        public LoginForm(ILoginService LoginService, IServerComms NetworkModule, INotificationService NotificationService)
        {
            InitializeComponent();
            ViewModel = new LoginFormViewModel(LoginService, NetworkModule, NotificationService);
        }
        //Creates the ViewModel object of type LoginFormViewModel
        //This sets the binding context of the xaml page to the
        //LoginFormViewModel
        public LoginFormViewModel ViewModel
        {
            get
            {
                return BindingContext as LoginFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}