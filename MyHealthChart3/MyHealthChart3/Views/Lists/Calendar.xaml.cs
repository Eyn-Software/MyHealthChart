using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentPage
    {
        public Calendar(UserViewModel User, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new CalendarViewModel(User, NetworkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetCalendarCmd.Execute(null);
            base.OnAppearing();
        }
        public CalendarViewModel ViewModel
        {
            get
            {
                return BindingContext as CalendarViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}