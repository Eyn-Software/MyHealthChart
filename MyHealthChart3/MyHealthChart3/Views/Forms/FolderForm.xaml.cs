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
    public partial class FolderForm : ContentPage
    {
        public FolderForm(FolderListModel folder, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            ViewModel = new FolderFormViewModel(folder, networkmodule);
        }
        /*
        Name: Submit
        Purpose: Submits the folder and pops to the previous page
        Author: Samuel McManus
        Uses: N/A
        Used by: N/A
        Date: July 19, 2020
        */
        private async void Submit(object sender, EventArgs e)
        {
            await ViewModel.Submit();
            if(ViewModel.Error.Equals(""))
                await Navigation.PopAsync();
        }
        public FolderFormViewModel ViewModel
        {
            get
            {
                return BindingContext as FolderFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}