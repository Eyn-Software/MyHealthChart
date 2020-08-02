using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ViewCounterparts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentPage
    {
        public Calendar(User User, Services.IServerComms NetworkModule)
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