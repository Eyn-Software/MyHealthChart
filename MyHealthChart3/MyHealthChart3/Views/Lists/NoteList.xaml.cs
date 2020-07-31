using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ViewCounterparts.Lists;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHealthChart3.Views.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteList : ContentPage
    {
        IServerComms NetworkModule;
        Models.Folder F;
        public NoteList(Models.Folder folder, IServerComms networkmodule)
        {
            InitializeComponent();
            NetworkModule = networkmodule;
            F = folder;
            ViewModel = new NoteListViewModel(folder, networkmodule);
        }
        /*
        Name: OnAppearing
        Purpose: Set all notes and folders 
        Author: Samuel McManus
        Uses: SetFolders, SetNotes
        Used by: N/A
        Date: July 19, 2020
        */
        protected override void OnAppearing()
        {
            ViewModel.NotesAndFolders.Clear();
            ViewModel.SetFoldersCmd.Execute(null);
            ViewModel.SetNotesCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: ItemSelected
        Purpose: Shows the user the contents of the selected folder or note
        Author: Samuel McManus
        Uses: NoteList
        Used by: N/A
        Date: July 19, 2020
        */
        private void ItemSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.Folder Folder = e.ItemData as Models.Folder;
            if(Folder != null)
            {
                Folder.UId = F.UId;
                Folder.Password = F.Password;
                Navigation.PushAsync(new NoteList(Folder, NetworkModule));
            }
            else
            {
                Models.Note Note = e.ItemData as Models.Note;
                Note.UId = F.UId;
                Note.Password = F.Password;
                Navigation.PushAsync(new Details.NoteDetail(Note, NetworkModule));
            }
        }
        /*
        Name: NewFolder
        Purpose: Sends the user to the folder creation form
        Author: Samuel McManus
        Uses: FolderForm
        Used by: N/A
        Date: July 19, 2020
        */
        private async void NewFolder(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forms.FolderForm(F, NetworkModule));
        }
        /*
        Name: NewNote
        Purpose: Takes the user to the note form
        Author: Samuel McManus
        Uses: NoteForm
        Used by: N/A
        Date: July 19, 2020
        */
        private async void NewNote(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Forms.NoteForm(F, NetworkModule));
        }
        public NoteListViewModel ViewModel
        {
            get
            {
                return BindingContext as NoteListViewModel;
            }
            set
            {
                BindingContext = value;
            }
        }
    }
}