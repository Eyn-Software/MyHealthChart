namespace MyHealthChart3.Models
{
    public enum GeneralMenuItemType
    {
        About
    }
    public class GeneralMenuItem : MenuItem
    {
        public GeneralMenuItemType Id { get; set; }
        public string Name { get; set; }
    }
}
