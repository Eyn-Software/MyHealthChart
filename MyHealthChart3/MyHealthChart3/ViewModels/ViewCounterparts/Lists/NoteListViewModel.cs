using MyHealthChart3.Models;
using MyHealthChart3.Services;
using System.Collections.ObjectModel;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Lists
{
    public class NoteListViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private Folder Parent;
        private ObservableCollection<Folder> folders;
        private ObservableCollection<Note> notes;
        private ObservableCollection<NoteFolder> notesandfolders;

        public ObservableCollection<NoteFolder> NotesAndFolders
        {
            get
            {
                return notesandfolders;
            }
            set
            {
                SetValue(ref notesandfolders, value);
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
        public NoteListViewModel(Folder fo, IServerComms networkmodule)
        {
            Parent = fo;
            NetworkModule = networkmodule;
            NotesAndFolders = new ObservableCollection<NoteFolder>();

            SetFoldersCmd = new Xamarin.Forms.Command(async() => await SetFolders());
            SetNotesCmd = new Xamarin.Forms.Command(async () => await SetNotes());

        }
        private async System.Threading.Tasks.Task SetFolders()
        {
            folders = await NetworkModule.GetFolders(Parent);
            foreach (Folder f in folders)
                NotesAndFolders.Add(f);
        }
        private async System.Threading.Tasks.Task SetNotes()
        {
            notes = await NetworkModule.GetNotes(Parent);
            foreach (Note n in notes)
                NotesAndFolders.Add(n);
        }
    }
}
