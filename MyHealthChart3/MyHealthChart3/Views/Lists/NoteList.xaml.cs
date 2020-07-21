using MyHealthChart3.Services;
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
    public partial class NoteList : ContentPage
    {
        IServerComms NetworkModule;
        Models.ViewDataObjects.FolderListModel F;
        public NoteList(Models.ViewDataObjects.FolderListModel folder, IServerComms networkmodule)
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
            ViewModel.SetFoldersCmd.Execute(null);
            ViewModel.SetNotesCmd.Execute(null);
            base.OnAppearing();
        }
        /*
        Name: FolderSelected
        Purpose: Shows the user the contents of the selected folder
        Author: Samuel McManus
        Uses: NoteList
        Used by: N/A
        Date: July 19, 2020
        */
        private void FolderSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.ViewDataObjects.FolderListModel Folder = e.ItemData as Models.ViewDataObjects.FolderListModel;
            Folder.UId = F.UId;
            Folder.Password = F.Password;
            Navigation.PushAsync(new NoteList(Folder, NetworkModule));
        }
        private void NoteSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.ViewDataObjects.NoteListModel Note = e.ItemData as Models.ViewDataObjects.NoteListModel;
            Note.UId = F.UId;
            Note.Password = F.Password;
            Navigation.PushAsync(new Details.NoteDetail(Note, NetworkModule));
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