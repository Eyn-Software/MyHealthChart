using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class MainPageViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private bool authenticated;
        private bool unauthenticated;

        //Tells whether the user is authenticated, and 
        //sets certain list items' visibility value
        public bool Authenticated
        {
            get
            {
                return authenticated;
            }
            set
            {
                SetValue(ref authenticated, value);
                Unauthenticated = !authenticated;
            }
        }
        //Tells whether the user is authenticated, and 
        //sets certain list items' visibility value
        public bool Unauthenticated
        {
            get
            {
                return unauthenticated;
            }
            set
            {
                SetValue(ref unauthenticated, value);
            }
        }
        //Creates a collection of users to be displayed
        //by the main page in the hamburger menu
        public ObservableCollection<UserViewModel> Users
        {
            get;
            private set;
        } = new ObservableCollection<UserViewModel>();
        //Creates a collection of items to be shown if the user has not yet been authenticated
        public ObservableCollection<UnauthenticatedMenuItem> UnauthenticatedList
        {
            get;
            private set;
        } = new ObservableCollection<UnauthenticatedMenuItem>();
        /*
        Name: MainPageViewModel
        Purpose: Initialization of the main page view model
        Author: Samuel McManus
        Uses: N/A
        Used by: MainPage
        Date: June 29 2020
        */
        public MainPageViewModel(IServerComms networkModule)
        {
            //Creates a message whenever users are added or updated
            //via the user form
            MessagingCenter.Subscribe<LoginFormViewModel, UserViewModel>
                (this, Events.UserAdded, OnUserAdded);
            MessagingCenter.Subscribe<RegistrationFormViewModel, UserViewModel>
                (this, Events.UserAdded, OnUserAdded);
            MessagingCenter.Subscribe<Forms.UserFormViewModel, UserViewModel>
                (this, Events.UserAdded, OnUserAdded);
            NetworkModule = networkModule;
            Authenticated = false;

            UnauthenticatedList = new ObservableCollection<UnauthenticatedMenuItem>
            {
                new UnauthenticatedMenuItem {Id = MenuItemType.Register, Title="Register" },
                new UnauthenticatedMenuItem {Id = MenuItemType.Login, Title="Log in" },
                new UnauthenticatedMenuItem {Id = MenuItemType.Guest, Title="Continue as a guest"}
            };
        }
        /*
        Name: OnUserAdded
        Purpose: Updates the users section
        Author: Samuel McManus
        Uses: N/A
        Used by: LoginFormViewModel, RegistrationFormViewModel
        Date: June 26 2020
        */
        private void OnUserAdded(LoginFormViewModel src, UserViewModel user)
        {
            Users.Add(user);
            Authenticated = true;
        }
        private void OnUserAdded(RegistrationFormViewModel src, UserViewModel user)
        {
            Users.Add(user);
            Authenticated = true;
        }
        private void OnUserAdded(Forms.UserFormViewModel src, UserViewModel user)
        {
            Users.Add(user);
            Authenticated = true;
        }
    }
}