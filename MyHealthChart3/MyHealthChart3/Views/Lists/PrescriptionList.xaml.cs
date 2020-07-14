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
    public partial class PrescriptionList : ContentPage
    {
        private UserViewModel User;
        private Services.IServerComms NetworkModule;
        public PrescriptionList(UserViewModel Usr, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            User = Usr;
            NetworkModule = networkmodule;
            ViewModel = new PrescriptionListViewModel(User, networkmodule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetPrescriptionsCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: PrescriptionSelected
        Purpose: Redirects the user to prescription detail page when they select a prescription
        Author: Samuel McManus
        Uses: PrescriptionDetail
        Used by: N/A
        Date: July 14, 2020
        */
        private async void PrescriptionSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.ViewDataObjects.PrescriptionListModel Prescription = e.ItemData as Models.ViewDataObjects.PrescriptionListModel;
            Prescription.User = User;
            await Navigation.PushAsync(new Details.PrescriptionDetail(Prescription, NetworkModule));
        }
        public PrescriptionListViewModel ViewModel
        {
            get
            {
                return BindingContext as PrescriptionListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}