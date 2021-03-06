﻿using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class ConditionFormViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private bool haserror;
        private string error;
        private UserViewModel user;
        private ConditionFormModel condition;

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
                if(!Error.Equals(""))
                {
                    HasError = true;
                }
            }
        }
        public ConditionFormModel Condition
        {
            get
            {
                return condition;
            }
            set
            {
                SetValue(ref condition, value);
            }
        }
        public ConditionFormViewModel(UserViewModel Usr, IServerComms networkModule)
        {
            user = Usr;
            NetworkModule = networkModule;
            Condition = new ConditionFormModel(Usr);
            Error = "";

        }
        /*
        Name: Submit
        Purpose: Submits the entered condition, then returns to the view
        Author: Samuel McManus
        Uses: AddCondition
        Used by: ConditionForm
        Date: July 7, 2020
        */
        public async Task<bool> Submit()
        {
            Error = await NetworkModule.AddCondition(Condition);
            if (Error.Equals("Success"))
                return true;
            else
                return false;
        }
    }
}
