using System.ComponentModel;
using Xamarin.Forms;
using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;

namespace MyHealthChart3.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        IServerComms NetworkModule;
        ILoginService LoginService;
        INotificationService NotificationService;
        public MainPage()
        {
            InitializeComponent();
            //Sets the initial detail page to the welcome page
            Detail = new NavigationPage(new WelcomePage());
            //Creates an interface on which to send data to the server
            NetworkModule = new ServerComm();
            //Creates a login interface to help with initial user authentication
            LoginService = new LoginService();
            //Creates a notification service to store any reminders
            NotificationService = new NotificationService();

            ViewModel = new MainPageViewModel(LoginService, NetworkModule, NotificationService);
        }

        //Upon appearing, this executes the Get Users command in the 
        //user viewmodel
        protected override void OnAppearing()
        {
            //ViewModel.GetUsersCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: ItemSelected
        Purpose: Chooses which of the potential menu actions to perform based on the
                 type of item selected
        Author: Samuel McManus
        Uses: OptionList, RegistrationForm, LoginForm, WelcomePage
        Used by: MainPage
        Date: August 3, 2020
        */
        public void ItemSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            IsPresented = false;
            User SelectedUser = e.ItemData as User;
            if (SelectedUser != null)
                Detail = new NavigationPage(new OptionList(SelectedUser, NetworkModule));
            UnauthenticatedMenuItem UnauthItem = e.ItemData as UnauthenticatedMenuItem;
            if(UnauthItem != null)
            {
                if (UnauthItem.Id == UnauthenticatedMenuItemType.Register)
                    Detail = new NavigationPage(new RegistrationForm(LoginService, NetworkModule, NotificationService));
                else
                    Detail = new NavigationPage(new LoginForm(LoginService, NetworkModule, NotificationService));
            }
            GeneralMenuItem GeneralItem = e.ItemData as GeneralMenuItem;
            if (GeneralItem != null)
                Detail = new NavigationPage(new About());
            AuthenticatedMenuItem AuthItem = e.ItemData as AuthenticatedMenuItem;
            if(AuthItem != null)
            {
                Application.Current.Properties.Clear();
                ViewModel.Authenticated = false;
                Detail = new NavigationPage(new WelcomePage());
            }
        }
        //Creates the ViewModel object of type MainPageViewModel
        //This sets the binding context of the xaml page to the
        //MainPageViewModel
        public MainPageViewModel ViewModel
        {
            get
            {
                return BindingContext as MainPageViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}