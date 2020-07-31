using MyHealthChart3.Models;
using MyHealthChart3.ViewModels.ViewCounterparts.Details;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetail : ContentPage
    {
        Services.IServerComms networkmodule;
        public NoteDetail(Note note, Services.IServerComms NetworkModule)
        {
            InitializeComponent();
            networkmodule = NetworkModule;
            ViewModel = new NoteDetailViewModel(note, NetworkModule);
        }
        protected override void OnAppearing()
        {
            ViewModel.SetDetailsCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: DeleteNote
        Purpose: Deletes a note and pops back to the note list
        Author: Samuel McManus
        Uses: DeleteNoteCmd
        Used by: N/A
        Date: July 20, 2020
        */
        public async void DeleteNote(object sender, EventArgs e)
        {
            ViewModel.DeleteNoteCmd.Execute(null);
            await Navigation.PopAsync();
        }
        /*
        Name: EditNote
        Purpose: Takes the user to the note edit form
        Author: Samuel McManus
        Uses: NoteEditForm
        Used by: N/A
        Date: July 20, 2020
        */
        public async void EditNote(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forms.NoteEditForm(ViewModel.Note, networkmodule));
        }
        public NoteDetailViewModel ViewModel
        {
            get
            {
                return BindingContext as NoteDetailViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}