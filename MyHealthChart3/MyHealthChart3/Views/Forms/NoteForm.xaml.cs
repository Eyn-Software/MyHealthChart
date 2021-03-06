﻿using MyHealthChart3.ViewModels.ViewCounterparts.Forms;
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
    public partial class NoteForm : ContentPage
    {
        public NoteForm(Models.ViewDataObjects.FolderListModel folder, Services.IServerComms networkmodule)
        {
            InitializeComponent();
            ViewModel = new NoteFormViewModel(folder, networkmodule);
        }
        /*
        Name: Submit
        Purpose: Submits the note and returns the user to the note list
        Author: Samuel McManus
        Uses: Submit
        Used by: N/A
        Date: July 19, 2020
        */
        private async void Submit(object sender, EventArgs e)
        {
            await ViewModel.Submit();
            if(ViewModel.Error.Equals(""))
                await Navigation.PopAsync();
        }
        public NoteFormViewModel ViewModel
        {
            get
            {
                return BindingContext as NoteFormViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}