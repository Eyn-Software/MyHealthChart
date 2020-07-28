using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ViewCounterparts.Details;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionDetail : ContentPage
    {
        Prescription Prescription;
        Services.IServerComms NetworkModule;
        public PrescriptionDetail(Prescription Rx, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            Prescription = Rx;
            NetworkModule = networkmodule;
            ViewModel = new PrescriptionDetailViewModel(Prescription, networkmodule);
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