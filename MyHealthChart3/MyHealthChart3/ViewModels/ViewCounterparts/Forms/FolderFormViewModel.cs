using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class FolderFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private string error;
        private FolderListModel ParentFolder;
        private FolderFormModel folder;

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
        public FolderFormModel Folder
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
        public FolderFormViewModel(FolderListModel parentfolder, IServerComms networkmodule)
        {
            ParentFolder = parentfolder;
            NetworkModule = networkmodule;
            Folder = new FolderFormModel(ParentFolder);
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
