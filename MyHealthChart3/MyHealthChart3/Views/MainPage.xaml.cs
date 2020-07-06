using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyHealthChart3.Models;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;

namespace MyHealthChart3.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        IServerComms NetworkModule;
        public MainPage()
        {
            InitializeComponent();

            //Sets the initial detail page to the welcome page
            Detail = new NavigationPage(new WelcomePage());
            //Creates an interface on which to send data to the server
            NetworkModule = new ServerComm();

            ViewModel = new MainPageViewModel(NetworkModule);
        }

        //Upon appearing, this executes the Get Users command in the 
        //user viewmodel
        protected override void OnAppearing()
        {
            //ViewModel.GetUsersCmd.Execute(null);
            base.OnAppearing();
        }
        public void UserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IsPresented = false;
            UserViewModel SelectedUser = e.SelectedItem as UserViewModel;
            Detail = new NavigationPage(new OptionList(SelectedUser, NetworkModule));
        }
        public void UnauthenticatedSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IsPresented = false;
            UnauthenticatedMenuItem SelectedItem = e.SelectedItem as UnauthenticatedMenuItem;
            if (SelectedItem.Id == MenuItemType.Register)
            {
                Detail = new NavigationPage(new RegistrationForm(NetworkModule));
            }
            else if (SelectedItem.Id == MenuItemType.Login)
            {
                Detail = new NavigationPage(new LoginForm(NetworkModule));
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