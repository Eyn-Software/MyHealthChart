﻿using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDoctorForm : ContentPage
    {
        public EditDoctorForm(DoctorViewModel Doctor, UserViewModel User, IServerComms NetworkModule)
        {
            InitializeComponent();
            IPageService PS = new PageService();
            ViewModel = new DoctorEditViewModel(Doctor, User, PS, NetworkModule);
        }

        public DoctorEditViewModel ViewModel
        {
            get
            {
                return BindingContext as DoctorEditViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}