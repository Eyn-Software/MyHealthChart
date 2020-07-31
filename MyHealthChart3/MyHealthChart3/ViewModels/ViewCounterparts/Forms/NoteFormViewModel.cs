using MyHealthChart3.Models;
using MyHealthChart3.Services;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class NoteFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private string error;
        private Folder Folder;
        private Note note;

        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                SetValue(ref error, value);
            }
        }
        public Note Note
        {
            get
            {
                return note;
            }
            set
            {
                SetValue(ref note, value);
            }
        }

        public NoteFormViewModel(Folder folder, IServerComms networkmodule)
        {
            NetworkModule = networkmodule;
            Folder = folder;
            Note = new Note(Folder);
        }
        /*
        Name: Submit
        Purpose: Submits the note to the database
        Author: Samuel McManus
        Uses: AddNote
        Used by: NoteForm
        Date: July 19, 2020
        */
        public async System.Threading.Tasks.Task Submit()
        {
            Error = "";
            if (Note.Name != null && !Note.Name.Equals(""))
            {
                Note.CreationDate = System.DateTime.Now.ToString("yyyy-MM-dd");
                await NetworkModule.AddNote(Note);
            }
            else
            {
                Error = "Your note must have a title";
            }
        }
    }
}
