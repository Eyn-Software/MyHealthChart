﻿using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationForm : ContentPage
    {
        public RegistrationForm(IServerComms networkModule)
        {
            InitializeComponent();
            ViewModel = new RegistrationFormViewModel(networkModule);
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