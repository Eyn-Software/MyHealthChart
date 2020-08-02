namespace MyHealthChart3.Models
{
    public enum UnauthenticatedMenuItemType
    {
        Register,
        Login
    }
    public class UnauthenticatedMenuItem
    {
        public UnauthenticatedMenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
