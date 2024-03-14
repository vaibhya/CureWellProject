using CureWell.Models;

namespace CureWell.Service
{
    public interface ICureWellService
    {
        Task<List<Doctor>> GetAllDoctors();

        Task<List<Specialization>> GetAllSpecialization();

        Task<List<Surgery>> GetAllSurgeryTypeForToday();

        Task<Doctor> AddDoctor(Doctor doctor);

        Task<Surgery> AddSurgery(Surgery surgery);

        Task<Specialization> AddSpecialization(Specialization specialization);

        Task<Doctor> UpdateDoctorDetails(Doctor doctor);

        Task<Surgery> UpdateSurgery(Surgery surgery);

        Task<int> DeleteDoctor(int DoctorId);
    }
}