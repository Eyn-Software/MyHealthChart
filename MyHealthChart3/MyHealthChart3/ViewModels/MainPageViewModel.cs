﻿using MyHealthChart3.Models;
using MyHealthChart3.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class MainPageViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private ILoginService LoginService;
        private INotificationService NotificationService;
        private bool authenticated;
        private LoginFormModel LoginCreds;

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
                SetList();
            }
        }
        //Creates a collection of users to be displayed
        //by the main page in the hamburger menu
        public ObservableCollection<User> Users
        {
            get;
            private set;
        } = new ObservableCollection<User>();
        //Creates a collection of items to be shown if the user has not yet been authenticated
        public ObservableCollection<Models.MenuItem> ItemList
        {
            get;
            private set;
        } = new ObservableCollection<Models.MenuItem>();
        /*
        Name: MainPageViewModel
        Purpose: Initialization of the main page view model
        Author: Samuel McManus
        Uses: N/A
        Used by: MainPage
        Date: June 29 2020
        */
        public MainPageViewModel(ILoginService loginService, IServerComms networkModule, INotificationService notificationService)
        {
            //Creates a message whenever users are added or updated
            //via the user form
            MessagingCenter.Subscribe<LoginService, User>
                (this, Events.UserAdded, OnUserAdded);
            MessagingCenter.Subscribe<RegistrationFormViewModel, User>
                (this, Events.UserAdded, OnUserAdded);
            MessagingCenter.Subscribe<Forms.UserFormViewModel, User>
                (this, Events.UserAdded, OnUserAdded);
            NetworkModule = networkModule;
            LoginService = loginService; 
            NotificationService = notificationService;
            Authenticated = false;
            LoginCreds = new LoginFormModel();

            if (Application.Current.Properties.ContainsKey("Email") && Application.Current.Properties.ContainsKey("Password"))
            {
                LoginCreds.Email = Application.Current.Properties["Email"] as string;
                LoginCreds.Password = Application.Current.Properties["Password"] as string;
                SetUsers(); 
            }
        }
        public void SetList()
        {
            if (Authenticated)
            {
                ItemList.Clear();
                ItemList.Add(new GeneralMenuItem { Id = GeneralMenuItemType.About, Name = "About" });
                foreach(User u in Users)
                {
                    ItemList.Add(u);
                }
                ItemList.Add(new AuthenticatedMenuItem { Id = AuthenticatedItemType.LogOut, Name = "Log Out" });
            }
            else
            {
                ItemList.Clear();
                ItemList.Add(new GeneralMenuItem { Id = GeneralMenuItemType.About, Name = "About" });
                ItemList.Add(new UnauthenticatedMenuItem { Id = UnauthenticatedMenuItemType.Register, Name = "Register" });
                ItemList.Add(new UnauthenticatedMenuItem { Id = UnauthenticatedMenuItemType.Login, Name = "Log in" });
            }
        }
        public async void SetUsers()
        {
            if((await LoginService.SetUsers(LoginCreds, NetworkModule, NotificationService)).Equals("Success"))
                (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage((Page)System.Activator.CreateInstance(typeof(Views.WelcomePage)));
        }
        /*
        Name: OnUserAdded
        Purpose: Updates the users section
        Author: Samuel McManus
        Uses: N/A
        Used by: LoginFormViewModel, RegistrationFormViewModel
        Date: June 26 2020
        */
        private void OnUserAdded(LoginService src, User user)
        {
            Users.Add(user);
            Authenticated = true;
        }
        private void OnUserAdded(RegistrationFormViewModel src, User user)
        {
            Users.Add(user);
            Authenticated = true;
        }
        private void OnUserAdded(Forms.UserFormViewModel src, User user)
        {
            Users.Add(user);
            Authenticated = true;
        }
    }
}