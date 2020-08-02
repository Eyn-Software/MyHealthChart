using MyHealthChart3.Models;
using MyHealthChart3.Services;

namespace MyHealthChart3.ViewModels.ViewCounterparts
{
    public class AllergyDetailViewModel : BaseViewModel
    {
        private IServerComms NetworkModule;
        private Allergy allergy;

        public Allergy Allergy
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
        public AllergyDetailViewModel(Allergy Al, IServerComms networkmodule)
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
        public async System.Threading.Tasks.Task DeleteAllergy()
        {
            await NetworkModule.DeleteAllergy(Allergy);
        }
    }
}
