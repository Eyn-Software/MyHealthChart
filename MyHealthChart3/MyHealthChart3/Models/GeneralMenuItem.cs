using System.ComponentModel.DataAnnotations;

namespace MyHealthChart3.Models
{
    public enum GeneralMenuItemType
    {
        About, 
        [Display(Name = "Log Out")] LogOut
    }
    public class GeneralMenuItem
    {
        public GeneralMenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
