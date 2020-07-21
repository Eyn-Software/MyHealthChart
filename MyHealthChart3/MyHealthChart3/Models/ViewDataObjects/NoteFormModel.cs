using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class NoteFormModel
    {
        public NoteFormModel(FolderListModel Folder)
        {
            CreationDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            ParentFolderId = Folder.Id;
            UId = Folder.UId;
            Password = Folder.Password;
        }
        public NoteFormModel(NoteListModel Note)
        {
            Id = Note.Id;
            Name = Note.Name;
            CreationDate = Note.CreationDate.ToString("yyyy-MM-dd hh:mm:ss");
            UId = Note.UId;
            Password = Note.Password;
        }
        public NoteFormModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public int ParentFolderId { get; set; }
        public int UId { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
