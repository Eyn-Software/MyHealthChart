namespace MyHealthChart3.Models
{
    public enum AuthenticatedItemType
    {
        LogOut
    }
    public class AuthenticatedMenuItem : MenuItem
    {
        public AuthenticatedItemType Id { get; set; }
        public string Name { get; set; }
    }
}
