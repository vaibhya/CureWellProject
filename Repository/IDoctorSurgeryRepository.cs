using CureWell.Models;

namespace CureWell.Repository
{
    public interface IDoctorSurgeryRepository
    {
        Task<Surgery> GetSurgeryById(int id);
        Task<List<Surgery>> GetAllSurgeries();
        Task<Surgery> AddDoctorSurgery(Surgery doctor);
        Task<Surgery> UpdateDoctorSurgery(Surgery doctor);
        Task<int> DeleteDoctorSurgery(int id);

    }
}