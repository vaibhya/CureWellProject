using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CureWell.Models
{
    public class Specialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(3, MinimumLength = 3)]
        public string SpecializationCode { get; set; }
        public string? SpecializationName { get; set; }

        public List<DoctorSpecialization>? DoctorSpecialization { get; set; }

        public List<Surgery>? Surgeries { get; set; }


    }
}