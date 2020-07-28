using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class AllergyViewModel : BaseViewModel
    {

        public AllergyViewModel()
        {

        }

        public AllergyViewModel(Models.Allergy allergy)
        {
            Type = allergy.Type;
            Users = allergy.Users;
        }

        private string type;
        private List<Models.User> users;

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                SetValue(ref type, value);
            }
        }
        public List<Models.User> Users
        {
            get
            {
                return users;
            }
            set
            {
                SetValue(ref users, value);
            }
        }
    }
}
