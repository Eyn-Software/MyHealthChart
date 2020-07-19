using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class NoteFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private string error;
        private FolderListModel Folder;
        private NoteFormModel note;

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
        public NoteFormModel Note
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

        public NoteFormViewModel(FolderListModel folder, IServerComms networkmodule)
        {
            NetworkModule = networkmodule;
            Folder = folder;
            Note = new NoteFormModel(Folder);
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
                await NetworkModule.AddNote(Note);
            }
            else
            {
                Error = "Your note must have a title";
            }
        }
    }
}
