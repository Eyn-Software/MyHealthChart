using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class NoteViewModel : BaseViewModel
    {
        public NoteViewModel()
        {

        }
        public NoteViewModel(Models.Note note)
        {
            Id = note.Id;
            Name = note.Name;
            CreationDate = note.CreationDate;
            ParentFolderId = note.ParentFolderId;
            UId = note.uId;
            Description = note.Description;
            Picture = note.Picture;
        }

        private int id;
        private string name;
        private DateTime creationdate;
        private int parentfolderid;
        private int uid;
        private string description;
        private byte[] picture;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                SetValue(ref id, value);
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetValue(ref name, value);
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return creationdate;
            }
            set
            {
                SetValue(ref creationdate, value);
            }
        }
        public int ParentFolderId
        {
            get
            {
                return parentfolderid;
            }
            set
            {
                SetValue(ref parentfolderid, value);
            }
        }
        public int UId
        {
            get
            {
                return uid;
            }
            set
            {
                SetValue(ref uid, value);
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                SetValue(ref description, value);
            }
        }
        public byte[] Picture
        {
            get
            {
                return picture;
            }
            set
            {
                SetValue(ref picture, value);
            }
        }
    }
}
