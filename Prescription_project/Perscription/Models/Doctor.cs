using System.ComponentModel.DataAnnotations;

namespace Perscription.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public virtual ICollection<Prescription> DoctorsPrescription { get; set; }
    }
}
