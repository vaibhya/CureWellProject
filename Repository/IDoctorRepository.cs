using CureWell.Models;

namespace CureWell.Repository
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorById(int id);
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> AddDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<int> DeleteDoctor(int id);

    }
}