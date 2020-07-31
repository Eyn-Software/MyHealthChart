using MyHealthChart3.Models;
using MyHealthChart3.Services;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class FolderFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private bool haserror;
        private string error;
        private Folder ParentFolder;
        private Folder folder;

        public bool HasError
        {
            get
            {
                return haserror;
            }
            set
            {
                SetValue(ref haserror, value);
            }
        }
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                SetValue(ref error, value);
                if (Error.Equals(""))
                    HasError = false;
                else
                    HasError = true;
            }
        }
        public Folder Folder
        {
            get
            {
                return folder;
            }
            set
            {
                SetValue(ref folder, value);
            }
        }
        public FolderFormViewModel(Folder parentfolder, IServerComms networkmodule)
        {
            Folder = new Folder();
            Folder.ParentFolderId = parentfolder.Id;
            Folder.UId = parentfolder.UId;
            Folder.Password = parentfolder.Password;
            Folder.CreationDate = System.DateTime.Now.ToString("yyyy-MM-dd");
            NetworkModule = networkmodule;
        }
        /*
        Name: Submit
        Purpose: Submits the folder or displays an error
        Author: Samuel McManus
        Uses: N/A
        Used by: FolderForm
        Date: July 19, 2020
        */
        public async System.Threading.Tasks.Task Submit()
        {
            Error = "";
            if(Folder.Name != null && !Folder.Name.Equals(""))
            {
                await NetworkModule.AddFolder(Folder);
            }
            else
            {
                Error = "Title can not be empty";
            }
        }
    }
}
