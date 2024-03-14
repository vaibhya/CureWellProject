using CureWell.Models;

namespace CureWell.Repository
{
    public interface IDoctorSpecializationRepository
    {
        
        Task<List<DoctorSpecialization>> GetAllDoctorSpecializations();
        Task<DoctorSpecialization> AddDoctorSpecialization(DoctorSpecialization doctorSpecialization);
        Task<DoctorSpecialization> UpdateDoctorSpecialization(DoctorSpecialization doctorSpecialization);
        Task<int> DeleteDoctorSpecialization(int DoctorId,string specializationCode);

    }
}