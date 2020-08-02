namespace MyHealthChart3.Models
{
    public class LoginFormModel
    {
        public LoginFormModel()
        {
            Email = "";
            Password = "";
        }
        public string Email { get; set; }
        public string Password{ get; set; }
    }
}
