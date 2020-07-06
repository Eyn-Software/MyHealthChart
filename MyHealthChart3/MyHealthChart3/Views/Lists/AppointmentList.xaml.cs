using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts;
using MyHealthChart3.Views.Forms;
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
    public partial class AppointmentList : ContentPage
    {
        UserViewModel User;
        IServerComms NetworkModule;
        public AppointmentList(UserViewModel Usr, IServerComms networkModule)
        {
            InitializeComponent();
            User = Usr;
            NetworkModule = networkModule;
            IPageService ps = new PageService();
            ViewModel = new AppointmentListViewModel(User, ps, networkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetAppointmentsCmd.Execute(null);
            base.OnAppearing();
        }
        public async void AppointmentSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            AppointmentListModel Appointment = e.ItemData as AppointmentListModel;
            await Navigation.PushAsync(new AppointmentDetail(User, Appointment.Id, NetworkModule));
        }
        public AppointmentListViewModel ViewModel
        {
            get
            {
                return BindingContext as AppointmentListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}