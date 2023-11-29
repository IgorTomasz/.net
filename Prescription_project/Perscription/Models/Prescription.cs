using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perscription.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        [ForeignKey(nameof(IdDoctor))]
        public virtual Doctor Doctor { get; set; } = null!;
        [ForeignKey(nameof(IdPatient))]
        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<PrescriptionMedicament> PrescriptionsMedicament { get; set; }
    }
}
