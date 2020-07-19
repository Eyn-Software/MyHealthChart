using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ModelCounterparts;
using MyHealthChart3.ViewModels.ViewCounterparts.Lists;
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
    public partial class VaccineList : ContentPage
    {
        private UserViewModel User;
        private Services.IServerComms NetworkModule;
        public VaccineList(UserViewModel user, Services.IServerComms networkModule)
        {
            InitializeComponent();
            User = user;
            NetworkModule = networkModule;
            ViewModel = new VaccineListViewModel(User, NetworkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetVaccinesCmd.Execute(null);
            base.OnAppearing();
        }
        private async void VaccineSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            VaccineListModel Vaccine = e.ItemData as VaccineListModel;
            Vaccine.User = User;
            await Navigation.PushAsync(new Details.VaccineDetail(Vaccine, NetworkModule));
        }
        public VaccineListViewModel ViewModel
        {
            get
            {
                return BindingContext as VaccineListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}