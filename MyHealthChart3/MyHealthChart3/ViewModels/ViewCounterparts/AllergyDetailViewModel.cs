using MyHealthChart3.Models.ViewDataObjects;
using MyHealthChart3.Services;
using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AllergyDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private AllergyFormModel allergy;

        public AllergyFormModel Allergy
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
        public AllergyDetailViewModel(AllergyFormModel Al, IServerComms networkmodule)
        {
            Allergy = Al;
            NetworkModule = networkmodule;
        }
        /*
        Name: DeleteAllergy
        Purpose: Deletes an allergy from the database
        Author: Samuel McManus
        Uses: N/A
        Used by: AllergyDetail
        Date: July 8, 2020
        */
        public async Task DeleteAllergy()
        {
            await NetworkModule.DeleteAllergy(Allergy);
        }
    }
}
