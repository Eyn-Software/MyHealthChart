using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentDetail : ContentPage
    {
        public AppointmentDetail(UserViewModel User, int AId, IServerComms NetworkModule)
        {
            InitializeComponent();
            IPageService PS = new PageService();
            ViewModel = new AppointmentDetailViewModel(User, AId, PS, NetworkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetDetailsCmd.Execute(null);
            base.OnAppearing();
        }
        public AppointmentDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}