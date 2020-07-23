﻿using MyHealthChart3.Models.ViewDataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ViewCounterparts.Forms
{
    public class NoteEditViewModel : BaseViewModel
    {
        private Services.IServerComms NetworkModule;
        private string error;
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
        public NoteEditViewModel(NoteFormModel n, Services.IServerComms networkmodule)
        {
            Note = n;
            NetworkModule = networkmodule;
        }
        /*
        Name: Submit
        Purpose: Calls the edit note network module or displays an error message
        Author: Samuel McManus
        Uses: N/A
        Used by: NoteEdit
        Date: July 20, 2020
        */
        public async System.Threading.Tasks.Task Submit()
        {
            Error = "";
            if (Note.Name != null && !Note.Name.Equals(""))
            {
                await NetworkModule.EditNote(Note);
            }
            else
            {
                Error = "Your note must have a title";
            }
        }
    }
}