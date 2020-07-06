using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public enum MenuItemType
    {
        Register,
        Login,
        Guest
    }
    public class UnauthenticatedMenuItem
    {
        public MenuItemType Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
    }
}
