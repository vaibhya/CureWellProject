using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CureWell.Models
{
    public class DoctorSpecialization
    {
        [Key]
        //[ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public Doctor? Doctor { get; set; }

        [Key]
        [StringLength(3, MinimumLength = 3)]
        public string SpecializationCode { get; set; }

        public Specialization? Specialization { get; set; }

        public DateOnly SpecializationDate { get; set; }


    }
}