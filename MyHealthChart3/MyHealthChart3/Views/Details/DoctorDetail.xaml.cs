using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts.Details;
using MyHealthChart3.Views.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorDetail : ContentPage
    {
        IServerComms NetworkModule;
        UserViewModel User;
        public DoctorDetail(Models.Doctor Doctor, UserViewModel user, IServerComms networkModule)
        {
            InitializeComponent();
            NetworkModule = networkModule;
            User = user;
            ViewModel = new DoctorDetailViewModel(Doctor, NetworkModule);
        }
        /*
        Name: OnEdit
        Purpose: Calls the edit command
        Author: Samuel McManus
        Uses: PushAsync
        Used by: N/A
        Date: May 30 2020
        */
        private void EditDoctor(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            ViewModel.Doctor.Id = (int)mi.CommandParameter;
            Navigation.PushAsync(new EditDoctorForm(ViewModel.Doctor, User, NetworkModule));
        }
        public DoctorDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as DoctorDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}