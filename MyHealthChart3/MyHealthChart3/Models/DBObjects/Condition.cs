using MyHealthChart3.ViewModels.ModelCounterparts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class Condition
    {
        public Condition()
        {

        }
        public Condition(ConditionViewModel condition)
        {
            Type = condition.Type;
            Users = condition.Users;
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

