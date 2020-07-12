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
        public VaccineList(UserViewModel User, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new VaccineListViewModel(User, NetworkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetVaccinesCmd.Execute(null);
            base.OnAppearing();
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