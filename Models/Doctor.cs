using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CureWell.Models
{
    public class Doctor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }

        public List<Surgery>? Surgery { get; set; }
        public List<DoctorSpecialization>? DoctorSpecialization { get; set; }


    }
}