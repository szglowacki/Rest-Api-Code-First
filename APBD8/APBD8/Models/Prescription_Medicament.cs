using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Models
{
    public class Prescription_Medicament
    {
        public int IdMedicament { get; set; }
        
        public int IdPrescription { get; set; }
        
        public int? Dose { get; set; }
        [Required]
        [MaxLength(100)]
        public string Details { get; set; }
        [ForeignKey(nameof(IdMedicament))]
        public virtual Medicament Medicament { get; set; }
        [ForeignKey(nameof(IdPrescription))]
        public virtual Prescription Prescription { get; set; }
    }
}
