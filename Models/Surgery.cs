using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CureWell.Models
{
    public class Surgery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SurgeryID { get; set; }
        
        public int DoctorID { get; set; }

        public DateTime SurgeryDate { get; set; }

        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string SpecializationCode { get; set; }

        public Specialization? Specialization {get;set;}

        public Doctor? Doctor { get; set; }


    }
}