using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Lists
{
    public class NoteListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private FolderListModel Parent;
        private ObservableCollection<FolderListModel> folders;
        private ObservableCollection<NoteListModel> notes;

        public ObservableCollection<FolderListModel> Folders
        {
            get
            {
                return folders;
            }
            set
            {
                SetValue(ref folders, value);
            }
        }
        public ObservableCollection<NoteListModel> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                SetValue(ref notes, value);
            }
        }
        public System.Windows.Input.ICommand SetFoldersCmd
        {
            get;
            private set;
        }
        public System.Windows.Input.ICommand SetNotesCmd
        {
            get;
            private set;
        }
        public NoteListViewModel(FolderListModel fo, IServerComms networkmodule)
        {
            Parent = fo;
            NetworkModule = networkmodule;

            SetFoldersCmd = new Xamarin.Forms.Command(async() => await SetFolders());
            SetNotesCmd = new Xamarin.Forms.Command(async () => await SetNotes());
        }
        private async System.Threading.Tasks.Task SetFolders()
        {
            Folders = await NetworkModule.GetFolders(Parent);
        }
        private async System.Threading.Tasks.Task SetNotes()
        {
            Notes = await NetworkModule.GetNotes(Parent);
        }
    }
}
