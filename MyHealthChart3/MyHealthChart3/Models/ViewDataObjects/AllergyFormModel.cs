using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class AllergyFormModel
    {
        public AllergyFormModel(ViewModels.ModelCounterparts.UserViewModel User)
        {
            UId = User.Id;
            Password = User.Password;
        }

        public string Type { get; set; }
        public int UId { get; set; }
        public string Password { get; set; }
    }
}
