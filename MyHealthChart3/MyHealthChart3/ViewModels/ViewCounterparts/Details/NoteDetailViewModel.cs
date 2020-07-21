using MyHealthChart3.Models.ViewDataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Details
{
    public class NoteDetailViewModel : BaseViewModel
    {
        private Services.IServerComms NetworkModule;
        private NoteFormModel note;
        private NoteListModel N;

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
        public System.Windows.Input.ICommand SetDetailsCmd
        {
            get;
            private set;
        }
        public System.Windows.Input.ICommand DeleteNoteCmd
        {
            get;
            private set;
        }
        public NoteDetailViewModel(NoteListModel n, Services.IServerComms networkmodule)
        {
            NetworkModule = networkmodule;
            N = n;

            SetDetailsCmd = new Xamarin.Forms.Command(async () => await SetDetails());
            DeleteNoteCmd = new Xamarin.Forms.Command(async () => await DeleteNote());
        }
        /*
        Name: SetDetails
        Purpose: Sets the name and description of a note
        Author: Samuel McManus
        Uses: GetNote
        Used by: NoteDetail
        Date: July 20, 2020
        */
        private async System.Threading.Tasks.Task SetDetails()
        {
            Note = await NetworkModule.GetNote(N);
        }
        /*
        Name: DeleteNote
        Purpose: Deletes a note from the database
        Author: Samuel McManus
        Uses: DeleteNote
        Used by: NoteDetail
        Date: July 20, 2020
        */
        private async System.Threading.Tasks.Task DeleteNote()
        {
            await NetworkModule.DeleteNote(Note);
        }
    }
}
