using MyHealthChart3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models.ViewDataObjects
{
    public class RegistrationFormModel
    {
        public RegistrationFormModel()
        {
            Name = "";
            Birthday = DateTime.Now;
            Email = "";
            Password = "";
            ConfirmPassword = "";
        }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
