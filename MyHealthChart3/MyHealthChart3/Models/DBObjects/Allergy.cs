using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Allergy
    {
        public Allergy()
        {

        }
        public Allergy(AllergyViewModel allergy)
        {
            Type = allergy.Type;
            Users = allergy.Users;
        }
        public string Type
        {
            get;
            set;
        }

        public List<User> Users
        {
            get;
            set;
        }
    }
}
