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
        public DoctorDetail(Models.Doctor Doctor, IServerComms networkModule)
        {
            InitializeComponent();
            NetworkModule = networkModule;
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
            Navigation.PushAsync(new EditDoctorForm(ViewModel.Doctor, NetworkModule));
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