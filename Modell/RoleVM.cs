using System.ComponentModel.DataAnnotations;

namespace Backery.Modell
{
    public class RoleVM
    {
        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
