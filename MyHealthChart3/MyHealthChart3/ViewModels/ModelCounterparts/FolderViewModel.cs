using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class FolderViewModel : BaseViewModel
    {
        public FolderViewModel()
        {

        }
        public FolderViewModel(Models.Folder folder)
        {
            Id = folder.Id;
            Name = folder.Name;
            CreationDate = folder.CreationDate;
            ParentFolderId = folder.ParentFolderId;
            UId = folder.uId;
            IsRoot = folder.IsRoot;
            ChildrenFolders = folder.ChildrenFolders;
            ParentFolder = folder.ParentFolder;
            Notes = folder.Notes;
        }

        private int id;
        private string name;
        private DateTime creationdate;
        private int parentfolderid;
        private int uid;
        private bool isroot;
        private List<Models.Folder> childrenfolders;
        private Models.Folder parentfolder;
        private List<Models.Note> notes;

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
        public bool IsRoot
        {
            get
            {
                return isroot;
            }
            set
            {
                SetValue(ref isroot, value);
            }
        }
        public List<Models.Folder> ChildrenFolders
        {
            get
            {
                return childrenfolders;
            }
            set
            {
                SetValue(ref childrenfolders, value);
            }
        }
        public Models.Folder ParentFolder
        {
            get
            {
                return parentfolder;
            }
            set
            {
                SetValue(ref parentfolder, value);
            }
        }
        public List<Models.Note> Notes
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
    }
}

