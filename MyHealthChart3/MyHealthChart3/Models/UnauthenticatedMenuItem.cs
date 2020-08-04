namespace MyHealthChart3.Models
{
    public enum UnauthenticatedMenuItemType
    {
        Register,
        Login
    }
    public class UnauthenticatedMenuItem : MenuItem
    {
        public UnauthenticatedMenuItemType Id { get; set; }
        public string Name { get; set; }
    }
}
