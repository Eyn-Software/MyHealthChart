namespace MyHealthChart3.Models
{
    public class Allergy
    {
        public Allergy()
        {
            Type = "";
            Password = "";
        }
        public Allergy(User User)
        {
            Type = "";
            UId = User.Id;
            Password = User.Password;
        }
        public string Type { get; set; }
        public int UId { get; set; }
        public string Password { get; set; }
    }
}
