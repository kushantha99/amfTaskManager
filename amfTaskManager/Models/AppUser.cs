using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace amfTaskManager.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100, ErrorMessage = "The Name must be at most 100 characters long.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "The Address must be at most 200 characters long.")]
        public string? Address { get; set; }
    }
}
