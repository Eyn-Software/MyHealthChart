using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ViewCounterparts.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEditForm : ContentPage
    {
        public NoteEditForm(Note Note, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            ViewModel = new NoteEditViewModel(Note, networkmodule);
        }
        /*
        Name: Submit
        Purpose: Submits the note and returns the user to the previous screen
        Author: Samuel McManus
        Uses: Submit
        Used by: N/A
        Date: July 20, 2020
        */
        private async void Submit(object sender, EventArgs e)
        {
            await ViewModel.Submit();
            if (ViewModel.Error.Equals(""))
                await Navigation.PopAsync();
        }
        public NoteEditViewModel ViewModel
        {
            get
            {
                return BindingContext as NoteEditViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}