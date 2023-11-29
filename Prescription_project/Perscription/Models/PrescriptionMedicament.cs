using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perscription.Models
{
    [PrimaryKey(nameof(IdMedicament),nameof(IdPrescription))]
    public class PrescriptionMedicament
    {
        [Required]
        public int IdMedicament { get; set; }
        [Required]
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        [Required]
        [MaxLength(100)]
        public string Details { get; set; } = null!;
        [ForeignKey(nameof(IdMedicament))]
        public virtual Medicament Medicament { get; set; }
        [ForeignKey(nameof(IdPrescription))]
        public virtual Prescription Prescription { get; set; }
    }
}
