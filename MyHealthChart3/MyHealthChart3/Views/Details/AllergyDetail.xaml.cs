using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.ViewModels.ViewCounterparts;
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
    public partial class AllergyDetail : ContentPage
    {
        public AllergyDetail(AllergyFormModel Allergy, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            ViewModel = new AllergyDetailViewModel(Allergy, NetworkModule);
        }
        /*
        Name: DeleteAllergy
        Purpose: Deletes an allergy from the user_allergy table then returns to the list
        Author: Samuel McManus
        Uses: DeleteAllergy
        Used by: N/A
        Date: July 8, 2020
        */
        public async void DeleteAllergy(object sender, EventArgs e)
        {
            await ViewModel.DeleteAllergy();
            await Navigation.PopAsync();
        }
        public AllergyDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as AllergyDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}