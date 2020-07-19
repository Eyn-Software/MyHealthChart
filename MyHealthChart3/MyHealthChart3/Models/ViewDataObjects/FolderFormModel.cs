using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class FolderFormModel
    {
        public FolderFormModel(FolderListModel Folder)
        {
            CreationDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            UId = Folder.UId;
            Password = Folder.Password;
            ParentFolderId = Folder.Id;
        }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public int UId { get; set; }
        public string Password { get; set; }
        public int ParentFolderId { get; set; }

    }
}
