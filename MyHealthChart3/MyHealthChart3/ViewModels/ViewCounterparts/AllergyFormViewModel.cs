using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AllergyFormViewModel : BaseViewModel
    {
        private UserViewModel User;
        private IServerComms NetworkModule;
        private string error;
        private Models.ViewDataObjects.AllergyFormModel allergy;

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
        public Models.ViewDataObjects.AllergyFormModel Allergy
        {
            get
            {
                return allergy;
            }
            set
            {
                SetValue(ref allergy, value);
            }
        }
        public AllergyFormViewModel(UserViewModel user, IServerComms networkModule)
        {
            User = user;
            NetworkModule = networkModule;
            Allergy = new Models.ViewDataObjects.AllergyFormModel(User);
            Error = "";
        }
        /*
        Name: Submit
        Purpose: Submits an allergy to the user_allergy table
        Author: Samuel McManus
        Uses: N/A
        Used by: ConditionListViewModel
        Date: July 8, 2020
        */
        public async Task<bool> Submit()
        {
            Error = await NetworkModule.AddAllergy(Allergy);
            if(Error.Equals("Success"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
