using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ViewCounterparts.Forms;
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
    public partial class PrescriptionEditForm : ContentPage
    {
        public PrescriptionEditForm(PrescriptionListModel Prescription, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new PrescriptionEditViewModel(Prescription, NetworkModule);
        }
        public async void SubmitClicked(object sender, EventArgs e)
        {
            await ViewModel.Submit();
            if(ViewModel.result.Equals("Success"))
                await Navigation.PopAsync();
        }
        public PrescriptionEditViewModel ViewModel
        {
            get
            {
                return BindingContext as PrescriptionEditViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}