using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Folder : NoteFolder
    {
        public Folder()
        {

        }
        public Folder(FolderViewModel folder)
        {
            Id = folder.Id;
            Name = folder.Name;
            CreationDate = folder.CreationDate;
            ParentFolderId = folder.ParentFolderId;
            uId = folder.UId;
            IsRoot = folder.IsRoot;
            ChildrenFolders = folder.ChildrenFolders;
            ParentFolder = folder.ParentFolder;
            Notes = folder.Notes;
        }

        public bool IsRoot
        {
            get;
            set;
        }
        public List<Folder> ChildrenFolders
        {
            get;
            set;
        }
        public Folder ParentFolder
        {
            get;
            set;
        }

        public List<Note> Notes
        {
            get;
            set;
        }
    }
}
