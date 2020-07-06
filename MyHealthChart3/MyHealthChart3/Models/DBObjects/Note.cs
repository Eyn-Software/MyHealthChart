using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Note : NoteFolder
    {
        public Note()
        {

        }
        public Note(NoteViewModel note)
        {
            Id = note.Id;
            Name = note.Name;
            CreationDate = note.CreationDate;
            ParentFolderId = note.ParentFolderId;
            uId = note.UId;
            Description = note.Description;
            Picture = note.Picture;
        }
        public string Description
        {
            get;
            set;
        }
        public byte[] Picture
        {
            get;
            set;
        }
    }
}
