using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class ConditionFormModel
    {
        private string type;
        private string password;
        private int uid;

        public ConditionFormModel(UserViewModel User)
        {
            Password = User.Password;
            UId = User.Id;

        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                password = value;
            }
        }
        public int UId
        {
            get
            {
                return uid;
            }
            private set
            {
                uid = value;
            }
        }
    }
}
