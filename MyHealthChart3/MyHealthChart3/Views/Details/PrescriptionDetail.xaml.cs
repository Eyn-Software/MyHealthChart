using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ViewCounterparts.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionDetail : ContentPage
    {
        PrescriptionListModel Prescription;
        Services.IServerComms NetworkModule;
        public PrescriptionDetail(PrescriptionListModel Rx, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            Prescription = Rx;
            NetworkModule = networkmodule;
            ViewModel = new PrescriptionDetailViewModel(Prescription, networkmodule);
        }
        protected override void OnAppearing()
        {
            ViewModel.GetPrescriptionCmd.Execute(null);
            base.OnAppearing();
        }
        public async void EditPrescription(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forms.PrescriptionEditForm(Prescription, NetworkModule));
        }
        public PrescriptionDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as PrescriptionDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}