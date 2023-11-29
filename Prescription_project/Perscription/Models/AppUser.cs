using System.ComponentModel.DataAnnotations;

namespace Perscription.Models
{
    public class AppUser
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Salt { get; set; } = null!;
        
        public string? RefToken { get; set; } = null;
        
        public DateTime? ExpiresAt { get; set; } = null;

    }
}
