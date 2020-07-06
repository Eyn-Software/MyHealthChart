using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    public class LoginFormModel
    {
        private string email;
        private string password;

        public LoginFormModel()
        {
            this.Email = "";
            this.Password = "";
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
    }
}
