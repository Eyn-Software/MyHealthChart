using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.ViewModels.ModelCounterparts
{
    public class ConditionViewModel : BaseViewModel
    {
        public ConditionViewModel()
        {

        }
        public ConditionViewModel(Models.Condition condition)
        {
            Type = condition.Type;
            Users = condition.Users;
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

